using Mir3DClientEditor.FormValueEditors;
using Mir3DClientEditor.Services;
using StormLibSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mir3DClientEditor
{
    public partial class FSyncClientTexts : Form
    {
        public FSyncClientTexts()
        {
            InitializeComponent();
        }

        private void ButtonSelectLatestClientPath_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;

            var clientPath = dialog.SelectedPath;
            TextLatestClientPath.Text = clientPath;
        }

        private void ButtonSelectOldClientPath_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;

            var clientPath = dialog.SelectedPath;
            TextOldClientPath.Text = clientPath;
        }

        private void ButtonSyncronizeTexts_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(TextLatestClientPath.Text))
            {
                MessageBox.Show($"Directory '{TextLatestClientPath.Text}' not exists");
                return;
            }

            if (!Directory.Exists(TextOldClientPath.Text))
            {
                MessageBox.Show($"Directory '{TextOldClientPath.Text}' not exists");
                return;
            }

            var latestPaks = Directory.GetFiles(TextLatestClientPath.Text, "*.pak", SearchOption.AllDirectories);
            var oldPaks = Directory.GetFiles(TextOldClientPath.Text, "*.pak", SearchOption.AllDirectories);

            var latestArchives = new List<MpqArchiveManager>();
            var oldArchives = new List<MpqArchiveManager>();

            foreach (var mpq in latestPaks)
            {
                latestArchives.Add(new MpqArchiveManager
                {
                    FilePath = mpq,
                    Archive = new MpqArchive(mpq, FileAccess.ReadWrite)
                });
            }

            foreach (var mpq in oldPaks)
            {
                oldArchives.Add(new MpqArchiveManager
                {
                    FilePath = mpq,
                    Archive = new MpqArchive(mpq, FileAccess.ReadWrite)
                });
            }

            foreach (var manager in latestArchives)
            {
                using (var stream = manager.Archive.OpenFile("(listfile)"))
                {
                    var buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, (int)stream.Length);
                    var content = Encoding.UTF8.GetString(buffer);
                    var files = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    manager.ListFiles = files.Select(x => new MpqArchiveManagerFile { Path = x, Manager = manager }).ToArray();
                }
            }

            foreach (var manager in oldArchives)
            {
                using (var stream = manager.Archive.OpenFile("(listfile)"))
                {
                    var buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, (int)stream.Length);
                    var content = Encoding.UTF8.GetString(buffer);
                    var files = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    manager.ListFiles = files.Select(x => new MpqArchiveManagerFile { Path = x, Manager = manager }).ToArray();
                }
            }

            foreach (var latestArchive in latestArchives)
            {
                foreach (var file in latestArchive.ListFiles)
                {
                    if (Path.GetExtension(file.Path) != ".txt") continue;
                    var oldFile = oldArchives.SelectMany(x => x.ListFiles).FirstOrDefault(x => x.Path == file.Path);
                    if (oldFile == null) continue;
                    SyncronizeTextFile(file, oldFile);
                }
            }

            latestArchives.ForEach(x => x.Archive.Dispose());
            oldArchives.ForEach(x => x.Archive.Dispose());

            MessageBox.Show("Syncronization completed!");
        }

        private void SyncronizeTextFile(MpqArchiveManagerFile latestFile, MpqArchiveManagerFile oldFile)
        {
            using (var latestStream = latestFile.Manager.Archive.OpenFile(latestFile.Path))
            using (var oldStream = oldFile.Manager.Archive.OpenFile(oldFile.Path))
            {
                var latestBuffer = new byte[latestStream.Length];
                var oldBuffer = new byte[oldStream.Length];

                latestStream.Read(latestBuffer, 0, latestBuffer.Length);
                oldStream.Read(oldBuffer, 0, oldBuffer.Length);

                latestBuffer = Crypto.Decrypt(latestBuffer);
                oldBuffer = Crypto.Decrypt(oldBuffer);

                var latestContent = latestBuffer.DecodeString(out var latestEncoding);
                var latestData = CSV.Read(latestContent);

                var oldContent = oldBuffer.DecodeString(out var _);
                var oldData = CSV.Read(oldContent);

                switch (Path.GetFileName(latestFile.Path).ToLowerInvariant())
                {
                    case "achievement.txt":
                        CopyData(latestData, oldData, "ID", "Name", "Desc");
                        break;
                    case "activity.txt":
                        CopyData(latestData, oldData, "idActivity", "activityName", "levelString", "personString", "acceptNpcName", "timeString");
                        break;
                    case "air.txt":
                        CopyData(latestData, oldData, "ID", "Description");
                        break;
                    case "Apperance.txt":
                        CopyData(latestData, oldData, "Index", "MainType", "DisplayName");
                        break;
                    case "AssistDrop.txt":
                        CopyData(latestData, oldData, "ID", "Items", "Name", "ItemClass", "Valuable", "AutoPick", "AutoDecompose", "Visible", "Group", "DataVisible", "CanDecompose", "Sort");
                        break;
                    case "AssistItem.txt":
                        CopyData(latestData, oldData, "ItemID", "ItemType", "Sort", "ItemGroup", "ItemName");
                        break;
                    case "Attribute.txt":
                        CopyData(latestData, oldData, "AttributeID", "Key", "Param1", "Param2", "Pow", "Tip", "IsTextValid");
                        break;
                    case "AuctionCategory.txt":
                        CopyData(latestData, oldData, "Index", "MainType", "MainTypeValue");
                        break;
                    case "aura.txt":
                        CopyData(latestData, oldData, "Index", "Eternal", "DotHoldOneHp", "CanCancel", "Category", "Type", "AttackType", "JudgeType", "ElementaryType", "ResistType", "DisplayGroup", "TemplateID", "BuffName", "Group", "Duration", "Delay", "Interval", "InitStackCount", "EffectPct", "EffectValue", "DisplayValue");
                        break;
                    case "Chaos_rules.txt":
                        CopyData(latestData, oldData, "ID", "Name", "Des", "Type", "PointIncRate", "PointIncValue", "DropCoordinate");
                        break;
                    case "ChaosAward.txt":
                        CopyData(latestData, oldData, "ID", "ChaosStone", "Award_1", "Count_1", "Award_2", "Award_ID_2", "Count_2", "Award_3", "Award_ID_3", "Count_3", "Award_4", "Award_ID_4", "Count_4", "Award_5", "Award_ID_5", "Count_5");
                        break;
                    case "doodad.txt":
                        CopyData(latestData, oldData, "Client", "DoodadName", "Description", "DisplayName");
                        break;
                    case "dragon_soul.txt":
                        CopyData(latestData, oldData, "Name_1", "Name_2", "Name_3", "Name_Mark_2", "Name_Mark_3");
                        break;
                    case "EquipGroupEffect.txt":
                        CopyData(latestData, oldData, "Id", "Item1", "ItemName1", "Item2", "ItemName2");
                        break;
                    case "FreeTips.txt":
                        CopyData(latestData, oldData, "TipsScript");
                        break;
                    case "gift_detail.txt":
                        CopyData(latestData, oldData, "GiftID", "GiftName", "ItemID1", "ItemCount1", "AddExp");
                        break;
                    case "guide.txt":
                        CopyData(latestData, oldData, "Index", "PackageFolder", "GuideDesc", "GuideReq", "QuestReq", "ItemReqNew.ItemId1", "ItemReqNew.ItemId2", "ItemReqNew.ItemId3", "ItemReqNew.ItemId4", "ItemReqNew.ItemId5");
                        break;
                    case "guild_achievement.txt":
                        CopyData(latestData, oldData, "ID", "Name", "Desc");
                        break;
                    case "guild_activity.txt":
                        CopyData(latestData, oldData, "Type", "Level", "Open", "GuildVariableIndex", "GuildVariableIndex2", "Name", "Desc", "NpcId");
                        break;
                    case "guild_building.txt":
                        CopyData(latestData, oldData, "ID", "Name", "Level", "MaxLevel", "Description");
                        break;
                    case "guild_welfare.txt":
                        CopyData(latestData, oldData, "ID", "Name", "Level", "AuraID");
                        break;
                    case "handbook.txt":
                        CopyData(latestData, oldData, "HandbookID", "HandbookType", "HandbookIndex", "ID", "Name", "AchievementId", "Text0", "Text1", "Text2", "Icon");
                        break;
                    case "item.txt":
                        CopyData(latestData, oldData, "ID", "Name", "Type", "SubType", "LimitType", "LimitTime", "RequireLevel", "RequireClass", "DisplayIcon", "Description");
                        break;
                    case "item_armor.txt":
                        CopyData(latestData, oldData, "ID", "Name", "Type", "SubType", "RequireLevel", "Description");
                        break;
                    case "kill_npc_quest.txt":
                        CopyData(latestData, oldData, "QuestID", "NpcTemplateID", "NpcGroupID", "Desc", "Icon", "Name1", "Name2", "Name3", "Name4", "Name5", "Name6");
                        break;
                    case "npc.txt":
                        CopyData(latestData, oldData, "TemplateID", "Index", "BodyType", "NameID", "Level", "DisplayName");
                        break;
                    case "ore_herb_formula.txt":
                        CopyData(latestData, oldData, "ID", "Name");
                        break;
                    case "Physique.txt":
                        CopyData(latestData, oldData, "ID", "Name", "Type", "Class", "Quality", "SubType");
                        break;
                    case "quest.txt":
                        CopyData(latestData, oldData, "Index", "QuestTempID", "QuestName", "AcceptQuestDesc", "QuestDescript", "QuestCompletedDescript", "AcceptQuestDialog", "PreSubmitQuestDialog", "CompleteQuestDialog");
                        break;
                    case "ReputationTemp.txt":
                        CopyData(latestData, oldData, "Index", "ForceID", "ListLevel", "ForceName", "ForceTips", "ForceInfo");
                        break;
                    case "scene.txt":
                        CopyData(latestData, oldData, "SceneID", "Level", "MapDisplayName", "MapDescript", "MapName");
                        break;
                    case "seven_days_list.txt":
                        CopyData(latestData, oldData, "ID", "Tittle");
                        break;
                    case "soul_stone.txt":
                        CopyData(latestData, oldData, "SoulStoneID", "Name");
                        break;
                    case "soul_stone_attr.txt":
                        CopyData(latestData, oldData, "Type", "Name", "Description");
                        break;
                    case "StringMap.txt":
                        CopyData(latestData, oldData, "Key", "INT", "CHN");
                        break;
                    case "title.txt":
                        CopyData(latestData, oldData, "ID", "Tip");
                        break;
                    default:
                        return;
                }

                latestBuffer = CSV.Write(latestData).EncodeString(latestEncoding);
                latestBuffer = Crypto.Encrypt(latestBuffer);

                latestFile.Manager.Archive.FileCreateFile(latestFile.Path, latestStream.GetFlags(), latestBuffer);
            }
        }

        private void CopyData(string[][] latestData, string[][] oldData, string idField, params string[] textsFields)
        {
            var latestIdFieldPosition = Array.FindIndex(latestData[0], x => x == idField);
            var oldIdFieldPosition = Array.FindIndex(oldData[0], x => x == idField);

            if (latestIdFieldPosition == -1) return;
            if (oldIdFieldPosition == -1) return;

            for (var i = 1; i < latestData.Length; i++)
            {
                var latestIdValue = latestData[i][latestIdFieldPosition];
                var oldRow = oldData.Where(x => x[oldIdFieldPosition] == latestIdValue).FirstOrDefault();
                if (oldRow == null) continue;

                for (var c = 0; c < textsFields.Length; c++)
                {
                    var latestTextFieldPosition = Array.FindIndex(latestData[0], x => x == textsFields[c]);
                    var oldTextFieldPosition = Array.FindIndex(oldData[0], x => x == textsFields[c]);

                    if (latestTextFieldPosition == -1) continue;
                    if (oldTextFieldPosition == -1) continue;

                    var latestValue = latestData[i][latestTextFieldPosition];
                    var oldValue = oldRow[oldTextFieldPosition];

                    if (latestValue != oldValue)
                        latestData[i][latestTextFieldPosition] = oldValue;
                }
            }
        }
    }
}

