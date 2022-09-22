
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

var jsonOptions = new JsonSerializerSettings
{
    DefaultValueHandling = DefaultValueHandling.Ignore,
    NullValueHandling = NullValueHandling.Ignore,
    TypeNameHandling = TypeNameHandling.None,
    Formatting = Formatting.Indented
};

// var chineseDbSystemPath = @"D:\Descargas\YH191\Database\System";
var chineseDbSystemPath = @"D:\YH191\YH191\System";
// var mir3dDbSystemPath = @"D:\Descargas\YH191\Database\English\System";
var mir3dDbSystemPath = @"D:\Mir3D\Clean\Mir3D\Database\System";

void DumpBuffs()
{
    var chineseFolder = Path.Combine(chineseDbSystemPath, "技能数据", "Buff数据");
    var mir3DbFolder = Path.Combine(mir3dDbSystemPath, "Skills", "Buffs");

    var chineseFiles = Directory.GetFiles(chineseFolder, "*.txt", SearchOption.TopDirectoryOnly);
    var mir3DbFiles = Directory.GetFiles(mir3DbFolder, "*.txt", SearchOption.TopDirectoryOnly);

    var chineseModels = new List<JObject>();
    var mir3DbModels = new List<JObject>();

    foreach (var chineseFile in chineseFiles)
    {
        var content = File.ReadAllText(chineseFile);
        chineseModels.Add((JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content, jsonOptions));
    }

    foreach (var mir3dFile in mir3DbFiles)
    {
        var content = File.ReadAllText(mir3dFile);
        mir3DbModels.Add((JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content, jsonOptions));
    }

    foreach (var chineseModel in chineseModels)
    {
        var chineseConverted = new Dictionary<string, object>();

        foreach (var chineseProp in chineseModel)
        {
            switch (chineseProp.Key)
            {
                case "Buff名字":
                    chineseConverted["Name"] = chineseProp.Value.Value<string>();
                    break;
                case "Buff编号":
                    chineseConverted["Id"] = chineseProp.Value.Value<int>();
                    break;
                case "分组编号":
                    chineseConverted["Group"] = chineseProp.Value.Value<int>();
                    break;
                case "Buff效果":
                    chineseConverted["Effect"] = ConvertEffect(chineseProp.Value.Value<string>());
                    break;
                case "同步至客户端":
                    chineseConverted["SyncClient"] = chineseProp.Value.Value<bool>();
                    break;
                case "到期主动消失":
                    chineseConverted["RemoveOnExpire"] = chineseProp.Value.Value<bool>();
                    break;
                case "Buff初始层数":
                    chineseConverted["BuffInitialLayer"] = chineseProp.Value.Value<byte>();
                    break;
                case "Buff最大层数":
                    chineseConverted["MaxBuffCount"] = chineseProp.Value.Value<byte>();
                    break;
                case "Buff合成层数":
                    chineseConverted["BuffSynthesisLayer"] = chineseProp.Value.Value<byte>();
                    break;
                case "Buff处理间隔":
                    chineseConverted["ProcessInterval"] = chineseProp.Value.Value<int>();
                    break;
                case "Buff处理延迟":
                    chineseConverted["ProcessDelay"] = chineseProp.Value.Value<int>();
                    break;
                case "Buff持续时间":
                    chineseConverted["Duration"] = chineseProp.Value.Value<int>();
                    break;
                case "依存Buff列表":
                    chineseConverted["RequireBuff"] = chineseProp.Value.Values<ushort>().ToList();
                    break;
                case "Buff伤害基数":
                    chineseConverted["DamageBase"] = chineseProp.Value.Values<int>().ToList();
                    break;
                case "Buff伤害系数":
                    chineseConverted["DamageFactor"] = chineseProp.Value.Values<int>().ToList();
                    break;
                case "特定技能编号":
                    chineseConverted["SpecificSkillId"] = chineseProp.Value.Values<int>().ToList();
                    break;
                case "伤害增减基数":
                    chineseConverted["DamageIncOrDecBase"] = chineseProp.Value.Values<int>().ToList();
                    break;
                case "伤害增减系数":
                    chineseConverted["DamageIncOrDecFactor"] = chineseProp.Value.Values<float>().ToList();
                    break;
                case "触发陷阱技能":
                    chineseConverted["TriggerTrapSkills"] = chineseProp.Value.Value<string>();
                    break;
                case "体力回复基数":
                    chineseConverted["PhysicalRecoveryBase"] = chineseProp.Value.Value<string>();
                    break;
                case "作用类型":
                    chineseConverted["ActionType"] = ConvertActionType(chineseProp.Value.Value<string>());
                    break;
                case "叠加类型":
                    chineseConverted["OverlayType"] = ConvertOverlayType(chineseProp.Value.Value<string>());
                    break;
                case "角色死亡消失":
                    chineseConverted["OnPlayerDiesRemove"] = chineseProp.Value.Value<bool>();
                    break;
                case "绑定技能等级":
                    chineseConverted["BindingSkillLevel"] = chineseProp.Value.Value<bool>();
                    break;
                case "持续时间延长":
                    chineseConverted["ExtendedDuration"] = chineseProp.Value.Value<bool>();
                    break;
                case "Buff伤害类型":
                    chineseConverted["DamageType"] = ConvertSkillDamageType(chineseProp.Value.Value<string>());
                    break;
                case "切换武器消失":
                    chineseConverted["OnChangeWeaponRemove"] = chineseProp.Value.Value<bool>();
                    break;
                case "角色下线消失":
                    chineseConverted["OnPlayerDisconnectRemove"] = chineseProp.Value.Value<bool>();
                    break;
                case "属性增减":
                    chineseConverted["StatsIncOrDec"] = chineseProp.Value.Values<JObject>().Select(x => ConvertInscriptionStat(x)).ToList();
                    break;
                case "角色所处状态":
                    chineseConverted["PlayerState"] = ConvertObjectState(chineseProp.Value.Value<string>());
                    break;
                case "强化铭文编号":
                    chineseConverted["StrengthenInscriptionId"] = chineseProp.Value.Value<int>();
                    break;
                case "铭文强化基数":
                    chineseConverted["StrengthenInscriptionBase"] = chineseProp.Value.Value<int>();
                    break;
                case "效果生效移除":
                    chineseConverted["EffectRemoved"] = chineseProp.Value.Value<bool>();
                    break;
                case "效果判定方式":
                    chineseConverted["HowJudgeEffect"] = ConvertBuffDetherminationMethod(chineseProp.Value.Value<string>());
                    break;
                case "效果判定类型":
                    chineseConverted["EffectJudgeType"] = ConvertBuffJudgmentType(chineseProp.Value.Value<string>());
                    break;
                case "技能等级延时":
                    chineseConverted["SkillLevelDelay"] = chineseProp.Value.Value<bool>();
                    break;
                case "每级延长时间":
                    chineseConverted["ExtendedTimePerLevel"] = chineseProp.Value.Value<int>();
                    break;
                case "角色属性延时":
                    chineseConverted["PlayerStatDelay"] = chineseProp.Value.Value<bool>();
                    break;
                case "绑定角色属性":
                    chineseConverted["BoundPlayerStat"] = ConvertStat(chineseProp.Value.Value<string>());
                    break;
                case "属性延时系数":
                    chineseConverted["StatDelayFactor"] = chineseProp.Value.Value<float>();
                    break;
                case "特定铭文延时":
                    chineseConverted["HasSpecificInscriptionDelay"] = chineseProp.Value.Value<bool>();
                    break;
                case "特定铭文技能":
                    chineseConverted["SpecificInscriptionSkills"] = chineseProp.Value.Value<int>();
                    break;
                case "铭文延长时间":
                    chineseConverted["InscriptionExtendedTime"] = chineseProp.Value.Value<int>();
                    break;
                case "移除添加冷却":
                    chineseConverted["RemoveAddCooling"] = chineseProp.Value.Value<bool>();
                    break;
                case "技能冷却时间":
                    chineseConverted["SkillCooldown"] = chineseProp.Value.Value<int>();
                    break;
                case "后接Buff编号":
                    chineseConverted["FollowedById"] = chineseProp.Value.Value<int>();
                    break;
                case "生效后接编号":
                    chineseConverted["EffectiveFollowedById"] = chineseProp.Value.Value<int>();
                    break;
                case "Buff允许合成":
                    chineseConverted["AllowsSynthesis"] = chineseProp.Value.Value<bool>();
                    break;
                case "Buff合成编号":
                    chineseConverted["BuffSynthesisId"] = chineseProp.Value.Value<int>();
                    break;
                case "连带Buff编号":
                    chineseConverted["AssociatedId"] = chineseProp.Value.Value<int>();
                    break;
                case "限定伤害上限":
                    chineseConverted["LimitedDamage"] = chineseProp.Value.Value<bool>();
                    break;
                case "限定伤害数值":
                    chineseConverted["LimitedDamageValue"] = chineseProp.Value.Value<int>();
                    break;
                case "释放技能消失":
                    chineseConverted["OnReleaseSkillRemove"] = chineseProp.Value.Value<bool>();
                    break;
                default:
                    throw new ApplicationException();
            }
        }

        var chineseId = chineseModel.Value<int>("Buff编号");
        var mir3dModel = mir3DbModels.FirstOrDefault(x => x.Value<int>("Id") == chineseId);
        var mir3dOutputPath = Path.Combine(mir3DbFolder, $"{chineseConverted["Id"]}-{chineseConverted["Name"]}.txt");

        if (mir3dModel == null)
        {
            var content = JsonConvert.SerializeObject(chineseConverted, jsonOptions);
            File.WriteAllText(mir3dOutputPath, content);
        }
    }
}

