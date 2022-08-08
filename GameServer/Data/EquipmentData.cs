using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameServer.Templates;

namespace GameServer.Data
{

    public class EquipmentData : ItemData
    {

        public EquipmentItem 装备模板
        {
            get
            {
                return base.物品模板 as EquipmentItem;
            }
        }


        public int 装备战力
        {
            get
            {
                if (装备模板.Type == ItemType.武器)
                {
                    int num = (int)(装备模板.BasicPowerCombat * (幸运等级.V + 20) * 1717986919L >> 32 >> 3);
                    int num2 = Sacred伤害.V * 3 + 升级Attack.V * 5 + 升级Magic.V * 5 + 升级Taoism.V * 5 + 升级Needle.V * 5 + 升级Archery.V * 5;
                    int num3 = 随机Stat.Sum((RandomStats x) => x.CombatBonus);
                    return num + num2 + num3;
                }
                int num4 = 0;
                switch (装备模板.EquipSet)
                {
                    case GameEquipmentSet.祖玛装备:
                        switch (装备模板.Type)
                        {
                            case ItemType.腰带:
                            case ItemType.鞋子:
                            case ItemType.头盔:
                                num4 = 2 * 升级次数.V;
                                break;
                            case ItemType.衣服:
                                num4 = 4 * 升级次数.V;
                                break;
                        }
                        break;
                    case GameEquipmentSet.赤月装备:
                        switch (装备模板.Type)
                        {
                            case ItemType.腰带:
                            case ItemType.鞋子:
                            case ItemType.头盔:
                                num4 = 4 * 升级次数.V;
                                break;
                            case ItemType.衣服:
                                num4 = 6 * 升级次数.V;
                                break;
                        }
                        break;
                    case GameEquipmentSet.魔龙装备:
                        switch (装备模板.Type)
                        {
                            case ItemType.腰带:
                            case ItemType.鞋子:
                            case ItemType.头盔:
                                num4 = 5 * 升级次数.V;
                                break;
                            case ItemType.衣服:
                                num4 = 8 * 升级次数.V;
                                break;
                        }
                        break;
                    case GameEquipmentSet.苍月装备:
                        switch (装备模板.Type)
                        {
                            case ItemType.腰带:
                            case ItemType.鞋子:
                            case ItemType.头盔:
                                num4 = 7 * 升级次数.V;
                                break;
                            case ItemType.衣服:
                                num4 = 11 * 升级次数.V;
                                break;
                        }
                        break;
                    case GameEquipmentSet.星王装备:
                        if (装备模板.Type == ItemType.衣服)
                        {
                            num4 = 13 * 升级次数.V;
                        }
                        break;
                    case GameEquipmentSet.神秘装备:
                    case GameEquipmentSet.城主装备:
                        switch (装备模板.Type)
                        {
                            case ItemType.腰带:
                            case ItemType.鞋子:
                            case ItemType.头盔:
                                num4 = 9 * 升级次数.V;
                                break;
                            case ItemType.衣服:
                                num4 = 13 * 升级次数.V;
                                break;
                        }
                        break;
                }
                int num5 = 孔洞颜色.Count * 10;
                using (IEnumerator<GameItems> enumerator = 镶嵌灵石.Values.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        switch (enumerator.Current.Name)
                        {
                            case "驭朱灵石8级":
                            case "精绿灵石8级":
                            case "韧紫灵石8级":
                            case "抵御幻彩灵石8级":
                            case "进击幻彩灵石8级":
                            case "盈绿灵石8级":
                            case "狂热幻彩灵石8级":
                            case "透蓝灵石8级":
                            case "守阳灵石8级":
                            case "新阳灵石8级":
                            case "命朱灵石8级":
                            case "蔚蓝灵石8级":
                            case "赤褐灵石8级":
                            case "橙黄灵石8级":
                            case "纯紫灵石8级":
                            case "深灰灵石8级":
                                num5 += 80;
                                break;
                            case "精绿灵石5级":
                            case "新阳灵石5级":
                            case "命朱灵石5级":
                            case "蔚蓝灵石5级":
                            case "橙黄灵石5级":
                            case "进击幻彩灵石5级":
                            case "深灰灵石5级":
                            case "盈绿灵石5级":
                            case "透蓝灵石5级":
                            case "韧紫灵石5级":
                            case "抵御幻彩灵石5级":
                            case "驭朱灵石5级":
                            case "赤褐灵石5级":
                            case "守阳灵石5级":
                            case "狂热幻彩灵石5级":
                            case "纯紫灵石5级":
                                num5 += 50;
                                break;
                            case "精绿灵石2级":
                            case "蔚蓝灵石2级":
                            case "驭朱灵石2级":
                            case "橙黄灵石2级":
                            case "守阳灵石2级":
                            case "纯紫灵石2级":
                            case "透蓝灵石2级":
                            case "抵御幻彩灵石2级":
                            case "命朱灵石2级":
                            case "深灰灵石2级":
                            case "赤褐灵石2级":
                            case "新阳灵石2级":
                            case "进击幻彩灵石2级":
                            case "狂热幻彩灵石2级":
                            case "盈绿灵石2级":
                            case "韧紫灵石2级":
                                num5 += 20;
                                break;
                            case "抵御幻彩灵石7级":
                            case "命朱灵石7级":
                            case "赤褐灵石7级":
                            case "狂热幻彩灵石7级":
                            case "精绿灵石7级":
                            case "纯紫灵石7级":
                            case "韧紫灵石7级":
                            case "驭朱灵石7级":
                            case "深灰灵石7级":
                            case "盈绿灵石7级":
                            case "新阳灵石7级":
                            case "蔚蓝灵石7级":
                            case "橙黄灵石7级":
                            case "守阳灵石7级":
                            case "进击幻彩灵石7级":
                            case "透蓝灵石7级":
                                num5 += 70;
                                break;
                            case "精绿灵石9级":
                            case "驭朱灵石9级":
                            case "蔚蓝灵石9级":
                            case "橙黄灵石9级":
                            case "抵御幻彩灵石9级":
                            case "透蓝灵石9级":
                            case "纯紫灵石9级":
                            case "命朱灵石9级":
                            case "赤褐灵石9级":
                            case "深灰灵石9级":
                            case "守阳灵石9级":
                            case "新阳灵石9级":
                            case "盈绿灵石9级":
                            case "进击幻彩灵石9级":
                            case "狂热幻彩灵石9级":
                            case "韧紫灵石9级":
                                num5 += 90;
                                break;
                            case "驭朱灵石4级":
                            case "深灰灵石4级":
                            case "新阳灵石4级":
                            case "盈绿灵石4级":
                            case "蔚蓝灵石4级":
                            case "命朱灵石4级":
                            case "橙黄灵石4级":
                            case "进击幻彩灵石4级":
                            case "抵御幻彩灵石4级":
                            case "透蓝灵石4级":
                            case "守阳灵石4级":
                            case "精绿灵石4级":
                            case "赤褐灵石4级":
                            case "纯紫灵石4级":
                            case "韧紫灵石4级":
                            case "狂热幻彩灵石4级":
                                num5 += 40;
                                break;
                            case "透蓝灵石6级":
                            case "抵御幻彩灵石6级":
                            case "命朱灵石6级":
                            case "盈绿灵石6级":
                            case "深灰灵石6级":
                            case "蔚蓝灵石6级":
                            case "进击幻彩灵石6级":
                            case "橙黄灵石6级":
                            case "赤褐灵石6级":
                            case "驭朱灵石6级":
                            case "精绿灵石6级":
                            case "新阳灵石6级":
                            case "韧紫灵石6级":
                            case "守阳灵石6级":
                            case "纯紫灵石6级":
                            case "狂热幻彩灵石6级":
                                num5 += 60;
                                break;
                            case "透蓝灵石1级":
                            case "驭朱灵石1级":
                            case "韧紫灵石1级":
                            case "守阳灵石1级":
                            case "赤褐灵石1级":
                            case "纯紫灵石1级":
                            case "狂热幻彩灵石1级":
                            case "精绿灵石1级":
                            case "新阳灵石1级":
                            case "盈绿灵石1级":
                            case "蔚蓝灵石1级":
                            case "橙黄灵石1级":
                            case "深灰灵石1级":
                            case "命朱灵石1级":
                            case "进击幻彩灵石1级":
                            case "抵御幻彩灵石1级":
                                num5 += 10;
                                break;
                            case "蔚蓝灵石10级":
                            case "狂热幻彩灵石10级":
                            case "精绿灵石10级":
                            case "透蓝灵石10级":
                            case "橙黄灵石10级":
                            case "抵御幻彩灵石10级":
                            case "进击幻彩灵石10级":
                            case "命朱灵石10级":
                            case "守阳灵石10级":
                            case "赤褐灵石10级":
                            case "盈绿灵石10级":
                            case "深灰灵石10级":
                            case "韧紫灵石10级":
                            case "纯紫灵石10级":
                            case "新阳灵石10级":
                            case "驭朱灵石10级":
                                num5 += 100;
                                break;
                            case "驭朱灵石3级":
                            case "韧紫灵石3级":
                            case "精绿灵石3级":
                            case "新阳灵石3级":
                            case "守阳灵石3级":
                            case "盈绿灵石3级":
                            case "蔚蓝灵石3级":
                            case "命朱灵石3级":
                            case "橙黄灵石3级":
                            case "进击幻彩灵石3级":
                            case "抵御幻彩灵石3级":
                            case "透蓝灵石3级":
                            case "赤褐灵石3级":
                            case "深灰灵石3级":
                            case "狂热幻彩灵石3级":
                            case "纯紫灵石3级":
                                num5 += 30;
                                break;
                        }
                    }
                }
                int num6 = 随机Stat.Sum((RandomStats x) => x.CombatBonus);
                return 装备模板.BasicPowerCombat + num4 + num6 + num5;
            }
        }


