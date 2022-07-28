using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameServer.Maps;
using GameServer.Data;
using GameServer.Networking;

namespace GameServer.Templates
{
    public class SkillInstance
    {
        // (get) Token: 0x060006B0 RID: 1712 RVA: 0x00005F0E File Offset: 0x0000410E
        public int 来源编号
        {
            get
            {
                return this.CasterObject.MapId;
            }
        }


        // (get) Token: 0x060006B1 RID: 1713 RVA: 0x00005F1B File Offset: 0x0000411B
        public byte GroupId
        {
            get
            {
                return this.技能模板.GroupId;
            }
        }


        // (get) Token: 0x060006B2 RID: 1714 RVA: 0x00005F28 File Offset: 0x00004128
        public byte Id
        {
            get
            {
                return this.技能模板.Id;
            }
        }


        // (get) Token: 0x060006B3 RID: 1715 RVA: 0x00005F35 File Offset: 0x00004135
        public ushort SkillId
        {
            get
            {
                return this.技能模板.OwnSkillId;
            }
        }


        // (get) Token: 0x060006B4 RID: 1716 RVA: 0x00031360 File Offset: 0x0002F560
        public byte 技能等级
        {
            get
            {
                if (this.技能模板.BindingLevelId == 0)
                {
                    return 0;
                }
                PlayerObject PlayerObject = this.CasterObject as PlayerObject;
                SkillData SkillData;
                if (PlayerObject != null && PlayerObject.MainSkills表.TryGetValue(this.技能模板.BindingLevelId, out SkillData))
                {
                    return SkillData.技能等级.V;
                }
                TrapObject TrapObject = this.CasterObject as TrapObject;
                if (TrapObject != null)
                {
                    PlayerObject PlayerObject2 = TrapObject.陷阱来源 as PlayerObject;
                    SkillData SkillData2;
                    if (PlayerObject2 != null && PlayerObject2.MainSkills表.TryGetValue(this.技能模板.BindingLevelId, out SkillData2))
                    {
                        return SkillData2.技能等级.V;
                    }
                }
                return 0;
            }
        }


        // (get) Token: 0x060006B5 RID: 1717 RVA: 0x00005F42 File Offset: 0x00004142
        public bool 检查计数
        {
            get
            {
                return this.技能模板.CheckSkillCount;
            }
        }


        public SkillInstance(MapObject 技能来源, GameSkills 技能模板, SkillData SkillData, byte 动作编号, MapInstance 释放地图, Point 释放位置, MapObject 技能目标, Point 技能锚点, SkillInstance 父类技能, Dictionary<int, HitDetail> 命中列表 = null, bool 目标借位 = false)
        {
            this.CasterObject = 技能来源;
            this.技能模板 = 技能模板;
            this.SkillData = SkillData;
            this.动作编号 = 动作编号;
            this.释放地图 = 释放地图;
            this.释放位置 = 释放位置;
            this.技能目标 = 技能目标;
            this.技能锚点 = 技能锚点;
            this.父类技能 = 父类技能;
            this.释放时间 = MainProcess.CurrentTime;
            this.目标借位 = 目标借位;
            this.Hits = (命中列表 ?? new Dictionary<int, HitDetail>());
            this.Nodes = new SortedDictionary<int, SkillTask>(技能模板.Nodes);
            if (this.Nodes.Count != 0)
            {
                this.CasterObject.技能任务.Add(this);
                this.AppointmentTime = this.释放时间.AddMilliseconds((double)(this.飞行耗时 + this.Nodes.First<KeyValuePair<int, SkillTask>>().Key));
            }
        }