void DumpSkillsData()
{
    var chineseFolder = Path.Combine(chineseDbSystemPath, "技能数据", "技能数据");
    var mir3DbFolder = Path.Combine(mir3dDbSystemPath, "Skills", "Skills");

    var chineseFiles = Directory.GetFiles(chineseFolder, "*.txt", SearchOption.TopDirectoryOnly);
    var mir3DbFiles = Directory.GetFiles(mir3DbFolder, "*.txt", SearchOption.TopDirectoryOnly);

    var chineseModels = new List<JObject>();
    var mir3DbModels = new List<JObject>();

    foreach (var chineseFile in chineseFiles)
    {
        var content = File.ReadAllText(chineseFile);
        chineseModels.Add((JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content, jsonOptions));
    }

    foreach (var mir3dFile in mir3DbFiles)
    {
        var content = File.ReadAllText(mir3dFile);
        mir3DbModels.Add((JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content, jsonOptions));
    }

    foreach (var chineseModel in chineseModels)
    {
        var chineseConverted = new Dictionary<string, object>();

        foreach (var chineseProp in chineseModel)
        {
            switch (chineseProp.Key)
            {
                case "技能名字":
                    chineseConverted["SkillName"] = chineseProp.Value.Value<string>();
                    break;
                case "技能职业":
                    chineseConverted["Race"] = ConvertObjectRace(chineseProp.Value.Value<string>());
                    break;
                case "技能类型":
                    chineseConverted["SkillType"] = ConvertSkillType(chineseProp.Value.Value<string>());
                    break;
                case "技能最远距离":
                    chineseConverted["MaxDistance"] = chineseProp.Value.Value<int>();
                    break;
                case "计算触发概率":
                    chineseConverted["CalculateTriggerProbability"] = chineseProp.Value.Value<float>();
                    break;
                case "需要消耗魔法":
                    chineseConverted["NeedConsumeMagic"] = chineseProp.Value.Values<int>().ToList();
                    break;
                case "节点列表":
                    chineseConverted["Nodes"] = chineseProp.Value.Values<JProperty>().ToDictionary(x => x.Name, y => ConvertSkillNode((JObject)y.Value));
                    break;
                case "自身技能编号":
                    chineseConverted["OwnSkillId"] = chineseProp.Value.Value<int>();
                    break;
                case "绑定等级编号":
                    chineseConverted["BindingLevelId"] = chineseProp.Value.Value<int>();
                    break;
                case "检查忙绿状态":
                    chineseConverted["CheckBusyGreen"] = chineseProp.Value.Value<bool>();
                    break;
                case "检查硬直状态":
                    chineseConverted["CheckStiff"] = chineseProp.Value.Value<bool>();
                    break;
                case "角色Buff层数":
                    chineseConverted["PlayerBuffLayer"] = chineseProp.Value.Value<int>();
                    break;
                case "目标Buff层数":
                    chineseConverted["TargetBuffLayers"] = chineseProp.Value.Value<int>();
                    break;
                case "验证已学技能":
                    chineseConverted["ValidateLearnedSkills"] = chineseProp.Value.Value<int>();
                    break;
                case "验证技能铭文":
                    chineseConverted["VerficationSkillInscription"] = chineseProp.Value.Value<bool>();
                    break;
                case "验证目标类型":
                    chineseConverted["VerifyTargetType"] = ConvertSpecifyTargetType(chineseProp.Value.Value<string>());
                    break;
                case "检查技能标记":
                    chineseConverted["CheckSkillMarks"] = chineseProp.Value.Value<bool>();
                    break;
                case "技能标记编号":
                    chineseConverted["SkillTagId"] = chineseProp.Value.Value<int>();
                    break;
                case "自身铭文编号":
                    chineseConverted["Id"] = chineseProp.Value.Value<int>();
                    break;
                case "目标最近距离": // not exists fields... ignore
                case "目标最远距离":
                    break;
                case "技能分组编号":
                    chineseConverted["GroupId"] = chineseProp.Value.Value<int>();
                    break;
                case "检查职业武器":
                    chineseConverted["CheckOccupationalWeapons"] = chineseProp.Value.Value<bool>();
                    break;
                case "检查技能计数":
                    chineseConverted["CheckSkillCount"] = chineseProp.Value.Value<bool>();
                    break;
                case "检查被动标记":
                    chineseConverted["CheckPassiveTags"] = chineseProp.Value.Value<bool>();
                    break;
                case "计算幸运概率":
                    chineseConverted["CalculateLuckyProbability"] = chineseProp.Value.Value<bool>();
                    break;
                case "需要消耗物品":
                    chineseConverted["NeedConsumeItems"] = chineseProp.Value.Values<int>().ToArray();
                    break;
                case "消耗物品数量":
                    chineseConverted["NeedConsumeItemsQuantity"] = chineseProp.Value.Value<int>();
                    break;
                case "战具扣除点数":
                    chineseConverted["GearDeductionPoints"] = chineseProp.Value.Value<int>();
                    break;
                case "需要正向走位":
                    chineseConverted["NeedMoveForward"] = chineseProp.Value.Value<bool>();
                    break;
                default:
                    throw new ApplicationException();
            }
        }

        var mir3dModel = mir3DbModels.FirstOrDefault(x => x.Value<string>("SkillName") == chineseModel.Value<string>("技能名字"));

        var name = chineseConverted["SkillName"];
        var ownSkillId = chineseConverted.ContainsKey("OwnSkillId") ? (int)chineseConverted["OwnSkillId"] : 0;
        var id = chineseConverted.ContainsKey("Id") ? (int)chineseConverted["Id"] : 0;
        var fileName = $"{ownSkillId}-{id}-{name}.txt";

        var mir3dOutputPath = Path.Combine(mir3DbFolder, fileName);

        if (mir3dModel == null)
        {
            var content = JsonConvert.SerializeObject(chineseConverted, jsonOptions);
            File.WriteAllText(mir3dOutputPath, content);
        }
        else
        {
            //if (CompareRecursiveValue(chineseConverted, mir3dModel, new string[] { "SkillName" }))
            //{
            //    var content = JsonConvert.SerializeObject(chineseConverted, jsonOptions);
            //    File.WriteAllText(mir3dOutputPath, content);
            //}
        }
    }
}