        public int 修理费用
        {
            get
            {
                int value = 最大持久.V - 当前持久.V;
                decimal d = ((EquipmentItem)对应模板.V).RepairCost;
                decimal d2 = ((EquipmentItem)对应模板.V).MaxDura * 1000m;
                return (int)(d / d2 * value);
            }
        }


        public int 特修费用
        {
            get
            {
                decimal d = 最大持久.V - 当前持久.V;
                decimal d2 = ((EquipmentItem)对应模板.V).SpecialRepairCost;
                decimal d3 = ((EquipmentItem)对应模板.V).MaxDura * 1000m;
                return (int)(d2 / d3 * d * Config.EquipRepairDto * 1.15m);
            }
        }


        public int NeedAttack
        {
            get
            {
                return ((EquipmentItem)base.物品模板).NeedAttack;
            }
        }


        public int NeedMagic
        {
            get
            {
                return ((EquipmentItem)base.物品模板).NeedMagic;
            }
        }


        public int NeedTaoism
        {
            get
            {
                return ((EquipmentItem)base.物品模板).NeedTaoism;
            }
        }


        public int NeedAcupuncture
        {
            get
            {
                return ((EquipmentItem)base.物品模板).NeedAcupuncture;
            }
        }


        public int NeedArchery
        {
            get
            {
                return ((EquipmentItem)base.物品模板).NeedArchery;
            }
        }


        public string 装备名字
        {
            get
            {
                return base.物品模板.Name;
            }
        }


        public bool DisableDismount
        {
            get
            {
                return ((EquipmentItem)对应模板.V).DisableDismount;
            }
        }


        public bool CanRepair
        {
            get
            {
                return base.PersistType == PersistentItemType.装备;
            }
        }


