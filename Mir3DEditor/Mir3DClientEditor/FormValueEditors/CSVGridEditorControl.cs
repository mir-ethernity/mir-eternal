using Mir3DClientEditor.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mir3DClientEditor.FormValueEditors
{
    public partial class CSVGridEditorControl : BaseGridEditorControl
    {
        private string _name = string.Empty;
        private Encoding _encoding = Encoding.UTF8;
        private bool _hasPendingChangesToSave = false;
        public override bool HasPendingChangesToSave { get => _hasPendingChangesToSave; }

        public CSVGridEditorControl()
        {
            InitializeComponent();
            DataGrid.CellValueChanged += DataGrid_CellValueChanged;
            Disposed += CSVGridEditorControl_Disposed;
        }

        private void CSVGridEditorControl_Disposed(object? sender, EventArgs e)
        {
            DataGrid.Rows.Clear();
            DataGrid.Columns.Clear();
        }

        private void DataGrid_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            _hasPendingChangesToSave = true;
        }

        public override void SetBuffer(string name, byte[] buffer)
        {
            _name = name;
            var content = buffer.DecodeString(out _encoding);

            var data = CSV.Read(content);

            for (var i = 0; i < data.Length; i++)
            {
                if (i == 0)
                {
                    foreach (var field in data[i])
                        DataGrid.Columns.Add(field, field);
                }
                else
                {
                    var row = new DataGridViewRow();

                    row.CreateCells(DataGrid);

                    for (var c = 0; c < data[i].Length; c++)
                        row.Cells[c].Value = data[i][c];

                    DataGrid.Rows.Add(row);
                }
            }

            DataGrid.Refresh();
        }

        public override byte[] GetBuffer()
        {
            var data = new List<string[]>();

            var header = new List<string>();
            foreach (DataGridViewColumn column in DataGrid.Columns)
                header.Add(column.Name);

            data.Add(header.ToArray());

            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.IsNewRow) continue;

                var rowData = new List<string>();

                foreach (DataGridViewCell cell in row.Cells)
                    rowData.Add((string)cell.Value);

                data.Add(rowData.ToArray());
            }

            var content = CSV.Write(data.ToArray());
            var buffer = content.EncodeString(_encoding);

            return buffer;
        }

        private void ExpandValue(Dictionary<string, object> context, string field, string value)
        {
            var parts = field.Split('.');
            var obj = context;

            var isIntegerRegex = new Regex(@"^[-]?\d+$");
            var isDecimalRegex = new Regex(@"^[-]?\d+\.\d+$");

            for (var i = 0; i < parts.Length; i++)
            {
                var key = parts[i];
                if (parts.Length > i + 1)
                {
                    if (!obj.ContainsKey(key)) obj.Add(key, new Dictionary<string, object>());
                    obj = (Dictionary<string, object>)obj[key];
                }
                else
                {
                    if (isIntegerRegex.IsMatch(value))
                        obj.Add(key, long.Parse(value));
                    else if (isDecimalRegex.IsMatch(value))
                        obj.Add(key, decimal.Parse(value));
                    else
                        obj.Add(key, value);
                }
            }
        }

        struct CheckVar
        {
            public string CheckVarType;
            public int CheckVarID;
            public int CheckVarCnt;
        }

        private Dictionary<string, object> ExportQuest(DataGridViewRow row)
        {
            var obj = new Dictionary<string, object>();

            var checkVars = new CheckVar[4];
            for (var i = 1; i <= 4; i++)
            {
                checkVars[i - 1] = new CheckVar
                {
                    CheckVarType = (string)row.Cells[$"CheckVar.CheckVarType{i}"].Value,
                    CheckVarCnt = int.Parse((string)row.Cells[$"CheckVar.CheckVarCnt{i}"].Value),
                    CheckVarID = int.Parse((string)row.Cells[$"CheckVar.CheckVarID{i}"].Value)
                };
            }

            var checkClassVars = new int[6];
            for (var i = 1; i <= 6; i++)
                checkClassVars[i - 1] = int.Parse((string)row.Cells[$"CheckClassVar.CheckClassVarCnt{i}"].Value);

            obj.Add("Id", int.Parse((string)row.Cells["QuestTempID"].Value));
            obj.Add("Chapter", int.Parse((string)row.Cells["QuestChapter"].Value));
            obj.Add("Stage", int.Parse((string)row.Cells["QuestStage"].Value));
            obj.Add("Name", (string)row.Cells["QuestName"].Value);
            obj.Add("Level", int.Parse((string)row.Cells["QuestLevel"].Value));
            obj.Add("Type", int.Parse((string)row.Cells["QuestType"].Value));
            obj.Add("Reset", int.Parse((string)row.Cells["ResetType"].Value));
            obj.Add("RelationLimit", int.Parse((string)row.Cells["RelationLimit"].Value));
            obj.Add("StartNPCMap", int.Parse((string)row.Cells["StartNPCMap"].Value));
            obj.Add("StartNPCID", int.Parse((string)row.Cells["StartNPCNew"].Value));
            obj.Add("FinishNPCID", int.Parse((string)row.Cells["FinishNpcNew"].Value));
            obj.Add("AutoStartNextID", int.Parse((string)row.Cells["AutoStartNextID"].Value));
            obj.Add("MaxCompleteCount", int.Parse((string)row.Cells["MaxCompleteCount"].Value));
            obj.Add("ResetTime", int.Parse((string)row.Cells["nResetTime"].Value));
            obj.Add("CanAbandon", (string)row.Cells["CanAbandon"].Value == "1");
            obj.Add("CanShare", (string)row.Cells["CanShare"].Value == "1");
            obj.Add("CanPublish", (string)row.Cells["CanPublish"].Value == "1");
            obj.Add("CanTeleport", (string)row.Cells["QuestTeleportCan"].Value == "1");
            obj.Add("TeleportCostId", int.Parse((string)row.Cells["QuestTeleportCostID"].Value));
            obj.Add("TeleportCostValue", int.Parse((string)row.Cells["QuestTeleportCostCnt"].Value));
            var rewards = new List<Dictionary<string, object>>();
            obj.Add("Rewards", rewards);

            var awardCurrencyType = int.Parse((string)row.Cells["AwardCurrencyType"].Value);
            var awardCurrencyAmount = int.Parse((string)row.Cells["AwardCurrencyAmount"].Value);
            if (awardCurrencyType > 0 && awardCurrencyAmount > 0)
            {
                rewards.Add(new Dictionary<string, object> {
                    { "Type", "Currency" },
                    { "Id", awardCurrencyType },
                    { "Count", awardCurrencyAmount }
                });
            }
            var awardCurrencyTypeEx = int.Parse((string)row.Cells["AwardCurrencyTypeEx"].Value);
            var awardCurrencyAmountEx = int.Parse((string)row.Cells["AwardCurrencyAmountEx"].Value);
            if (awardCurrencyTypeEx > 0 && awardCurrencyAmountEx > 0)
            {
                rewards.Add(new Dictionary<string, object> {
                    { "Type", "Currency" },
                    { "Id", awardCurrencyTypeEx },
                    { "Count", awardCurrencyAmountEx }
                });
            }

            var awardReputationType = int.Parse((string)row.Cells["AwardReputationType"].Value);
            var awardReputation = int.Parse((string)row.Cells["AwardReputation"].Value);
            if (awardReputationType > 0 && awardReputation > 0)
            {
                rewards.Add(new Dictionary<string, object> {
                    { "Type", "Reputation" },
                    { "Id", awardReputationType },
                    { "Count", awardReputation }
                });
            }

            var awardActivity = int.Parse((string)row.Cells["AwardActivity"].Value);
            if (awardActivity > 0)
            {
                rewards.Add(new Dictionary<string, object> {
                    { "Type", "Activity" },
                    { "Count", awardActivity }
                });
            }

            for (var i = 1; i <= 5; i++)
            {
                var awardItemID = int.Parse((string)row.Cells[$"AwardItem.AwardItemID{i}"].Value);
                var awardItemBinded = (string)row.Cells[$"AwardItem.AwardItemBinded{i}"].Value == "1";
                var awardItemCount = int.Parse((string)row.Cells[$"AwardItem.AwardItemCnt{i}"].Value);
                if (awardItemID > 0 && awardItemCount > 0)
                {
                    var item = new Dictionary<string, object> {
                        { "Type", "Item" },
                        { "Id", awardItemID },
                        { "Count", awardItemCount }
                    };
                    if (awardItemBinded) item.Add("Bind", awardItemBinded);
                    rewards.Add(item);
                }
            }

            var selectableRewards = new List<Dictionary<string, object>>();
            obj.Add("SelectableRewards", selectableRewards);

            for (var i = 1; i <= 20; i++)
            {
                var awardItemID = int.Parse((string)row.Cells[$"SelectableAwardItem.SelectableAwardItemID{i}"].Value);
                var awardItemCount = int.Parse((string)row.Cells[$"SelectableAwardItem.SelectableAwardItemCnt{i}"].Value);

                if (awardItemID > 0 && awardItemCount > 0)
                {
                    var item = new Dictionary<string, object> {
                        { "Type", "Item" },
                        { "Id", awardItemID },
                        { "Count", awardItemCount }
                    };
                    selectableRewards.Add(item);
                }
            }

            var missions = new List<Dictionary<string, object>>();
            obj.Add("Missions", missions);

            for (var i = 1; i <= 4; i++)
            {
                var checkItemID = int.Parse((string)row.Cells[$"CheckItem.CheckItemID{i}"].Value);
                var checkItemCount = int.Parse((string)row.Cells[$"CheckItem.CheckItemCnt{i}"].Value);
                if (checkItemCount > 0 && checkItemCount > 0)
                {
                    var mission = new Dictionary<string, object> {
                        { "Type", "AdquireItem" },
                        { "Id", checkItemID },
                        { "Count", checkItemCount }
                    };
                    missions.Add(mission);
                }
            }

            for (var i = 1; i <= 4; i++)
            {
                var recycleItemID = int.Parse((string)row.Cells[$"RecycleItem.RecycleItemID{i}"].Value);
                if (recycleItemID > 0)
                {
                    var checkVar = checkVars[i - 1];
                    var mission = new Dictionary<string, object> {
                        { "Type", "RecycleItem" },
                        { "Id", recycleItemID },
                        { "Count", checkVar.CheckVarType == "vtItemRecycle" ? checkVar.CheckVarCnt : 1 }
                    };
                    missions.Add(mission);
                }
            }

            for (var i = 1; i <= 4; i++)
            {
                var checkKillNpcNew = int.Parse((string)row.Cells[$"CheckKillNpc.CheckKillNpcNew{i}"].Value);
                var checkKillNpcGroupId = int.Parse((string)row.Cells[$"CheckKillNpc.CheckKillNpcGroupId{i}"].Value);
                var checkKillNpcCnt = int.Parse((string)row.Cells[$"CheckKillNpc.CheckKillNpcCnt{i}"].Value);

                if (checkKillNpcNew > 0 && checkKillNpcCnt > 0)
                {
                    var mission = new Dictionary<string, object> {
                        { "Type", "KillMob" },
                        { "Id", checkKillNpcNew },
                        { "Count", checkKillNpcCnt }
                    };
                    missions.Add(mission);
                }
                else if (checkKillNpcGroupId > 0 && checkKillNpcCnt > 0)
                {
                    var mission = new Dictionary<string, object> {
                        { "Type", "KillMobGroup" },
                        { "Id", checkKillNpcGroupId },
                        { "Count", checkKillNpcCnt }
                    };
                    missions.Add(mission);
                }
            }


            for (var i = 1; i <= 4; i++)
            {
                var checkKillDoodadID = int.Parse((string)row.Cells[$"CheckKillDoodad.CheckKillDoodadID{i}"].Value);
                var checkKillDoodadCnt = int.Parse((string)row.Cells[$"CheckKillDoodad.CheckKillDoodadCnt{i}"].Value);

                if (checkKillDoodadID > 0 && checkKillDoodadCnt > 0)
                {
                    var mission = new Dictionary<string, object> {
                        { "Type", "KillDoodad" },
                        { "Id", checkKillDoodadID },
                        { "Count", checkKillDoodadCnt }
                    };
                    missions.Add(mission);
                }
            }

            foreach (var checkvar in checkVars)
            {
                switch (checkvar.CheckVarType)
                {
                    case "vtClient":
                        switch (checkvar.CheckVarID)
                        {
                            case 1:
                                switch (checkvar.CheckVarCnt)
                                {
                                    case 6:
                                        missions.Add(new Dictionary<string, object>
                                        {
                                            { "Type", "RefineInscription" }
                                        });
                                        break;
                                    case 20: // learn skill
                                        for (var i = 0; i < checkClassVars.Length; i++)
                                        {
                                            if (checkClassVars[i] > 0)
                                            {
                                                var mission = new Dictionary<string, object> {
                                                    { "Type", "LearnSkill" },
                                                    { "Role", i },
                                                    { "Id", checkClassVars[i] }
                                                };
                                                missions.Add(mission);
                                            }
                                        }
                                        break;
                                    case 22:
                                        for (var i = 0; i < checkClassVars.Length; i++)
                                        {
                                            if (checkClassVars[i] > 0)
                                            {
                                                var mission = new Dictionary<string, object> {
                                                    { "Type", "EquipItem" },
                                                    { "Role", i },
                                                    { "Id", checkClassVars[i] }
                                                };
                                                missions.Add(mission);
                                            }
                                        }
                                        break;
                                    case 23:
                                        for (var i = 0; i < checkClassVars.Length; i++)
                                        {
                                            if (checkClassVars[i] > 0)
                                            {
                                                var mission = new Dictionary<string, object> {
                                                    { "Type", "GearEquipmentSynthesis" },
                                                    { "Role", i },
                                                    { "Id", checkClassVars[i] }
                                                };
                                                missions.Add(mission);
                                            }
                                        }
                                        break;
                                    case 24:
                                        missions.Add(new Dictionary<string, object>
                                        {
                                            { "Type", "Dismantle" }
                                        });
                                        break;
                                    case 25:
                                        missions.Add(new Dictionary<string, object>
                                        {
                                            { "Type", "GearReforging" }
                                        });
                                        break;
                                    case 26:
                                        missions.Add(new Dictionary<string, object>
                                        {
                                            { "Type", "TomeRecollection" }
                                        });
                                        break;
                                    case 27:
                                        missions.Add(new Dictionary<string, object>
                                        {
                                            { "Type", "HiringMercenary" }
                                        });
                                        break;
                                    case 28:
                                        missions.Add(new Dictionary<string, object>
                                        {
                                            { "Type", "Training" }
                                        });
                                        break;
                                    default:
                                        throw new NotImplementedException();
                                }
                                break;
                            case 3:
                                switch (checkvar.CheckVarCnt)
                                {
                                    case 5:
                                        missions.Add(new Dictionary<string, object>
                                        {
                                            { "Type", "UpgradeSkill" }
                                        });
                                        break;
                                }
                                break;
                            default:
                                throw new NotImplementedException();
                        }
                        break;
                    case "vtRole":
                        {
                            var mission = new Dictionary<string, object> {
                                { "Type", "ParticipateEvent" },
                                { "Id", checkvar.CheckVarID },
                                { "Count", checkvar.CheckVarCnt }
                            };
                            missions.Add(mission);
                        }
                        break;
                    case "vtItemRecycle":
                    case "vtQuest":
                    case "vtInvalid":
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            var constraints = new List<Dictionary<string, object>>();
            obj.Add("Constraints", constraints);

            for (var i = 1; i <= 2; i++)
            {
                var preQuestTempID = int.Parse((string)row.Cells[$"PreQuestTempID{i}"].Value);
                if (preQuestTempID > 0)
                {
                    constraints.Add(new Dictionary<string, object>
                    {
                        { "Type", "QuestCompleted" },
                        { "Value", preQuestTempID }
                    });
                }
            }

            var minLevelLimit = int.Parse((string)row.Cells[$"MinLevelLimit"].Value);
            if (minLevelLimit > 0)
            {
                constraints.Add(new Dictionary<string, object>
                {
                    { "Type", "MinLevel" },
                    { "Value", minLevelLimit }
                });
            }

            var maxLevelLimit = int.Parse((string)row.Cells[$"MaxLevelLimit"].Value);
            if (minLevelLimit > 0)
            {
                constraints.Add(new Dictionary<string, object>
                {
                    { "Type", "MaxLevel" },
                    { "Value", maxLevelLimit }
                });
            }

            var nAcceptTimeStart = int.Parse((string)row.Cells[$"nAcceptTimeStart"].Value);
            if (nAcceptTimeStart > 0)
            {
                constraints.Add(new Dictionary<string, object>
                {
                    { "Type", "AcceptStartTime" },
                    { "Value", nAcceptTimeStart }
                });
            }

            var nAcceptTimeEnd = int.Parse((string)row.Cells[$"nAcceptTimeEnd"].Value);
            if (nAcceptTimeEnd > 0)
            {
                constraints.Add(new Dictionary<string, object>
                {
                    { "Type", "AcceptEndTime" },
                    { "Value", nAcceptTimeEnd }
                });
            }

            var classLimit = int.Parse((string)row.Cells[$"nAcceptTimeEnd"].Value);
            if (classLimit != 7 && classLimit != -1)
            {
                constraints.Add(new Dictionary<string, object>
                {
                    { "Type", "Job" },
                    { "Value", classLimit }
                });
            }

            var sexLimit = int.Parse((string)row.Cells[$"SexLimit"].Value);
            if (sexLimit != 0)
            {
                constraints.Add(new Dictionary<string, object>
                {
                    { "Type", "Gender" },
                    { "Value", sexLimit }
                });
            }

            return obj;
        }

        private void ButtonExport_ButtonClick(object sender, EventArgs e)
        {
            using var ms = new MemoryStream();

            using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
            {

                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                for (var i = 0; i < DataGrid.Rows.Count; i++)
                {
                    var row = DataGrid.Rows[i];

                    if (row.IsNewRow || (string)row.Cells[0].Value == "Client" || (string)row.Cells[0].Value == "0" || (string)row.Cells[0].Value == "Both")
                        continue;

                    Dictionary<string, object> obj = null;

                    var idField = 1;
                    var nameField = 2;

                    switch (_name)
                    {
                        case "quest.txt":
                            idField = 1;
                            nameField = 2;
                            obj = ExportQuest(row);
                            break;
                        default:
                            obj = new Dictionary<string, object>();

                            for (var c = 0; c < row.Cells.Count; c++)
                            {
                                if (row.Cells[c].OwningColumn.Name.Equals("id", StringComparison.InvariantCultureIgnoreCase))
                                    idField = c;
                                else if (row.Cells[c].OwningColumn.Name.Equals("name", StringComparison.InvariantCultureIgnoreCase))
                                    nameField = c;
                                ExpandValue(obj, row.Cells[c].OwningColumn.Name, (string)row.Cells[c].Value);
                            }
                            break;
                    }

                    var content = JsonConvert.SerializeObject(obj, settings);

                    var entry = zip.CreateEntry($"{row.Cells[idField].Value}-{row.Cells[nameField].Value}.txt");

                    using var entryStream = entry.Open();
                    using var entryWriter = new StreamWriter(entryStream, _encoding);

                    entryWriter.Write(content);
                }
            }

            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "DB Backup|*.zip";

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;

            File.WriteAllBytes(saveDialog.FileName, ms.ToArray());
        }
    }
}