void DumpSkillInscriptions()
{
    var chineseFolder = Path.Combine(chineseDbSystemPath, "技能数据", "铭文数据");
    var mir3DbFolder = Path.Combine(mir3dDbSystemPath, "Skills", "Inscriptions");

    var chineseFiles = Directory.GetFiles(chineseFolder, "*.txt", SearchOption.TopDirectoryOnly);
    var mir3DbFiles = Directory.GetFiles(mir3DbFolder, "*.txt", SearchOption.TopDirectoryOnly);

    var chineseModels = new List<JObject>();
    var mir3DbModels = new List<JObject>();

    foreach (var chineseFile in chineseFiles)
    {
        var content = File.ReadAllText(chineseFile);
        chineseModels.Add((JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content, jsonOptions));
    }

    foreach (var mir3dFile in mir3DbFiles)
    {
        var content = File.ReadAllText(mir3dFile);
        mir3DbModels.Add((JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content, jsonOptions));
    }

    foreach (var chineseModel in chineseModels)
    {
        var chineseConverted = new Dictionary<string, object>();

        foreach (var chineseProp in chineseModel)
        {
            switch (chineseProp.Key)
            {
                case "技能名字":
                    chineseConverted["SkillName"] = chineseProp.Value.Value<string>();
                    break;
                case "技能编号":
                    chineseConverted["SkillId"] = chineseProp.Value.Value<int>();
                    break;
                case "被动技能":
                    chineseConverted["PassiveSkill"] = chineseProp.Value.Value<bool>();
                    break;
                case "需要角色等级":
                    chineseConverted["MinPlayerLevel"] = chineseProp.Value.Value<string>();
                    break;
                case "需要技能经验":
                    chineseConverted["MinSkillExp"] = chineseProp.Value.Values<int>().ToArray();
                    break;
                case "技能战力加成":
                    chineseConverted["SkillCombatBonus"] = chineseProp.Value.Values<int>().ToArray();
                    break;
                case "铭文附带Buff":
                    chineseConverted["ComesWithBuff"] = chineseProp.Value.Values<int>().ToArray();
                    break;
                case "被动技能列表":
                    chineseConverted["PassiveSkills"] = chineseProp.Value.Values<int>().ToArray();
                    break;
                case "主体技能列表":
                    chineseConverted["MainSkills"] = chineseProp.Value.Values<string>().ToArray();
                    break;
                case "开关技能列表":
                    chineseConverted["SwitchSkills"] = chineseProp.Value.Values<string>().ToArray();
                    break;
                case "铭文属性加成":
                    chineseConverted["StatsBonus"] = chineseProp.Value.Values<JObject>().Select(x => ConvertInscriptionStat(x)).ToArray();
                    break;
                case "铭文编号":
                    chineseConverted["Id"] = chineseProp.Value.Value<int>();
                    break;
                case "铭文品质":
                    chineseConverted["Quality"] = chineseProp.Value.Value<int>();
                    break;
                case "洗练概率":
                    chineseConverted["Probability"] = chineseProp.Value.Value<int>();
                    break;
                case "广播通知":
                    chineseConverted["BroadcastNotification"] = chineseProp.Value.Value<bool>();
                    break;
                case "技能职业":
                    chineseConverted["Race"] = ConvertObjectRace(chineseProp.Value.Value<string>());
                    break;
                case "技能计数":
                    chineseConverted["SkillCount"] = chineseProp.Value.Value<int>();
                    break;
                case "计数周期":
                    chineseConverted["PeriodCount"] = chineseProp.Value.Value<int>();
                    break;
                case "角色死亡消失":
                    chineseConverted["RemoveOnDie"] = chineseProp.Value.Value<bool>();
                    break;
                case "角色所处状态": // field not exists, ignore.
                    break;
                default:
                    throw new ApplicationException();
            }
        }

        var mir3dModel = mir3DbModels.FirstOrDefault(x => x.Value<int>("SkillId") == chineseModel.Value<int>("技能编号"));

        var name = chineseConverted["SkillName"];
        var skillId = chineseConverted["SkillId"];
        var id = chineseConverted.ContainsKey("Id") ? (int)chineseConverted["Id"] : 0;
        var fileName = $"{skillId}-{id}-{name}.txt";

        var mir3dOutputPath = Path.Combine(mir3DbFolder, fileName);

        if (mir3dModel == null)
        {
            var content = JsonConvert.SerializeObject(chineseConverted, jsonOptions);
            File.WriteAllText(mir3dOutputPath, content);
        }
    }
}

void DumpCommonItems()
{
    var chineseFolder = Path.Combine(chineseDbSystemPath, "物品数据", "普通物品");
    var mir3DbFolder = Path.Combine(mir3dDbSystemPath, "Items", "Common");

    var chineseFiles = Directory.GetFiles(chineseFolder, "*.txt", SearchOption.TopDirectoryOnly);
    var mir3DbFiles = Directory.GetFiles(mir3DbFolder, "*.txt", SearchOption.TopDirectoryOnly);

    var chineseModels = new List<JObject>();
    var mir3DbModels = new List<JObject>();

    foreach (var chineseFile in chineseFiles)
    {
        var content = File.ReadAllText(chineseFile);
        chineseModels.Add((JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content, jsonOptions));
    }

    foreach (var mir3dFile in mir3DbFiles)
    {
        var content = File.ReadAllText(mir3dFile);
        mir3DbModels.Add((JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content, jsonOptions));
    }

    foreach (var chineseModel in chineseModels)
    {
        var chineseConverted = new Dictionary<string, object>();

        foreach (var chineseProp in chineseModel)
        {
            switch (chineseProp.Key)
            {
                case "物品名字":
                    chineseConverted["Name"] = chineseProp.Value.Value<string>();
                    break;
                case "物品编号":
                    chineseConverted["Id"] = chineseProp.Value.Value<int>();
                    break;
                case "需要等级":
                    chineseConverted["NeedLevel"] = chineseProp.Value.Value<int>();
                    break;
                case "出售价格":
                    chineseConverted["SalePrice"] = chineseProp.Value.Value<int>();
                    break;
                case "物品持久":
                    chineseConverted["MaxDura"] = chineseProp.Value.Value<int>();
                    break;
                case "物品重量":
                    chineseConverted["Weight"] = chineseProp.Value.Value<int>();
                    break;
                case "能否掉落":
                    chineseConverted["CanDrop"] = chineseProp.Value.Value<bool>();
                    break;
                case "能否出售":
                    chineseConverted["CanSold"] = chineseProp.Value.Value<bool>();
                    break;
                case "物品分类":
                    chineseConverted["Type"] = ConvertItemType(chineseProp.Value.Value<string>());
                    break;
                case "需要职业":
                    chineseConverted["NeedRace"] = ConvertObjectRace(chineseProp.Value.Value<string>());
                    break;
                case "持久类型":
                    chineseConverted["PersistType"] = ConvertPersistentItemType(chineseProp.Value.Value<string>());
                    break;
                case "物品掉落列表": // not exists, ignore.
                    break;
                case "商店类型":
                    chineseConverted["StoreType"] = ConvertStoreType(chineseProp.Value.Value<string>());
                    break;
                case "物品属性":
                    chineseConverted["Props"] = ConvertItemProps(chineseProp.Value.Value<JObject>());
                    break;
                case "贵重物品":
                    chineseConverted["ValuableObjects"] = chineseProp.Value.Value<bool>();
                    break;
                case "物品等级":
                    chineseConverted["Level"] = chineseProp.Value.Value<int>();
                    break;
                case "是否绑定":
                    chineseConverted["IsBound"] = chineseProp.Value.Value<bool>();
                    break;
                case "宝盒物品":
                    chineseConverted["TreasureItems"] = chineseProp.Value.Values<JObject>().Select(x => ConvertTreasureItem(x)).ToArray();
                    break;
                case "物品分组":
                    chineseConverted["Group"] = chineseProp.Value.Value<int>();
                    break;
                case "分组冷却":
                    chineseConverted["GroupCooling"] = chineseProp.Value.Value<int>();
                    break;
                case "附加技能":
                    chineseConverted["AdditionalSkill"] = chineseProp.Value.Value<int>();
                    break;
                case "解包物品编号":
                    chineseConverted["UnpackItemId"] = chineseProp.Value.Value<int>();
                    break;
                case "冷却时间":
                    chineseConverted["Cooldown"] = chineseProp.Value.Value<int>();
                    break;
                case "传送地图编号": // ignore field not found
                    break;
                default:
                    throw new ApplicationException();
            }
        }

        var mir3dModel = mir3DbModels.FirstOrDefault(x => x.Value<int>("Id") == chineseModel.Value<int>("物品编号"));

        var name = chineseConverted["Name"];
        var id = chineseConverted.ContainsKey("Id") ? (int)chineseConverted["Id"] : 0;
        var fileName = $"{id}-{name}.txt";

        var mir3dOutputPath = Path.Combine(mir3DbFolder, fileName);

        if (mir3dModel == null)
        {
            var content = JsonConvert.SerializeObject(chineseConverted, jsonOptions);
            File.WriteAllText(mir3dOutputPath, content);
        }
    }
}