        public int 传承材料
        {
            get
            {
                switch (base.Id)
                {
                    case 99900022:
                        return 21001;
                    case 99900023:
                        return 21002;
                    case 99900024:
                        return 21003;
                    case 99900025:
                        return 21001;
                    case 99900026:
                        return 21001;
                    case 99900027:
                        return 21003;
                    case 99900028:
                        return 21002;
                    case 99900029:
                        return 21002;
                    case 99900030:
                        return 21001;
                    case 99900031:
                        return 21003;
                    case 99900032:
                        return 21001;
                    case 99900033:
                        return 21002;
                    case 99900037:
                        return 21001;
                    case 99900038:
                        return 21003;
                    case 99900039:
                        return 21002;
                    case 99900044:
                        return 21003;
                    case 99900045:
                        return 21001;
                    case 99900046:
                        return 21002;
                    case 99900047:
                        return 21003;
                    case 99900048:
                        return 21001;
                    case 99900049:
                        return 21003;
                    case 99900050:
                        return 21002;
                    case 99900055:
                        return 21004;
                    case 99900056:
                        return 21004;
                    case 99900057:
                        return 21004;
                    case 99900058:
                        return 21004;
                    case 99900059:
                        return 21004;
                    case 99900060:
                        return 21004;
                    case 99900061:
                        return 21004;
                    case 99900062:
                        return 21004;
                    case 99900063:
                        return 21002;
                    case 99900064:
                        return 21003;
                    case 99900074:
                        return 21005;
                    case 99900076:
                        return 21005;
                    case 99900077:
                        return 21005;
                    case 99900078:
                        return 21005;
                    case 99900079:
                        return 21005;
                    case 99900080:
                        return 21005;
                    case 99900081:
                        return 21005;
                    case 99900082:
                        return 21005;
                    case 99900104:
                        return 21006;
                    case 99900105:
                        return 21006;
                    case 99900106:
                        return 21006;
                    case 99900107:
                        return 21006;
                    case 99900108:
                        return 21006;
                    case 99900109:
                        return 21006;
                    case 99900110:
                        return 21006;
                    case 99900111:
                        return 21006;
                }
                return 0;
            }
        }


        public string StatDescription
        {
            get
            {
                string text = "";
                Dictionary<GameObjectStats, int> dictionary = new Dictionary<GameObjectStats, int>();
                foreach (RandomStats 随机Stat in 随机Stat)
                {
                    dictionary[随机Stat.Stat] = 随机Stat.Value;
                }
                if (dictionary.ContainsKey(GameObjectStats.MinAttack) || dictionary.ContainsKey(GameObjectStats.MaxAttack))
                {
                    int num;
                    int num2;
                    text += string.Format("\nAttack{0}-{1}", dictionary.TryGetValue(GameObjectStats.MinAttack, out num) ? num : 0, dictionary.TryGetValue(GameObjectStats.MaxAttack, out num2) ? num2 : 0);
                }
                if (dictionary.ContainsKey(GameObjectStats.MinMagic) || dictionary.ContainsKey(GameObjectStats.MaxMagic))
                {
                    int num3;
                    int num4;
                    text += string.Format("\nMagic{0}-{1}", dictionary.TryGetValue(GameObjectStats.MinMagic, out num3) ? num3 : 0, dictionary.TryGetValue(GameObjectStats.MaxMagic, out num4) ? num4 : 0);
                }
                if (dictionary.ContainsKey(GameObjectStats.Minimalist) || dictionary.ContainsKey(GameObjectStats.GreatestTaoism))
                {
                    int num5;
                    int num6;
                    text += string.Format("\nTaoism{0}-{1}", dictionary.TryGetValue(GameObjectStats.Minimalist, out num5) ? num5 : 0, dictionary.TryGetValue(GameObjectStats.GreatestTaoism, out num6) ? num6 : 0);
                }
                if (dictionary.ContainsKey(GameObjectStats.MinNeedle) || dictionary.ContainsKey(GameObjectStats.MaxNeedle))
                {
                    int num7;
                    int num8;
                    text += string.Format("\nNeedle{0}-{1}", dictionary.TryGetValue(GameObjectStats.MinNeedle, out num7) ? num7 : 0, dictionary.TryGetValue(GameObjectStats.MaxNeedle, out num8) ? num8 : 0);
                }
                if (dictionary.ContainsKey(GameObjectStats.MinBow) || dictionary.ContainsKey(GameObjectStats.MaxBow))
                {
                    int num9;
                    int num10;
                    text += string.Format("\nArchery{0}-{1}", dictionary.TryGetValue(GameObjectStats.MinBow, out num9) ? num9 : 0, dictionary.TryGetValue(GameObjectStats.MaxBow, out num10) ? num10 : 0);
                }
                if (dictionary.ContainsKey(GameObjectStats.MinDef) || dictionary.ContainsKey(GameObjectStats.MaxDef))
                {
                    int num11;
                    int num12;
                    text += string.Format("\nDefence{0}-{1}", dictionary.TryGetValue(GameObjectStats.MinDef, out num11) ? num11 : 0, dictionary.TryGetValue(GameObjectStats.MaxDef, out num12) ? num12 : 0);
                }
                if (dictionary.ContainsKey(GameObjectStats.MinMagicDef) || dictionary.ContainsKey(GameObjectStats.MaxMagicDef))
                {
                    int num13;
                    int num14;
                    text += string.Format("\nMagic Defense{0}-{1}", dictionary.TryGetValue(GameObjectStats.MinMagicDef, out num13) ? num13 : 0, dictionary.TryGetValue(GameObjectStats.MaxMagicDef, out num14) ? num14 : 0);
                }
                if (dictionary.ContainsKey(GameObjectStats.PhysicallyAccurate))
                {
                    int num15;
                    text += string.Format("\nAccuracy{0}", dictionary.TryGetValue(GameObjectStats.PhysicallyAccurate, out num15) ? num15 : 0);
                }
                if (dictionary.ContainsKey(GameObjectStats.PhysicalAgility))
                {
                    int num16;
                    text += string.Format("\nAgility{0}", dictionary.TryGetValue(GameObjectStats.PhysicalAgility, out num16) ? num16 : 0);
                }
                if (dictionary.ContainsKey(GameObjectStats.MaxPhysicalStrength))
                {
                    int num17;
                    text += string.Format("\nStamina{0}", dictionary.TryGetValue(GameObjectStats.MaxPhysicalStrength, out num17) ? num17 : 0);
                }
                if (dictionary.ContainsKey(GameObjectStats.MaxMagic2))
                {
                    int num18;
                    text += string.Format("\nMana{0}", dictionary.TryGetValue(GameObjectStats.MaxMagic2, out num18) ? num18 : 0);
                }
                if (dictionary.ContainsKey(GameObjectStats.MagicDodge))
                {
                    int num19;
                    text += string.Format("\nMagicDodge{0}%", (dictionary.TryGetValue(GameObjectStats.MagicDodge, out num19) ? num19 : 0) / 100);
                }
                if (dictionary.ContainsKey(GameObjectStats.中毒躲避))
                {
                    int num20;
                    text += string.Format("\nPoisoning evasion{0}%", (dictionary.TryGetValue(GameObjectStats.中毒躲避, out num20) ? num20 : 0) / 100);
                }
                if (dictionary.ContainsKey(GameObjectStats.幸运等级))
                {
                    int num21;
                    text += string.Format("\nLuck+{0}", dictionary.TryGetValue(GameObjectStats.幸运等级, out num21) ? num21 : 0);
                }
                return text;
            }
        }