        public void Process()
        {
            if ((AppointmentTime - ProcessingTime).TotalMilliseconds > 5.0 && MainProcess.CurrentTime < AppointmentTime)
                return;

            var keyValuePair = this.Nodes.First();
            Nodes.Remove(keyValuePair.Key);

            SkillTask task = keyValuePair.Value;
            ProcessingTime = this.AppointmentTime;

            if (task != null)
            {
                if (task is A_00_触发SubSkills a_00_触发SubSkills)
                {
                    if (GameSkills.DataSheet.TryGetValue(a_00_触发SubSkills.触发SkillName, out GameSkills 游戏技能))
                    {

                        bool flag = true;

                        if (a_00_触发SubSkills.CalculateTriggerProbability)
                        {
                            flag = !a_00_触发SubSkills.CalculateLuckyProbability
                                ? ComputingClass.计算概率(a_00_触发SubSkills.技能触发概率 + ((a_00_触发SubSkills.增加概率Buff == 0 || !CasterObject.Buff列表.ContainsKey(a_00_触发SubSkills.增加概率Buff)) ? 0f : a_00_触发SubSkills.Buff增加系数))
                                : ComputingClass.计算概率(ComputingClass.计算幸运(CasterObject[GameObjectStats.幸运等级]));
                        }

                        if (flag && a_00_触发SubSkills.验证ItSelfBuff)
                        {
                            if (!CasterObject.Buff列表.ContainsKey(a_00_触发SubSkills.Id))
                                flag = false;
                            else if (a_00_触发SubSkills.触发成功移除)
                                CasterObject.移除Buff时处理(a_00_触发SubSkills.Id);
                        }

                        if (flag && a_00_触发SubSkills.验证铭文技能 && CasterObject is PlayerObject playerObj)
                        {
                            int num = a_00_触发SubSkills.所需Id / 10;
                            int num2 = a_00_触发SubSkills.所需Id % 10;
                            flag = playerObj.MainSkills表.TryGetValue((ushort)num, out var v)
                                && ((!a_00_触发SubSkills.同组铭文无效) ? (num2 == 0 || num2 == v.Id) : (num2 == v.Id));
                        }

                        if (flag)
                        {
                            switch (a_00_触发SubSkills.技能触发方式)
                            {
                                case 技能触发方式.原点位置绝对触发:
                                    new SkillInstance(CasterObject, 游戏技能, SkillData, 动作编号, 释放地图, 释放位置, 技能目标, 释放位置, this);
                                    break;
                                case 技能触发方式.锚点位置绝对触发:
                                    new SkillInstance(CasterObject, 游戏技能, SkillData, 动作编号, 释放地图, 释放位置, 技能目标, 技能锚点, this);
                                    break;
                                case 技能触发方式.刺杀位置绝对触发:
                                    new SkillInstance(CasterObject, 游戏技能, SkillData, 动作编号, 释放地图, 释放位置, 技能目标, ComputingClass.前方坐标(释放位置, 技能锚点, 2), this);
                                    break;
                                case 技能触发方式.目标命中绝对触发:
                                    foreach (var item in Hits)
                                        if ((item.Value.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常)
                                            _ = new SkillInstance(CasterObject, 游戏技能, SkillData, 动作编号, 释放地图, (父类技能 == null) ? 释放位置 : 技能锚点, item.Value.Object, item.Value.Object.CurrentCoords, this);
                                    break;
                                case 技能触发方式.怪物死亡绝对触发:
                                    foreach (var item in Hits)
                                        if (item.Value.Object is MonsterObject && (item.Value.Feedback & SkillHitFeedback.死亡) != 0)
                                            _ = new SkillInstance(CasterObject, 游戏技能, SkillData, 动作编号, 释放地图, 释放位置, null, item.Value.Object.CurrentCoords, this);
                                    break;
                                case 技能触发方式.怪物死亡换位触发:
                                    foreach (var item in Hits)
                                        if (item.Value.Object is MonsterObject && (item.Value.Feedback & SkillHitFeedback.死亡) != 0)
                                            _ = new SkillInstance(CasterObject, 游戏技能, null, item.Value.Object.动作编号++, 释放地图, item.Value.Object.CurrentCoords, item.Value.Object, item.Value.Object.CurrentCoords, this, 目标借位: true);
                                    break;
                                case 技能触发方式.怪物命中绝对触发:
                                    foreach (var item in Hits)
                                        if (item.Value.Object is MonsterObject && (item.Value.Feedback & SkillHitFeedback.死亡) != 0)
                                            _ = new SkillInstance(CasterObject, 游戏技能, SkillData, 动作编号, 释放地图, 释放位置, null, 技能锚点, this);
                                    break;
                                case 技能触发方式.无目标锚点位触发:
                                    if (Hits.Count == 0 || Hits.Values.FirstOrDefault((HitDetail O) => O.Feedback != SkillHitFeedback.丢失) == null)
                                        _ = new SkillInstance(CasterObject, 游戏技能, SkillData, 动作编号, 释放地图, 释放位置, null, 技能锚点, this);
                                    break;
                                case 技能触发方式.目标位置绝对触发:
                                    foreach (var item in Hits)
                                        _ = new SkillInstance(CasterObject, 游戏技能, SkillData, 动作编号, 释放地图, 释放位置, item.Value.Object, item.Value.Object.CurrentCoords, this);
                                    break;
                                case 技能触发方式.正手反手随机触发:
                                    if (ComputingClass.计算概率(0.5f) && GameSkills.DataSheet.TryGetValue(a_00_触发SubSkills.反手SkillName, out var value3))
                                        _ = new SkillInstance(CasterObject, value3, SkillData, 动作编号, 释放地图, 释放位置, null, 技能锚点, this);
                                    else
                                        _ = new SkillInstance(CasterObject, 游戏技能, SkillData, 动作编号, 释放地图, 释放位置, null, 技能锚点, this);
                                    break;
                                case 技能触发方式.目标死亡绝对触发:
                                    foreach (var item in Hits)
                                        if ((item.Value.Feedback & SkillHitFeedback.死亡) != 0)
                                            new SkillInstance(CasterObject, 游戏技能, SkillData, 动作编号, 释放地图, 释放位置, null, item.Value.Object.CurrentCoords, this);
                                    break;
                                case 技能触发方式.目标闪避绝对触发:
                                    foreach (var item in Hits)
                                        if ((item.Value.Feedback & SkillHitFeedback.Miss) != 0)
                                            new SkillInstance(CasterObject, 游戏技能, SkillData, 动作编号, 释放地图, 释放位置, null, item.Value.Object.CurrentCoords, this);
                                    break;
                            }
                        }
                    }
                }
                else if (task is A_01_触发对象Buff 触发Buff)
                {
                    bool flag2 = false;
                    if (触发Buff.角色ItSelf添加)
                    {
                        bool flag3 = true;
                        if (!ComputingClass.计算概率(触发Buff.Buff触发概率))
                            flag3 = false;

                        if (flag3 && 触发Buff.验证铭文技能 && CasterObject is PlayerObject PlayerObject2)
                        {
                            int num3 = (int)(触发Buff.所需Id / 10);
                            int num4 = (int)(触发Buff.所需Id % 10);
                            flag3 = PlayerObject2.MainSkills表.TryGetValue((ushort)num3, out SkillData skill) && 触发Buff.同组铭文无效
                                ? num4 == (int)skill.Id
                                : num4 == 0 || num4 == (int)skill.Id;
                        }
                        if (flag3 && 触发Buff.验证ItSelfBuff)
                        {
                            if (!CasterObject.Buff列表.ContainsKey(触发Buff.Id))
                                flag3 = false;
                            else
                            {
                                if (触发Buff.触发成功移除)
                                    CasterObject.移除Buff时处理(触发Buff.Id);
                                if (触发Buff.移除伴生Buff)
                                    this.CasterObject.移除Buff时处理(触发Buff.移除伴生编号);
                            }
                        }

                        if (flag3 && 触发Buff.验证分组Buff && this.CasterObject.Buff列表.Values.FirstOrDefault((BuffData O) => O.Buff分组 == 触发Buff.BuffGroupId) == null)
                            flag3 = false;

                        if (flag3 && 触发Buff.VerifyTargetBuff && this.Hits.Values.FirstOrDefault((HitDetail O) => (O.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (O.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常 && O.Object.Buff列表.TryGetValue(触发Buff.目标Id, out BuffData BuffData2) && BuffData2.当前层数.V >= 触发Buff.所需Buff层数) == null)
                            flag3 = false;

                        if (flag3 && 触发Buff.VerifyTargetType && this.Hits.Values.FirstOrDefault((HitDetail O) => (O.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (O.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常 && O.Object.IsSpecificType(this.CasterObject, 触发Buff.所需目标类型)) == null)
                            flag3 = false;

                        if (flag3)
                        {
                            CasterObject.添加Buff时处理(触发Buff.触发Id, this.CasterObject);
                            if (触发Buff.伴生Id > 0)
                                CasterObject.添加Buff时处理(触发Buff.伴生Id, this.CasterObject);
                            flag2 = true;
                        }
                    }
                    else
                    {
                        bool flag4 = true;
                        if (触发Buff.验证ItSelfBuff)
                        {
                            if (!CasterObject.Buff列表.ContainsKey(触发Buff.Id))
                                flag4 = false;
                            else
                            {
                                if (触发Buff.触发成功移除)
                                    CasterObject.移除Buff时处理(触发Buff.Id);
                                if (触发Buff.移除伴生Buff)
                                    CasterObject.移除Buff时处理(触发Buff.移除伴生编号);
                            }
                        }

                        if (flag4 && 触发Buff.验证分组Buff && this.CasterObject.Buff列表.Values.FirstOrDefault((BuffData O) => O.Buff分组 == 触发Buff.BuffGroupId) == null)
                            flag4 = false;

                        if (flag4 && 触发Buff.验证铭文技能 && CasterObject is PlayerObject PlayerObject3)
                        {
                            int num5 = 触发Buff.所需Id / 10;
                            int num6 = 触发Buff.所需Id % 10;

                            flag4 = PlayerObject3.MainSkills表.TryGetValue((ushort)num5, out SkillData SkillData4) && 触发Buff.同组铭文无效
                                ? (num6 == (int)SkillData4.Id)
                                : (num6 == 0 || num6 == (int)SkillData4.Id);
                        }

                        if (flag4)
                        {
                            foreach (var item in this.Hits)
                            {
                                bool flag5 = true;

                                if ((item.Value.Feedback & (SkillHitFeedback.Miss | SkillHitFeedback.丢失)) != SkillHitFeedback.正常)
                                    flag5 = false;

                                if (flag5 && !ComputingClass.计算概率(触发Buff.Buff触发概率))
                                    flag5 = false;

                                if (flag5 && 触发Buff.VerifyTargetType && !item.Value.Object.IsSpecificType(CasterObject, 触发Buff.所需目标类型))
                                    flag5 = false;

                                if (flag5 && 触发Buff.VerifyTargetBuff)
                                    flag5 = (item.Value.Object.Buff列表.TryGetValue(触发Buff.目标Id, out BuffData buffData) && buffData.当前层数.V >= 触发Buff.所需Buff层数);

                                if (flag5)
                                {
                                    item.Value.Object.添加Buff时处理(触发Buff.触发Id, CasterObject);
                                    if (触发Buff.伴生Id > 0) item.Value.Object.添加Buff时处理(触发Buff.伴生Id, CasterObject);
                                    flag2 = true;
                                }
                            }
                        }
                    }

                    if (flag2 && 触发Buff.增加技能经验 && CasterObject is PlayerObject playerObj)
                        playerObj.SkillGainExp(触发Buff.经验SkillId);
                }
                else if (task is A_02_TriggerTrapSkills a_02_TriggerTrapSkills)
                {
                    if (SkillTraps.DataSheet.TryGetValue(a_02_TriggerTrapSkills.TriggerTrapSkills, out SkillTraps 陷阱模板))
                    {
                        int num7 = 0;
                        var array = ComputingClass.技能范围(技能锚点, ComputingClass.计算方向(释放位置, 技能锚点), a_02_TriggerTrapSkills.NumberTrapsTriggered);
                        foreach (var coord in array)
                        {
                            if (!释放地图.地形阻塞(coord) && (陷阱模板.AllowStacking || !释放地图[coord].Any(o => o is TrapObject trapObj && trapObj.陷阱GroupId != 0 && trapObj.陷阱GroupId == 陷阱模板.GroupId)))
                            {
                                CasterObject.陷阱列表.Add(new TrapObject(CasterObject, 陷阱模板, 释放地图, coord));
                                num7++;
                            }
                        }

                        if (num7 != 0 && a_02_TriggerTrapSkills.经验SkillId != 0 && CasterObject is PlayerObject playerObj)
                            playerObj.SkillGainExp(a_02_TriggerTrapSkills.经验SkillId);
                    }
                }
                else if (task is B_00_技能切换通知 b_00_技能切换通知)
                {
                    if (CasterObject.Buff列表.ContainsKey(b_00_技能切换通知.SkillTagId))
                    {
                        if (b_00_技能切换通知.允许移除标记)
                            CasterObject.移除Buff时处理(b_00_技能切换通知.SkillTagId);
                    }
                    else if (GameBuffs.DataSheet.ContainsKey(b_00_技能切换通知.SkillTagId))
                        this.CasterObject.添加Buff时处理(b_00_技能切换通知.SkillTagId, this.CasterObject);
                }
                else if (task is B_01_技能释放通知 b_01_技能释放通知)
                {
                    if (b_01_技能释放通知.调整角色朝向)
                    {
                        var dir = ComputingClass.计算方向(释放位置, 技能锚点);
                        if (dir == CasterObject.当前方向)
                            CasterObject.发送封包(new ObjectRotationDirectionPacket
                            {
                                对象编号 = this.CasterObject.MapId,
                                对象朝向 = (ushort)dir,
                                转向耗时 = ((ushort)((this.CasterObject is PlayerObject) ? 0 : 1))
                            });
                        else
                            CasterObject.当前方向 = ComputingClass.计算方向(this.释放位置, this.技能锚点);
                    }

                    if (b_01_技能释放通知.移除技能标记 && 技能模板.SkillTagId != 0)
                        CasterObject.移除Buff时处理(技能模板.SkillTagId);

                    if (b_01_技能释放通知.ItSelfCooldown != 0 || b_01_技能释放通知.Buff增加冷却)
                    {
                        if (检查计数 && CasterObject is PlayerObject playerObj)
                        {
                            if ((SkillData.剩余次数.V -= 1) <= 0)
                                CasterObject.Coolings[SkillId | 16777216] = 释放时间.AddMilliseconds((SkillData.计数时间 - MainProcess.CurrentTime).TotalMilliseconds);

                            playerObj.ActiveConnection.发送封包(new SyncSkillCountPacket
                            {
                                SkillId = SkillData.SkillId.V,
                                SkillCount = SkillData.剩余次数.V,
                                技能冷却 = (int)(SkillData.计数时间 - MainProcess.CurrentTime).TotalMilliseconds
                            });
                        }
                        if (b_01_技能释放通知.ItSelfCooldown > 0 || b_01_技能释放通知.Buff增加冷却)
                        {
                            var num8 = b_01_技能释放通知.ItSelfCooldown;

                            if (b_01_技能释放通知.Buff增加冷却 && CasterObject.Buff列表.ContainsKey(b_01_技能释放通知.增加冷却Buff))
                                num8 += b_01_技能释放通知.冷却增加时间;

                            var dateTime = 释放时间.AddMilliseconds(num8);

                            var dateTime2 = CasterObject.Coolings.ContainsKey(SkillId | 0x1000000)
                                ? CasterObject.Coolings[SkillId | 0x1000000]
                                : default(DateTime);

                            if (num8 > 0 && dateTime > dateTime2)
                            {
                                this.CasterObject.Coolings[SkillId | 0x1000000] = dateTime;
                                this.CasterObject.发送封包(new AddedSkillCooldownPacket
                                {
                                    冷却编号 = ((int)this.SkillId | 0x1000000),
                                    Cooldown = num8
                                });
                            }
                        }
                    }

                    if (CasterObject is PlayerObject playerObj2 && b_01_技能释放通知.分组Cooldown != 0 && GroupId != 0)
                    {
                        DateTime dateTime2 = this.释放时间.AddMilliseconds((double)b_01_技能释放通知.分组Cooldown);
                        DateTime t2 = playerObj2.Coolings.ContainsKey((int)(this.GroupId | 0)) ? playerObj2.Coolings[(int)(this.GroupId | 0)] : default(DateTime);
                        if (dateTime2 > t2) playerObj2.Coolings[(int)(GroupId | 0)] = dateTime2;
                        CasterObject.发送封包(new AddedSkillCooldownPacket
                        {
                            冷却编号 = (int)(GroupId | 0),
                            Cooldown = b_01_技能释放通知.分组Cooldown
                        });
                    }

                    if (b_01_技能释放通知.角色忙绿时间 != 0)
                        CasterObject.忙碌时间 = 释放时间.AddMilliseconds((double)b_01_技能释放通知.角色忙绿时间);

                    if (b_01_技能释放通知.发送释放通知)
                        CasterObject.发送封包(new 开始释放技能
                        {
                            对象编号 = !目标借位 || 技能目标 == null ? CasterObject.MapId : 技能目标.MapId,
                            SkillId = SkillId,
                            技能等级 = 技能等级,
                            技能铭文 = Id,
                            锚点坐标 = 技能锚点,
                            动作编号 = 动作编号,
                            目标编号 = 技能目标?.MapId ?? 0,
                            锚点高度 = 释放地图.地形高度(this.技能锚点)
                        });
                }
                else if (task is B_02_技能命中通知 b_02_技能命中通知)
                {
                    if (b_02_技能命中通知.命中扩展通知)
                        CasterObject.发送封包(new 触发技能扩展
                        {
                            对象编号 = ((!目标借位 || 技能目标 == null) ? CasterObject.MapId : 技能目标.MapId),
                            SkillId = SkillId,
                            技能等级 = 技能等级,
                            技能铭文 = Id,
                            动作编号 = 动作编号,
                            命中描述 = HitDetail.GetHitDescription(this.Hits, this.飞行耗时)
                        });
                    else
                        CasterObject.发送封包(new SkillHitNormal
                        {
                            ObjectId = ((!目标借位 || 技能目标 == null) ? CasterObject.MapId : 技能目标.MapId),
                            SkillId = SkillId,
                            SkillLevel = 技能等级,
                            SkillInscription = Id,
                            ActionId = 动作编号,
                            HitDescription = HitDetail.GetHitDescription(Hits, 飞行耗时)
                        });

                    if (b_02_技能命中通知.计算飞行耗时)
                        飞行耗时 = ComputingClass.GridDistance(释放位置, 技能锚点) * b_02_技能命中通知.单格飞行耗时;
                }
                else if (task is B_03_前摇结束通知 b_03_前摇结束通知)
                {
                    if (b_03_前摇结束通知.计算攻速缩减)
                    {
                        攻速缩减 = ComputingClass.ValueLimit(ComputingClass.CalcAttackSpeed(-5), 攻速缩减 + ComputingClass.CalcAttackSpeed(CasterObject[GameObjectStats.AttackSpeed]), ComputingClass.CalcAttackSpeed(5));

                        if (攻速缩减 != 0)
                        {
                            foreach (var item in Nodes)
                            {
                                if (item.Value is B_04_后摇结束通知)
                                {
                                    int num9 = item.Key - 攻速缩减;
                                    while (Nodes.ContainsKey(num9)) num9++;
                                    Nodes.Remove(item.Key);
                                    Nodes.Add(num9, item.Value);
                                    break;
                                }
                            }
                        }
                    }

                    if (b_03_前摇结束通知.禁止行走时间 != 0)
                        CasterObject.行走时间 = 释放时间.AddMilliseconds(b_03_前摇结束通知.禁止行走时间);

                    if (b_03_前摇结束通知.禁止奔跑时间 != 0)
                        CasterObject.奔跑时间 = 释放时间.AddMilliseconds(b_03_前摇结束通知.禁止奔跑时间);

                    if (b_03_前摇结束通知.角色硬直时间 != 0)
                        CasterObject.硬直时间 = 释放时间.AddMilliseconds((b_03_前摇结束通知.计算攻速缩减 ? (b_03_前摇结束通知.角色硬直时间 - this.攻速缩减) : b_03_前摇结束通知.角色硬直时间));

                    if (b_03_前摇结束通知.发送结束通知)
                        CasterObject.发送封包(new SkillHitNormal
                        {
                            ObjectId = ((!目标借位 || 技能目标 == null) ? CasterObject.MapId : 技能目标.MapId),
                            SkillId = SkillId,
                            SkillLevel = 技能等级,
                            SkillInscription = Id,
                            ActionId = 动作编号
                        });

                    if (b_03_前摇结束通知.解除技能陷阱 && CasterObject is TrapObject trapObj)
                        trapObj.陷阱消失处理();
                }
                else if (task is B_04_后摇结束通知 b_04_后摇结束通知)
                {
                    CasterObject.发送封包(new 技能释放完成
                    {
                        SkillId = SkillId,
                        动作编号 = 动作编号
                    });

                    if (b_04_后摇结束通知.后摇结束死亡)
                        CasterObject.ItSelf死亡处理(null, 技能击杀: false);
                }
                else if (task is C_00_计算技能锚点 c_00_计算技能锚点)
                {
                    if (c_00_计算技能锚点.计算当前位置)
                    {
                        技能目标 = null;
                        if (c_00_计算技能锚点.计算当前方向)
                            技能锚点 = ComputingClass.前方坐标(CasterObject.CurrentCoords, CasterObject.当前方向, c_00_计算技能锚点.技能最近距离);
                        else
                            技能锚点 = ComputingClass.前方坐标(CasterObject.CurrentCoords, 技能锚点, c_00_计算技能锚点.技能最近距离);
                    }
                    else if (ComputingClass.GridDistance(释放位置, 技能锚点) > c_00_计算技能锚点.MaxDistance)
                    {
                        技能目标 = null;
                        技能锚点 = ComputingClass.前方坐标(释放位置, 技能锚点, c_00_计算技能锚点.MaxDistance);
                    }
                    else if (ComputingClass.GridDistance(释放位置, 技能锚点) < c_00_计算技能锚点.技能最近距离)
                    {
                        this.技能目标 = null;

                        if (释放位置 == 技能锚点)
                            技能锚点 = ComputingClass.前方坐标(释放位置, CasterObject.当前方向, c_00_计算技能锚点.技能最近距离);
                        else
                            技能锚点 = ComputingClass.前方坐标(释放位置, 技能锚点, c_00_计算技能锚点.技能最近距离);
                    }
                }
                else if (task is C_01_CalculateHitTarget c_01_calculateHitTarget)
                {
                    if (c_01_calculateHitTarget.清空命中列表)
                        Hits = new Dictionary<int, HitDetail>();

                    if (c_01_calculateHitTarget.技能能否穿墙 || !释放地图.地形遮挡(释放位置, 技能锚点))
                    {
                        switch (c_01_calculateHitTarget.技能锁定方式)
                        {
                            case 技能锁定类型.锁定ItSelf:
                                CasterObject.ProcessSkillHit(this, c_01_calculateHitTarget);
                                break;
                            case 技能锁定类型.锁定目标:
                                技能目标?.ProcessSkillHit(this, c_01_calculateHitTarget);
                                break;
                            case 技能锁定类型.锁定ItSelf坐标:
                                foreach (var 坐标2 in ComputingClass.技能范围(CasterObject.CurrentCoords, ComputingClass.计算方向(释放位置, 技能锚点), c_01_calculateHitTarget.技能范围类型))
                                    foreach (var mapObj in 释放地图[坐标2])
                                        mapObj.ProcessSkillHit(this, c_01_calculateHitTarget);
                                break;
                            case 技能锁定类型.锁定目标坐标:
                                {
                                    var array = ComputingClass.技能范围((技能目标 != null) ? 技能目标.CurrentCoords : 技能锚点, ComputingClass.计算方向(释放位置, 技能锚点), c_01_calculateHitTarget.技能范围类型);

                                    foreach (var 坐标3 in array)
                                        foreach (MapObject mapObj in 释放地图[坐标3])
                                            mapObj.ProcessSkillHit(this, c_01_calculateHitTarget);

                                    break;
                                }
                            case 技能锁定类型.锁定锚点坐标:
                                var array2 = ComputingClass.技能范围(技能锚点, ComputingClass.计算方向(释放位置, 技能锚点), c_01_calculateHitTarget.技能范围类型);

                                foreach (var 坐标4 in array2)
                                    foreach (MapObject mapObj in 释放地图[坐标4])
                                        mapObj.ProcessSkillHit(this, c_01_calculateHitTarget);

                                break;
                            case 技能锁定类型.放空锁定ItSelf:
                                var array3 = ComputingClass.技能范围(技能锚点, ComputingClass.计算方向(释放位置, 技能锚点), c_01_calculateHitTarget.技能范围类型);

                                foreach (Point 坐标5 in array3)
                                    foreach (MapObject mapObj in 释放地图[坐标5])
                                        mapObj.ProcessSkillHit(this, c_01_calculateHitTarget);

                                if (Hits.Count == 0) CasterObject.ProcessSkillHit(this, c_01_calculateHitTarget);

                                break;
                        }
                    }

                    if (Hits.Count == 0 && c_01_calculateHitTarget.放空结束技能)
                    {
                        if (c_01_calculateHitTarget.发送中断通知)
                            CasterObject.发送封包(new 技能释放中断
                            {
                                对象编号 = CasterObject.MapId,
                                SkillId = SkillId,
                                技能等级 = 技能等级,
                                技能铭文 = Id,
                                动作编号 = 动作编号,
                                技能分段 = 分段编号
                            });

                        CasterObject.技能任务.Remove(this);
                        return;
                    }

                    if (c_01_calculateHitTarget.补发释放通知)
                        CasterObject.发送封包(new 开始释放技能
                        {
                            对象编号 = ((!目标借位 || 技能目标 == null) ? CasterObject.MapId : 技能目标.MapId),
                            SkillId = SkillId,
                            技能等级 = 技能等级,
                            技能铭文 = Id,
                            目标编号 = 技能目标?.MapId ?? 0,
                            锚点坐标 = 技能锚点,
                            锚点高度 = 释放地图.地形高度(this.技能锚点),
                            动作编号 = 动作编号
                        });

                    if (Hits.Count != 0 && c_01_calculateHitTarget.攻速提升类型 != SpecifyTargetType.None && Hits[0].Object.IsSpecificType(CasterObject, c_01_calculateHitTarget.攻速提升类型))
                        攻速缩减 = ComputingClass.ValueLimit(ComputingClass.CalcAttackSpeed(-5), 攻速缩减 + ComputingClass.CalcAttackSpeed(c_01_calculateHitTarget.攻速提升幅度), ComputingClass.CalcAttackSpeed(5));

                    if (c_01_calculateHitTarget.清除目标状态 && c_01_calculateHitTarget.清除状态列表.Count != 0)
                        foreach (var item in Hits)
                            if ((item.Value.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常)
                                foreach (ushort 编号 in c_01_calculateHitTarget.清除状态列表.ToList())
                                    item.Value.Object.移除Buff时处理(编号);

                    if (c_01_calculateHitTarget.触发PassiveSkill && Hits.Count != 0 && ComputingClass.计算概率(c_01_calculateHitTarget.触发被动概率))
                        CasterObject[GameObjectStats.SkillSign] = 1;

                    if (c_01_calculateHitTarget.增加技能经验 && Hits.Count != 0 && CasterObject is PlayerObject playerObj)
                        playerObj.SkillGainExp(c_01_calculateHitTarget.经验SkillId);

                    if (c_01_calculateHitTarget.计算飞行耗时 && c_01_calculateHitTarget.单格飞行耗时 != 0)
                        飞行耗时 = ComputingClass.GridDistance(释放位置, 技能锚点) * c_01_calculateHitTarget.单格飞行耗时;

                    if (c_01_calculateHitTarget.技能命中通知)
                        CasterObject.发送封包(new SkillHitNormal
                        {
                            ObjectId = ((!目标借位 || 技能目标 == null) ? CasterObject.MapId : 技能目标.MapId),
                            SkillId = SkillId,
                            SkillLevel = 技能等级,
                            SkillInscription = Id,
                            ActionId = 动作编号,
                            HitDescription = HitDetail.GetHitDescription(this.Hits, this.飞行耗时)
                        });

                    if (c_01_calculateHitTarget.技能扩展通知)
                        CasterObject.发送封包(new 触发技能扩展
                        {
                            对象编号 = ((!目标借位 || 技能目标 == null) ? CasterObject.MapId : 技能目标.MapId),
                            SkillId = SkillId,
                            技能等级 = 技能等级,
                            技能铭文 = Id,
                            动作编号 = 动作编号,
                            命中描述 = HitDetail.GetHitDescription(this.Hits, this.飞行耗时)
                        });
                }
                else if (task is C_02_计算目标伤害 c_02_计算目标伤害)
                {
                    float num9 = 1f;

                    foreach (var item in Hits)
                    {
                        if (c_02_计算目标伤害.点爆命中目标 && item.Value.Object.Buff列表.ContainsKey(c_02_计算目标伤害.点爆标记编号))
                            item.Value.Object.移除Buff时处理(c_02_计算目标伤害.点爆标记编号);
                        else if (c_02_计算目标伤害.点爆命中目标 && c_02_计算目标伤害.失败添加层数)
                        {
                            item.Value.Object.添加Buff时处理(c_02_计算目标伤害.点爆标记编号, CasterObject);
                            continue;
                        }

                        item.Value.Object.被动受伤时处理(this, c_02_计算目标伤害, item.Value, num9);

                        if ((item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常)
                        {
                            if (c_02_计算目标伤害.数量衰减伤害)
                                num9 = Math.Max(c_02_计算目标伤害.伤害衰减下限, num9 - c_02_计算目标伤害.伤害衰减系数);

                            CasterObject.发送封包(new 触发命中特效
                            {
                                对象编号 = ((!目标借位 || 技能目标 == null) ? CasterObject.MapId : 技能目标.MapId),
                                SkillId = SkillId,
                                技能等级 = 技能等级,
                                技能铭文 = Id,
                                动作编号 = 动作编号,
                                目标编号 = item.Value.Object.MapId,
                                技能反馈 = (ushort)item.Value.Feedback,
                                技能伤害 = -item.Value.Damage,
                                招架伤害 = item.Value.MissDamage
                            });
                        }
                    }

                    if (c_02_计算目标伤害.目标死亡回复)
                    {
                        foreach (var item in Hits)
                        {
                            if ((item.Value.Feedback & SkillHitFeedback.死亡) != SkillHitFeedback.正常 && item.Value.Object.IsSpecificType(CasterObject, c_02_计算目标伤害.回复限定类型))
                            {
                                int num11 = c_02_计算目标伤害.PhysicalRecoveryBase;
                                if (c_02_计算目标伤害.等级差减回复)
                                {
                                    int Value = (CasterObject.当前等级 - item.Value.Object.当前等级) - c_02_计算目标伤害.减回复等级差;
                                    int num12 = c_02_计算目标伤害.零回复等级差 - c_02_计算目标伤害.减回复等级差;
                                    float num13 = ComputingClass.ValueLimit(0, Value, num12) / (float)num12;
                                    num11 = (int)((float)num11 - (float)num11 * num13);
                                }
                                if (num11 > 0)
                                {
                                    CasterObject.当前体力 += num11;
                                    CasterObject.发送封包(new 体力变动飘字
                                    {
                                        血量变化 = num11,
                                        对象编号 = CasterObject.MapId
                                    });
                                }
                            }
                        }
                    }

                    if (c_02_计算目标伤害.击杀减少冷却)
                    {
                        int num14 = 0;

                        foreach (var item in Hits)
                            if ((item.Value.Feedback & SkillHitFeedback.死亡) != SkillHitFeedback.正常 && item.Value.Object.IsSpecificType(CasterObject, c_02_计算目标伤害.冷却减少类型))
                                num14 += (int)c_02_计算目标伤害.冷却减少时间;

                        if (num14 > 0)
                        {
                            if (CasterObject.Coolings.TryGetValue((int)c_02_计算目标伤害.冷却减少技能 | 0x1000000, out var dateTime3))
                            {
                                dateTime3 -= TimeSpan.FromMilliseconds(num14);
                                CasterObject.Coolings[c_02_计算目标伤害.冷却减少技能 | 0x1000000] = dateTime3;
                                CasterObject.发送封包(new AddedSkillCooldownPacket
                                {
                                    冷却编号 = (c_02_计算目标伤害.冷却减少技能 | 0x1000000),
                                    Cooldown = Math.Max(0, (int)(dateTime3 - MainProcess.CurrentTime).TotalMilliseconds)
                                });
                            }

                            if (c_02_计算目标伤害.冷却减少分组 != 0 && CasterObject is PlayerObject PlayerObject8 && PlayerObject8.Coolings.TryGetValue((int)(c_02_计算目标伤害.冷却减少分组 | 0), out var dateTime4))
                            {
                                dateTime4 -= TimeSpan.FromMilliseconds(num14);
                                PlayerObject8.Coolings[(c_02_计算目标伤害.冷却减少分组 | 0)] = dateTime4;
                                CasterObject.发送封包(new AddedSkillCooldownPacket
                                {
                                    冷却编号 = (c_02_计算目标伤害.冷却减少分组 | 0),
                                    Cooldown = Math.Max(0, (int)(dateTime4 - MainProcess.CurrentTime).TotalMilliseconds)
                                });
                            }
                        }
                    }

                    if (c_02_计算目标伤害.命中减少冷却)
                    {
                        int num15 = 0;

                        foreach (var item in Hits)
                            if ((item.Value.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常 && item.Value.Object.IsSpecificType(CasterObject, c_02_计算目标伤害.冷却减少类型))
                                num15 += (int)c_02_计算目标伤害.冷却减少时间;

                        if (num15 > 0)
                        {
                            if (CasterObject.Coolings.TryGetValue((int)c_02_计算目标伤害.冷却减少技能 | 0x1000000, out var dateTime5))
                            {
                                dateTime5 -= TimeSpan.FromMilliseconds(num15);
                                CasterObject.Coolings[c_02_计算目标伤害.冷却减少技能 | 0x1000000] = dateTime5;
                                CasterObject.发送封包(new AddedSkillCooldownPacket
                                {
                                    冷却编号 = (c_02_计算目标伤害.冷却减少技能 | 0x1000000),
                                    Cooldown = Math.Max(0, (int)(dateTime5 - MainProcess.CurrentTime).TotalMilliseconds)
                                });
                            }

                            if (c_02_计算目标伤害.冷却减少分组 != 0)
                            {
                                if (CasterObject is PlayerObject PlayerObject9 && PlayerObject9.Coolings.TryGetValue((int)(c_02_计算目标伤害.冷却减少分组 | 0), out var dateTime6))
                                {
                                    dateTime6 -= TimeSpan.FromMilliseconds(num15);
                                    PlayerObject9.Coolings[(c_02_计算目标伤害.冷却减少分组 | 0)] = dateTime6;
                                    CasterObject.发送封包(new AddedSkillCooldownPacket
                                    {
                                        冷却编号 = (c_02_计算目标伤害.冷却减少分组 | 0),
                                        Cooldown = Math.Max(0, (int)(dateTime6 - MainProcess.CurrentTime).TotalMilliseconds)
                                    });
                                }
                            }
                        }
                    }

                    if (c_02_计算目标伤害.目标硬直时间 > 0)
                        foreach (var item in Hits)
                            if ((item.Value.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常)
                                if (item.Value.Object is MonsterObject monsterObj && monsterObj.Category != MonsterLevelType.Boss)
                                    item.Value.Object.硬直时间 = MainProcess.CurrentTime.AddMilliseconds(c_02_计算目标伤害.目标硬直时间);

                    if (c_02_计算目标伤害.清除目标状态 && c_02_计算目标伤害.清除状态列表.Count != 0)
                        foreach (var item in Hits)
                            if ((item.Value.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常)
                                foreach (ushort 编号2 in c_02_计算目标伤害.清除状态列表)
                                    item.Value.Object.移除Buff时处理(编号2);

                    if (CasterObject is PlayerObject playerObj)
                    {
                        if (c_02_计算目标伤害.增加技能经验 && this.Hits.Count != 0)
                            playerObj.SkillGainExp(c_02_计算目标伤害.经验SkillId);

                        if (c_02_计算目标伤害.扣除武器持久 && this.Hits.Count != 0)
                            playerObj.武器损失持久();
                    }
                }
                else if (task is C_03_计算对象位移 c_03_计算对象位移)
                {
                    byte[] ItSelf位移次数 = c_03_计算对象位移.ItSelf位移次数;
                    byte b2 = (byte)((((ItSelf位移次数 != null) ? ItSelf位移次数.Length : 0) > 技能等级) ? c_03_计算对象位移.ItSelf位移次数[技能等级] : 0);

                    if (c_03_计算对象位移.角色ItSelf位移 && (this.释放地图 != this.CasterObject.CurrentMap || this.分段编号 >= b2))
                    {
                        CasterObject.发送封包(new 技能释放中断
                        {
                            对象编号 = ((!this.目标借位 || this.技能目标 == null) ? this.CasterObject.MapId : this.技能目标.MapId),
                            SkillId = this.SkillId,
                            技能等级 = this.技能等级,
                            技能铭文 = this.Id,
                            动作编号 = this.动作编号,
                            技能分段 = this.分段编号
                        });
                        CasterObject.发送封包(new 技能释放完成
                        {
                            SkillId = this.SkillId,
                            动作编号 = this.动作编号
                        });
                    }
                    else if (c_03_计算对象位移.角色ItSelf位移)
                    {
                        int 数量 = (c_03_计算对象位移.推动目标位移 ? c_03_计算对象位移.连续推动数量 : 0);
                        byte[] ItSelf位移距离 = c_03_计算对象位移.ItSelf位移距离;
                        int num16 = ((((ItSelf位移距离 != null) ? ItSelf位移距离.Length : 0) > 技能等级) ? c_03_计算对象位移.ItSelf位移距离[技能等级] : 0);
                        int num17 = (c_03_计算对象位移.允许超出锚点 || c_03_计算对象位移.锚点反向位移) ? num16 : Math.Min(num16, ComputingClass.GridDistance(释放位置, 技能锚点));
                        Point 锚点 = c_03_计算对象位移.锚点反向位移 ? ComputingClass.前方坐标(CasterObject.CurrentCoords, ComputingClass.计算方向(技能锚点, CasterObject.CurrentCoords), num17) : 技能锚点;
                        if (CasterObject.能否位移(CasterObject, 锚点, num17, 数量, c_03_计算对象位移.能否穿越障碍, out var point, out var array2))
                        {
                            foreach (MapObject mapObj in array2)
                            {
                                if (c_03_计算对象位移.目标位移编号 != 0 && ComputingClass.计算概率(c_03_计算对象位移.位移Buff概率))
                                    mapObj.添加Buff时处理(c_03_计算对象位移.目标位移编号, CasterObject);

                                if (c_03_计算对象位移.目标附加编号 != 0 && ComputingClass.计算概率(c_03_计算对象位移.附加Buff概率) && mapObj.IsSpecificType(this.CasterObject, c_03_计算对象位移.限定附加类型))
                                    mapObj.添加Buff时处理(c_03_计算对象位移.目标附加编号, CasterObject);

                                mapObj.当前方向 = ComputingClass.计算方向(mapObj.CurrentCoords, CasterObject.CurrentCoords);
                                Point point2 = ComputingClass.前方坐标(mapObj.CurrentCoords, ComputingClass.计算方向(CasterObject.CurrentCoords, mapObj.CurrentCoords), 1);
                                mapObj.忙碌时间 = MainProcess.CurrentTime.AddMilliseconds((c_03_计算对象位移.目标位移耗时 * 60));
                                mapObj.硬直时间 = MainProcess.CurrentTime.AddMilliseconds((c_03_计算对象位移.目标位移耗时 * 60 + c_03_计算对象位移.目标硬直时间));

                                mapObj.发送封包(new ObjectPassiveDisplacementPacket
                                {
                                    位移坐标 = point2,
                                    对象编号 = mapObj.MapId,
                                    位移朝向 = (ushort)mapObj.当前方向,
                                    位移速度 = c_03_计算对象位移.目标位移耗时
                                });

                                mapObj.ItSelf移动时处理(point2);

                                if (c_03_计算对象位移.推动增加经验 && !经验增加 && CasterObject is PlayerObject playerObj)
                                {
                                    playerObj.SkillGainExp(SkillId);
                                    经验增加 = true;
                                }
                            }

                            if (c_03_计算对象位移.成功Id != 0 && ComputingClass.计算概率(c_03_计算对象位移.成功Buff概率))
                                CasterObject.添加Buff时处理(c_03_计算对象位移.成功Id, CasterObject);

                            CasterObject.当前方向 = ComputingClass.计算方向(CasterObject.CurrentCoords, point);
                            int num18 = c_03_计算对象位移.ItSelf位移耗时 * CasterObject.网格距离(point);
                            CasterObject.忙碌时间 = MainProcess.CurrentTime.AddMilliseconds((num18 * 60));
                            CasterObject.发送封包(new ObjectPassiveDisplacementPacket
                            {
                                位移坐标 = point,
                                对象编号 = CasterObject.MapId,
                                位移朝向 = (ushort)CasterObject.当前方向,
                                位移速度 = (ushort)num18
                            });
                            CasterObject.ItSelf移动时处理(point);

                            if (c_03_计算对象位移.位移增加经验 && !经验增加 && CasterObject is PlayerObject playerObj2)
                            {
                                playerObj2.SkillGainExp(this.SkillId);
                                经验增加 = true;
                            }

                            if (c_03_计算对象位移.多段位移通知)
                            {
                                CasterObject.发送封包(new SkillHitNormal
                                {
                                    ObjectId = ((!目标借位 || 技能目标 == null) ? CasterObject.MapId : 技能目标.MapId),
                                    SkillId = SkillId,
                                    SkillLevel = 技能等级,
                                    SkillInscription = Id,
                                    ActionId = 动作编号,
                                    SkillSegment = 分段编号
                                });
                            }

                            if (b2 > 1)
                                技能锚点 = ComputingClass.前方坐标(CasterObject.CurrentCoords, CasterObject.当前方向, num17);

                            分段编号++;
                        }
                        else
                        {
                            if (ComputingClass.计算概率(c_03_计算对象位移.失败Buff概率))
                                CasterObject.添加Buff时处理(c_03_计算对象位移.失败Id, CasterObject);

                            CasterObject.硬直时间 = MainProcess.CurrentTime.AddMilliseconds(c_03_计算对象位移.ItSelf硬直时间);
                            分段编号 = b2;
                        }

                        if (b2 > 1)
                        {
                            int num19 = keyValuePair.Key + (int)(c_03_计算对象位移.ItSelf位移耗时 * 60);

                            while (Nodes.ContainsKey(num19))
                                num19++;

                            Nodes.Add(num19, keyValuePair.Value);
                        }
                    }
                    else if (!c_03_计算对象位移.推动目标位移)
                    {
                        foreach (var item in Hits)
                        {
                            if ((item.Value.Feedback & SkillHitFeedback.Miss) != SkillHitFeedback.正常 || (item.Value.Feedback & SkillHitFeedback.丢失) != SkillHitFeedback.正常 || (item.Value.Feedback & SkillHitFeedback.死亡) != SkillHitFeedback.正常 || ComputingClass.计算概率(c_03_计算对象位移.推动目标概率) || item.Value.Object.IsSpecificType(CasterObject, c_03_计算对象位移.推动目标类型))
                                continue;

                            byte[] 目标位移距离 = c_03_计算对象位移.目标位移距离;
                            int val = ((((目标位移距离 != null) ? 目标位移距离.Length : 0) > 技能等级) ? c_03_计算对象位移.目标位移距离[技能等级] : 0);
                            int num20 = ComputingClass.GridDistance(CasterObject.CurrentCoords, item.Value.Object.CurrentCoords);
                            int num21 = Math.Max(0, Math.Min(8 - num20, val));

                            if (num21 == 0) continue;

                            var 方向 = ComputingClass.计算方向(this.CasterObject.CurrentCoords, item.Value.Object.CurrentCoords);
                            var 锚点2 = ComputingClass.前方坐标(item.Value.Object.CurrentCoords, 方向, num21);

                            if (!item.Value.Object.能否位移(CasterObject, 锚点2, num21, 0, false, out var point3, out var array4))
                                continue;

                            if (ComputingClass.计算概率(c_03_计算对象位移.位移Buff概率))
                                item.Value.Object.添加Buff时处理(c_03_计算对象位移.目标位移编号, CasterObject);

                            if (ComputingClass.计算概率(c_03_计算对象位移.附加Buff概率) && item.Value.Object.IsSpecificType(CasterObject, c_03_计算对象位移.限定附加类型))
                                item.Value.Object.添加Buff时处理(c_03_计算对象位移.目标附加编号, CasterObject);

                            item.Value.Object.当前方向 = ComputingClass.计算方向(item.Value.Object.CurrentCoords, CasterObject.CurrentCoords);
                            ushort num22 = (ushort)(ComputingClass.GridDistance(item.Value.Object.CurrentCoords, point3) * c_03_计算对象位移.目标位移耗时);
                            item.Value.Object.忙碌时间 = MainProcess.CurrentTime.AddMilliseconds((num22 * 60));
                            item.Value.Object.硬直时间 = MainProcess.CurrentTime.AddMilliseconds((num22 * 60 + c_03_计算对象位移.目标硬直时间));
                            item.Value.Object.发送封包(new ObjectPassiveDisplacementPacket
                            {
                                位移坐标 = point3,
                                位移速度 = num22,
                                对象编号 = item.Value.Object.MapId,
                                位移朝向 = (ushort)item.Value.Object.当前方向
                            });
                            item.Value.Object.ItSelf移动时处理(point3);
                            if (c_03_计算对象位移.推动增加经验 && !经验增加 && CasterObject is PlayerObject playerObj)
                            {
                                playerObj.SkillGainExp(this.SkillId);
                                this.经验增加 = true;
                            }
                        }
                    }
                }
                else if (task is C_04_计算目标诱惑 c_04_计算目标诱惑)
                {
                    if (CasterObject is PlayerObject playerObj)
                        foreach (var item in Hits)
                            playerObj.玩家诱惑目标(this, c_04_计算目标诱惑, item.Value.Object);
                }
                else if (task is C_06_计算宠物召唤 c_06_计算宠物召唤)
                {
                    if (c_06_计算宠物召唤.怪物召唤同伴)
                    {
                        if (c_06_计算宠物召唤.召唤宠物名字 == null || c_06_计算宠物召唤.召唤宠物名字.Length == 0)
                            return;

                        if (Monsters.DataSheet.TryGetValue(c_06_计算宠物召唤.召唤宠物名字, out var 对应模板))
                            _ = new MonsterObject(对应模板, 释放地图, int.MaxValue, new Point[] { 释放位置 }, true, true) { 存活时间 = MainProcess.CurrentTime.AddMinutes(1.0) };
                    }
                    else if (CasterObject is PlayerObject playerObj)
                    {
                        if (c_06_计算宠物召唤.检查技能铭文 && (!playerObj.MainSkills表.TryGetValue(this.SkillId, out var skill) || skill.Id != this.Id))
                            return;

                        if (c_06_计算宠物召唤.召唤宠物名字 == null || c_06_计算宠物召唤.召唤宠物名字.Length == 0)
                            return;

                        int num21 = ((c_06_计算宠物召唤.召唤宠物数量?.Length > 技能等级) ? c_06_计算宠物召唤.召唤宠物数量[技能等级] : 0);
                        if (playerObj.宠物列表.Count < num21 && Monsters.DataSheet.TryGetValue(c_06_计算宠物召唤.召唤宠物名字, out var value5))
                        {
                            byte 等级上限 = (byte)((c_06_计算宠物召唤.宠物等级上限?.Length > 技能等级) ? c_06_计算宠物召唤.宠物等级上限[技能等级] : 0);
                            PetObject 宠物实例 = new PetObject(playerObj, value5, 技能等级, 等级上限, c_06_计算宠物召唤.宠物绑定武器);
                            playerObj.ActiveConnection.发送封包(new SyncPetLevelPacket
                            {
                                宠物编号 = 宠物实例.MapId,
                                宠物等级 = 宠物实例.宠物等级
                            });
                            playerObj.ActiveConnection.发送封包(new GameErrorMessagePacket
                            {
                                错误代码 = 9473,
                                第一参数 = (int)playerObj.PetMode
                            });
                            playerObj.PetData.Add(宠物实例.PetData);
                            playerObj.宠物列表.Add(宠物实例);

                            if (c_06_计算宠物召唤.增加技能经验)
                                playerObj.SkillGainExp(c_06_计算宠物召唤.经验SkillId);
                        }
                    }
                }
                else if (task is C_05_计算目标回复 c_05_计算目标回复)
                {
                    foreach (var keyValuePair20 in Hits)
                        keyValuePair20.Value.Object.被动回复时处理(this, c_05_计算目标回复);

                    if (c_05_计算目标回复.增加技能经验 && this.Hits.Count != 0 && CasterObject is PlayerObject playerObj)
                        playerObj.SkillGainExp(c_05_计算目标回复.经验SkillId);
                }
                else if (task is C_07_计算目标瞬移 c_07_计算目标瞬移 && CasterObject is PlayerObject playerObj)
                    playerObj.玩家瞬间移动(this, c_07_计算目标瞬移);
            }

            if (Nodes.Count == 0)
            {
                CasterObject.技能任务.Remove(this);
                return;
            }

            AppointmentTime = 释放时间.AddMilliseconds(飞行耗时 + Nodes.First().Key);
            Process();
        }


        public void 技能中断()
        {
            this.Nodes.Clear();
            this.CasterObject.发送封包(new 技能释放中断
            {
                对象编号 = ((!this.目标借位 || this.技能目标 == null) ? this.CasterObject.MapId : this.技能目标.MapId),
                SkillId = this.SkillId,
                技能等级 = this.技能等级,
                技能铭文 = this.Id,
                动作编号 = this.动作编号,
                技能分段 = this.分段编号
            });
        }


        public GameSkills 技能模板;


        public SkillData SkillData;


        public MapObject CasterObject;


        public byte 动作编号;


        public byte 分段编号;


        public MapInstance 释放地图;


        public MapObject 技能目标;


        public Point 技能锚点;


        public Point 释放位置;


        public DateTime 释放时间;


        public SkillInstance 父类技能;


        public bool 目标借位;


        public Dictionary<int, HitDetail> Hits;


        public int 飞行耗时;


        public int 攻速缩减;


        public bool 经验增加;


        public DateTime ProcessingTime;


        public DateTime AppointmentTime;


        public SortedDictionary<int, SkillTask> Nodes;
    }
}