void DumpMonsters()
{
    var chineseFolder = Path.Combine(chineseDbSystemPath, "Npc数据", "怪物数据");
    var mir3DbFolder = Path.Combine(mir3dDbSystemPath, "Npc", "Monsters");

    var chineseFiles = Directory.GetFiles(chineseFolder, "*.txt", SearchOption.TopDirectoryOnly);
    var mir3DbFiles = Directory.GetFiles(mir3DbFolder, "*.txt", SearchOption.TopDirectoryOnly);

    var chineseModels = new List<JObject>();
    var mir3DbModels = new List<JObject>();

    foreach (var chineseFile in chineseFiles)
    {
        var content = File.ReadAllText(chineseFile);
        chineseModels.Add((JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content, jsonOptions));
    }

    foreach (var mir3dFile in mir3DbFiles)
    {
        var content = File.ReadAllText(mir3dFile);
        mir3DbModels.Add((JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content, jsonOptions));
    }

    foreach (var chineseModel in chineseModels)
    {
        var chineseConverted = new Dictionary<string, object>();

        foreach (var chineseProp in chineseModel)
        {
            switch (chineseProp.Key)
            {
                case "怪物名字":
                    chineseConverted["MonsterName"] = chineseProp.Value.Value<string>();
                    break;
                case "怪物编号":
                    chineseConverted["Id"] = chineseProp.Value.Value<int>();
                    break;
                case "怪物等级":
                    chineseConverted["Level"] = chineseProp.Value.Value<int>();
                    break;
                case "怪物级别":
                    chineseConverted["Category"] = ConvertMonsterCategory(chineseProp.Value.Value<string>());
                    break;
                case "可被技能推动":
                    chineseConverted["CanBeDrivenBySkills"] = chineseProp.Value.Value<bool>();
                    break;
                case "可被技能控制":
                    chineseConverted["CanBeControlledBySkills"] = chineseProp.Value.Value<bool>();
                    break;
                case "怪物移动间隔":
                    chineseConverted["MoveInterval"] = chineseProp.Value.Value<int>();
                    break;
                case "怪物漫游间隔":
                    chineseConverted["RoamInterval"] = chineseProp.Value.Value<int>();
                    break;
                case "尸体保留时长":
                    chineseConverted["CorpsePreservationDuration"] = chineseProp.Value.Value<int>();
                    break;
                case "主动攻击目标":
                    chineseConverted["ActiveAttackTarget"] = chineseProp.Value.Value<bool>();
                    break;
                case "怪物仇恨范围":
                    chineseConverted["RangeHate"] = chineseProp.Value.Value<int>();
                    break;
                case "怪物仇恨时间":
                    chineseConverted["HateTime"] = chineseProp.Value.Value<int>();
                    break;
                case "普通攻击技能":
                    chineseConverted["NormalAttackSkills"] = chineseProp.Value.Value<string>();
                    break;
                case "怪物基础":
                    chineseConverted["Stats"] = chineseProp.Value.Values<JObject>().Select(x => ConvertMonsterStat(x)).ToArray();
                    break;
                case "怪物提供经验":
                    chineseConverted["ProvideExperience"] = chineseProp.Value.Value<int>();
                    break;
                case "怪物掉落物品":
                    chineseConverted["Drops"] = chineseProp.Value.Values<JObject>().Select(x => ConvertMonsterDrop(x)).ToArray();
                    break;
                case "怪物分类":
                    chineseConverted["Category"] = ConvertMonsterRace(chineseProp.Value.Value<string>());
                    break;
                case "可被技能诱惑":
                    chineseConverted["CanBeSeducedBySkills"] = chineseProp.Value.Value<bool>();
                    break;
                case "基础诱惑概率":
                    chineseConverted["BaseTemptationProbability"] = chineseProp.Value.Value<float>();
                    break;
                case "怪物成长":
                    chineseConverted["Grows"] = chineseProp.Value.Values<JObject>().Select(x => ConvertGrowthStat(x)).ToArray();
                    break;
                case "继承属性":
                    chineseConverted["InheritsStats"] = chineseProp.Value.Values<JObject>().Select(x => ConvertInheritStat(x)).ToArray();
                    break;
                case "可见隐身目标":
                    chineseConverted["VisibleStealthTargets"] = chineseProp.Value.Value<bool>();
                    break;
                case "概率触发技能":
                    chineseConverted["ProbabilityTriggerSkills"] = chineseProp.Value.Value<string>();
                    break;
                case "进入战斗技能":
                    chineseConverted["EnterCombatSkills"] = chineseProp.Value.Value<string>();
                    break;
                case "退出战斗技能":
                    chineseConverted["ExitCombatSkills"] = chineseProp.Value.Value<string>();
                    break;
                case "瞬移释放技能":
                    chineseConverted["MoveReleaseSkill"] = chineseProp.Value.Value<string>();
                    break;
                case "复活释放技能":
                    chineseConverted["BirthReleaseSkill"] = chineseProp.Value.Value<string>();
                    break;
                case "死亡释放技能":
                    chineseConverted["DeathReleaseSkill"] = chineseProp.Value.Value<string>();
                    break;
                case "脱战自动石化":
                    chineseConverted["OutWarAutomaticPetrochemical"] = chineseProp.Value.Value<bool>();
                    break;
                case "石化状态编号":
                    chineseConverted["PetrochemicalStatusId"] = chineseProp.Value.Value<int>();
                    break;
                case "怪物禁止移动":
                    chineseConverted["ForbbidenMove"] = chineseProp.Value.Value<bool>();
                    break;
                case "怪物体型":
                    chineseConverted["Size"] = ConvertObjectSize(chineseProp.Value.Value<string>());
                    break;
                case "可被技能召唤": // ignore not use...
                    break;
                default:
                    throw new ApplicationException();
            }
        }

        var mir3dModel = mir3DbModels.FirstOrDefault(x => x.Value<int>("Id") == chineseModel.Value<int>("怪物编号"));

        var name = chineseConverted["MonsterName"];
        var id = chineseConverted.ContainsKey("Id") ? (int)chineseConverted["Id"] : 0;
        var fileName = $"{id}-{name}.txt";

        var mir3dOutputPath = Path.Combine(mir3DbFolder, fileName);

        if (mir3dModel == null)
        {
            var content = JsonConvert.SerializeObject(chineseConverted, jsonOptions);
            File.WriteAllText(mir3dOutputPath, content);
        }
    }
}