        public InscriptionSkill 第一铭文
        {
            get
            {
                if (当前铭栏.V == 0)
                {
                    return 铭文技能[0];
                }
                return 铭文技能[2];
            }
            set
            {
                if (当前铭栏.V == 0)
                {
                    铭文技能[0] = value;
                    return;
                }
                铭文技能[2] = value;
            }
        }


        public InscriptionSkill 第二铭文
        {
            get
            {
                if (当前铭栏.V == 0)
                {
                    return 铭文技能[1];
                }
                return 铭文技能[3];
            }
            set
            {
                if (当前铭栏.V == 0)
                {
                    铭文技能[1] = value;
                    return;
                }
                铭文技能[3] = value;
            }
        }


        public InscriptionSkill 最优铭文
        {
            get
            {
                if (当前铭栏.V == 0)
                {
                    if (铭文技能[0].Quality < 铭文技能[1].Quality)
                    {
                        return 铭文技能[1];
                    }
                    return 铭文技能[0];
                }
                else
                {
                    if (铭文技能[2].Quality < 铭文技能[3].Quality)
                    {
                        return 铭文技能[3];
                    }
                    return 铭文技能[2];
                }
            }
            set
            {
                if (当前铭栏.V == 0)
                {
                    if (铭文技能[0].Quality >= 铭文技能[1].Quality)
                    {
                        铭文技能[0] = value;
                        return;
                    }
                    铭文技能[1] = value;
                    return;
                }
                else
                {
                    if (铭文技能[2].Quality >= 铭文技能[3].Quality)
                    {
                        铭文技能[2] = value;
                        return;
                    }
                    铭文技能[3] = value;
                    return;
                }
            }
        }


        public InscriptionSkill 最差铭文
        {
            get
            {
                if (当前铭栏.V == 0)
                {
                    if (铭文技能[0].Quality >= 铭文技能[1].Quality)
                    {
                        return 铭文技能[1];
                    }
                    return 铭文技能[0];
                }
                else
                {
                    if (铭文技能[2].Quality >= 铭文技能[3].Quality)
                    {
                        return 铭文技能[3];
                    }
                    return 铭文技能[2];
                }
            }
            set
            {
                if (当前铭栏.V == 0)
                {
                    if (铭文技能[0].Quality < 铭文技能[1].Quality)
                    {
                        铭文技能[0] = value;
                        return;
                    }
                    铭文技能[1] = value;
                    return;
                }
                else
                {
                    if (铭文技能[2].Quality < 铭文技能[3].Quality)
                    {
                        铭文技能[2] = value;
                        return;
                    }
                    铭文技能[3] = value;
                    return;
                }
            }
        }


        public int 双铭文点
        {
            get
            {
                if (当前铭栏.V == 0)
                {
                    return 洗练数一.V;
                }
                return 洗练数二.V;
            }
            set
            {
                if (当前铭栏.V == 0)
                {
                    洗练数一.V = value;
                    return;
                }
                洗练数二.V = value;
            }
        }


