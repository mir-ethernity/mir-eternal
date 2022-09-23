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

        private string ToPascalCase(string value)
        {
            var output = new StringBuilder();
            var words = value.Split("_");
            foreach (var word in words)
            {
                var v = word[0].ToString().ToUpper() + word.Substring(1).ToLowerInvariant();
                output.Append(v);
            }
            return output.ToString();
        }

        private Dictionary<string, object> ExportItem(DataGridViewRow row)
        {
            var obj = new Dictionary<string, object>();

            var id = int.Parse((string)row.Cells["ID"].Value);
            obj.Add("Id", id);
            obj.Add("Name", (string)row.Cells["Name"].Value);
            obj.Add("NeedLevel", int.Parse((string)row.Cells["RequireLevel"].Value));
            var needRaceSource = (string)row.Cells["RequireClass"].Value;
            var needRaceOwn = needRaceSource != "0" ? string.Join(",", needRaceSource.Split(',').Select(x =>
            {
                switch (x)
                {
                    case "clsWarrior":
                        return "战士";
                    case "clsMage":
                        return "法师";
                    case "clsRogue":
                        return "刺客";
                    case "clsArcher":
                        return "弓手";
                    case "clsTaoist":
                        return "道士";
                    case "clsSpear":
                        return "龙枪";
                    default:
                        throw new NotImplementedException();
                }
            }).ToArray()) : null;

            if (!string.IsNullOrEmpty(needRaceOwn))
                obj.Add("NeedRace", needRaceOwn);

            var type = ((string)row.Cells["Type"].Value).Replace("ITEMTYPE_", string.Empty);
            obj.Add("Type", ToPascalCase(type));
            var subType = ((string)row.Cells["SubType"].Value).Replace("ITEMSUBTYPE_", string.Empty);
            obj.Add("SubType", ToPascalCase(subType));

            switch ((string)row.Cells["RequireGender"].Value)
            {
                case "0": // Not required
                    break;
                case "1": // Male
                    obj.Add("NeedGender", "男性");
                    break;
                case "2": // Female
                    obj.Add("NeedGender", "女性");
                    break;
                default:
                    throw new NotImplementedException();
            }

            switch ((string)row.Cells["DurType"].Value)
            {
                case "DURTYPE_NONE":
                    break;
                case "DURTYPE_STACK":
                    obj.Add("PersistType", "堆叠");
                    break;
                case "DURTYPE_RECOVER":
                    obj.Add("PersistType", "消耗");
                    break;
                case "DURTYPE_DEPOSIT":
                    obj.Add("PersistType", "容器");
                    break;
                case "DURTYPE_USE":
                    obj.Add("PersistType", "消耗");
                    break;
                case "DURTYPE_PURITY":
                    obj.Add("PersistType", "纯度");
                    break;
                default:
                    throw new NotImplementedException();
            }
            obj.Add("MaxDura", int.Parse((string)row.Cells["Dur"].Value));
            var weight = (string)row.Cells["Weight"].Value;
            if (!string.IsNullOrEmpty(weight)) obj.Add("Weight", int.Parse(weight));

            var spellId = (string)row.Cells["SpellID"].Value;
            if (!string.IsNullOrEmpty(spellId)) obj.Add("AdditionalSkill", int.Parse(spellId));

            var groupCooling = (string)row.Cells["GroupCoolDown"].Value;

            if (!string.IsNullOrEmpty(groupCooling) && groupCooling != "0")
            {
                var parts = groupCooling.Split('-');
                obj.Add("Group", int.Parse(parts[0]));
                obj.Add("GroupCooling", int.Parse(parts[1].TrimEnd(';')));
            }

            var price = int.Parse((string)row.Cells["Price"].Value);
            if (price > 0) obj.Add("SalePrice", price);

            obj.Add("CanDrop", (string)row.Cells["CanDrop"].Value == "1");
            obj.Add("CanSold", (string)row.Cells["CanSell"].Value == "1");

            var itemLevel = int.Parse((string)row.Cells["ItemLevel"].Value);
            if (itemLevel > 0) obj.Add("Level", itemLevel);

            var itemPack = (string)row.Cells["ItemPack"].Value;
            if (!string.IsNullOrEmpty(itemPack))
                obj.Add("__ItemPack__", int.Parse(itemPack));

            var itemPack2 = (string)row.Cells["ItemPack2"].Value;
            if (!string.IsNullOrEmpty(itemPack2))
                obj.Add("__ItemPack2__", int.Parse(itemPack2));

            var shopType = (string)row.Cells["ShopTypeSell"].Value;

            switch (shopType)
            {
                case "":
                    break;
                case "1":
                    obj.Add("StoreType", "药品");
                    break;
                case "2":
                    obj.Add("StoreType", "杂货");
                    break;
                case "3":
                    obj.Add("StoreType", "书籍");
                    break;
                case "4":
                    obj.Add("StoreType", "武器");
                    break;
                case "5":
                    obj.Add("StoreType", "服装");
                    break;
                case "6":
                    obj.Add("StoreType", "首饰");
                    break;
                default:
                    throw new NotSupportedException();
            }

            var description = (string)row.Cells["Description"].Value;
            var usageProps = new Dictionary<string, int>();

            switch (subType)
            {
                case "USABLE_POTION":
                    var recoveryMatch1Effect = Regex.Match(description, @"^恢复(?<amount>\d+)点(?<effect>(?:.+?))\s?。$");
                    if (recoveryMatch1Effect.Success)
                    {
                        switch (recoveryMatch1Effect.Groups["effect"].Value)
                        {
                            case "体力值":
                                usageProps.Add("UsageType", 1);
                                usageProps.Add("RecoveryTime", 1);
                                usageProps.Add("RecoveryBase", int.Parse(recoveryMatch1Effect.Groups["amount"].Value) / 4);
                                usageProps.Add("RecoverySteps", 4);
                                break;
                            case "魔法值":
                                usageProps.Add("UsageType", 2);
                                usageProps.Add("RecoveryTime", 1);
                                usageProps.Add("RecoveryBase", int.Parse(recoveryMatch1Effect.Groups["amount"].Value) / 4);
                                usageProps.Add("RecoverySteps", 4);
                                break;
                            default:
                                throw new NotImplementedException();
                        }
                        break;
                    }

                    var recoveryMatch2Effects = Regex.Match(description, @"^立刻恢复(?<amount_1>\d+)点(?<effect_1>.+?)，(?<amount_2>\d+)点(?<effect_2>.+?).?。$");
                    if (recoveryMatch2Effects.Success)
                    {
                        var value1Str = recoveryMatch1Effect.Groups["amount_1"].Value;
                        var value1 = string.IsNullOrEmpty(value1Str) ? 0 : int.Parse(value1Str);

                        var value2Str = recoveryMatch1Effect.Groups["amount_2"].Value;
                        var value2 = string.IsNullOrEmpty(value2Str) ? 0 : int.Parse(value2Str);

                        if (value1 == 0 && value2 == 0) break;

                        usageProps.Add("UsageType", 3);

                        if (value1 > 0)
                        {
                            switch (recoveryMatch2Effects.Groups["effect_1"].Value)
                            {
                                case "魔法":
                                    usageProps.Add("IncreaseMP", value1);
                                    break;
                                case "体力":
                                    usageProps.Add("IncreaseHP", value1);
                                    break;
                                default:
                                    throw new NotImplementedException();
                            }
                        }
                        if (value2 > 0)
                        {
                            switch (recoveryMatch2Effects.Groups["effect_2"].Value)
                            {
                                case "魔法":
                                    usageProps.Add("IncreaseMP", value2);
                                    break;
                                case "体力":
                                    usageProps.Add("IncreaseHP", value2);
                                    break;
                                default:
                                    throw new NotImplementedException();
                            }
                        }
                        break;
                    }
                    break;
            }
            if (usageProps.Count > 0) obj.Add("Props", usageProps);

            var bindType = int.Parse((string)row.Cells["BindType"].Value);
            if (bindType > 0) obj.Add("IsBound", true);

            var isExpensive = (string)row.Cells["Expensive"].Value == "1";
            if (isExpensive) obj.Add("ValuableObjects", true);

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

                    if (row.IsNewRow
                        || (string)row.Cells[0].Value == "Client"
                        || (string)row.Cells[0].Value == "0"
                        || (string)row.Cells[0].Value == "Both"
                        || (string)row.Cells[0].Value == "-1"
                    ) continue;

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
                        case "item.txt":
                            idField = 0;
                            nameField = 1;
                            obj = ExportItem(row);
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