bool CompareRecursiveValue(object source, JToken target, string[] omitFields)
{
    var modified = false;

    switch (target.Type)
    {
        case JTokenType.String:
            if ((string)((JValue)target).Value != (string)source)
            {
                modified = true;
                ((JValue)target).Value = source;
            }
            break;
        case JTokenType.Boolean:
            if ((bool)((JValue)target).Value != (bool)source)
            {
                modified = true;
                ((JValue)target).Value = source;
            }
            break;
        case JTokenType.Float:
            if ((float)((JValue)target).Value != (float)source)
            {
                modified = true;
                ((JValue)target).Value = source;
            }
            break;
        case JTokenType.Integer:
            var targetInt = ((JValue)target).Value != null && ((JValue)target).Value is int ? new int?((int)((JValue)target).Value) : null;
            var targetLong = ((JValue)target).Value != null && ((JValue)target).Value is long ? new long?((long)((JValue)target).Value) : null;

            var sourceInt = source != null && source is int ? new int?((int)source) : null;
            var sourceLong = source != null && source is long ? new long?((long)source) : null;

            if (targetInt == null && targetLong == null) return false;
            else if (sourceInt == null && sourceLong == null) return false;

            var targetNum = targetLong != null ? targetLong : (int)targetInt;
            var sourceNum = sourceLong != null ? sourceLong : (int)sourceInt;

            if (targetNum != sourceNum)
            {
                modified = true;
                ((JValue)target).Value = source;
            }
            break;
        case JTokenType.Object:
            if (source is not IDictionary sourceObj)
                throw new ApplicationException();

            var keys = sourceObj.Keys.Cast<string>().ToArray();

            foreach (var prop in (JObject)target)
            {
                if (!omitFields.Contains(prop.Key) && keys.Contains(prop.Key) && CompareRecursiveValue(sourceObj[prop.Key], prop.Value, omitFields))
                    modified = true;
            }
            break;
        case JTokenType.Array:
            if (source is not IEnumerable collection) throw new ApplicationException();
            var arr = collection.Cast<object>().ToArray();

            for (var i = 0; i < arr.Length; i++)
            {
                var sourceItem = arr[i];
                var targetItem = ((JArray)target)[i];
                if (CompareRecursiveValue(sourceItem, targetItem, omitFields))
                    modified = true;
            }
            break;
        default:
            throw new NotImplementedException();
    }

    return modified;
}

Dictionary<string, object> ConvertTreasureItem(JObject obj)
{
    var output = new Dictionary<string, object>();

    foreach (var prop in obj)
    {
        switch (prop.Key)
        {
            case "物品名":
                output.Add("ItemName", prop.Value.Value<string>());
                break;
            case "职业":
                output.Add("NeedRace", ConvertObjectRace(prop.Value.Value<string>()));
                break;
            case "概率":
                output.Add("Rate", prop.Value.Value<int>());
                break;
            default:
                throw new ApplicationException();
        }
    }

    return output;
}

