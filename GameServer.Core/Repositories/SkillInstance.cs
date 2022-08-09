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
        public GameSkills SkillInfo;
        public SkillData SkillData;
        public MapObject CasterObject;
        public byte ActionId;
        public byte SegmentId;
        public MapInstance ReleaseMap;
        public MapObject SkillTarget;
        public Point SkillLocation;
        public Point ReleaseLocation;
        public DateTime ReleaseTime;
        public SkillInstance ParentSkill;
        public bool TargetBorrow;
        public Dictionary<int, HitDetail> Hits;
        public int FightTime;
        public int AttackSpeedReduction;
        public bool GainExperience;
        public DateTime ProcessingTime;
        public DateTime AppointmentTime;
        public SortedDictionary<int, SkillTask> Nodes;

        public int MapId => CasterObject.ObjectId;
        public byte GroupId => SkillInfo.GroupId;
        public byte Id => SkillInfo.Id;
        public ushort SkillId => SkillInfo.OwnSkillId;
        public byte SkillLevel
        {
            get
            {
                if (SkillInfo.BindingLevelId == 0) return 0;

                if (CasterObject is PlayerObject playerObj && playerObj.MainSkills表.TryGetValue(SkillInfo.BindingLevelId, out var skillData))
                    return skillData.SkillLevel.V;

                if (CasterObject is TrapObject trapObj && trapObj.TrapSource is PlayerObject playerObj2 && playerObj2.MainSkills表.TryGetValue(SkillInfo.BindingLevelId, out var skillData2))
                    return skillData2.SkillLevel.V;

                return 0;
            }
        }
        public bool CheckCount => SkillInfo.CheckSkillCount;

        public SkillInstance(MapObject casterObject, GameSkills skillInfo, SkillData skillData, byte actionId, MapInstance releaseMap, Point releaseLocation, MapObject skillTarget, Point skillPointer, SkillInstance parentSkill, Dictionary<int, HitDetail> hits = null, bool targetBorrow = false)
        {
            CasterObject = casterObject;
            SkillInfo = skillInfo;
            SkillData = skillData;
            ActionId = actionId;
            ReleaseMap = releaseMap;
            ReleaseLocation = releaseLocation;
            SkillTarget = skillTarget;
            SkillLocation = skillPointer;
            ParentSkill = parentSkill;
            ReleaseTime = MainProcess.CurrentTime;
            TargetBorrow = targetBorrow;
            Hits = (hits ?? new Dictionary<int, HitDetail>());
            Nodes = new SortedDictionary<int, SkillTask>(skillInfo.Nodes);

            if (Nodes.Count != 0)
            {
                CasterObject.SkillTasks.Add(this);
                AppointmentTime = ReleaseTime.AddMilliseconds(FightTime + Nodes.First().Key);
            }
        }

        public void Process()
        {
            if ((AppointmentTime - ProcessingTime).TotalMilliseconds > 5.0 && MainProcess.CurrentTime < AppointmentTime)
                return;

            var keyValuePair = Nodes.First();
            Nodes.Remove(keyValuePair.Key);

            SkillTask task = keyValuePair.Value;
            ProcessingTime = AppointmentTime;

            if (task != null)
            {
                if (task is A_00_TriggerSubSkills a_00)
                {
                    if (GameSkills.DataSheet.TryGetValue(a_00.触发SkillName, out GameSkills skill))
                    {

                        bool flag = true;

                        if (a_00.CalculateTriggerProbability)
                        {
                            flag = !a_00.CalculateLuckyProbability
                                ? ComputingClass.CheckProbability(a_00.技能触发概率 + ((a_00.增加概率Buff == 0 || !CasterObject.Buffs.ContainsKey(a_00.增加概率Buff)) ? 0f : a_00.Buff增加系数))
                                : ComputingClass.CheckProbability(ComputingClass.计算幸运(CasterObject[GameObjectStats.Luck]));
                        }

                        if (flag && a_00.验证ItSelfBuff)
                        {
                            if (!CasterObject.Buffs.ContainsKey(a_00.Id))
                                flag = false;
                            else if (a_00.触发成功移除)
                                CasterObject.移除Buff时处理(a_00.Id);
                        }

                        if (flag && a_00.验证铭文技能 && CasterObject is PlayerObject playerObj)
                        {
                            int num = a_00.所需Id / 10;
                            int num2 = a_00.所需Id % 10;
                            flag = playerObj.MainSkills表.TryGetValue((ushort)num, out var v)
                                && ((!a_00.同组铭文无效) ? (num2 == 0 || num2 == v.Id) : (num2 == v.Id));
                        }

                        if (flag)
                        {
                            switch (a_00.技能触发方式)
                            {
                                case SkillTriggerMethod.OriginAbsolutePosition:
                                    new SkillInstance(CasterObject, skill, SkillData, ActionId, ReleaseMap, ReleaseLocation, SkillTarget, ReleaseLocation, this);
                                    break;
                                case SkillTriggerMethod.AnchorAbsolutePosition:
                                    new SkillInstance(CasterObject, skill, SkillData, ActionId, ReleaseMap, ReleaseLocation, SkillTarget, SkillLocation, this);
                                    break;
                                case SkillTriggerMethod.AssassinationAbsolutePosition:
                                    new SkillInstance(CasterObject, skill, SkillData, ActionId, ReleaseMap, ReleaseLocation, SkillTarget, ComputingClass.GetFrontPosition(ReleaseLocation, SkillLocation, 2), this);
                                    break;
                                case SkillTriggerMethod.TargetHitDefinitely:
                                    foreach (var item in Hits)
                                        if ((item.Value.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常)
                                            _ = new SkillInstance(CasterObject, skill, SkillData, ActionId, ReleaseMap, (ParentSkill == null) ? ReleaseLocation : SkillLocation, item.Value.Object, item.Value.Object.CurrentPosition, this);
                                    break;
                                case SkillTriggerMethod.MonsterDeathDefinitely:
                                    foreach (var item in Hits)
                                        if (item.Value.Object is MonsterObject && (item.Value.Feedback & SkillHitFeedback.死亡) != 0)
                                            _ = new SkillInstance(CasterObject, skill, SkillData, ActionId, ReleaseMap, ReleaseLocation, null, item.Value.Object.CurrentPosition, this);
                                    break;
                                case SkillTriggerMethod.MonsterDeathTransposition:
                                    foreach (var item in Hits)
                                        if (item.Value.Object is MonsterObject && (item.Value.Feedback & SkillHitFeedback.死亡) != 0)
                                            _ = new SkillInstance(CasterObject, skill, null, item.Value.Object.ActionId++, ReleaseMap, item.Value.Object.CurrentPosition, item.Value.Object, item.Value.Object.CurrentPosition, this, targetBorrow: true);
                                    break;
                                case SkillTriggerMethod.MonsterHitDefinitely:
                                    foreach (var item in Hits)
                                        if (item.Value.Object is MonsterObject && (item.Value.Feedback & SkillHitFeedback.死亡) != 0)
                                            _ = new SkillInstance(CasterObject, skill, SkillData, ActionId, ReleaseMap, ReleaseLocation, null, SkillLocation, this);
                                    break;
                                case SkillTriggerMethod.NoTargetPosition:
                                    if (Hits.Count == 0 || Hits.Values.FirstOrDefault((HitDetail O) => O.Feedback != SkillHitFeedback.丢失) == null)
                                        _ = new SkillInstance(CasterObject, skill, SkillData, ActionId, ReleaseMap, ReleaseLocation, null, SkillLocation, this);
                                    break;
                                case SkillTriggerMethod.TargetPositionAbsolute:
                                    foreach (var item in Hits)
                                        _ = new SkillInstance(CasterObject, skill, SkillData, ActionId, ReleaseMap, ReleaseLocation, item.Value.Object, item.Value.Object.CurrentPosition, this);
                                    break;
                                case SkillTriggerMethod.ForehandAndBackhandRandom:
                                    if (ComputingClass.CheckProbability(0.5f) && GameSkills.DataSheet.TryGetValue(a_00.反手SkillName, out var value3))
                                        _ = new SkillInstance(CasterObject, value3, SkillData, ActionId, ReleaseMap, ReleaseLocation, null, SkillLocation, this);
                                    else
                                        _ = new SkillInstance(CasterObject, skill, SkillData, ActionId, ReleaseMap, ReleaseLocation, null, SkillLocation, this);
                                    break;
                                case SkillTriggerMethod.TargetDeathDefinitely:
                                    foreach (var item in Hits)
                                        if ((item.Value.Feedback & SkillHitFeedback.死亡) != 0)
                                            new SkillInstance(CasterObject, skill, SkillData, ActionId, ReleaseMap, ReleaseLocation, null, item.Value.Object.CurrentPosition, this);
                                    break;
                                case SkillTriggerMethod.TargetMissDefinitely:
                                    foreach (var item in Hits)
                                        if ((item.Value.Feedback & SkillHitFeedback.Miss) != 0)
                                            new SkillInstance(CasterObject, skill, SkillData, ActionId, ReleaseMap, ReleaseLocation, null, item.Value.Object.CurrentPosition, this);
                                    break;
                            }
                        }
                    }
                }
                else if (task is A_01_TriggerObjectBuff a_01)
                {
                    bool flag2 = false;
                    if (a_01.角色ItSelf添加)
                    {
                        bool flag3 = true;
                        if (!ComputingClass.CheckProbability(a_01.Buff触发概率))
                            flag3 = false;

                        if (flag3 && a_01.验证铭文技能 && CasterObject is PlayerObject PlayerObject2)
                        {
                            int num3 = (int)(a_01.所需Id / 10);
                            int num4 = (int)(a_01.所需Id % 10);
                            flag3 = PlayerObject2.MainSkills表.TryGetValue((ushort)num3, out SkillData skill) && a_01.同组铭文无效
                                ? num4 == (int)skill.Id
                                : num4 == 0 || num4 == (int)skill.Id;
                        }
                        if (flag3 && a_01.验证ItSelfBuff)
                        {
                            if (!CasterObject.Buffs.ContainsKey(a_01.Id))
                                flag3 = false;
                            else
                            {
                                if (a_01.触发成功移除)
                                    CasterObject.移除Buff时处理(a_01.Id);
                                if (a_01.移除伴生Buff)
                                    CasterObject.移除Buff时处理(a_01.移除伴生编号);
                            }
                        }

                        if (flag3 && a_01.验证分组Buff && CasterObject.Buffs.Values.FirstOrDefault((BuffData O) => O.Buff分组 == a_01.BuffGroupId) == null)
                            flag3 = false;

                        if (flag3 && a_01.VerifyTargetBuff && Hits.Values.FirstOrDefault((HitDetail O) => (O.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (O.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常 && O.Object.Buffs.TryGetValue(a_01.目标Id, out BuffData BuffData2) && BuffData2.当前层数.V >= a_01.所需Buff层数) == null)
                            flag3 = false;

                        if (flag3 && a_01.VerifyTargetType && Hits.Values.FirstOrDefault((HitDetail O) => (O.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (O.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常 && O.Object.IsSpecificType(CasterObject, a_01.所需目标类型)) == null)
                            flag3 = false;

                        if (flag3)
                        {
                            CasterObject.OnAddBuff(a_01.触发Id, CasterObject);
                            if (a_01.伴生Id > 0)
                                CasterObject.OnAddBuff(a_01.伴生Id, CasterObject);
                            flag2 = true;
                        }
                    }
                    else
                    {
                        bool flag4 = true;
                        if (a_01.验证ItSelfBuff)
                        {
                            if (!CasterObject.Buffs.ContainsKey(a_01.Id))
                                flag4 = false;
                            else
                            {
                                if (a_01.触发成功移除)
                                    CasterObject.移除Buff时处理(a_01.Id);
                                if (a_01.移除伴生Buff)
                                    CasterObject.移除Buff时处理(a_01.移除伴生编号);
                            }
                        }

                        if (flag4 && a_01.验证分组Buff && CasterObject.Buffs.Values.FirstOrDefault((BuffData O) => O.Buff分组 == a_01.BuffGroupId) == null)
                            flag4 = false;

                        if (flag4 && a_01.验证铭文技能 && CasterObject is PlayerObject PlayerObject3)
                        {
                            int num5 = a_01.所需Id / 10;
                            int num6 = a_01.所需Id % 10;

                            flag4 = PlayerObject3.MainSkills表.TryGetValue((ushort)num5, out SkillData SkillData4) && a_01.同组铭文无效
                                ? (num6 == (int)SkillData4.Id)
                                : (num6 == 0 || num6 == (int)SkillData4.Id);
                        }

                        if (flag4)
                        {
                            foreach (var item in Hits)
                            {
                                bool flag5 = true;

                                if ((item.Value.Feedback & (SkillHitFeedback.Miss | SkillHitFeedback.丢失)) != SkillHitFeedback.正常)
                                    flag5 = false;

                                if (flag5 && !ComputingClass.CheckProbability(a_01.Buff触发概率))
                                    flag5 = false;

                                if (flag5 && a_01.VerifyTargetType && !item.Value.Object.IsSpecificType(CasterObject, a_01.所需目标类型))
                                    flag5 = false;

                                if (flag5 && a_01.VerifyTargetBuff)
                                    flag5 = (item.Value.Object.Buffs.TryGetValue(a_01.目标Id, out BuffData buffData) && buffData.当前层数.V >= a_01.所需Buff层数);

                                if (flag5)
                                {
                                    item.Value.Object.OnAddBuff(a_01.触发Id, CasterObject);
                                    if (a_01.伴生Id > 0) item.Value.Object.OnAddBuff(a_01.伴生Id, CasterObject);
                                    flag2 = true;
                                }
                            }
                        }
                    }

                    if (flag2 && a_01.GainSkillExp && CasterObject is PlayerObject playerObj)
                        playerObj.SkillGainExp(a_01.经验SkillId);
                }
                else if (task is A_02_TriggerTrapSkills a_02)
                {
                    if (SkillTraps.DataSheet.TryGetValue(a_02.TriggerTrapSkills, out SkillTraps 陷阱模板))
                    {
                        int num7 = 0;
                        var array = ComputingClass.GetLocationRange(SkillLocation, ComputingClass.GetDirection(ReleaseLocation, SkillLocation), a_02.NumberTrapsTriggered);
                        foreach (var coord in array)
                        {
                            if (!ReleaseMap.IsBlocked(coord) && (陷阱模板.AllowStacking || !ReleaseMap[coord].Any(o => o is TrapObject trapObj && trapObj.陷阱GroupId != 0 && trapObj.陷阱GroupId == 陷阱模板.GroupId)))
                            {
                                CasterObject.Traps.Add(new TrapObject(CasterObject, 陷阱模板, ReleaseMap, coord));
                                num7++;
                            }
                        }

                        if (num7 != 0 && a_02.经验SkillId != 0 && CasterObject is PlayerObject playerObj)
                            playerObj.SkillGainExp(a_02.经验SkillId);
                    }
                }
                else if (task is B_00_SkillSwitchNotification b_00)
                {
                    if (CasterObject.Buffs.ContainsKey(b_00.SkillTagId))
                    {
                        if (b_00.允许移除标记)
                            CasterObject.移除Buff时处理(b_00.SkillTagId);
                    }
                    else if (GameBuffs.DataSheet.ContainsKey(b_00.SkillTagId))
                        CasterObject.OnAddBuff(b_00.SkillTagId, CasterObject);
                }
                else if (task is B_01_SkillReleaseNotification b_01)
                {
                    if (b_01.调整角色朝向)
                    {
                        var dir = ComputingClass.GetDirection(ReleaseLocation, SkillLocation);
                        if (dir == CasterObject.CurrentDirection)
                            CasterObject.SendPacket(new ObjectRotationDirectionPacket
                            {
                                对象编号 = CasterObject.ObjectId,
                                对象朝向 = (ushort)dir,
                                转向耗时 = ((ushort)((CasterObject is PlayerObject) ? 0 : 1))
                            });
                        else
                            CasterObject.CurrentDirection = ComputingClass.GetDirection(ReleaseLocation, SkillLocation);
                    }

                    if (b_01.移除技能标记 && SkillInfo.SkillTagId != 0)
                        CasterObject.移除Buff时处理(SkillInfo.SkillTagId);

                    if (b_01.ItSelfCooldown != 0 || b_01.Buff增加冷却)
                    {
                        if (CheckCount && CasterObject is PlayerObject playerObj)
                        {
                            if ((SkillData.RemainingTimeLeft.V -= 1) <= 0)
                                CasterObject.Coolings[SkillId | 16777216] = ReleaseTime.AddMilliseconds((SkillData.计数时间 - MainProcess.CurrentTime).TotalMilliseconds);

                            playerObj.ActiveConnection.SendPacket(new SyncSkillCountPacket
                            {
                                SkillId = SkillData.SkillId.V,
                                SkillCount = SkillData.RemainingTimeLeft.V,
                                技能冷却 = (int)(SkillData.计数时间 - MainProcess.CurrentTime).TotalMilliseconds
                            });
                        }
                        if (b_01.ItSelfCooldown > 0 || b_01.Buff增加冷却)
                        {
                            var num8 = b_01.ItSelfCooldown;

                            if (b_01.Buff增加冷却 && CasterObject.Buffs.ContainsKey(b_01.增加冷却Buff))
                                num8 += b_01.冷却增加时间;

                            var dateTime = ReleaseTime.AddMilliseconds(num8);

                            var dateTime2 = CasterObject.Coolings.ContainsKey(SkillId | 0x1000000)
                                ? CasterObject.Coolings[SkillId | 0x1000000]
                                : default(DateTime);

                            if (num8 > 0 && dateTime > dateTime2)
                            {
                                CasterObject.Coolings[SkillId | 0x1000000] = dateTime;
                                CasterObject.SendPacket(new AddedSkillCooldownPacket
                                {
                                    冷却编号 = ((int)SkillId | 0x1000000),
                                    Cooldown = num8
                                });
                            }
                        }
                    }

                    if (CasterObject is PlayerObject playerObj2 && b_01.分组Cooldown != 0 && GroupId != 0)
                    {
                        DateTime dateTime2 = ReleaseTime.AddMilliseconds((double)b_01.分组Cooldown);
                        DateTime t2 = playerObj2.Coolings.ContainsKey((int)(GroupId | 0)) ? playerObj2.Coolings[(int)(GroupId | 0)] : default(DateTime);
                        if (dateTime2 > t2) playerObj2.Coolings[(int)(GroupId | 0)] = dateTime2;
                        CasterObject.SendPacket(new AddedSkillCooldownPacket
                        {
                            冷却编号 = (int)(GroupId | 0),
                            Cooldown = b_01.分组Cooldown
                        });
                    }

                    if (b_01.角色忙绿时间 != 0)
                        CasterObject.BusyTime = ReleaseTime.AddMilliseconds((double)b_01.角色忙绿时间);

                    if (b_01.发送释放通知)
                        CasterObject.SendPacket(new 开始释放技能
                        {
                            对象编号 = !TargetBorrow || SkillTarget == null ? CasterObject.ObjectId : SkillTarget.ObjectId,
                            SkillId = SkillId,
                            SkillLevel = SkillLevel,
                            技能铭文 = Id,
                            锚点坐标 = SkillLocation,
                            动作编号 = ActionId,
                            目标编号 = SkillTarget?.ObjectId ?? 0,
                            锚点高度 = ReleaseMap.GetTerrainHeight(SkillLocation)
                        });
                }
                else if (task is B_02_SkillHitNotification b_02)
                {
                    if (b_02.命中扩展通知)
                        CasterObject.SendPacket(new 触发技能扩展
                        {
                            对象编号 = ((!TargetBorrow || SkillTarget == null) ? CasterObject.ObjectId : SkillTarget.ObjectId),
                            SkillId = SkillId,
                            SkillLevel = SkillLevel,
                            技能铭文 = Id,
                            动作编号 = ActionId,
                            命中描述 = HitDetail.GetHitDescription(Hits, FightTime)
                        });
                    else
                        CasterObject.SendPacket(new SkillHitNormal
                        {
                            ObjectId = ((!TargetBorrow || SkillTarget == null) ? CasterObject.ObjectId : SkillTarget.ObjectId),
                            SkillId = SkillId,
                            SkillLevel = SkillLevel,
                            SkillInscription = Id,
                            ActionId = ActionId,
                            HitDescription = HitDetail.GetHitDescription(Hits, FightTime)
                        });

                    if (b_02.计算飞行耗时)
                        FightTime = ComputingClass.GridDistance(ReleaseLocation, SkillLocation) * b_02.单格飞行耗时;
                }
                else if (task is B_03_FrontShakeEndNotification b_03)
                {
                    if (b_03.计算攻速缩减)
                    {
                        AttackSpeedReduction = ComputingClass.ValueLimit(ComputingClass.CalcAttackSpeed(-5), AttackSpeedReduction + ComputingClass.CalcAttackSpeed(CasterObject[GameObjectStats.AttackSpeed]), ComputingClass.CalcAttackSpeed(5));

                        if (AttackSpeedReduction != 0)
                        {
                            foreach (var item in Nodes)
                            {
                                if (item.Value is B_04_PostShakeEndNotification)
                                {
                                    int num9 = item.Key - AttackSpeedReduction;
                                    while (Nodes.ContainsKey(num9)) num9++;
                                    Nodes.Remove(item.Key);
                                    Nodes.Add(num9, item.Value);
                                    break;
                                }
                            }
                        }
                    }

                    if (b_03.禁止行走时间 != 0)
                        CasterObject.WalkTime = ReleaseTime.AddMilliseconds(b_03.禁止行走时间);

                    if (b_03.禁止奔跑时间 != 0)
                        CasterObject.RunTime = ReleaseTime.AddMilliseconds(b_03.禁止奔跑时间);

                    if (b_03.角色硬直时间 != 0)
                        CasterObject.HardTime = ReleaseTime.AddMilliseconds((b_03.计算攻速缩减 ? (b_03.角色硬直时间 - AttackSpeedReduction) : b_03.角色硬直时间));

                    if (b_03.发送结束通知)
                        CasterObject.SendPacket(new SkillHitNormal
                        {
                            ObjectId = ((!TargetBorrow || SkillTarget == null) ? CasterObject.ObjectId : SkillTarget.ObjectId),
                            SkillId = SkillId,
                            SkillLevel = SkillLevel,
                            SkillInscription = Id,
                            ActionId = ActionId
                        });

                    if (b_03.解除技能陷阱 && CasterObject is TrapObject trapObj)
                        trapObj.陷阱消失处理();
                }
                else if (task is B_04_PostShakeEndNotification b_04)
                {
                    CasterObject.SendPacket(new 技能释放完成
                    {
                        SkillId = SkillId,
                        动作编号 = ActionId
                    });

                    if (b_04.后摇结束死亡)
                        CasterObject.Dies(null, skillKill: false);
                }
                else if (task is C_00_CalculateSkillAnchor c_00)
                {
                    if (c_00.计算当前位置)
                    {
                        SkillTarget = null;
                        if (c_00.计算当前方向)
                            SkillLocation = ComputingClass.前方坐标(CasterObject.CurrentPosition, CasterObject.CurrentDirection, c_00.技能最近距离);
                        else
                            SkillLocation = ComputingClass.GetFrontPosition(CasterObject.CurrentPosition, SkillLocation, c_00.技能最近距离);
                    }
                    else if (ComputingClass.GridDistance(ReleaseLocation, SkillLocation) > c_00.MaxDistance)
                    {
                        SkillTarget = null;
                        SkillLocation = ComputingClass.GetFrontPosition(ReleaseLocation, SkillLocation, c_00.MaxDistance);
                    }
                    else if (ComputingClass.GridDistance(ReleaseLocation, SkillLocation) < c_00.技能最近距离)
                    {
                        SkillTarget = null;

                        if (ReleaseLocation == SkillLocation)
                            SkillLocation = ComputingClass.前方坐标(ReleaseLocation, CasterObject.CurrentDirection, c_00.技能最近距离);
                        else
                            SkillLocation = ComputingClass.GetFrontPosition(ReleaseLocation, SkillLocation, c_00.技能最近距离);
                    }
                }
                else if (task is C_01_CalculateHitTarget c_01)
                {
                    if (c_01.清空命中列表)
                        Hits = new Dictionary<int, HitDetail>();

                    if (c_01.技能能否穿墙 || !ReleaseMap.地形遮挡(ReleaseLocation, SkillLocation))
                    {
                        switch (c_01.技能锁定方式)
                        {
                            case 技能锁定类型.锁定ItSelf:
                                CasterObject.ProcessSkillHit(this, c_01);
                                break;
                            case 技能锁定类型.锁定目标:
                                SkillTarget?.ProcessSkillHit(this, c_01);
                                break;
                            case 技能锁定类型.锁定ItSelf坐标:
                                foreach (var 坐标2 in ComputingClass.GetLocationRange(CasterObject.CurrentPosition, ComputingClass.GetDirection(ReleaseLocation, SkillLocation), c_01.技能范围类型))
                                    foreach (var mapObj in ReleaseMap[坐标2])
                                        mapObj.ProcessSkillHit(this, c_01);
                                break;
                            case 技能锁定类型.锁定目标坐标:
                                {
                                    var array = ComputingClass.GetLocationRange((SkillTarget != null) ? SkillTarget.CurrentPosition : SkillLocation, ComputingClass.GetDirection(ReleaseLocation, SkillLocation), c_01.技能范围类型);

                                    foreach (var 坐标3 in array)
                                        foreach (MapObject mapObj in ReleaseMap[坐标3])
                                            mapObj.ProcessSkillHit(this, c_01);

                                    break;
                                }
                            case 技能锁定类型.锁定锚点坐标:
                                var array2 = ComputingClass.GetLocationRange(SkillLocation, ComputingClass.GetDirection(ReleaseLocation, SkillLocation), c_01.技能范围类型);

                                foreach (var 坐标4 in array2)
                                    foreach (MapObject mapObj in ReleaseMap[坐标4])
                                        mapObj.ProcessSkillHit(this, c_01);

                                break;
                            case 技能锁定类型.放空锁定ItSelf:
                                var array3 = ComputingClass.GetLocationRange(SkillLocation, ComputingClass.GetDirection(ReleaseLocation, SkillLocation), c_01.技能范围类型);

                                foreach (Point 坐标5 in array3)
                                    foreach (MapObject mapObj in ReleaseMap[坐标5])
                                        mapObj.ProcessSkillHit(this, c_01);

                                if (Hits.Count == 0) CasterObject.ProcessSkillHit(this, c_01);

                                break;
                        }
                    }

                    if (Hits.Count == 0 && c_01.放空结束技能)
                    {
                        if (c_01.发送中断通知)
                            CasterObject.SendPacket(new 技能释放中断
                            {
                                对象编号 = CasterObject.ObjectId,
                                SkillId = SkillId,
                                SkillLevel = SkillLevel,
                                技能铭文 = Id,
                                动作编号 = ActionId,
                                技能分段 = SegmentId
                            });

                        CasterObject.SkillTasks.Remove(this);
                        return;
                    }

                    if (c_01.补发释放通知)
                        CasterObject.SendPacket(new 开始释放技能
                        {
                            对象编号 = ((!TargetBorrow || SkillTarget == null) ? CasterObject.ObjectId : SkillTarget.ObjectId),
                            SkillId = SkillId,
                            SkillLevel = SkillLevel,
                            技能铭文 = Id,
                            目标编号 = SkillTarget?.ObjectId ?? 0,
                            锚点坐标 = SkillLocation,
                            锚点高度 = ReleaseMap.GetTerrainHeight(SkillLocation),
                            动作编号 = ActionId
                        });

                    if (Hits.Count != 0 && c_01.攻速提升类型 != SpecifyTargetType.None && Hits[0].Object.IsSpecificType(CasterObject, c_01.攻速提升类型))
                        AttackSpeedReduction = ComputingClass.ValueLimit(ComputingClass.CalcAttackSpeed(-5), AttackSpeedReduction + ComputingClass.CalcAttackSpeed(c_01.攻速提升幅度), ComputingClass.CalcAttackSpeed(5));

                    if (c_01.清除目标状态 && c_01.清除状态列表.Count != 0)
                        foreach (var item in Hits)
                            if ((item.Value.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常)
                                foreach (ushort 编号 in c_01.清除状态列表.ToList())
                                    item.Value.Object.移除Buff时处理(编号);

                    if (c_01.触发PassiveSkill && Hits.Count != 0 && ComputingClass.CheckProbability(c_01.触发被动概率))
                        CasterObject[GameObjectStats.SkillSign] = 1;

                    if (c_01.GainSkillExp && Hits.Count != 0 && CasterObject is PlayerObject playerObj)
                        playerObj.SkillGainExp(c_01.经验SkillId);

                    if (c_01.计算飞行耗时 && c_01.单格飞行耗时 != 0)
                        FightTime = ComputingClass.GridDistance(ReleaseLocation, SkillLocation) * c_01.单格飞行耗时;

                    if (c_01.技能命中通知)
                        CasterObject.SendPacket(new SkillHitNormal
                        {
                            ObjectId = ((!TargetBorrow || SkillTarget == null) ? CasterObject.ObjectId : SkillTarget.ObjectId),
                            SkillId = SkillId,
                            SkillLevel = SkillLevel,
                            SkillInscription = Id,
                            ActionId = ActionId,
                            HitDescription = HitDetail.GetHitDescription(Hits, FightTime)
                        });

                    if (c_01.技能扩展通知)
                        CasterObject.SendPacket(new 触发技能扩展
                        {
                            对象编号 = ((!TargetBorrow || SkillTarget == null) ? CasterObject.ObjectId : SkillTarget.ObjectId),
                            SkillId = SkillId,
                            SkillLevel = SkillLevel,
                            技能铭文 = Id,
                            动作编号 = ActionId,
                            命中描述 = HitDetail.GetHitDescription(Hits, FightTime)
                        });
                }
                else if (task is C_02_CalculateTargetDamage c_02)
                {
                    float num9 = 1f;

                    foreach (var item in Hits)
                    {
                        if (c_02.点爆命中目标 && item.Value.Object.Buffs.ContainsKey(c_02.点爆标记编号))
                            item.Value.Object.移除Buff时处理(c_02.点爆标记编号);
                        else if (c_02.点爆命中目标 && c_02.失败添加层数)
                        {
                            item.Value.Object.OnAddBuff(c_02.点爆标记编号, CasterObject);
                            continue;
                        }

                        item.Value.Object.被动受伤时处理(this, c_02, item.Value, num9);

                        if ((item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常)
                        {
                            if (c_02.数量衰减伤害)
                                num9 = Math.Max(c_02.伤害衰减下限, num9 - c_02.伤害衰减系数);

                            CasterObject.SendPacket(new 触发命中特效
                            {
                                对象编号 = ((!TargetBorrow || SkillTarget == null) ? CasterObject.ObjectId : SkillTarget.ObjectId),
                                SkillId = SkillId,
                                SkillLevel = SkillLevel,
                                技能铭文 = Id,
                                动作编号 = ActionId,
                                目标编号 = item.Value.Object.ObjectId,
                                技能反馈 = (ushort)item.Value.Feedback,
                                技能伤害 = -item.Value.Damage,
                                招架伤害 = item.Value.MissDamage
                            });
                        }
                    }

                    if (c_02.目标死亡回复)
                    {
                        foreach (var item in Hits)
                        {
                            if ((item.Value.Feedback & SkillHitFeedback.死亡) != SkillHitFeedback.正常 && item.Value.Object.IsSpecificType(CasterObject, c_02.回复限定类型))
                            {
                                int num11 = c_02.PhysicalRecoveryBase;
                                if (c_02.等级差减回复)
                                {
                                    int Value = (CasterObject.CurrentLevel - item.Value.Object.CurrentLevel) - c_02.减回复等级差;
                                    int num12 = c_02.零回复等级差 - c_02.减回复等级差;
                                    float num13 = ComputingClass.ValueLimit(0, Value, num12) / (float)num12;
                                    num11 = (int)((float)num11 - (float)num11 * num13);
                                }
                                if (num11 > 0)
                                {
                                    CasterObject.CurrentHP += num11;
                                    CasterObject.SendPacket(new 体力变动飘字
                                    {
                                        血量变化 = num11,
                                        对象编号 = CasterObject.ObjectId
                                    });
                                }
                            }
                        }
                    }

                    if (c_02.击杀减少冷却)
                    {
                        int num14 = 0;

                        foreach (var item in Hits)
                            if ((item.Value.Feedback & SkillHitFeedback.死亡) != SkillHitFeedback.正常 && item.Value.Object.IsSpecificType(CasterObject, c_02.冷却减少类型))
                                num14 += (int)c_02.冷却减少时间;

                        if (num14 > 0)
                        {
                            if (CasterObject.Coolings.TryGetValue((int)c_02.冷却减少技能 | 0x1000000, out var dateTime3))
                            {
                                dateTime3 -= TimeSpan.FromMilliseconds(num14);
                                CasterObject.Coolings[c_02.冷却减少技能 | 0x1000000] = dateTime3;
                                CasterObject.SendPacket(new AddedSkillCooldownPacket
                                {
                                    冷却编号 = (c_02.冷却减少技能 | 0x1000000),
                                    Cooldown = Math.Max(0, (int)(dateTime3 - MainProcess.CurrentTime).TotalMilliseconds)
                                });
                            }

                            if (c_02.冷却减少分组 != 0 && CasterObject is PlayerObject PlayerObject8 && PlayerObject8.Coolings.TryGetValue((int)(c_02.冷却减少分组 | 0), out var dateTime4))
                            {
                                dateTime4 -= TimeSpan.FromMilliseconds(num14);
                                PlayerObject8.Coolings[(c_02.冷却减少分组 | 0)] = dateTime4;
                                CasterObject.SendPacket(new AddedSkillCooldownPacket
                                {
                                    冷却编号 = (c_02.冷却减少分组 | 0),
                                    Cooldown = Math.Max(0, (int)(dateTime4 - MainProcess.CurrentTime).TotalMilliseconds)
                                });
                            }
                        }
                    }

                    if (c_02.命中减少冷却)
                    {
                        int num15 = 0;

                        foreach (var item in Hits)
                            if ((item.Value.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常 && item.Value.Object.IsSpecificType(CasterObject, c_02.冷却减少类型))
                                num15 += (int)c_02.冷却减少时间;

                        if (num15 > 0)
                        {
                            if (CasterObject.Coolings.TryGetValue((int)c_02.冷却减少技能 | 0x1000000, out var dateTime5))
                            {
                                dateTime5 -= TimeSpan.FromMilliseconds(num15);
                                CasterObject.Coolings[c_02.冷却减少技能 | 0x1000000] = dateTime5;
                                CasterObject.SendPacket(new AddedSkillCooldownPacket
                                {
                                    冷却编号 = (c_02.冷却减少技能 | 0x1000000),
                                    Cooldown = Math.Max(0, (int)(dateTime5 - MainProcess.CurrentTime).TotalMilliseconds)
                                });
                            }

                            if (c_02.冷却减少分组 != 0)
                            {
                                if (CasterObject is PlayerObject PlayerObject9 && PlayerObject9.Coolings.TryGetValue((int)(c_02.冷却减少分组 | 0), out var dateTime6))
                                {
                                    dateTime6 -= TimeSpan.FromMilliseconds(num15);
                                    PlayerObject9.Coolings[(c_02.冷却减少分组 | 0)] = dateTime6;
                                    CasterObject.SendPacket(new AddedSkillCooldownPacket
                                    {
                                        冷却编号 = (c_02.冷却减少分组 | 0),
                                        Cooldown = Math.Max(0, (int)(dateTime6 - MainProcess.CurrentTime).TotalMilliseconds)
                                    });
                                }
                            }
                        }
                    }

                    if (c_02.目标硬直时间 > 0)
                        foreach (var item in Hits)
                            if ((item.Value.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常)
                                if (item.Value.Object is MonsterObject monsterObj && monsterObj.Category != MonsterLevelType.Boss)
                                    item.Value.Object.HardTime = MainProcess.CurrentTime.AddMilliseconds(c_02.目标硬直时间);

                    if (c_02.清除目标状态 && c_02.清除状态列表.Count != 0)
                        foreach (var item in Hits)
                            if ((item.Value.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常 && (item.Value.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常)
                                foreach (ushort 编号2 in c_02.清除状态列表)
                                    item.Value.Object.移除Buff时处理(编号2);

                    if (CasterObject is PlayerObject playerObj)
                    {
                        if (c_02.GainSkillExp && Hits.Count != 0)
                            playerObj.SkillGainExp(c_02.经验SkillId);

                        if (c_02.扣除武器持久 && Hits.Count != 0)
                            playerObj.武器损失持久();
                    }
                }
                else if (task is C_03_CalculateObjectDisplacement c_03)
                {
                    byte[] ItSelf位移次数 = c_03.ItSelf位移次数;
                    byte b2 = (byte)((((ItSelf位移次数 != null) ? ItSelf位移次数.Length : 0) > SkillLevel) ? c_03.ItSelf位移次数[SkillLevel] : 0);

                    if (c_03.角色ItSelf位移 && (ReleaseMap != CasterObject.CurrentMap || SegmentId >= b2))
                    {
                        CasterObject.SendPacket(new 技能释放中断
                        {
                            对象编号 = ((!TargetBorrow || SkillTarget == null) ? CasterObject.ObjectId : SkillTarget.ObjectId),
                            SkillId = SkillId,
                            SkillLevel = SkillLevel,
                            技能铭文 = Id,
                            动作编号 = ActionId,
                            技能分段 = SegmentId
                        });
                        CasterObject.SendPacket(new 技能释放完成
                        {
                            SkillId = SkillId,
                            动作编号 = ActionId
                        });
                    }
                    else if (c_03.角色ItSelf位移)
                    {
                        int 数量 = (c_03.推动目标位移 ? c_03.连续推动数量 : 0);
                        byte[] ItSelf位移距离 = c_03.ItSelf位移距离;
                        int num16 = ((((ItSelf位移距离 != null) ? ItSelf位移距离.Length : 0) > SkillLevel) ? c_03.ItSelf位移距离[SkillLevel] : 0);
                        int num17 = (c_03.允许超出锚点 || c_03.锚点反向位移) ? num16 : Math.Min(num16, ComputingClass.GridDistance(ReleaseLocation, SkillLocation));
                        Point 锚点 = c_03.锚点反向位移 ? ComputingClass.前方坐标(CasterObject.CurrentPosition, ComputingClass.GetDirection(SkillLocation, CasterObject.CurrentPosition), num17) : SkillLocation;
                        if (CasterObject.CanBeDisplaced(CasterObject, 锚点, num17, 数量, c_03.能否穿越障碍, out var point, out var array2))
                        {
                            foreach (MapObject mapObj in array2)
                            {
                                if (c_03.目标位移编号 != 0 && ComputingClass.CheckProbability(c_03.位移Buff概率))
                                    mapObj.OnAddBuff(c_03.目标位移编号, CasterObject);

                                if (c_03.目标附加编号 != 0 && ComputingClass.CheckProbability(c_03.附加Buff概率) && mapObj.IsSpecificType(CasterObject, c_03.限定附加类型))
                                    mapObj.OnAddBuff(c_03.目标附加编号, CasterObject);

                                mapObj.CurrentDirection = ComputingClass.GetDirection(mapObj.CurrentPosition, CasterObject.CurrentPosition);
                                Point point2 = ComputingClass.前方坐标(mapObj.CurrentPosition, ComputingClass.GetDirection(CasterObject.CurrentPosition, mapObj.CurrentPosition), 1);
                                mapObj.BusyTime = MainProcess.CurrentTime.AddMilliseconds((c_03.目标位移耗时 * 60));
                                mapObj.HardTime = MainProcess.CurrentTime.AddMilliseconds((c_03.目标位移耗时 * 60 + c_03.目标硬直时间));

                                mapObj.SendPacket(new ObjectPassiveDisplacementPacket
                                {
                                    位移坐标 = point2,
                                    对象编号 = mapObj.ObjectId,
                                    位移朝向 = (ushort)mapObj.CurrentDirection,
                                    位移速度 = c_03.目标位移耗时
                                });

                                mapObj.ItSelf移动时处理(point2);

                                if (c_03.BoostSkillExp && !GainExperience && CasterObject is PlayerObject playerObj)
                                {
                                    playerObj.SkillGainExp(SkillId);
                                    GainExperience = true;
                                }
                            }

                            if (c_03.成功Id != 0 && ComputingClass.CheckProbability(c_03.成功Buff概率))
                                CasterObject.OnAddBuff(c_03.成功Id, CasterObject);

                            CasterObject.CurrentDirection = ComputingClass.GetDirection(CasterObject.CurrentPosition, point);
                            int num18 = c_03.ItSelf位移耗时 * CasterObject.GetDistance(point);
                            CasterObject.BusyTime = MainProcess.CurrentTime.AddMilliseconds((num18 * 60));
                            CasterObject.SendPacket(new ObjectPassiveDisplacementPacket
                            {
                                位移坐标 = point,
                                对象编号 = CasterObject.ObjectId,
                                位移朝向 = (ushort)CasterObject.CurrentDirection,
                                位移速度 = (ushort)num18
                            });
                            CasterObject.ItSelf移动时处理(point);

                            if (c_03.DisplacementIncreaseExp && !GainExperience && CasterObject is PlayerObject playerObj2)
                            {
                                playerObj2.SkillGainExp(SkillId);
                                GainExperience = true;
                            }

                            if (c_03.多段位移通知)
                            {
                                CasterObject.SendPacket(new SkillHitNormal
                                {
                                    ObjectId = ((!TargetBorrow || SkillTarget == null) ? CasterObject.ObjectId : SkillTarget.ObjectId),
                                    SkillId = SkillId,
                                    SkillLevel = SkillLevel,
                                    SkillInscription = Id,
                                    ActionId = ActionId,
                                    SkillSegment = SegmentId
                                });
                            }

                            if (b2 > 1)
                                SkillLocation = ComputingClass.前方坐标(CasterObject.CurrentPosition, CasterObject.CurrentDirection, num17);

                            SegmentId++;
                        }
                        else
                        {
                            if (ComputingClass.CheckProbability(c_03.失败Buff概率))
                                CasterObject.OnAddBuff(c_03.失败Id, CasterObject);

                            CasterObject.HardTime = MainProcess.CurrentTime.AddMilliseconds(c_03.ItSelf硬直时间);
                            SegmentId = b2;
                        }

                        if (b2 > 1)
                        {
                            int num19 = keyValuePair.Key + (int)(c_03.ItSelf位移耗时 * 60);

                            while (Nodes.ContainsKey(num19))
                                num19++;

                            Nodes.Add(num19, keyValuePair.Value);
                        }
                    }
                    else if (!c_03.推动目标位移)
                    {
                        foreach (var item in Hits)
                        {
                            if ((item.Value.Feedback & SkillHitFeedback.Miss) != SkillHitFeedback.正常 || (item.Value.Feedback & SkillHitFeedback.丢失) != SkillHitFeedback.正常 || (item.Value.Feedback & SkillHitFeedback.死亡) != SkillHitFeedback.正常 || ComputingClass.CheckProbability(c_03.推动目标概率) || item.Value.Object.IsSpecificType(CasterObject, c_03.推动目标类型))
                                continue;

                            byte[] 目标位移距离 = c_03.目标位移距离;
                            int val = ((((目标位移距离 != null) ? 目标位移距离.Length : 0) > SkillLevel) ? c_03.目标位移距离[SkillLevel] : 0);
                            int num20 = ComputingClass.GridDistance(CasterObject.CurrentPosition, item.Value.Object.CurrentPosition);
                            int num21 = Math.Max(0, Math.Min(8 - num20, val));

                            if (num21 == 0) continue;

                            var 方向 = ComputingClass.GetDirection(CasterObject.CurrentPosition, item.Value.Object.CurrentPosition);
                            var 锚点2 = ComputingClass.前方坐标(item.Value.Object.CurrentPosition, 方向, num21);

                            if (!item.Value.Object.CanBeDisplaced(CasterObject, 锚点2, num21, 0, false, out var point3, out var array4))
                                continue;

                            if (ComputingClass.CheckProbability(c_03.位移Buff概率))
                                item.Value.Object.OnAddBuff(c_03.目标位移编号, CasterObject);

                            if (ComputingClass.CheckProbability(c_03.附加Buff概率) && item.Value.Object.IsSpecificType(CasterObject, c_03.限定附加类型))
                                item.Value.Object.OnAddBuff(c_03.目标附加编号, CasterObject);

                            item.Value.Object.CurrentDirection = ComputingClass.GetDirection(item.Value.Object.CurrentPosition, CasterObject.CurrentPosition);
                            ushort num22 = (ushort)(ComputingClass.GridDistance(item.Value.Object.CurrentPosition, point3) * c_03.目标位移耗时);
                            item.Value.Object.BusyTime = MainProcess.CurrentTime.AddMilliseconds((num22 * 60));
                            item.Value.Object.HardTime = MainProcess.CurrentTime.AddMilliseconds((num22 * 60 + c_03.目标硬直时间));
                            item.Value.Object.SendPacket(new ObjectPassiveDisplacementPacket
                            {
                                位移坐标 = point3,
                                位移速度 = num22,
                                对象编号 = item.Value.Object.ObjectId,
                                位移朝向 = (ushort)item.Value.Object.CurrentDirection
                            });
                            item.Value.Object.ItSelf移动时处理(point3);
                            if (c_03.BoostSkillExp && !GainExperience && CasterObject is PlayerObject playerObj)
                            {
                                playerObj.SkillGainExp(SkillId);
                                GainExperience = true;
                            }
                        }
                    }
                }
                else if (task is C_04_CalculateTargetTemptation c_04)
                {
                    if (CasterObject is PlayerObject playerObj)
                        foreach (var item in Hits)
                            playerObj.玩家诱惑目标(this, c_04, item.Value.Object);
                }
                else if (task is C_06_CalculatePetSummoning c_06)
                {
                    if (c_06.怪物召唤同伴)
                    {
                        if (c_06.召唤PetName == null || c_06.召唤PetName.Length == 0)
                            return;

                        if (Monsters.DataSheet.TryGetValue(c_06.召唤PetName, out var 对应模板))
                            _ = new MonsterObject(对应模板, ReleaseMap, int.MaxValue, new Point[] { ReleaseLocation }, true, true) { 存活时间 = MainProcess.CurrentTime.AddMinutes(1.0) };
                    }
                    else if (CasterObject is PlayerObject playerObj)
                    {
                        if (c_06.检查技能铭文 && (!playerObj.MainSkills表.TryGetValue(SkillId, out var skill) || skill.Id != Id))
                            return;

                        if (c_06.召唤PetName == null || c_06.召唤PetName.Length == 0)
                            return;

                        int num21 = ((c_06.召唤宠物数量?.Length > SkillLevel) ? c_06.召唤宠物数量[SkillLevel] : 0);
                        if (playerObj.Pets.Count < num21 && Monsters.DataSheet.TryGetValue(c_06.召唤PetName, out var value5))
                        {
                            byte GradeCap = (byte)((c_06.宠物GradeCap?.Length > SkillLevel) ? c_06.宠物GradeCap[SkillLevel] : 0);
                            PetObject 宠物实例 = new PetObject(playerObj, value5, SkillLevel, GradeCap, c_06.宠物BoundWeapons);
                            playerObj.ActiveConnection.SendPacket(new SyncPetLevelPacket
                            {
                                宠物编号 = 宠物实例.ObjectId,
                                宠物等级 = 宠物实例.宠物等级
                            });
                            playerObj.ActiveConnection.SendPacket(new GameErrorMessagePacket
                            {
                                错误代码 = 9473,
                                第一参数 = (int)playerObj.PetMode
                            });
                            playerObj.PetData.Add(宠物实例.PetData);
                            playerObj.Pets.Add(宠物实例);

                            if (c_06.GainSkillExp)
                                playerObj.SkillGainExp(c_06.经验SkillId);
                        }
                    }
                }
                else if (task is C_05_CalculateTargetReply c_05)
                {
                    foreach (var keyValuePair20 in Hits)
                        keyValuePair20.Value.Object.被动回复时处理(this, c_05);

                    if (c_05.GainSkillExp && Hits.Count != 0 && CasterObject is PlayerObject playerObj)
                        playerObj.SkillGainExp(c_05.经验SkillId);
                }
                else if (task is C_07_CalculateTargetTeleportation c_07 && CasterObject is PlayerObject playerObj)
                    playerObj.玩家瞬间移动(this, c_07);
            }

            if (Nodes.Count == 0)
            {
                CasterObject.SkillTasks.Remove(this);
                return;
            }

            AppointmentTime = ReleaseTime.AddMilliseconds(FightTime + Nodes.First().Key);
            Process();
        }
        public void SkillAbort()
        {
            Nodes.Clear();
            CasterObject.SendPacket(new 技能释放中断
            {
                对象编号 = ((!TargetBorrow || SkillTarget == null) ? CasterObject.ObjectId : SkillTarget.ObjectId),
                SkillId = SkillId,
                SkillLevel = SkillLevel,
                技能铭文 = Id,
                动作编号 = ActionId,
                技能分段 = SegmentId
            });
        }
    }
}