        public Dictionary<GameObjectStats, int> 装备Stat
        {
            get
            {
                Dictionary<GameObjectStats, int> dictionary = new Dictionary<GameObjectStats, int>();
                if (装备模板.MinAttack != 0)
                {
                    dictionary[GameObjectStats.MinAttack] = 装备模板.MinAttack;
                }
                if (装备模板.MaxAttack != 0)
                {
                    dictionary[GameObjectStats.MaxAttack] = 装备模板.MaxAttack;
                }
                if (装备模板.MinMagic != 0)
                {
                    dictionary[GameObjectStats.MinMagic] = 装备模板.MinMagic;
                }
                if (装备模板.MaxMagic != 0)
                {
                    dictionary[GameObjectStats.MaxMagic] = 装备模板.MaxMagic;
                }
                if (装备模板.Minimalist != 0)
                {
                    dictionary[GameObjectStats.Minimalist] = 装备模板.Minimalist;
                }
                if (装备模板.GreatestTaoism != 0)
                {
                    dictionary[GameObjectStats.GreatestTaoism] = 装备模板.GreatestTaoism;
                }
                if (装备模板.MinNeedle != 0)
                {
                    dictionary[GameObjectStats.MinNeedle] = 装备模板.MinNeedle;
                }
                if (装备模板.MaxNeedle != 0)
                {
                    dictionary[GameObjectStats.MaxNeedle] = 装备模板.MaxNeedle;
                }
                if (装备模板.MinBow != 0)
                {
                    dictionary[GameObjectStats.MinBow] = 装备模板.MinBow;
                }
                if (装备模板.MaxBow != 0)
                {
                    dictionary[GameObjectStats.MaxBow] = 装备模板.MaxBow;
                }
                if (装备模板.MinDef != 0)
                {
                    dictionary[GameObjectStats.MinDef] = 装备模板.MinDef;
                }
                if (装备模板.MaxDef != 0)
                {
                    dictionary[GameObjectStats.MaxDef] = 装备模板.MaxDef;
                }
                if (装备模板.MinMagicDef != 0)
                {
                    dictionary[GameObjectStats.MinMagicDef] = 装备模板.MinMagicDef;
                }
                if (装备模板.MaxMagicDef != 0)
                {
                    dictionary[GameObjectStats.MaxMagicDef] = 装备模板.MaxMagicDef;
                }
                if (装备模板.MaxPhysicalStrength != 0)
                {
                    dictionary[GameObjectStats.MaxPhysicalStrength] = 装备模板.MaxPhysicalStrength;
                }
                if (装备模板.MaxMagic2 != 0)
                {
                    dictionary[GameObjectStats.MaxMagic2] = 装备模板.MaxMagic2;
                }
                if (装备模板.AttackSpeed != 0)
                {
                    dictionary[GameObjectStats.AttackSpeed] = 装备模板.AttackSpeed;
                }
                if (装备模板.MagicDodge != 0)
                {
                    dictionary[GameObjectStats.MagicDodge] = 装备模板.MagicDodge;
                }
                if (装备模板.PhysicallyAccurate != 0)
                {
                    dictionary[GameObjectStats.PhysicallyAccurate] = 装备模板.PhysicallyAccurate;
                }
                if (装备模板.PhysicalAgility != 0)
                {
                    dictionary[GameObjectStats.PhysicalAgility] = 装备模板.PhysicalAgility;
                }
                if (幸运等级.V != 0)
                {
                    dictionary[GameObjectStats.幸运等级] = (dictionary.ContainsKey(GameObjectStats.幸运等级) ? (dictionary[GameObjectStats.幸运等级] + (int)幸运等级.V) : ((int)幸运等级.V));
                }
                if (升级Attack.V != 0)
                {
                    dictionary[GameObjectStats.MaxAttack] = (dictionary.ContainsKey(GameObjectStats.MaxAttack) ? (dictionary[GameObjectStats.MaxAttack] + (int)升级Attack.V) : ((int)升级Attack.V));
                }
                if (升级Magic.V != 0)
                {
                    dictionary[GameObjectStats.MaxMagic] = (dictionary.ContainsKey(GameObjectStats.MaxMagic) ? (dictionary[GameObjectStats.MaxMagic] + (int)升级Magic.V) : ((int)升级Magic.V));
                }
                if (升级Taoism.V != 0)
                {
                    dictionary[GameObjectStats.GreatestTaoism] = (dictionary.ContainsKey(GameObjectStats.GreatestTaoism) ? (dictionary[GameObjectStats.GreatestTaoism] + (int)升级Taoism.V) : ((int)升级Taoism.V));
                }
                if (升级Needle.V != 0)
                {
                    dictionary[GameObjectStats.MaxNeedle] = (dictionary.ContainsKey(GameObjectStats.MaxNeedle) ? (dictionary[GameObjectStats.MaxNeedle] + (int)升级Needle.V) : ((int)升级Needle.V));
                }
                if (升级Archery.V != 0)
                {
                    dictionary[GameObjectStats.MaxBow] = (dictionary.ContainsKey(GameObjectStats.MaxBow) ? (dictionary[GameObjectStats.MaxBow] + (int)升级Archery.V) : ((int)升级Archery.V));
                }
                foreach (RandomStats 随机Stat in 随机Stat.ToList<RandomStats>())
                {
                    dictionary[随机Stat.Stat] = (dictionary.ContainsKey(随机Stat.Stat) ? (dictionary[随机Stat.Stat] + 随机Stat.Value) : 随机Stat.Value);
                }
                foreach (GameItems GameItems in 镶嵌灵石.Values)
                {
                    int Id = GameItems.Id;
                    if (Id <= 10324)
                    {
                        switch (Id)
                        {
                            case 10110:
                                dictionary[GameObjectStats.GreatestTaoism] = (dictionary.ContainsKey(GameObjectStats.GreatestTaoism) ? (dictionary[GameObjectStats.GreatestTaoism] + 1) : 1);
                                break;
                            case 10111:
                                dictionary[GameObjectStats.GreatestTaoism] = (dictionary.ContainsKey(GameObjectStats.GreatestTaoism) ? (dictionary[GameObjectStats.GreatestTaoism] + 2) : 2);
                                break;
                            case 10112:
                                dictionary[GameObjectStats.GreatestTaoism] = (dictionary.ContainsKey(GameObjectStats.GreatestTaoism) ? (dictionary[GameObjectStats.GreatestTaoism] + 3) : 3);
                                break;
                            case 10113:
                                dictionary[GameObjectStats.GreatestTaoism] = (dictionary.ContainsKey(GameObjectStats.GreatestTaoism) ? (dictionary[GameObjectStats.GreatestTaoism] + 4) : 4);
                                break;
                            case 10114:
                                dictionary[GameObjectStats.GreatestTaoism] = (dictionary.ContainsKey(GameObjectStats.GreatestTaoism) ? (dictionary[GameObjectStats.GreatestTaoism] + 5) : 5);
                                break;
                            case 10115:
                            case 10116:
                            case 10117:
                            case 10118:
                            case 10119:
                                break;
                            case 10120:
                                dictionary[GameObjectStats.MaxPhysicalStrength] = (dictionary.ContainsKey(GameObjectStats.MaxPhysicalStrength) ? (dictionary[GameObjectStats.MaxPhysicalStrength] + 5) : 5);
                                break;
                            case 10121:
                                dictionary[GameObjectStats.MaxPhysicalStrength] = (dictionary.ContainsKey(GameObjectStats.MaxPhysicalStrength) ? (dictionary[GameObjectStats.MaxPhysicalStrength] + 10) : 10);
                                break;
                            case 10122:
                                dictionary[GameObjectStats.MaxPhysicalStrength] = (dictionary.ContainsKey(GameObjectStats.MaxPhysicalStrength) ? (dictionary[GameObjectStats.MaxPhysicalStrength] + 15) : 15);
                                break;
                            case 10123:
                                dictionary[GameObjectStats.MaxPhysicalStrength] = (dictionary.ContainsKey(GameObjectStats.MaxPhysicalStrength) ? (dictionary[GameObjectStats.MaxPhysicalStrength] + 20) : 20);
                                break;
                            case 10124:
                                dictionary[GameObjectStats.MaxPhysicalStrength] = (dictionary.ContainsKey(GameObjectStats.MaxPhysicalStrength) ? (dictionary[GameObjectStats.MaxPhysicalStrength] + 25) : 25);
                                break;
                            default:
                                switch (Id)
                                {
                                    case 10220:
                                        dictionary[GameObjectStats.MaxDef] = (dictionary.ContainsKey(GameObjectStats.MaxDef) ? (dictionary[GameObjectStats.MaxDef] + 1) : 1);
                                        break;
                                    case 10221:
                                        dictionary[GameObjectStats.MaxDef] = (dictionary.ContainsKey(GameObjectStats.MaxDef) ? (dictionary[GameObjectStats.MaxDef] + 2) : 2);
                                        break;
                                    case 10222:
                                        dictionary[GameObjectStats.MaxDef] = (dictionary.ContainsKey(GameObjectStats.MaxDef) ? (dictionary[GameObjectStats.MaxDef] + 3) : 3);
                                        break;
                                    case 10223:
                                        dictionary[GameObjectStats.MaxDef] = (dictionary.ContainsKey(GameObjectStats.MaxDef) ? (dictionary[GameObjectStats.MaxDef] + 4) : 4);
                                        break;
                                    case 10224:
                                        dictionary[GameObjectStats.MaxDef] = (dictionary.ContainsKey(GameObjectStats.MaxDef) ? (dictionary[GameObjectStats.MaxDef] + 5) : 5);
                                        break;
                                    default:
                                        switch (Id)
                                        {
                                            case 10320:
                                                dictionary[GameObjectStats.MaxMagic] = (dictionary.ContainsKey(GameObjectStats.MaxMagic) ? (dictionary[GameObjectStats.MaxMagic] + 1) : 1);
                                                break;
                                            case 10321:
                                                dictionary[GameObjectStats.MaxMagic] = (dictionary.ContainsKey(GameObjectStats.MaxMagic) ? (dictionary[GameObjectStats.MaxMagic] + 2) : 2);
                                                break;
                                            case 10322:
                                                dictionary[GameObjectStats.MaxMagic] = (dictionary.ContainsKey(GameObjectStats.MaxMagic) ? (dictionary[GameObjectStats.MaxMagic] + 3) : 3);
                                                break;
                                            case 10323:
                                                dictionary[GameObjectStats.MaxMagic] = (dictionary.ContainsKey(GameObjectStats.MaxMagic) ? (dictionary[GameObjectStats.MaxMagic] + 4) : 4);
                                                break;
                                            case 10324:
                                                dictionary[GameObjectStats.MaxMagic] = (dictionary.ContainsKey(GameObjectStats.MaxMagic) ? (dictionary[GameObjectStats.MaxMagic] + 5) : 5);
                                                break;
                                        }
                                        break;
                                }
                                break;
                        }
                    }
                    else if (Id <= 10524)
                    {
                        switch (Id)
                        {
                            case 10420:
                                dictionary[GameObjectStats.MaxAttack] = (dictionary.ContainsKey(GameObjectStats.MaxAttack) ? (dictionary[GameObjectStats.MaxAttack] + 1) : 1);
                                break;
                            case 10421:
                                dictionary[GameObjectStats.MaxAttack] = (dictionary.ContainsKey(GameObjectStats.MaxAttack) ? (dictionary[GameObjectStats.MaxAttack] + 2) : 2);
                                break;
                            case 10422:
                                dictionary[GameObjectStats.MaxAttack] = (dictionary.ContainsKey(GameObjectStats.MaxAttack) ? (dictionary[GameObjectStats.MaxAttack] + 3) : 3);
                                break;
                            case 10423:
                                dictionary[GameObjectStats.MaxAttack] = (dictionary.ContainsKey(GameObjectStats.MaxAttack) ? (dictionary[GameObjectStats.MaxAttack] + 4) : 4);
                                break;
                            case 10424:
                                dictionary[GameObjectStats.MaxAttack] = (dictionary.ContainsKey(GameObjectStats.MaxAttack) ? (dictionary[GameObjectStats.MaxAttack] + 5) : 5);
                                break;
                            default:
                                switch (Id)
                                {
                                    case 10520:
                                        dictionary[GameObjectStats.MaxMagicDef] = (dictionary.ContainsKey(GameObjectStats.MaxMagicDef) ? (dictionary[GameObjectStats.MaxMagicDef] + 1) : 1);
                                        break;
                                    case 10521:
                                        dictionary[GameObjectStats.MaxMagicDef] = (dictionary.ContainsKey(GameObjectStats.MaxMagicDef) ? (dictionary[GameObjectStats.MaxMagicDef] + 2) : 2);
                                        break;
                                    case 10522:
                                        dictionary[GameObjectStats.MaxMagicDef] = (dictionary.ContainsKey(GameObjectStats.MaxMagicDef) ? (dictionary[GameObjectStats.MaxMagicDef] + 3) : 3);
                                        break;
                                    case 10523:
                                        dictionary[GameObjectStats.MaxMagicDef] = (dictionary.ContainsKey(GameObjectStats.MaxMagicDef) ? (dictionary[GameObjectStats.MaxMagicDef] + 4) : 4);
                                        break;
                                    case 10524:
                                        dictionary[GameObjectStats.MaxMagicDef] = (dictionary.ContainsKey(GameObjectStats.MaxMagicDef) ? (dictionary[GameObjectStats.MaxMagicDef] + 5) : 5);
                                        break;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (Id)
                        {
                            case 10620:
                                dictionary[GameObjectStats.MaxNeedle] = (dictionary.ContainsKey(GameObjectStats.MaxNeedle) ? (dictionary[GameObjectStats.MaxNeedle] + 1) : 1);
                                break;
                            case 10621:
                                dictionary[GameObjectStats.MaxNeedle] = (dictionary.ContainsKey(GameObjectStats.MaxNeedle) ? (dictionary[GameObjectStats.MaxNeedle] + 2) : 2);
                                break;
                            case 10622:
                                dictionary[GameObjectStats.MaxNeedle] = (dictionary.ContainsKey(GameObjectStats.MaxNeedle) ? (dictionary[GameObjectStats.MaxNeedle] + 3) : 3);
                                break;
                            case 10623:
                                dictionary[GameObjectStats.MaxNeedle] = (dictionary.ContainsKey(GameObjectStats.MaxNeedle) ? (dictionary[GameObjectStats.MaxNeedle] + 4) : 4);
                                break;
                            case 10624:
                                dictionary[GameObjectStats.MaxNeedle] = (dictionary.ContainsKey(GameObjectStats.MaxNeedle) ? (dictionary[GameObjectStats.MaxNeedle] + 5) : 5);
                                break;
                            default:
                                switch (Id)
                                {
                                    case 10720:
                                        dictionary[GameObjectStats.MaxBow] = (dictionary.ContainsKey(GameObjectStats.MaxBow) ? (dictionary[GameObjectStats.MaxBow] + 1) : 1);
                                        break;
                                    case 10721:
                                        dictionary[GameObjectStats.MaxBow] = (dictionary.ContainsKey(GameObjectStats.MaxBow) ? (dictionary[GameObjectStats.MaxBow] + 2) : 2);
                                        break;
                                    case 10722:
                                        dictionary[GameObjectStats.MaxBow] = (dictionary.ContainsKey(GameObjectStats.MaxBow) ? (dictionary[GameObjectStats.MaxBow] + 3) : 3);
                                        break;
                                    case 10723:
                                        dictionary[GameObjectStats.MaxBow] = (dictionary.ContainsKey(GameObjectStats.MaxBow) ? (dictionary[GameObjectStats.MaxBow] + 4) : 4);
                                        break;
                                    case 10724:
                                        dictionary[GameObjectStats.MaxBow] = (dictionary.ContainsKey(GameObjectStats.MaxBow) ? (dictionary[GameObjectStats.MaxBow] + 5) : 5);
                                        break;
                                }
                                break;
                        }
                    }
                }
                return dictionary;
            }
        }

        public EquipmentData() { }

        public EquipmentData(EquipmentItem item, CharacterData character, byte 容器, byte location, bool randomGenerated = false)
        {
            对应模板.V = item;
            生成来源.V = character;
            物品容器.V = 容器;
            物品位置.V = location;
            生成时间.V = MainProcess.CurrentTime;
            物品状态.V = 1;
            最大持久.V = ((item.PersistType == PersistentItemType.装备) ? (item.MaxDura * 1000) : item.MaxDura);
            DataMonitor<int> 当前持久 = this.当前持久;
            int v;
            if (randomGenerated)
            {
                if (item.PersistType == PersistentItemType.装备)
                {
                    v = MainProcess.RandomNumber.Next(0, 最大持久.V);
                    goto IL_B8;
                }
            }
            v = 最大持久.V;
        IL_B8:
            当前持久.V = v;
            if (randomGenerated && item.PersistType == PersistentItemType.装备)
            {
                随机Stat.SetValue(GameServer.Templates.EquipmentStats.GenerateStats(base.物品类型, false));
            }
            GameDataGateway.EquipmentData表.AddData(this, true);
        }

        public int 重铸所需灵气
        {
            get
            {
                switch (base.物品类型)
                {
                    case ItemType.衣服:
                    case ItemType.披风:
                    case ItemType.腰带:
                    case ItemType.鞋子:
                    case ItemType.护肩:
                    case ItemType.护腕:
                    case ItemType.头盔:
                        return 112003;
                    case ItemType.项链:
                    case ItemType.戒指:
                    case ItemType.手镯:
                    case ItemType.勋章:
                    case ItemType.玉佩:
                        return 112002;
                    case ItemType.武器:
                        return 112001;
                    default:
                        return 0;
                }
            }
        }


        public override byte[] 字节描述()
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    binaryWriter.Write(ItemData.数据版本);
                    BinaryWriter binaryWriter2 = binaryWriter;
                    binaryWriter2.Write(生成来源.V?.数据索引.V ?? 0);
                    binaryWriter.Write(ComputingClass.TimeShift(生成时间.V));
                    binaryWriter.Write(对应模板.V.Id);
                    binaryWriter.Write(物品容器.V);
                    binaryWriter.Write(物品位置.V);
                    binaryWriter.Write(当前持久.V);
                    binaryWriter.Write(最大持久.V);
                    binaryWriter.Write((byte)(IsBound ? 10 : 0));

                    int num = 256;
                    num = 0x100 | 当前铭栏.V;

                    if (双铭文栏.V) num |= 0x200;
                    binaryWriter.Write((short)num);

                    int num2 = 0;
                    if (物品状态.V != 1) num2 |= 1;
                    else if (随机Stat.Count != 0) num2 |= 1;
                    else if (Sacred伤害.V != 0) num2 |= 1;

                    if (随机Stat.Count >= 1) num2 |= 2;

                    if (随机Stat.Count >= 2) num2 |= 4;

                    if (随机Stat.Count >= 3) num2 |= 8;

                    if (随机Stat.Count >= 4) num2 |= 0x10;

                    if (幸运等级.V != 0) num2 |= 0x800;

                    if (升级次数.V != 0) num2 |= 0x1000;

                    if (孔洞颜色.Count != 0) num2 |= 0x2000;

                    if (镶嵌灵石[0] != null) num2 |= 0x4000;

                    if (镶嵌灵石[1] != null) num2 |= 0x8000;

                    if (镶嵌灵石[2] != null) num2 |= 0x10000;

                    if (镶嵌灵石[3] != null) num2 |= 0x20000;

                    if (Sacred伤害.V != 0) num2 |= 0x400000;

                    else if (圣石数量.V != 0) num2 |= 0x400000;

                    if (祈祷次数.V != 0) num2 |= 0x800000;

                    if (装备神佑.V) num2 |= 0x2000000;

                    binaryWriter.Write(num2);

                    if (((uint)num2 & (true ? 1u : 0u)) != 0)
                        binaryWriter.Write(物品状态.V);

                    if (((uint)num2 & 2u) != 0)
                        binaryWriter.Write((ushort)随机Stat[0].StatId);

                    if (((uint)num2 & 4u) != 0)
                        binaryWriter.Write((ushort)随机Stat[1].StatId);

                    if (((uint)num2 & 8u) != 0)
                        binaryWriter.Write((ushort)随机Stat[2].StatId);

                    if (((uint)num2 & 0x10u) != 0)
                        binaryWriter.Write((ushort)随机Stat[3].StatId);

                    if (((uint)num & 0x100u) != 0)
                    {
                        int num3 = 0;
                        if (铭文技能[0] != null) num3 |= 1;
                        if (铭文技能[1] != null) num3 |= 2;

                        binaryWriter.Write((short)num3);
                        binaryWriter.Write(洗练数一.V * 10000);

                        if (((uint)num3 & (true ? 1u : 0u)) != 0)
                            binaryWriter.Write(铭文技能[0].Index);

                        if (((uint)num3 & 2u) != 0)
                            binaryWriter.Write(铭文技能[1].Index);
                    }
                    if (((uint)num & 0x200u) != 0)
                    {
                        int num4 = 0;
                        if (铭文技能[2] != null) num4 |= 1;
                        if (铭文技能[3] != null) num4 |= 2;
                        binaryWriter.Write((short)num4);
                        binaryWriter.Write(洗练数二.V * 10000);
                        
                        if (((uint)num4 & (true ? 1u : 0u)) != 0)
                            binaryWriter.Write(铭文技能[2].Index);

                        if (((uint)num4 & 2u) != 0)
                            binaryWriter.Write(铭文技能[3].Index);
                    }

                    if (((uint)num2 & 0x800u) != 0)
                        binaryWriter.Write(幸运等级.V);

                    if (((uint)num2 & 0x1000u) != 0)
                    {
                        binaryWriter.Write(升级次数.V);
                        binaryWriter.Write((byte)0);
                        binaryWriter.Write(升级Attack.V);
                        binaryWriter.Write(升级Magic.V);
                        binaryWriter.Write(升级Taoism.V);
                        binaryWriter.Write(升级Needle.V);
                        binaryWriter.Write(升级Archery.V);
                        binaryWriter.Write(new byte[3]);
                        binaryWriter.Write(灵魂绑定.V);
                    }

                    if (((uint)num2 & 0x2000u) != 0)
                    {
                        binaryWriter.Write(new byte[4]
                        {
                            (byte)孔洞颜色[0],
                            (byte)孔洞颜色[1],
                            (byte)孔洞颜色[2],
                            (byte)孔洞颜色[3]
                        });
                    }

                    if (((uint)num2 & 0x4000u) != 0)
                        binaryWriter.Write(镶嵌灵石[0].Id);

                    if (((uint)num2 & 0x8000u) != 0)
                        binaryWriter.Write(镶嵌灵石[1].Id);

                    if (((uint)num2 & 0x10000u) != 0)
                        binaryWriter.Write(镶嵌灵石[2].Id);

                    if (((uint)num2 & 0x20000u) != 0)
                        binaryWriter.Write(镶嵌灵石[3].Id);

                    if (((uint)num2 & 0x80000u) != 0)
                        binaryWriter.Write(0);

                    if (((uint)num2 & 0x100000u) != 0)
                        binaryWriter.Write(0);

                    if (((uint)num2 & 0x200000u) != 0)
                        binaryWriter.Write(0);

                    if (((uint)num2 & 0x400000u) != 0)
                    {
                        binaryWriter.Write(Sacred伤害.V);
                        binaryWriter.Write(圣石数量.V);
                    }

                    if (((uint)num2 & 0x800000u) != 0)
                        binaryWriter.Write((int)祈祷次数.V);

                    if (((uint)num2 & 0x2000000u) != 0)
                        binaryWriter.Write(装备神佑.V);

                    if (((uint)num2 & 0x4000000u) != 0)
                        binaryWriter.Write(0);

                    result = memoryStream.ToArray();
                }
            }
            return result;
        }


        public readonly DataMonitor<byte> 升级次数;


        public readonly DataMonitor<byte> 升级Attack;


        public readonly DataMonitor<byte> 升级Magic;


        public readonly DataMonitor<byte> 升级Taoism;


        public readonly DataMonitor<byte> 升级Needle;


        public readonly DataMonitor<byte> 升级Archery;


        public readonly DataMonitor<bool> 灵魂绑定;


        public readonly DataMonitor<byte> 祈祷次数;


        public readonly DataMonitor<sbyte> 幸运等级;


        public readonly DataMonitor<bool> 装备神佑;


        public readonly DataMonitor<byte> Sacred伤害;


        public readonly DataMonitor<ushort> 圣石数量;


        public readonly DataMonitor<bool> 双铭文栏;


        public readonly DataMonitor<byte> 当前铭栏;


        public readonly DataMonitor<int> 洗练数一;


        public readonly DataMonitor<int> 洗练数二;


        public readonly DataMonitor<byte> 物品状态;


        public readonly ListMonitor<RandomStats> 随机Stat;


        public readonly ListMonitor<EquipHoleColor> 孔洞颜色;


        public readonly MonitorDictionary<byte, InscriptionSkill> 铭文技能;


        public readonly MonitorDictionary<byte, GameItems> 镶嵌灵石;
    }
}