Dictionary<string, object> ConvertSkillNode(JObject obj)
{
    var output = new Dictionary<string, object>();

    foreach (var prop in obj)
    {
        switch (prop.Key)
        {
            case "$type":
                output.Add("$type", ConvertSkillNodeType(prop.Value.Value<string>()));
                break;
            case "限定命中数量":
                output.Add("HitsLimit", prop.Value.Value<int>());
                break;
            case "限定目标类型":
                output.Add("LimitedTargetType", ConvertObjetType(prop.Value.Value<string>()));
                break;
            case "限定目标关系":
                output.Add("LimitedTargetRelationship", ConvertLimitedTargetRelationship(prop.Value.Value<string>()));
                break;
            case "清除状态列表":
                output.Add(prop.Key, prop.Value.Values<ushort>().ToList());
                break;
            case "技能锁定方式":
                output.Add("技能锁定方式", ConvertSkillLockType(prop.Value.Value<string>()));
                break;
            case "技能闪避方式":
                output.Add("SkillEvasion", ConvertSkillEvasion(prop.Value.Value<string>()));
                break;
            case "技能范围类型":
                output.Add("技能范围类型", ConvertObjectSize(prop.Value.Value<string>()));
                break;
            case "技能命中反馈":
                output.Add("SkillHitFeedback", ConvertSkillHitFeedback(prop.Value.Value<string>()));
                break;
            case "技能伤害类型":
                output.Add(prop.Key, ConvertSkillDamageType(prop.Value.Value<string>()));
                break;
            case "触发Buff编号":
                output.Add("触发Id", prop.Value.Value<int>());
                break;
            case "技能最远距离":
                output.Add("MaxDistance", prop.Value.Value<int>());
                break;
            case "触发被动技能":
                output.Add("触发PassiveSkill", prop.Value.Value<bool>());
                break;
            case "经验技能编号":
                output.Add("ExpSkillId", prop.Value.Value<int>());
                break;
            case "增加技能经验":
                output.Add("GainSkillExp", prop.Value.Value<bool>());
                break;
            case "触发技能名字":
                output.Add("触发SkillName", prop.Value.Value<string>());
                break;
            case "角色自身添加":
                output.Add("角色ItSelf添加", prop.Value.Value<bool>());
                break;
            case "体力回复基数":
                if (prop.Value.Type == JTokenType.String)
                    output.Add("PhysicalRecoveryBase", prop.Value.Value<string>());
                else
                    output.Add("PhysicalRecoveryBase", prop.Value.Value<int>());
                break;
            case "技能增伤类型":
            case "所需目标类型":
            case "回复限定类型":
            case "推动目标类型":
            case "限定附加类型":
            case "攻速提升类型":
            case "技能斩杀类型":
            case "冷却减少类型":
                output.Add(prop.Key, ConvertSpecifyTargetType(prop.Value.Value<string>()));
                break;
            case "限定特定类型":
                output.Add("QualifySpecificType", ConvertSpecifyTargetType(prop.Value.Value<string>()));
                break;
            case "技能触发方式":
                output.Add(prop.Key, ConvertSkillTriggerMethod(prop.Value.Value<string>()));
                break;
            case "技能标记编号":
                output.Add("SkillTagId", prop.Value.Value<int>());
                break;
            case "自身冷却时间":
                output.Add("ItSelfCooldown", prop.Value.Value<int>());
                break;
            case "角色自身位移":
                output.Add("角色ItSelf位移", prop.Value.Value<bool>());
                break;
            case "推动增加经验":
                output.Add("DisplacementIncreaseExp", prop.Value.Value<bool>());
                break;
            case "所需铭文编号":
                output.Add("所需Id", prop.Value.Value<int>());
                break;
            case "自身位移耗时":
                output.Add("ItSelf位移耗时", prop.Value.Value<int>());
                break;
            case "自身位移次数":
                output.Add("ItSelf位移次数", prop.Value.Value<string>());
                break;
            case "自身位移距离":
                output.Add("ItSelf位移距离", prop.Value.Value<string>());
                break;
            case "特定诱惑列表":
                output.Add(prop.Key, prop.Value.Values<string>().ToArray());
                break;
            case "基础诱惑数量":
            case "初始宠物等级":
                output.Add(prop.Key, prop.Value.Value<string>());
                break;
            case "点爆需要层数":
            case "冷却减少分组":
            case "连续推动数量":
                output.Add(prop.Key, prop.Value.Value<byte>());
                break;
            case "所需Buff层数":
            case "技能最近距离":
            case "角色忙绿时间":
            case "目标硬直时间":
            case "角色硬直时间":
            case "禁止行走时间":
            case "禁止奔跑时间":
            case "技能增伤基数":
            case "冷却减少时间":
            case "冷却减少技能":
            case "零回复等级差":
            case "减回复等级差":
            case "技能破防基数":
            case "点爆标记编号":
            case "增加冷却Buff":
            case "冷却增加时间":
            case "目标位移耗时":
            case "目标位移编号":
            case "目标附加编号":
            case "单格飞行耗时":
            case "攻速提升幅度":
            case "增加概率Buff":
            case "瞬移失败提示":
            case "失败添加Buff":
            case "瘫痪状态编号":
            case "狂暴状态编号":
            case "额外诱惑数量":
            case "额外诱惑时长":
                output.Add(prop.Key, prop.Value.Value<int>());
                break;
            case "Buff触发概率":
            case "触发被动概率":
            case "技能触发概率":
            case "Buff增加系数":
            case "技能增伤系数":
            case "技能破防系数":
            case "技能破防概率":
            case "技能斩杀概率":
            case "伤害衰减下限":
            case "伤害衰减系数":
            case "推动目标概率":
            case "位移Buff概率":
            case "附加Buff概率":
            case "失败Buff概率":
            case "成功Buff概率":
            case "额外诱惑概率":
            case "特定诱惑概率":
                output.Add(prop.Key, prop.Value.Value<float>());
                break;
            case "技能伤害基数":
            case "体力回复次数":
            case "立即回复基数":
                output.Add(prop.Key, prop.Value.Values<int>().ToArray());
                break;
            case "目标位移距离":
                output.Add(prop.Key, prop.Value.Value<string>());
                break;
            case "技能伤害系数":
            case "立即回复系数":
            case "每级成功概率":
                output.Add(prop.Key, prop.Value.Values<float>().ToArray());
                break;
            case "失败Buff编号":
                output.Add("失败Id", prop.Value.Value<int>());
                break;
            case "验证目标Buff":
                output.Add("VerifyTargetBuff", prop.Value.Value<bool>());
                break;
            case "放空结束技能":
            case "清除目标状态":
            case "发送释放通知":
            case "调整角色朝向":
            case "技能能否穿墙":
            case "技能能否招架":
            case "技能扩展通知":
            case "扣除武器持久":
            case "发送结束通知":
            case "计算攻速缩减":
            case "解除技能陷阱":
            case "后摇结束死亡":
            case "同组铭文无效":
            case "计算飞行耗时":
            case "验证铭文技能":
            case "触发成功移除":
            case "命中减少冷却":
            case "击杀减少冷却":
            case "增加宠物仇恨":
            case "等级差减回复":
            case "目标死亡回复":
            case "数量衰减伤害":
            case "失败添加层数":
            case "点爆命中目标":
            case "允许移除标记":
            case "移除技能标记":
            case "Buff增加冷却":
            case "允许超出锚点":
            case "锚点反向位移":
            case "多段位移通知":
            case "能否穿越障碍":
            case "推动目标位移":
            case "清空命中列表":
            case "发送中断通知":
            case "补发释放通知":
            case "技能命中通知":
            case "计算当前位置":
            case "计算当前方向":
            case "检查铭文技能":
                output.Add(prop.Key, prop.Value.Value<bool>());
                break;
            case "成功Buff编号":
                output.Add("成功Id", prop.Value.Value<bool>());
                break;
            case "位移增加经验":
                output.Add("DisplacementIncreaseExp", prop.Value.Value<bool>());
                break;
            case "分组冷却时间":
                output.Add("分组Cooldown", prop.Value.Value<int>());
                break;
            case "自身硬直时间":
                output.Add("ItSelf硬直时间", prop.Value.Value<int>());
                break;
            case "目标Buff编号":
                output.Add("目标Id", prop.Value.Value<int>());
                break;
            case "伴生Buff编号":
                output.Add("伴生Id", prop.Value.Value<int>());
                break;
            case "触发陷阱技能":
                output.Add("TriggerTrapSkills", prop.Value.Value<string>());
                break;
            case "触发陷阱数量":
                output.Add("NumberTrapsTriggered", ConvertObjectSize(prop.Value.Value<string>()));
                break;
            case "反手技能名字":
                output.Add("反手SkillName", prop.Value.Value<string>());
                break;
            case "验证自身Buff":
                output.Add("验证ItSelfBuff", prop.Value.Value<bool>());
                break;
            case "自身Buff编号":
                output.Add("Id", prop.Value.Value<int>());
                break;
            case "道术叠加次数":
                output.Add("Taoism叠加次数", prop.Value.Values<float>().ToArray());
                break;
            case "道术叠加基数":
                output.Add("Taoism叠加基数", prop.Value.Values<float>().ToArray());
                break;
            case "计算触发概率":
                output.Add("CalculateTriggerProbability", prop.Value.Value<bool>());
                break;
            case "计算幸运概率":
                output.Add("CalculateLuckyProbability", prop.Value.Value<bool>());
                break;
            case "验证目标类型":
                output.Add("VerifyTargetType", prop.Value.Value<bool>());
                break;
            case "检查铭文编号":
                output.Add("检查Id", prop.Value.Value<int>());
                break;
            case "限定锚点距离": // not exists ignore
                break;
            case "召唤宠物名字":
                output.Add("PetName", prop.Value.Value<string>());
                break;
            case "召唤宠物数量":
                output.Add("SpawnCount", prop.Value.Value<string>());
                break;
            case "宠物等级上限":
                output.Add("LevelCap", prop.Value.Value<string>());
                break;
            case "宠物绑定武器":
                output.Add("PetBoundWeapons", prop.Value.Value<bool>());
                break;
            case "检查技能铭文":
                output.Add("CheckSkillInscriptions", prop.Value.Value<bool>());
                break;
            case "怪物召唤同伴":
                output.Add("Companion", prop.Value.Value<bool>());
                break;
            default:
                throw new ApplicationException();
        }
    }

    return output;
}

Dictionary<string, object> ConvertItemProps(JObject obj)
{
    var output = new Dictionary<string, object>();

    foreach (var prop in obj)
    {
        switch (prop.Key)
        {
            case "使用类型":
                output.Add("UsageType", prop.Value.Value<int>());
                break;
            case "恢复时间":
                output.Add("RecoveryTime", prop.Value.Value<int>());
                break;
            case "恢复基数":
                output.Add("RecoveryBase", prop.Value.Value<int>());
                break;
            case "恢复步骤":
                output.Add("RecoverySteps", prop.Value.Value<int>());
                break;
            case "元宝数量":
                output.Add("IngotsAmount", prop.Value.Value<int>());
                break;
            case "宝盒物品概率":
                output.Add("TreasureItemRate", prop.Value.Value<int>());
                break;
            case "双倍经验概率":
                output.Add("DoubleExpRate", prop.Value.Value<int>());
                break;
            case "金币概率":
                output.Add("GoldRate", prop.Value.Value<int>());
                break;
            case "金币数量":
                output.Add("GoldAmount", prop.Value.Value<int>());
                break;
            case "双倍经验":
                output.Add("DoubleExpAmount", prop.Value.Value<int>());
                break;
            case "增加HP":
                output.Add("IncreaseHP", prop.Value.Value<int>());
                break;
            case "增加MP":
                output.Add("IncreaseMP", prop.Value.Value<int>());
                break;
            case "坐骑编号":
                output.Add("MountId", prop.Value.Value<int>());
                break;
            case "地图编号":
                output.Add("MapId", prop.Value.Value<int>());
                break;
            default:
                throw new ApplicationException();
        }
    }

    return output;
}

Dictionary<string, object> ConvertMonsterStat(JObject obj)
{
    var output = new Dictionary<string, object>();

    foreach (var prop in obj)
    {
        switch (prop.Key)
        {
            case "属性":
                output.Add("Stat", ConvertStat(prop.Value.Value<string>()));
                break;
            case "数值":
                output.Add("Value", prop.Value.Value<int>());
                break;
            default:
                throw new ApplicationException();
        }
    }

    return output;
}

Dictionary<string, object> ConvertGrowthStat(JObject obj)
{
    var output = new Dictionary<string, object>();

    foreach (var prop in obj)
    {
        switch (prop.Key)
        {
            case "属性":
                output.Add("Stat", ConvertStat(prop.Value.Value<string>()));
                break;
            case "零级":
                output.Add("Level0", prop.Value.Value<int>());
                break;
            case "一级":
                output.Add("Level1", prop.Value.Value<int>());
                break;
            case "二级":
                output.Add("Level2", prop.Value.Value<int>());
                break;
            case "三级":
                output.Add("Level3", prop.Value.Value<int>());
                break;
            case "四级":
                output.Add("Level4", prop.Value.Value<int>());
                break;
            case "五级":
                output.Add("Level5", prop.Value.Value<int>());
                break;
            case "六级":
                output.Add("Level6", prop.Value.Value<int>());
                break;
            case "七级":
                output.Add("Level7", prop.Value.Value<int>());
                break;
            default:
                throw new ApplicationException();
        }
    }

    return output;
}


Dictionary<string, object> ConvertInheritStat(JObject obj)
{
    var output = new Dictionary<string, object>();

    foreach (var prop in obj)
    {
        switch (prop.Key)
        {
            case "继承属性":
                output.Add("InheritsStats", ConvertStat(prop.Value.Value<string>()));
                break;
            case "转换属性":
                output.Add("ConvertStat", ConvertStat(prop.Value.Value<string>()));
                break;
            case "继承比例":
                output.Add("Ratio", prop.Value.Value<float>());
                break;
            default:
                throw new ApplicationException();
        }
    }

    return output;
}

Dictionary<string, object> ConvertMonsterDrop(JObject obj)
{
    var output = new Dictionary<string, object>();

    foreach (var prop in obj)
    {
        switch (prop.Key)
        {
            case "物品名字":
                output.Add("Name", prop.Value.Value<string>());
                break;
            case "怪物名字":
                output.Add("MonsterName", prop.Value.Value<string>());
                break;
            case "掉落概率":
                output.Add("Probability", prop.Value.Value<int>());
                break;
            case "最小数量":
                output.Add("MinAmount", prop.Value.Value<int>());
                break;
            case "最大数量":
                output.Add("MaxAmount", prop.Value.Value<int>());
                break;
            default:
                throw new ApplicationException();
        }
    }

    return output;
}

string ConvertMonsterRace(string chinese)
{
    switch (chinese)
    {
        case "n":
            return "Normal";
        case "不死生物":
            return "Undead";
        case "虫族生物":
            return "ZergCreature";
        case "沃玛怪物":
            return "WomaMonster";
        case "猪类怪物":
            return "PigMonster";
        case "祖玛怪物":
            return "ZumaMonster";
        case "sas":
            return "DragonMonster";
        default:
            throw new ApplicationException();
    }
}

string ConvertMonsterCategory(string chinese)
{
    switch (chinese)
    {
        case "普通怪物":
            return "Normal";
        case "精英干将":
            return "Elite";
        case "头目首领":
            return "Boss";
        default:
            throw new ApplicationException();
    }
}

string ConvertStoreType(string chinese)
{
    return chinese;
}

string ConvertPersistentItemType(string chinese)
{
    return chinese;
}

string ConvertItemType(string chinese)
{
    return chinese;
}

string ConvertLimitedTargetRelationship(string chinese)
{
    var values = chinese.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
    var output = new List<string>();
    foreach (var value in values)
    {
        switch (value)
        {
            case "敌对":
                return "Hostility";
            case "自身":
                return "ItSelf";
            case "友方":
                return "Friendly";
            default:
                throw new ApplicationException();
        }
    }
    return string.Join(", ", output);
}

string ConvertSpecifyTargetType(string chinese)
{
    var values = chinese.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
    var output = new List<string>();
    foreach (var value in values)
    {
        switch (value)
        {
            case "猪类怪物":
                return "PigMonster";
            case "所有怪物":
                return "AllMonsters";
            case "低级目标":
                return "LowLevelTarget";
            case "所有宠物":
                return "AllPets";
            case "低级怪物":
                return "LowLevelMonster";
            case "普通怪物":
                return "Normal";
            case "虫族生物":
                return "ZergCreature";
            case "带盾法师":
                return "ShieldMage";
            case "所有玩家":
                return "AllPlayers";
            case "背刺目标":
                return "Backstab";
            case "沃玛怪物":
                return "WomaMonster";
            case "不死生物":
                return "Undead";
            default:
                throw new ApplicationException();
        }
    }
    return string.Join(", ", output);
}

string ConvertSkillTriggerMethod(string chinese)
{
    var values = chinese.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
    var output = new List<string>();
    foreach (var value in values)
    {
        switch (value)
        {
            case "原点位置绝对触发":
                return "OriginAbsolutePosition";
            case "锚点位置绝对触发":
                return "AnchorAbsolutePosition";
            case "目标命中绝对触发":
                return "TargetHitDefinitely";
            case "刺杀位置绝对触发":
                return "AssassinationAbsolutePosition";
            case "正手反手随机触发":
                return "ForehandAndBackhandRandom";
            case "怪物命中绝对触发":
                return "MonsterHitDefinitely";
            case "目标闪避绝对触发":
                return "TargetMissDefinitely";
            case "无目标锚点位触发":
                return "NoTargetPosition";
            default:
                throw new ApplicationException();
        }
    }
    return string.Join(", ", output);
}


string ConvertObjetType(string chinese)
{
    var values = chinese.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
    var output = new List<string>();
    foreach (var value in values)
    {
        switch (value)
        {
            case "玩家":
                output.Add("Player");
                break;
            case "怪物":
                output.Add("Monster");
                break;
            case "宠物":
                output.Add("Pet");
                break;
            default:
                throw new ApplicationException();
        }
    }
    return string.Join(", ", output);
}

string ConvertSkillNodeType(string chinese)
{
    switch (chinese)
    {
        case "C_01_计算命中目标, Assembly-CSharp":
            return "C_01_CalculateHitTarget, Assembly-CSharp";
        case "A_01_触发对象Buff, Assembly-CSharp":
            return "A_01_TriggerObjectBuff, Assembly-CSharp";
        case "C_00_计算技能锚点, Assembly-CSharp":
            return "C_00_CalculateSkillAnchor, Assembly-CSharp";
        case "B_01_技能释放通知, Assembly-CSharp":
            return "B_01_SkillReleaseNotification, Assembly-CSharp";
        case "C_02_计算目标伤害, Assembly-CSharp":
            return "C_02_CalculateTargetDamage, Assembly-CSharp";
        case "B_03_前摇结束通知, Assembly-CSharp":
            return "B_03_FrontShakeEndNotification, Assembly-CSharp";
        case "B_04_后摇结束通知, Assembly-CSharp":
            return "B_04_PostShakeEndNotification, Assembly-CSharp";
        case "A_00_触发子类技能, Assembly-CSharp":
            return "A_00_TriggerSubSkills, Assembly-CSharp";
        case "B_00_技能切换通知, Assembly-CSharp":
            return "B_00_SkillSwitchNotification, Assembly-CSharp";
        case "C_03_计算对象位移, Assembly-CSharp":
            return "C_03_CalculateObjectDisplacement, Assembly-CSharp";
        case "A_02_触发陷阱技能, Assembly-CSharp":
            return "A_02_TriggerTrapSkills, Assembly-CSharp";
        case "C_05_计算目标回复, Assembly-CSharp":
            return "C_05_CalculateTargetReply, Assembly-CSharp";
        case "C_07_计算目标瞬移, Assembly-CSharp":
            return "C_07_CalculateTargetTeleportation, Assembly-CSharp";
        case "C_04_计算目标诱惑, Assembly-CSharp":
            return "C_04_CalculateTargetTemptation, Assembly-CSharp";
        case "C_06_计算宠物召唤, Assembly-CSharp":
            return "C_06_CalculatePetSummoning, Assembly-CSharp";
        default:
            throw new ApplicationException();
    }
}

string ConvertObjectSize(string chinese)
{
    switch (chinese)
    {
        case "空心3x3":
            return "Hollow3x3";
        case "空心5x5":
            return "Hollow5x5";
        case "半月3x1":
            return "HalfMoon3x1";
        case "半月3x2":
            return "HalfMoon3x2";
        case "半月3x3":
            return "HalfMoon3x3";
        case "斩月1x3":
            return "Zhanyue1x3";
        case "斩月3x3":
            return "Zhanyue3x3";
        case "螺旋7x7":
            return "Spiral7x7";
        case "前方3x1":
            return "Front3x1";
        case "线型1x2":
            return "LineType1x2";
        case "线型1x5":
            return "LineType1x5";
        case "线型1x6":
            return "LineType1x6";
        case "线型1x7":
            return "LineType1x7";
        case "线型1x8":
            return "LineType1x8";
        case "线型3x7":
            return "LineType3x7";
        case "线型3x8":
            return "LineType3x8";
        case "实心3x3":
            return "Solid3x3";
        case "实心5x5":
            return "Solid5x5";
        case "炎龙1x2":
            return "Yanlong1x2";
        case "菱形3x3":
            return "Diamond3x3";
        case "单体1x1":
            return "Single1x1";
        case "螺旋15x15":
            return "Spiral15x15";
        default:
            throw new ApplicationException();
    }
}

string ConvertSkillEvasion(string chinese)
{
    switch (chinese)
    {
        case "可被物理闪避":
            return "CanBePhsyicallyEvaded";
        case "可被魔法闪避":
            return "CanBeMagicEvaded";
        case "可被中毒闪避":
            return "CanBePoisonEvaded";
        default:
            throw new ApplicationException();
    }
}

string ConvertSkillHitFeedback(string chinese)
{
    return chinese; // not translated enum
}

string ConvertSkillLockType(string chinese)
{
    switch (chinese)
    {
        case "锁定目标":
        case "锁定锚点坐标":
        case "锁定目标坐标":
            return chinese;
        case "锁定自身坐标":
            return "锁定ItSelf坐标";
        case "放空锁定自身":
            return "放空锁定ItSelf";
        default:
            throw new ApplicationException();
    }
}

string ConvertObjectRace(string chinese)
{
    return chinese;
}


string ConvertSkillType(string chinese)
{
    switch (chinese)
    {
        case "子类技能":
            return "SubSkills";
        case "神圣":
            return "MainSkills";
        default:
            throw new ApplicationException();
    }
}

string ConvertSkillDamageType(string chinese)
{
    switch (chinese)
    {
        case "撕裂":
            return "Tear";
        case "神圣":
            return "Sacred";
        case "灼烧":
            return "Burn";
        case "毒性":
            return "Toxicity";
        case "刺术":
            return "Needle";
        case "魔法":
            return "Magic";
        case "弓术":
            return "Archery";
        case "道术":
            return "Taoism";
        default:
            throw new ApplicationException();
    }
}

string ConvertBuffJudgmentType(string chinese)
{
    switch (chinese)
    {
        case "来源技能伤害":
            return "SourceSkillDamage";
        case "所有特定伤害":
            return "AllSpecificInjuries";
        case "来源魔法伤害":
            return "SourceMagicDamage";
        default:
            throw new ApplicationException();
    }
}

string ConvertBuffDetherminationMethod(string chinese)
{
    switch (chinese)
    {
        case "被动受伤增伤":
            return "PassiveInjuryIncrease";
        case "被动受伤减伤":
            return "PassiveInjuryReduction";
        case "主动攻击减伤":
            return "ActiveAttackDamageReduction";
        default:
            throw new ApplicationException();
    }
}

string ConvertObjectState(string chinese)
{
    var values = chinese.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
    var output = new List<string>();
    foreach (var value in values)
    {
        switch (value)
        {
            case "麻痹状态":
                return "Paralyzed";
            case "潜行状态":
                return "StealthStatus";
            case "残废状态":
                return "Disabled";
            case "暴露状态":
                return "Exposed";
            case "失神状态":
                return "Absence";
            case "无敌状态":
                return "Invencible";
            case "中毒状态":
                return "Poisoned";
            case "隐身状态":
                return "Invisibility";
            default:
                throw new ApplicationException();
        }
    }
    return string.Join(", ", output);
}

string ConvertStat(string chinese)
{
    switch (chinese)
    {
        case "攻击速度":
            return "AttackSpeed";
        case "最大攻击":
            return "MaxDC";
        case "最小防御":
            return "MinDef";
        case "最大防御":
            return "MaxDef";
        case "最小魔防":
            return "MinMCDef";
        case "最大魔防":
            return "MaxMCDef";
        case "行走速度":
            return "WalkSpeed";
        case "奔跑速度":
            return "RunSpeed";
        case "最大魔法":
            return "MaxMC";
        case "最大道术":
            return "MaxSC";
        case "最大刺术":
            return "MaxNC";
        case "最大弓术":
            return "MaxBC";
        case "魔法闪避":
            return "MagicDodge";
        case "物理敏捷":
            return "PhysicalAgility";
        case "物理准确":
            return "PhysicallyAccurate";
        case "最大体力":
            return "MaxHP";
        case "最小攻击":
            return "MinDC";
        case "最小刺术":
            return "MinNC";
        case "最小魔法":
            return "MinMC";
        case "最小道术":
            return "MinSC";
        case "最小圣伤":
            return "MinHC";
        case "最大圣伤":
            return "MaxHC";
        case "幸运等级":
            return "Luck";
        case "体力恢复":
        case "怪物伤害":
        case "怪物闪避":
        case "中毒躲避":
            return chinese; // unstranslated into server
        default:
            throw new ApplicationException();
    }
}

Dictionary<string, object> ConvertInscriptionStat(JObject statObj)
{
    var output = new Dictionary<string, object>();

    foreach (var prop in statObj)
    {
        switch (prop.Key)
        {
            case "属性":
                output["Stat"] = ConvertStat(prop.Value.Value<string>());
                break;
            case "零级":
                output["Level0"] = prop.Value.Value<int>();
                break;
            case "一级":
                output["Level1"] = prop.Value.Value<int>();
                break;
            case "二级":
                output["Level2"] = prop.Value.Value<int>();
                break;
            case "三级":
                output["Level3"] = prop.Value.Value<int>();
                break;
        }
    }

    return output;
}

string ConvertActionType(string chinese)
{
    switch (chinese)
    {
        case "减益类型":
            return "Debuff";
        case "增益类型":
            return "Gain";
        default:
            throw new ApplicationException();
    }
}

string ConvertOverlayType(string chinese)
{
    switch (chinese)
    {
        case "同类叠加":
            return "HomogeneousStacking";
        case "同类替换":
            return "SimilarReplacement";
        case "同类延时":
            return "SimilarDelay";
        default:
            throw new ApplicationException();
    }
}

string ConvertEffect(string chinese)
{
    var values = chinese.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
    var output = new List<string>();
    foreach (var value in values)
    {
        switch (value)
        {
            case "诱惑提升":
                output.Add("TemptationBoost");
                break;
            case "造成伤害":
                output.Add("CausesSomeDamages");
                break;
            case "创建陷阱":
                output.Add("CreateTrap");
                break;
            case "属性增减":
                output.Add("StatsIncOrDec");
                break;
            case "状态标志":
                output.Add("StatusFlag");
                break;
            case "伤害增减":
                output.Add("DamageIncOrDec");
                break;
            case "生命回复":
                output.Add("LifeRecovery");
                break;
            case "技能标志":
                output.Add("SkillSign");
                break;
            default:
                throw new ApplicationException();
        }
    }
    return string.Join(", ", output);
}



DumpBuffs();
DumpSkillsData();
DumpSkillInscriptions();
DumpCommonItems();
DumpMonsters();