using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameServer.Maps;
using GameServer.Data;
using GameServer.Networking;

namespace GameServer.Templates
{
	
	public class 技能实例
	{
		
		// (get) Token: 0x060006B0 RID: 1712 RVA: 0x00005F0E File Offset: 0x0000410E
		public int 来源编号
		{
			get
			{
				return this.技能来源.MapId;
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
				PlayerObject PlayerObject = this.技能来源 as PlayerObject;
				SkillData SkillData;
				if (PlayerObject != null && PlayerObject.MainSkills表.TryGetValue(this.技能模板.BindingLevelId, out SkillData))
				{
					return SkillData.技能等级.V;
				}
				TrapObject TrapObject = this.技能来源 as TrapObject;
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

		
		public 技能实例(MapObject 技能来源, GameSkills 技能模板, SkillData SkillData, byte 动作编号, MapInstance 释放地图, Point 释放位置, MapObject 技能目标, Point 技能锚点, 技能实例 父类技能, Dictionary<int, 命中详情> 命中列表 = null, bool 目标借位 = false)
		{
			
			
			this.技能来源 = 技能来源;
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
			this.命中列表 = (命中列表 ?? new Dictionary<int, 命中详情>());
			this.Nodes = new SortedDictionary<int, SkillTask>(技能模板.Nodes);
			if (this.Nodes.Count != 0)
			{
				this.技能来源.技能任务.Add(this);
				this.预约时间 = this.释放时间.AddMilliseconds((double)(this.飞行耗时 + this.Nodes.First<KeyValuePair<int, SkillTask>>().Key));
			}
		}

		
		public void 处理任务()
		{
			if ((this.预约时间 - this.处理计时).TotalMilliseconds > 5.0 && MainProcess.CurrentTime < this.预约时间)
			{
				return;
			}
			KeyValuePair<int, SkillTask> keyValuePair = this.Nodes.First<KeyValuePair<int, SkillTask>>();
			this.Nodes.Remove(keyValuePair.Key);
			SkillTask value = keyValuePair.Value;
			this.处理计时 = this.预约时间;
			if (value != null)
			{
				A_00_触发SubSkills a_00_触发SubSkills = value as A_00_触发SubSkills;
				if (a_00_触发SubSkills != null)
				{
					GameSkills 游戏技能;
					if (!GameSkills.DataSheet.TryGetValue(a_00_触发SubSkills.触发SkillName, out 游戏技能))
					{
						goto IL_33E1;
					}
					bool flag = true;
					if (a_00_触发SubSkills.CalculateTriggerProbability)
					{
						if (a_00_触发SubSkills.CalculateLuckyProbability)
						{
							flag = ComputingClass.计算概率(ComputingClass.计算幸运(this.技能来源[GameObjectStats.幸运等级]));
						}
						else
						{
							flag = ComputingClass.计算概率(a_00_触发SubSkills.技能触发概率 + ((a_00_触发SubSkills.增加概率Buff == 0 || !this.技能来源.Buff列表.ContainsKey(a_00_触发SubSkills.增加概率Buff)) ? 0f : a_00_触发SubSkills.Buff增加系数));
						}
					}
					if (flag && a_00_触发SubSkills.验证ItSelfBuff)
					{
						if (!this.技能来源.Buff列表.ContainsKey(a_00_触发SubSkills.Id))
						{
							flag = false;
						}
						else if (a_00_触发SubSkills.触发成功移除)
						{
							this.技能来源.移除Buff时处理(a_00_触发SubSkills.Id);
						}
					}
					if (flag && a_00_触发SubSkills.验证铭文技能)
					{
						PlayerObject PlayerObject = this.技能来源 as PlayerObject;
						if (PlayerObject != null)
						{
							int num = (int)(a_00_触发SubSkills.所需Id / 10);
							int num2 = (int)(a_00_触发SubSkills.所需Id % 10);
							SkillData SkillData;
							if (!PlayerObject.MainSkills表.TryGetValue((ushort)num, out SkillData))
							{
								flag = false;
							}
							else if (a_00_触发SubSkills.同组铭文无效)
							{
								flag = (num2 == (int)SkillData.Id);
							}
							else
							{
								flag = (num2 == 0 || num2 == (int)SkillData.Id);
							}
						}
					}
					if (!flag)
					{
						goto IL_33E1;
					}
					switch (a_00_触发SubSkills.技能触发方式)
					{
					case 技能触发方式.原点位置绝对触发:
						new 技能实例(this.技能来源, 游戏技能, this.SkillData, this.动作编号, this.释放地图, this.释放位置, this.技能目标, this.释放位置, this, null, false);
						goto IL_33E1;
					case 技能触发方式.锚点位置绝对触发:
						new 技能实例(this.技能来源, 游戏技能, this.SkillData, this.动作编号, this.释放地图, this.释放位置, this.技能目标, this.技能锚点, this, null, false);
						goto IL_33E1;
					case 技能触发方式.刺杀位置绝对触发:
						new 技能实例(this.技能来源, 游戏技能, this.SkillData, this.动作编号, this.释放地图, this.释放位置, this.技能目标, ComputingClass.前方坐标(this.释放位置, this.技能锚点, 2), this, null, false);
						goto IL_33E1;
					case 技能触发方式.目标命中绝对触发:
						using (Dictionary<int, 命中详情>.Enumerator enumerator = this.命中列表.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								KeyValuePair<int, 命中详情> keyValuePair2 = enumerator.Current;
								if ((keyValuePair2.Value.技能反馈 & 技能命中反馈.闪避) == 技能命中反馈.正常 && (keyValuePair2.Value.技能反馈 & 技能命中反馈.丢失) == 技能命中反馈.正常)
								{
									new 技能实例(this.技能来源, 游戏技能, this.SkillData, this.动作编号, this.释放地图, (this.父类技能 == null) ? this.释放位置 : this.技能锚点, keyValuePair2.Value.技能目标, keyValuePair2.Value.技能目标.当前坐标, this, null, false);
								}
							}
							goto IL_33E1;
						}
						break;
					case 技能触发方式.怪物死亡绝对触发:
						break;
					case 技能触发方式.怪物死亡换位触发:
						goto IL_42A;
					case 技能触发方式.怪物命中绝对触发:
						goto IL_4F2;
					case 技能触发方式.怪物命中概率触发:
						goto IL_33E1;
					case 技能触发方式.无目标锚点位触发:
						goto IL_5A7;
					case 技能触发方式.目标位置绝对触发:
						using (Dictionary<int, 命中详情>.Enumerator enumerator = this.命中列表.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								KeyValuePair<int, 命中详情> keyValuePair3 = enumerator.Current;
								new 技能实例(this.技能来源, 游戏技能, this.SkillData, this.动作编号, this.释放地图, this.释放位置, keyValuePair3.Value.技能目标, keyValuePair3.Value.技能目标.当前坐标, this, null, false);
							}
							goto IL_33E1;
						}
						goto IL_698;
					case 技能触发方式.正手反手随机触发:
						goto IL_698;
					case 技能触发方式.目标死亡绝对触发:
						using (Dictionary<int, 命中详情>.Enumerator enumerator = this.命中列表.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								KeyValuePair<int, 命中详情> keyValuePair4 = enumerator.Current;
								if ((keyValuePair4.Value.技能反馈 & 技能命中反馈.死亡) != 技能命中反馈.正常)
								{
									new 技能实例(this.技能来源, 游戏技能, this.SkillData, this.动作编号, this.释放地图, this.释放位置, null, keyValuePair4.Value.技能目标.当前坐标, this, null, false);
								}
							}
							goto IL_33E1;
						}
						goto IL_7A7;
					case 技能触发方式.目标闪避绝对触发:
						goto IL_7A7;
					default:
						goto IL_33E1;
					}
					using (Dictionary<int, 命中详情>.Enumerator enumerator = this.命中列表.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							KeyValuePair<int, 命中详情> keyValuePair5 = enumerator.Current;
							if (keyValuePair5.Value.技能目标 is MonsterObject && (keyValuePair5.Value.技能反馈 & 技能命中反馈.死亡) != 技能命中反馈.正常)
							{
								new 技能实例(this.技能来源, 游戏技能, this.SkillData, this.动作编号, this.释放地图, this.释放位置, null, keyValuePair5.Value.技能目标.当前坐标, this, null, false);
							}
						}
						goto IL_33E1;
					}
					IL_42A:
					using (Dictionary<int, 命中详情>.Enumerator enumerator = this.命中列表.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							KeyValuePair<int, 命中详情> keyValuePair6 = enumerator.Current;
							if (keyValuePair6.Value.技能目标 is MonsterObject && (keyValuePair6.Value.技能反馈 & 技能命中反馈.死亡) != 技能命中反馈.正常)
							{
								MapObject MapObject = this.技能来源;
								GameSkills 游戏技能2 = 游戏技能;
								SkillData SkillData2 = null;
								MapObject MapObject2 = keyValuePair6.Value.技能目标;
								byte b = MapObject2.动作编号;
								MapObject2.动作编号 = (byte)(b + 1);
								new 技能实例(MapObject, 游戏技能2, SkillData2, b, this.释放地图, keyValuePair6.Value.技能目标.当前坐标, keyValuePair6.Value.技能目标, keyValuePair6.Value.技能目标.当前坐标, this, null, true);
							}
						}
						goto IL_33E1;
					}
					IL_4F2:
					using (Dictionary<int, 命中详情>.Enumerator enumerator = this.命中列表.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							KeyValuePair<int, 命中详情> keyValuePair7 = enumerator.Current;
							if (keyValuePair7.Value.技能目标 is MonsterObject && (keyValuePair7.Value.技能反馈 & 技能命中反馈.丢失) == 技能命中反馈.正常)
							{
								new 技能实例(this.技能来源, 游戏技能, this.SkillData, this.动作编号, this.释放地图, (this.父类技能 == null) ? this.释放位置 : this.技能锚点, keyValuePair7.Value.技能目标, keyValuePair7.Value.技能目标.当前坐标, this, null, false);
							}
						}
						goto IL_33E1;
					}
					IL_5A7:
					if (this.命中列表.Count != 0)
					{
						if (this.命中列表.Values.FirstOrDefault((命中详情 O) => O.技能反馈 != 技能命中反馈.丢失) != null)
						{
							goto IL_33E1;
						}
					}
					new 技能实例(this.技能来源, 游戏技能, this.SkillData, this.动作编号, this.释放地图, this.释放位置, null, this.技能锚点, this, null, false);
					goto IL_33E1;
					IL_698:
					GameSkills 游戏技能3;
					if (ComputingClass.计算概率(0.5f) && GameSkills.DataSheet.TryGetValue(a_00_触发SubSkills.反手SkillName, out 游戏技能3))
					{
						new 技能实例(this.技能来源, 游戏技能3, this.SkillData, this.动作编号, this.释放地图, this.释放位置, null, this.技能锚点, this, null, false);
						goto IL_33E1;
					}
					new 技能实例(this.技能来源, 游戏技能, this.SkillData, this.动作编号, this.释放地图, this.释放位置, null, this.技能锚点, this, null, false);
					goto IL_33E1;
					IL_7A7:
					using (Dictionary<int, 命中详情>.Enumerator enumerator = this.命中列表.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							KeyValuePair<int, 命中详情> keyValuePair8 = enumerator.Current;
							if ((keyValuePair8.Value.技能反馈 & 技能命中反馈.闪避) != 技能命中反馈.正常)
							{
								new 技能实例(this.技能来源, 游戏技能, this.SkillData, this.动作编号, this.释放地图, this.释放位置, null, keyValuePair8.Value.技能目标.当前坐标, this, null, false);
							}
						}
						goto IL_33E1;
					}
				}
				A_01_触发对象Buff 触发Buff = value as A_01_触发对象Buff;
				if (触发Buff != null)
				{
					bool flag2 = false;
					if (触发Buff.角色ItSelf添加)
					{
						bool flag3 = true;
						if (!ComputingClass.计算概率(触发Buff.Buff触发概率))
						{
							flag3 = false;
						}
						if (flag3 && 触发Buff.验证铭文技能)
						{
							PlayerObject PlayerObject2 = this.技能来源 as PlayerObject;
							if (PlayerObject2 != null)
							{
								int num3 = (int)(触发Buff.所需Id / 10);
								int num4 = (int)(触发Buff.所需Id % 10);
								SkillData SkillData3;
								if (!PlayerObject2.MainSkills表.TryGetValue((ushort)num3, out SkillData3))
								{
									flag3 = false;
								}
								else if (触发Buff.同组铭文无效)
								{
									flag3 = (num4 == (int)SkillData3.Id);
								}
								else
								{
									flag3 = (num4 == 0 || num4 == (int)SkillData3.Id);
								}
							}
						}
						if (flag3 && 触发Buff.验证ItSelfBuff)
						{
							if (!this.技能来源.Buff列表.ContainsKey(触发Buff.Id))
							{
								flag3 = false;
							}
							else
							{
								if (触发Buff.触发成功移除)
								{
									this.技能来源.移除Buff时处理(触发Buff.Id);
								}
								if (触发Buff.移除伴生Buff)
								{
									this.技能来源.移除Buff时处理(触发Buff.移除伴生编号);
								}
							}
						}
						if (flag3 && 触发Buff.验证分组Buff && this.技能来源.Buff列表.Values.FirstOrDefault((BuffData O) => O.Buff分组 == 触发Buff.BuffGroupId) == null)
						{
							flag3 = false;
						}
						if (flag3 && 触发Buff.VerifyTargetBuff && this.命中列表.Values.FirstOrDefault(delegate(命中详情 O)
						{
							BuffData BuffData2;
							return (O.技能反馈 & 技能命中反馈.闪避) == 技能命中反馈.正常 && (O.技能反馈 & 技能命中反馈.丢失) == 技能命中反馈.正常 && O.技能目标.Buff列表.TryGetValue(触发Buff.目标Id, out BuffData2) && BuffData2.当前层数.V >= 触发Buff.所需Buff层数;
						}) == null)
						{
							flag3 = false;
						}
						if (flag3 && 触发Buff.VerifyTargetType && this.命中列表.Values.FirstOrDefault((命中详情 O) => (O.技能反馈 & 技能命中反馈.闪避) == 技能命中反馈.正常 && (O.技能反馈 & 技能命中反馈.丢失) == 技能命中反馈.正常 && O.技能目标.特定类型(this.技能来源, 触发Buff.所需目标类型)) == null)
						{
							flag3 = false;
						}
						if (flag3)
						{
							this.技能来源.添加Buff时处理(触发Buff.触发Id, this.技能来源);
							if (触发Buff.伴生Id > 0)
							{
								this.技能来源.添加Buff时处理(触发Buff.伴生Id, this.技能来源);
							}
							flag2 = true;
						}
					}
					else
					{
						bool flag4 = true;
						if (触发Buff.验证ItSelfBuff)
						{
							if (!this.技能来源.Buff列表.ContainsKey(触发Buff.Id))
							{
								flag4 = false;
							}
							else
							{
								if (触发Buff.触发成功移除)
								{
									this.技能来源.移除Buff时处理(触发Buff.Id);
								}
								if (触发Buff.移除伴生Buff)
								{
									this.技能来源.移除Buff时处理(触发Buff.移除伴生编号);
								}
							}
						}
						if (flag4 && 触发Buff.验证分组Buff && this.技能来源.Buff列表.Values.FirstOrDefault((BuffData O) => O.Buff分组 == 触发Buff.BuffGroupId) == null)
						{
							flag4 = false;
						}
						if (flag4 && 触发Buff.验证铭文技能)
						{
							PlayerObject PlayerObject3 = this.技能来源 as PlayerObject;
							if (PlayerObject3 != null)
							{
								int num5 = (int)(触发Buff.所需Id / 10);
								int num6 = (int)(触发Buff.所需Id % 10);
								SkillData SkillData4;
								if (!PlayerObject3.MainSkills表.TryGetValue((ushort)num5, out SkillData4))
								{
									flag4 = false;
								}
								else if (触发Buff.同组铭文无效)
								{
									flag4 = (num6 == (int)SkillData4.Id);
								}
								else
								{
									flag4 = (num6 == 0 || num6 == (int)SkillData4.Id);
								}
							}
						}
						if (flag4)
						{
							foreach (KeyValuePair<int, 命中详情> keyValuePair9 in this.命中列表)
							{
								bool flag5 = true;
								if ((keyValuePair9.Value.技能反馈 & (技能命中反馈.闪避 | 技能命中反馈.丢失)) != 技能命中反馈.正常)
								{
									flag5 = false;
								}
								if (flag5 && !ComputingClass.计算概率(触发Buff.Buff触发概率))
								{
									flag5 = false;
								}
								if (flag5 && 触发Buff.VerifyTargetType && !keyValuePair9.Value.技能目标.特定类型(this.技能来源, 触发Buff.所需目标类型))
								{
									flag5 = false;
								}
								if (flag5 && 触发Buff.VerifyTargetBuff)
								{
									BuffData BuffData;
									flag5 = (keyValuePair9.Value.技能目标.Buff列表.TryGetValue(触发Buff.目标Id, out BuffData) && BuffData.当前层数.V >= 触发Buff.所需Buff层数);
								}
								if (flag5)
								{
									keyValuePair9.Value.技能目标.添加Buff时处理(触发Buff.触发Id, this.技能来源);
									if (触发Buff.伴生Id > 0)
									{
										keyValuePair9.Value.技能目标.添加Buff时处理(触发Buff.伴生Id, this.技能来源);
									}
									flag2 = true;
								}
							}
						}
					}
					if (flag2 && 触发Buff.增加技能经验)
					{
						PlayerObject PlayerObject4 = this.技能来源 as PlayerObject;
						if (PlayerObject4 != null)
						{
							PlayerObject4.技能增加经验(触发Buff.经验SkillId);
						}
					}
				}
				else
				{
					A_02_TriggerTrapSkills a_02_TriggerTrapSkills = value as A_02_TriggerTrapSkills;
					if (a_02_TriggerTrapSkills != null)
					{
						SkillTraps 陷阱模板;
						if (SkillTraps.DataSheet.TryGetValue(a_02_TriggerTrapSkills.TriggerTrapSkills, out 陷阱模板))
						{
							int num7 = 0;
							
							foreach (Point 坐标 in ComputingClass.技能范围(this.技能锚点, ComputingClass.计算方向(this.释放位置, this.技能锚点), a_02_TriggerTrapSkills.NumberTrapsTriggered))
							{
								if (!this.释放地图.地形阻塞(坐标))
								{
									if (!陷阱模板.AllowStacking)
									{
										IEnumerable<MapObject> source = this.释放地图[坐标];
										Func<MapObject, bool> predicate=null;
										if (predicate == null)
										{
											predicate  = delegate(MapObject O)
											{
												TrapObject TrapObject2 = O as TrapObject;
												return TrapObject2 != null && TrapObject2.陷阱GroupId != 0 && TrapObject2.陷阱GroupId == 陷阱模板.GroupId;
											};
										}
										if (source.FirstOrDefault(predicate) != null)
										{
											goto IL_E2A;
										}
									}
									this.技能来源.陷阱列表.Add(new TrapObject(this.技能来源, 陷阱模板, this.释放地图, 坐标));
									num7++;
								}
								IL_E2A:;
							}
							if (num7 != 0 && a_02_TriggerTrapSkills.经验SkillId != 0)
							{
								PlayerObject PlayerObject5 = this.技能来源 as PlayerObject;
								if (PlayerObject5 != null)
								{
									PlayerObject5.技能增加经验(a_02_TriggerTrapSkills.经验SkillId);
								}
							}
						}
					}
					else
					{
						B_00_技能切换通知 b_00_技能切换通知 = value as B_00_技能切换通知;
						if (b_00_技能切换通知 != null)
						{
							if (this.技能来源.Buff列表.ContainsKey(b_00_技能切换通知.SkillTagId))
							{
								if (b_00_技能切换通知.允许移除标记)
								{
									this.技能来源.移除Buff时处理(b_00_技能切换通知.SkillTagId);
								}
							}
							else if (GameBuffs.DataSheet.ContainsKey(b_00_技能切换通知.SkillTagId))
							{
								this.技能来源.添加Buff时处理(b_00_技能切换通知.SkillTagId, this.技能来源);
							}
						}
						else
						{
							B_01_技能释放通知 b_01_技能释放通知 = value as B_01_技能释放通知;
							if (b_01_技能释放通知 != null)
							{
								if (b_01_技能释放通知.调整角色朝向)
								{
									GameDirection GameDirection = ComputingClass.计算方向(this.释放位置, this.技能锚点);
									if (GameDirection == this.技能来源.当前方向)
									{
										this.技能来源.发送封包(new ObjectRotationDirectionPacket
										{
											对象编号 = this.技能来源.MapId,
											对象朝向 = (ushort)GameDirection,
											转向耗时 = ((ushort)((this.技能来源 is PlayerObject) ? 0 : 1))
										});
									}
									else
									{
										this.技能来源.当前方向 = ComputingClass.计算方向(this.释放位置, this.技能锚点);
									}
								}
								if (b_01_技能释放通知.移除技能标记 && this.技能模板.SkillTagId != 0)
								{
									this.技能来源.移除Buff时处理(this.技能模板.SkillTagId);
								}
								if (b_01_技能释放通知.ItSelfCooldown != 0 || b_01_技能释放通知.Buff增加冷却)
								{
									if (this.检查计数)
									{
										PlayerObject PlayerObject6 = this.技能来源 as PlayerObject;
										if (PlayerObject6 != null)
										{
											DataMonitor<byte> 剩余次数 = this.SkillData.剩余次数;
											if ((剩余次数.V -= 1) <= 0)
											{
												this.技能来源.冷却记录[(int)this.SkillId | 16777216] = this.释放时间.AddMilliseconds((this.SkillData.计数时间 - MainProcess.CurrentTime).TotalMilliseconds);
											}
											PlayerObject6.网络连接.发送封包(new SyncSkillCountPacket
											{
												SkillId = this.SkillData.SkillId.V,
												SkillCount = this.SkillData.剩余次数.V,
												技能冷却 = (int)(this.SkillData.计数时间 - MainProcess.CurrentTime).TotalMilliseconds
											});
											goto IL_11B7;
										}
									}
									if (b_01_技能释放通知.ItSelfCooldown > 0 || b_01_技能释放通知.Buff增加冷却)
									{
										int num8 = b_01_技能释放通知.ItSelfCooldown;
										if (b_01_技能释放通知.Buff增加冷却 && this.技能来源.Buff列表.ContainsKey(b_01_技能释放通知.增加冷却Buff))
										{
											num8 += b_01_技能释放通知.冷却增加时间;
										}
										DateTime dateTime = this.释放时间.AddMilliseconds((double)num8);
										DateTime t = this.技能来源.冷却记录.ContainsKey((int)this.SkillId | 16777216) ? this.技能来源.冷却记录[(int)this.SkillId | 16777216] : default(DateTime);
										if (num8 > 0 && dateTime > t)
										{
											this.技能来源.冷却记录[(int)this.SkillId | 16777216] = dateTime;
											this.技能来源.发送封包(new AddedSkillCooldownPacket
											{
												冷却编号 = ((int)this.SkillId | 16777216),
												Cooldown = num8
											});
										}
									}
								}
								IL_11B7:
								PlayerObject PlayerObject7 = this.技能来源 as PlayerObject;
								if (PlayerObject7 != null && b_01_技能释放通知.分组Cooldown != 0 && this.GroupId != 0)
								{
									DateTime dateTime2 = this.释放时间.AddMilliseconds((double)b_01_技能释放通知.分组Cooldown);
									DateTime t2 = PlayerObject7.冷却记录.ContainsKey((int)(this.GroupId | 0)) ? PlayerObject7.冷却记录[(int)(this.GroupId | 0)] : default(DateTime);
									if (dateTime2 > t2)
									{
										PlayerObject7.冷却记录[(int)(this.GroupId | 0)] = dateTime2;
									}
									this.技能来源.发送封包(new AddedSkillCooldownPacket
									{
										冷却编号 = (int)(this.GroupId | 0),
										Cooldown = b_01_技能释放通知.分组Cooldown
									});
								}
								if (b_01_技能释放通知.角色忙绿时间 != 0)
								{
									this.技能来源.忙碌时间 = this.释放时间.AddMilliseconds((double)b_01_技能释放通知.角色忙绿时间);
								}
								if (b_01_技能释放通知.发送释放通知)
								{
									MapObject MapObject3 = this.技能来源;
									开始释放技能 开始释放技能 = new 开始释放技能();
									开始释放技能.对象编号 = ((!this.目标借位 || this.技能目标 == null) ? this.技能来源.MapId : this.技能目标.MapId);
									开始释放技能.SkillId = this.SkillId;
									开始释放技能.技能等级 = this.技能等级;
									开始释放技能.技能铭文 = this.Id;
									开始释放技能.锚点坐标 = this.技能锚点;
									开始释放技能.动作编号 = this.动作编号;
									MapObject MapObject4 = this.技能目标;
									开始释放技能.目标编号 = ((MapObject4 != null) ? MapObject4.MapId : 0);
									开始释放技能.锚点高度 = this.释放地图.地形高度(this.技能锚点);
									MapObject3.发送封包(开始释放技能);
								}
							}
							else
							{
								B_02_技能命中通知 b_02_技能命中通知 = value as B_02_技能命中通知;
								if (b_02_技能命中通知 != null)
								{
									if (b_02_技能命中通知.命中扩展通知)
									{
										this.技能来源.发送封包(new 触发技能扩展
										{
											对象编号 = ((!this.目标借位 || this.技能目标 == null) ? this.技能来源.MapId : this.技能目标.MapId),
											SkillId = this.SkillId,
											技能等级 = this.技能等级,
											技能铭文 = this.Id,
											动作编号 = this.动作编号,
											命中描述 = 命中详情.命中描述(this.命中列表, this.飞行耗时)
										});
									}
									else
									{
										this.技能来源.发送封包(new 触发技能正常
										{
											对象编号 = ((!this.目标借位 || this.技能目标 == null) ? this.技能来源.MapId : this.技能目标.MapId),
											SkillId = this.SkillId,
											技能等级 = this.技能等级,
											技能铭文 = this.Id,
											动作编号 = this.动作编号,
											命中描述 = 命中详情.命中描述(this.命中列表, this.飞行耗时)
										});
									}
									if (b_02_技能命中通知.计算飞行耗时)
									{
										this.飞行耗时 = ComputingClass.网格距离(this.释放位置, this.技能锚点) * b_02_技能命中通知.单格飞行耗时;
									}
								}
								else
								{
									B_03_前摇结束通知 b_03_前摇结束通知 = value as B_03_前摇结束通知;
									if (b_03_前摇结束通知 != null)
									{
										if (b_03_前摇结束通知.计算攻速缩减)
										{
											this.攻速缩减 = ComputingClass.Value限制(ComputingClass.计算攻速(-5), this.攻速缩减 + ComputingClass.计算攻速(this.技能来源[GameObjectStats.AttackSpeed]), ComputingClass.计算攻速(5));
											if (this.攻速缩减 != 0)
											{
												foreach (KeyValuePair<int, SkillTask> keyValuePair10 in this.Nodes)
												{
													if (keyValuePair10.Value is B_04_后摇结束通知)
													{
														int num9 = keyValuePair10.Key - this.攻速缩减;
														while (this.Nodes.ContainsKey(num9))
														{
															num9++;
														}
														this.Nodes.Remove(keyValuePair10.Key);
														this.Nodes.Add(num9, keyValuePair10.Value);
														break;
													}
												}
											}
										}
										if (b_03_前摇结束通知.禁止行走时间 != 0)
										{
											this.技能来源.行走时间 = this.释放时间.AddMilliseconds((double)b_03_前摇结束通知.禁止行走时间);
										}
										if (b_03_前摇结束通知.禁止奔跑时间 != 0)
										{
											this.技能来源.奔跑时间 = this.释放时间.AddMilliseconds((double)b_03_前摇结束通知.禁止奔跑时间);
										}
										if (b_03_前摇结束通知.角色硬直时间 != 0)
										{
											this.技能来源.硬直时间 = this.释放时间.AddMilliseconds((double)(b_03_前摇结束通知.计算攻速缩减 ? (b_03_前摇结束通知.角色硬直时间 - this.攻速缩减) : b_03_前摇结束通知.角色硬直时间));
										}
										if (b_03_前摇结束通知.发送结束通知)
										{
											this.技能来源.发送封包(new 触发技能正常
											{
												对象编号 = ((!this.目标借位 || this.技能目标 == null) ? this.技能来源.MapId : this.技能目标.MapId),
												SkillId = this.SkillId,
												技能等级 = this.技能等级,
												技能铭文 = this.Id,
												动作编号 = this.动作编号
											});
										}
										if (b_03_前摇结束通知.解除技能陷阱)
										{
											TrapObject TrapObject = this.技能来源 as TrapObject;
											if (TrapObject != null)
											{
												TrapObject.陷阱消失处理();
											}
										}
									}
									else
									{
										B_04_后摇结束通知 b_04_后摇结束通知 = value as B_04_后摇结束通知;
										if (b_04_后摇结束通知 != null)
										{
											this.技能来源.发送封包(new 技能释放完成
											{
												SkillId = this.SkillId,
												动作编号 = this.动作编号
											});
											if (b_04_后摇结束通知.后摇结束死亡)
											{
												this.技能来源.ItSelf死亡处理(null, false);
											}
										}
										else
										{
											C_00_计算技能锚点 c_00_计算技能锚点 = value as C_00_计算技能锚点;
											if (c_00_计算技能锚点 != null)
											{
												if (c_00_计算技能锚点.计算当前位置)
												{
													this.技能目标 = null;
													if (c_00_计算技能锚点.计算当前方向)
													{
														this.技能锚点 = ComputingClass.前方坐标(this.技能来源.当前坐标, this.技能来源.当前方向, c_00_计算技能锚点.技能最近距离);
													}
													else
													{
														this.技能锚点 = ComputingClass.前方坐标(this.技能来源.当前坐标, this.技能锚点, c_00_计算技能锚点.技能最近距离);
													}
												}
												else if (ComputingClass.网格距离(this.释放位置, this.技能锚点) > c_00_计算技能锚点.MaxDistance)
												{
													this.技能目标 = null;
													this.技能锚点 = ComputingClass.前方坐标(this.释放位置, this.技能锚点, c_00_计算技能锚点.MaxDistance);
												}
												else if (ComputingClass.网格距离(this.释放位置, this.技能锚点) < c_00_计算技能锚点.技能最近距离)
												{
													this.技能目标 = null;
													if (this.释放位置 == this.技能锚点)
													{
														this.技能锚点 = ComputingClass.前方坐标(this.释放位置, this.技能来源.当前方向, c_00_计算技能锚点.技能最近距离);
													}
													else
													{
														this.技能锚点 = ComputingClass.前方坐标(this.释放位置, this.技能锚点, c_00_计算技能锚点.技能最近距离);
													}
												}
											}
											else
											{
												C_01_计算命中目标 c_01_计算命中目标 = value as C_01_计算命中目标;
												if (c_01_计算命中目标 != null)
												{
													if (c_01_计算命中目标.清空命中列表)
													{
														this.命中列表 = new Dictionary<int, 命中详情>();
													}
													if (c_01_计算命中目标.技能能否穿墙 || !this.释放地图.地形遮挡(this.释放位置, this.技能锚点))
													{
														switch (c_01_计算命中目标.技能锁定方式)
														{
														case 技能锁定类型.锁定ItSelf:
															this.技能来源.被技能命中处理(this, c_01_计算命中目标);
															break;
														case 技能锁定类型.锁定目标:
														{
															MapObject MapObject5 = this.技能目标;
															if (MapObject5 != null)
															{
																MapObject5.被技能命中处理(this, c_01_计算命中目标);
															}
															break;
														}
														case 技能锁定类型.锁定ItSelf坐标:
															foreach (Point 坐标2 in ComputingClass.技能范围(this.技能来源.当前坐标, ComputingClass.计算方向(this.释放位置, this.技能锚点), c_01_计算命中目标.技能范围类型))
															{
																foreach (MapObject MapObject6 in this.释放地图[坐标2])
																{
																	MapObject6.被技能命中处理(this, c_01_计算命中目标);
																}
															}
															break;
														case 技能锁定类型.锁定目标坐标:
														{
															MapObject MapObject7 = this.技能目标;
															foreach (Point 坐标3 in ComputingClass.技能范围((MapObject7 != null) ? MapObject7.当前坐标 : this.技能锚点, ComputingClass.计算方向(this.释放位置, this.技能锚点), c_01_计算命中目标.技能范围类型))
															{
																foreach (MapObject MapObject8 in this.释放地图[坐标3])
																{
																	MapObject8.被技能命中处理(this, c_01_计算命中目标);
																}
															}
															break;
														}
														case 技能锁定类型.锁定锚点坐标:
															foreach (Point 坐标4 in ComputingClass.技能范围(this.技能锚点, ComputingClass.计算方向(this.释放位置, this.技能锚点), c_01_计算命中目标.技能范围类型))
															{
																foreach (MapObject MapObject9 in this.释放地图[坐标4])
																{
																	MapObject9.被技能命中处理(this, c_01_计算命中目标);
																}
															}
															break;
														case 技能锁定类型.放空锁定ItSelf:
															foreach (Point 坐标5 in ComputingClass.技能范围(this.技能锚点, ComputingClass.计算方向(this.释放位置, this.技能锚点), c_01_计算命中目标.技能范围类型))
															{
																foreach (MapObject MapObject10 in this.释放地图[坐标5])
																{
																	MapObject10.被技能命中处理(this, c_01_计算命中目标);
																}
															}
															if (this.命中列表.Count == 0)
															{
																this.技能来源.被技能命中处理(this, c_01_计算命中目标);
															}
															break;
														}
													}
													if (this.命中列表.Count == 0 && c_01_计算命中目标.放空结束技能)
													{
														if (c_01_计算命中目标.发送中断通知)
														{
															this.技能来源.发送封包(new 技能释放中断
															{
																对象编号 = this.技能来源.MapId,
																SkillId = this.SkillId,
																技能等级 = this.技能等级,
																技能铭文 = this.Id,
																动作编号 = this.动作编号,
																技能分段 = this.分段编号
															});
														}
														this.技能来源.技能任务.Remove(this);
														return;
													}
													if (c_01_计算命中目标.补发释放通知)
													{
														MapObject MapObject11 = this.技能来源;
														开始释放技能 开始释放技能2 = new 开始释放技能();
														开始释放技能2.对象编号 = ((!this.目标借位 || this.技能目标 == null) ? this.技能来源.MapId : this.技能目标.MapId);
														开始释放技能2.SkillId = this.SkillId;
														开始释放技能2.技能等级 = this.技能等级;
														开始释放技能2.技能铭文 = this.Id;
														MapObject MapObject12 = this.技能目标;
														开始释放技能2.目标编号 = ((MapObject12 != null) ? MapObject12.MapId : 0);
														开始释放技能2.锚点坐标 = this.技能锚点;
														开始释放技能2.锚点高度 = this.释放地图.地形高度(this.技能锚点);
														开始释放技能2.动作编号 = this.动作编号;
														MapObject11.发送封包(开始释放技能2);
													}
													if (this.命中列表.Count != 0 && c_01_计算命中目标.攻速提升类型 != SpecifyTargetType.None && this.命中列表[0].技能目标.特定类型(this.技能来源, c_01_计算命中目标.攻速提升类型))
													{
														this.攻速缩减 = ComputingClass.Value限制(ComputingClass.计算攻速(-5), this.攻速缩减 + ComputingClass.计算攻速(c_01_计算命中目标.攻速提升幅度), ComputingClass.计算攻速(5));
													}
													if (c_01_计算命中目标.清除目标状态 && c_01_计算命中目标.清除状态列表.Count != 0)
													{
														foreach (KeyValuePair<int, 命中详情> keyValuePair11 in this.命中列表)
														{
															if ((keyValuePair11.Value.技能反馈 & 技能命中反馈.闪避) == 技能命中反馈.正常 && (keyValuePair11.Value.技能反馈 & 技能命中反馈.丢失) == 技能命中反馈.正常)
															{
																foreach (ushort 编号 in c_01_计算命中目标.清除状态列表.ToList<ushort>())
																{
																	keyValuePair11.Value.技能目标.移除Buff时处理(编号);
																}
															}
														}
													}
													if (c_01_计算命中目标.触发PassiveSkill && this.命中列表.Count != 0 && ComputingClass.计算概率(c_01_计算命中目标.触发被动概率))
													{
														this.技能来源[GameObjectStats.技能标志] = 1;
													}
													if (c_01_计算命中目标.增加技能经验 && this.命中列表.Count != 0)
													{
														(this.技能来源 as PlayerObject).技能增加经验(c_01_计算命中目标.经验SkillId);
													}
													if (c_01_计算命中目标.计算飞行耗时 && c_01_计算命中目标.单格飞行耗时 != 0)
													{
														this.飞行耗时 = ComputingClass.网格距离(this.释放位置, this.技能锚点) * c_01_计算命中目标.单格飞行耗时;
													}
													if (c_01_计算命中目标.技能命中通知)
													{
														this.技能来源.发送封包(new 触发技能正常
														{
															对象编号 = ((!this.目标借位 || this.技能目标 == null) ? this.技能来源.MapId : this.技能目标.MapId),
															SkillId = this.SkillId,
															技能等级 = this.技能等级,
															技能铭文 = this.Id,
															动作编号 = this.动作编号,
															命中描述 = 命中详情.命中描述(this.命中列表, this.飞行耗时)
														});
													}
													if (c_01_计算命中目标.技能扩展通知)
													{
														this.技能来源.发送封包(new 触发技能扩展
														{
															对象编号 = ((!this.目标借位 || this.技能目标 == null) ? this.技能来源.MapId : this.技能目标.MapId),
															SkillId = this.SkillId,
															技能等级 = this.技能等级,
															技能铭文 = this.Id,
															动作编号 = this.动作编号,
															命中描述 = 命中详情.命中描述(this.命中列表, this.飞行耗时)
														});
													}
												}
												else
												{
													C_02_计算目标伤害 c_02_计算目标伤害 = value as C_02_计算目标伤害;
													if (c_02_计算目标伤害 != null)
													{
														float num10 = 1f;
														foreach (KeyValuePair<int, 命中详情> keyValuePair12 in this.命中列表)
														{
															if (c_02_计算目标伤害.点爆命中目标 && keyValuePair12.Value.技能目标.Buff列表.ContainsKey(c_02_计算目标伤害.点爆标记编号))
															{
																keyValuePair12.Value.技能目标.移除Buff时处理(c_02_计算目标伤害.点爆标记编号);
															}
															else if (c_02_计算目标伤害.点爆命中目标 && c_02_计算目标伤害.失败添加层数)
															{
																keyValuePair12.Value.技能目标.添加Buff时处理(c_02_计算目标伤害.点爆标记编号, this.技能来源);
																continue;
															}
															keyValuePair12.Value.技能目标.被动受伤时处理(this, c_02_计算目标伤害, keyValuePair12.Value, num10);
															if ((keyValuePair12.Value.技能反馈 & 技能命中反馈.丢失) == 技能命中反馈.正常)
															{
																if (c_02_计算目标伤害.数量衰减伤害)
																{
																	num10 = Math.Max(c_02_计算目标伤害.伤害衰减下限, num10 - c_02_计算目标伤害.伤害衰减系数);
																}
																this.技能来源.发送封包(new 触发命中特效
																{
																	对象编号 = ((!this.目标借位 || this.技能目标 == null) ? this.技能来源.MapId : this.技能目标.MapId),
																	SkillId = this.SkillId,
																	技能等级 = this.技能等级,
																	技能铭文 = this.Id,
																	动作编号 = this.动作编号,
																	目标编号 = keyValuePair12.Value.技能目标.MapId,
																	技能反馈 = (ushort)keyValuePair12.Value.技能反馈,
																	技能伤害 = -keyValuePair12.Value.技能伤害,
																	招架伤害 = keyValuePair12.Value.招架伤害
																});
															}
														}
														if (c_02_计算目标伤害.目标死亡回复)
														{
															foreach (KeyValuePair<int, 命中详情> keyValuePair13 in this.命中列表)
															{
																if ((keyValuePair13.Value.技能反馈 & 技能命中反馈.死亡) != 技能命中反馈.正常 && keyValuePair13.Value.技能目标.特定类型(this.技能来源, c_02_计算目标伤害.回复限定类型))
																{
																	int num11 = c_02_计算目标伤害.PhysicalRecoveryBase;
																	if (c_02_计算目标伤害.等级差减回复)
																	{
																		int Value = (int)(this.技能来源.当前等级 - keyValuePair13.Value.技能目标.当前等级) - c_02_计算目标伤害.减回复等级差;
																		int num12 = c_02_计算目标伤害.零回复等级差 - c_02_计算目标伤害.减回复等级差;
																		float num13 = (float)ComputingClass.Value限制(0, Value, num12) / (float)num12;
																		num11 = (int)((float)num11 - (float)num11 * num13);
																	}
																	if (num11 > 0)
																	{
																		this.技能来源.当前体力 += num11;
																		this.技能来源.发送封包(new 体力变动飘字
																		{
																			血量变化 = num11,
																			对象编号 = this.技能来源.MapId
																		});
																	}
																}
															}
														}
														if (c_02_计算目标伤害.击杀减少冷却)
														{
															int num14 = 0;
															foreach (KeyValuePair<int, 命中详情> keyValuePair14 in this.命中列表)
															{
																if ((keyValuePair14.Value.技能反馈 & 技能命中反馈.死亡) != 技能命中反馈.正常 && keyValuePair14.Value.技能目标.特定类型(this.技能来源, c_02_计算目标伤害.冷却减少类型))
																{
																	num14 += (int)c_02_计算目标伤害.冷却减少时间;
																}
															}
															if (num14 > 0)
															{
																DateTime dateTime3;
																if (this.技能来源.冷却记录.TryGetValue((int)c_02_计算目标伤害.冷却减少技能 | 16777216, out dateTime3))
																{
																	dateTime3 -= TimeSpan.FromMilliseconds((double)num14);
																	this.技能来源.冷却记录[(int)c_02_计算目标伤害.冷却减少技能 | 16777216] = dateTime3;
																	this.技能来源.发送封包(new AddedSkillCooldownPacket
																	{
																		冷却编号 = ((int)c_02_计算目标伤害.冷却减少技能 | 16777216),
																		Cooldown = Math.Max(0, (int)(dateTime3 - MainProcess.CurrentTime).TotalMilliseconds)
																	});
																}
																if (c_02_计算目标伤害.冷却减少分组 != 0)
																{
																	PlayerObject PlayerObject8 = this.技能来源 as PlayerObject;
																	DateTime dateTime4;
																	if (PlayerObject8 != null && PlayerObject8.冷却记录.TryGetValue((int)(c_02_计算目标伤害.冷却减少分组 | 0), out dateTime4))
																	{
																		dateTime4 -= TimeSpan.FromMilliseconds((double)num14);
																		PlayerObject8.冷却记录[(int)(c_02_计算目标伤害.冷却减少分组 | 0)] = dateTime4;
																		this.技能来源.发送封包(new AddedSkillCooldownPacket
																		{
																			冷却编号 = (int)(c_02_计算目标伤害.冷却减少分组 | 0),
																			Cooldown = Math.Max(0, (int)(dateTime4 - MainProcess.CurrentTime).TotalMilliseconds)
																		});
																	}
																}
															}
														}
														if (c_02_计算目标伤害.命中减少冷却)
														{
															int num15 = 0;
															foreach (KeyValuePair<int, 命中详情> keyValuePair15 in this.命中列表)
															{
																if ((keyValuePair15.Value.技能反馈 & 技能命中反馈.闪避) == 技能命中反馈.正常 && (keyValuePair15.Value.技能反馈 & 技能命中反馈.丢失) == 技能命中反馈.正常 && keyValuePair15.Value.技能目标.特定类型(this.技能来源, c_02_计算目标伤害.冷却减少类型))
																{
																	num15 += (int)c_02_计算目标伤害.冷却减少时间;
																}
															}
															if (num15 > 0)
															{
																DateTime dateTime5;
																if (this.技能来源.冷却记录.TryGetValue((int)c_02_计算目标伤害.冷却减少技能 | 16777216, out dateTime5))
																{
																	dateTime5 -= TimeSpan.FromMilliseconds((double)num15);
																	this.技能来源.冷却记录[(int)c_02_计算目标伤害.冷却减少技能 | 16777216] = dateTime5;
																	this.技能来源.发送封包(new AddedSkillCooldownPacket
																	{
																		冷却编号 = ((int)c_02_计算目标伤害.冷却减少技能 | 16777216),
																		Cooldown = Math.Max(0, (int)(dateTime5 - MainProcess.CurrentTime).TotalMilliseconds)
																	});
																}
																if (c_02_计算目标伤害.冷却减少分组 != 0)
																{
																	PlayerObject PlayerObject9 = this.技能来源 as PlayerObject;
																	DateTime dateTime6;
																	if (PlayerObject9 != null && PlayerObject9.冷却记录.TryGetValue((int)(c_02_计算目标伤害.冷却减少分组 | 0), out dateTime6))
																	{
																		dateTime6 -= TimeSpan.FromMilliseconds((double)num15);
																		PlayerObject9.冷却记录[(int)(c_02_计算目标伤害.冷却减少分组 | 0)] = dateTime6;
																		this.技能来源.发送封包(new AddedSkillCooldownPacket
																		{
																			冷却编号 = (int)(c_02_计算目标伤害.冷却减少分组 | 0),
																			Cooldown = Math.Max(0, (int)(dateTime6 - MainProcess.CurrentTime).TotalMilliseconds)
																		});
																	}
																}
															}
														}
														if (c_02_计算目标伤害.目标硬直时间 > 0)
														{
															foreach (KeyValuePair<int, 命中详情> keyValuePair16 in this.命中列表)
															{
																if ((keyValuePair16.Value.技能反馈 & 技能命中反馈.闪避) == 技能命中反馈.正常 && (keyValuePair16.Value.技能反馈 & 技能命中反馈.丢失) == 技能命中反馈.正常)
																{
																	MonsterObject MonsterObject = keyValuePair16.Value.技能目标 as MonsterObject;
																	if (MonsterObject != null && MonsterObject.Category != MonsterLevelType.Boss)
																	{
																		keyValuePair16.Value.技能目标.硬直时间 = MainProcess.CurrentTime.AddMilliseconds((double)c_02_计算目标伤害.目标硬直时间);
																	}
																}
															}
														}
														if (c_02_计算目标伤害.清除目标状态 && c_02_计算目标伤害.清除状态列表.Count != 0)
														{
															foreach (KeyValuePair<int, 命中详情> keyValuePair17 in this.命中列表)
															{
																if ((keyValuePair17.Value.技能反馈 & 技能命中反馈.闪避) == 技能命中反馈.正常 && (keyValuePair17.Value.技能反馈 & 技能命中反馈.丢失) == 技能命中反馈.正常)
																{
																	foreach (ushort 编号2 in c_02_计算目标伤害.清除状态列表)
																	{
																		keyValuePair17.Value.技能目标.移除Buff时处理(编号2);
																	}
																}
															}
														}
														if (c_02_计算目标伤害.增加技能经验 && this.命中列表.Count != 0)
														{
															(this.技能来源 as PlayerObject).技能增加经验(c_02_计算目标伤害.经验SkillId);
														}
														if (c_02_计算目标伤害.扣除武器持久 && this.命中列表.Count != 0)
														{
															(this.技能来源 as PlayerObject).武器损失持久();
														}
													}
													else
													{
														C_03_计算对象位移 c_03_计算对象位移 = value as C_03_计算对象位移;
														if (c_03_计算对象位移 != null)
														{
															byte[] ItSelf位移次数 = c_03_计算对象位移.ItSelf位移次数;
															byte b2 = (byte)((((ItSelf位移次数 != null) ? ItSelf位移次数.Length : 0) > (int)this.技能等级) ? c_03_计算对象位移.ItSelf位移次数[(int)this.技能等级] : 0);
															if (c_03_计算对象位移.角色ItSelf位移 && (this.释放地图 != this.技能来源.当前地图 || this.分段编号 >= b2))
															{
																this.技能来源.发送封包(new 技能释放中断
																{
																	对象编号 = ((!this.目标借位 || this.技能目标 == null) ? this.技能来源.MapId : this.技能目标.MapId),
																	SkillId = this.SkillId,
																	技能等级 = this.技能等级,
																	技能铭文 = this.Id,
																	动作编号 = this.动作编号,
																	技能分段 = this.分段编号
																});
																this.技能来源.发送封包(new 技能释放完成
																{
																	SkillId = this.SkillId,
																	动作编号 = this.动作编号
																});
																goto IL_33E1;
															}
															if (c_03_计算对象位移.角色ItSelf位移)
															{
																int 数量 = (int)(c_03_计算对象位移.推动目标位移 ? c_03_计算对象位移.连续推动数量 : 0);
																byte[] ItSelf位移距离 = c_03_计算对象位移.ItSelf位移距离;
																int num16 = (int)((((ItSelf位移距离 != null) ? ItSelf位移距离.Length : 0) > (int)this.技能等级) ? c_03_计算对象位移.ItSelf位移距离[(int)this.技能等级] : 0);
																int num17 = (c_03_计算对象位移.允许超出锚点 || c_03_计算对象位移.锚点反向位移) ? num16 : Math.Min(num16, ComputingClass.网格距离(this.释放位置, this.技能锚点));
																Point 锚点 = c_03_计算对象位移.锚点反向位移 ? ComputingClass.前方坐标(this.技能来源.当前坐标, ComputingClass.计算方向(this.技能锚点, this.技能来源.当前坐标), num17) : this.技能锚点;
																Point point;
																MapObject[] array2;
																if (this.技能来源.能否位移(this.技能来源, 锚点, num17, 数量, c_03_计算对象位移.能否穿越障碍, out point, out array2))
																{
																	foreach (MapObject MapObject13 in array2)
																	{
																		if (c_03_计算对象位移.目标位移编号 != 0 && ComputingClass.计算概率(c_03_计算对象位移.位移Buff概率))
																		{
																			MapObject13.添加Buff时处理(c_03_计算对象位移.目标位移编号, this.技能来源);
																		}
																		if (c_03_计算对象位移.目标附加编号 != 0 && ComputingClass.计算概率(c_03_计算对象位移.附加Buff概率) && MapObject13.特定类型(this.技能来源, c_03_计算对象位移.限定附加类型))
																		{
																			MapObject13.添加Buff时处理(c_03_计算对象位移.目标附加编号, this.技能来源);
																		}
																		MapObject13.当前方向 = ComputingClass.计算方向(MapObject13.当前坐标, this.技能来源.当前坐标);
																		Point point2 = ComputingClass.前方坐标(MapObject13.当前坐标, ComputingClass.计算方向(this.技能来源.当前坐标, MapObject13.当前坐标), 1);
																		MapObject13.忙碌时间 = MainProcess.CurrentTime.AddMilliseconds((double)(c_03_计算对象位移.目标位移耗时 * 60));
																		MapObject13.硬直时间 = MainProcess.CurrentTime.AddMilliseconds((double)(c_03_计算对象位移.目标位移耗时 * 60 + c_03_计算对象位移.目标硬直时间));
																		MapObject13.发送封包(new ObjectPassiveDisplacementPacket
																		{
																			位移坐标 = point2,
																			对象编号 = MapObject13.MapId,
																			位移朝向 = (ushort)MapObject13.当前方向,
																			位移速度 = c_03_计算对象位移.目标位移耗时
																		});
																		MapObject13.ItSelf移动时处理(point2);
																		if (c_03_计算对象位移.推动增加经验 && !this.经验增加)
																		{
																			(this.技能来源 as PlayerObject).技能增加经验(this.SkillId);
																			this.经验增加 = true;
																		}
																	}
																	if (c_03_计算对象位移.成功Id != 0 && ComputingClass.计算概率(c_03_计算对象位移.成功Buff概率))
																	{
																		this.技能来源.添加Buff时处理(c_03_计算对象位移.成功Id, this.技能来源);
																	}
																	this.技能来源.当前方向 = ComputingClass.计算方向(this.技能来源.当前坐标, point);
																	int num18 = (int)c_03_计算对象位移.ItSelf位移耗时 * this.技能来源.网格距离(point);
																	this.技能来源.忙碌时间 = MainProcess.CurrentTime.AddMilliseconds((double)(num18 * 60));
																	this.技能来源.发送封包(new ObjectPassiveDisplacementPacket
																	{
																		位移坐标 = point,
																		对象编号 = this.技能来源.MapId,
																		位移朝向 = (ushort)this.技能来源.当前方向,
																		位移速度 = (ushort)num18
																	});
																	this.技能来源.ItSelf移动时处理(point);
																	PlayerObject PlayerObject10 = this.技能来源 as PlayerObject;
																	if (PlayerObject10 != null && c_03_计算对象位移.位移增加经验 && !this.经验增加)
																	{
																		PlayerObject10.技能增加经验(this.SkillId);
																		this.经验增加 = true;
																	}
																	if (c_03_计算对象位移.多段位移通知)
																	{
																		this.技能来源.发送封包(new 触发技能正常
																		{
																			对象编号 = ((!this.目标借位 || this.技能目标 == null) ? this.技能来源.MapId : this.技能目标.MapId),
																			SkillId = this.SkillId,
																			技能等级 = this.技能等级,
																			技能铭文 = this.Id,
																			动作编号 = this.动作编号,
																			技能分段 = this.分段编号
																		});
																	}
																	if (b2 > 1)
																	{
																		this.技能锚点 = ComputingClass.前方坐标(this.技能来源.当前坐标, this.技能来源.当前方向, num17);
																	}
																	this.分段编号 += 1;
																}
																else
																{
																	if (ComputingClass.计算概率(c_03_计算对象位移.失败Buff概率))
																	{
																		this.技能来源.添加Buff时处理(c_03_计算对象位移.失败Id, this.技能来源);
																	}
																	this.技能来源.硬直时间 = MainProcess.CurrentTime.AddMilliseconds((double)c_03_计算对象位移.ItSelf硬直时间);
																	this.分段编号 = b2;
																}
																if (b2 > 1)
																{
																	int num19 = keyValuePair.Key + (int)(c_03_计算对象位移.ItSelf位移耗时 * 60);
																	while (this.Nodes.ContainsKey(num19))
																	{
																		num19++;
																	}
																	this.Nodes.Add(num19, keyValuePair.Value);
																	goto IL_33E1;
																}
																goto IL_33E1;
															}
															else
															{
																if (!c_03_计算对象位移.推动目标位移)
																{
																	goto IL_33E1;
																}
																using (Dictionary<int, 命中详情>.Enumerator enumerator = this.命中列表.GetEnumerator())
																{
																	while (enumerator.MoveNext())
																	{
																		KeyValuePair<int, 命中详情> keyValuePair18 = enumerator.Current;
																		if ((keyValuePair18.Value.技能反馈 & 技能命中反馈.闪避) == 技能命中反馈.正常 && (keyValuePair18.Value.技能反馈 & 技能命中反馈.丢失) == 技能命中反馈.正常 && (keyValuePair18.Value.技能反馈 & 技能命中反馈.死亡) == 技能命中反馈.正常 && ComputingClass.计算概率(c_03_计算对象位移.推动目标概率) && keyValuePair18.Value.技能目标.特定类型(this.技能来源, c_03_计算对象位移.推动目标类型))
																		{
																			byte[] 目标位移距离 = c_03_计算对象位移.目标位移距离;
																			int val = (int)((((目标位移距离 != null) ? 目标位移距离.Length : 0) > (int)this.技能等级) ? c_03_计算对象位移.目标位移距离[(int)this.技能等级] : 0);
																			int num20 = ComputingClass.网格距离(this.技能来源.当前坐标, keyValuePair18.Value.技能目标.当前坐标);
																			int num21 = Math.Max(0, Math.Min(8 - num20, val));
																			if (num21 != 0)
																			{
																				GameDirection 方向 = ComputingClass.计算方向(this.技能来源.当前坐标, keyValuePair18.Value.技能目标.当前坐标);
																				Point 锚点2 = ComputingClass.前方坐标(keyValuePair18.Value.技能目标.当前坐标, 方向, num21);
																				Point point3;
																				MapObject[] array4;
																				if (keyValuePair18.Value.技能目标.能否位移(this.技能来源, 锚点2, num21, 0, false, out point3, out array4))
																				{
																					if (ComputingClass.计算概率(c_03_计算对象位移.位移Buff概率))
																					{
																						keyValuePair18.Value.技能目标.添加Buff时处理(c_03_计算对象位移.目标位移编号, this.技能来源);
																					}
																					if (ComputingClass.计算概率(c_03_计算对象位移.附加Buff概率) && keyValuePair18.Value.技能目标.特定类型(this.技能来源, c_03_计算对象位移.限定附加类型))
																					{
																						keyValuePair18.Value.技能目标.添加Buff时处理(c_03_计算对象位移.目标附加编号, this.技能来源);
																					}
																					keyValuePair18.Value.技能目标.当前方向 = ComputingClass.计算方向(keyValuePair18.Value.技能目标.当前坐标, this.技能来源.当前坐标);
																					ushort num22 = (ushort)(ComputingClass.网格距离(keyValuePair18.Value.技能目标.当前坐标, point3) * (int)c_03_计算对象位移.目标位移耗时);
																					keyValuePair18.Value.技能目标.忙碌时间 = MainProcess.CurrentTime.AddMilliseconds((double)(num22 * 60));
																					keyValuePair18.Value.技能目标.硬直时间 = MainProcess.CurrentTime.AddMilliseconds((double)(num22 * 60 + c_03_计算对象位移.目标硬直时间));
																					keyValuePair18.Value.技能目标.发送封包(new ObjectPassiveDisplacementPacket
																					{
																						位移坐标 = point3,
																						位移速度 = num22,
																						对象编号 = keyValuePair18.Value.技能目标.MapId,
																						位移朝向 = (ushort)keyValuePair18.Value.技能目标.当前方向
																					});
																					keyValuePair18.Value.技能目标.ItSelf移动时处理(point3);
																					if (c_03_计算对象位移.推动增加经验 && !this.经验增加)
																					{
																						(this.技能来源 as PlayerObject).技能增加经验(this.SkillId);
																						this.经验增加 = true;
																					}
																				}
																			}
																		}
																	}
																	goto IL_33E1;
																}
															}
														}
														C_04_计算目标诱惑 c_04_计算目标诱惑 = value as C_04_计算目标诱惑;
														if (c_04_计算目标诱惑 != null)
														{
															using (Dictionary<int, 命中详情>.Enumerator enumerator = this.命中列表.GetEnumerator())
															{
																while (enumerator.MoveNext())
																{
																	KeyValuePair<int, 命中详情> keyValuePair19 = enumerator.Current;
																	(this.技能来源 as PlayerObject).玩家诱惑目标(this, c_04_计算目标诱惑, keyValuePair19.Value.技能目标);
																}
																goto IL_33E1;
															}
														}
														C_06_计算宠物召唤 c_06_计算宠物召唤 = value as C_06_计算宠物召唤;
														if (c_06_计算宠物召唤 != null)
														{
															if (c_06_计算宠物召唤.怪物召唤同伴)
															{
																if (c_06_计算宠物召唤.召唤宠物名字 == null || c_06_计算宠物召唤.召唤宠物名字.Length == 0)
																{
																	return;
																}
																Monsters 对应模板;
																if (Monsters.DataSheet.TryGetValue(c_06_计算宠物召唤.召唤宠物名字, out 对应模板))
																{
																	new MonsterObject(对应模板, this.释放地图, int.MaxValue, new Point[]
																	{
																		this.释放位置
																	}, true, true).存活时间 = MainProcess.CurrentTime.AddMinutes(1.0);
																}
															}
															else
															{
																PlayerObject PlayerObject11 = this.技能来源 as PlayerObject;
																if (PlayerObject11 != null)
																{
																	SkillData SkillData5;
																	if (c_06_计算宠物召唤.检查技能铭文 && (!PlayerObject11.MainSkills表.TryGetValue(this.SkillId, out SkillData5) || SkillData5.Id != this.Id))
																	{
																		return;
																	}
																	if (c_06_计算宠物召唤.召唤宠物名字 == null || c_06_计算宠物召唤.召唤宠物名字.Length == 0)
																	{
																		return;
																	}
																	byte[] 召唤宠物数量 = c_06_计算宠物召唤.召唤宠物数量;
																	int? num23 = (召唤宠物数量 != null) ? new int?(召唤宠物数量.Length) : null;
																	int i = (int)this.技能等级;
																	int num24 = (int)((num23.GetValueOrDefault() > i & num23 != null) ? c_06_计算宠物召唤.召唤宠物数量[(int)this.技能等级] : 0);
																	Monsters 召唤宠物;
																	if (PlayerObject11.宠物列表.Count < num24 && Monsters.DataSheet.TryGetValue(c_06_计算宠物召唤.召唤宠物名字, out 召唤宠物))
																	{
																		byte[] 宠物等级上限 = c_06_计算宠物召唤.宠物等级上限;
																		num23 = ((宠物等级上限 != null) ? new int?(宠物等级上限.Length) : null);
																		i = (int)this.技能等级;
																		byte 等级上限 = (byte)((num23.GetValueOrDefault() > i & num23 != null) ? c_06_计算宠物召唤.宠物等级上限[(int)this.技能等级] : 0);
																		PetObject PetObject = new PetObject(PlayerObject11, 召唤宠物, this.技能等级, 等级上限, c_06_计算宠物召唤.宠物绑定武器);
																		PlayerObject11.网络连接.发送封包(new SyncPetLevelPacket
																		{
																			宠物编号 = PetObject.MapId,
																			宠物等级 = PetObject.宠物等级
																		});
																		PlayerObject11.网络连接.发送封包(new GameErrorMessagePacket
																		{
																			错误代码 = 9473,
																			第一参数 = (int)PlayerObject11.PetMode
																		});
																		PlayerObject11.PetData.Add(PetObject.PetData);
																		PlayerObject11.宠物列表.Add(PetObject);
																		if (c_06_计算宠物召唤.增加技能经验)
																		{
																			PlayerObject11.技能增加经验(c_06_计算宠物召唤.经验SkillId);
																		}
																	}
																}
															}
														}
														else
														{
															C_05_计算目标回复 c_05_计算目标回复 = value as C_05_计算目标回复;
															if (c_05_计算目标回复 != null)
															{
																foreach (KeyValuePair<int, 命中详情> keyValuePair20 in this.命中列表)
																{
																	keyValuePair20.Value.技能目标.被动回复时处理(this, c_05_计算目标回复);
																}
																if (c_05_计算目标回复.增加技能经验 && this.命中列表.Count != 0)
																{
																	(this.技能来源 as PlayerObject).技能增加经验(c_05_计算目标回复.经验SkillId);
																}
															}
															else
															{
																C_07_计算目标瞬移 c_07_计算目标瞬移 = value as C_07_计算目标瞬移;
																if (c_07_计算目标瞬移 != null)
																{
																	(this.技能来源 as PlayerObject).玩家瞬间移动(this, c_07_计算目标瞬移);
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			IL_33E1:
			if (this.Nodes.Count == 0)
			{
				this.技能来源.技能任务.Remove(this);
				return;
			}
			this.预约时间 = this.释放时间.AddMilliseconds((double)(this.飞行耗时 + this.Nodes.First<KeyValuePair<int, SkillTask>>().Key));
			this.处理任务();
		}

		
		public void 技能中断()
		{
			this.Nodes.Clear();
			this.技能来源.发送封包(new 技能释放中断
			{
				对象编号 = ((!this.目标借位 || this.技能目标 == null) ? this.技能来源.MapId : this.技能目标.MapId),
				SkillId = this.SkillId,
				技能等级 = this.技能等级,
				技能铭文 = this.Id,
				动作编号 = this.动作编号,
				技能分段 = this.分段编号
			});
		}

		
		public GameSkills 技能模板;

		
		public SkillData SkillData;

		
		public MapObject 技能来源;

		
		public byte 动作编号;

		
		public byte 分段编号;

		
		public MapInstance 释放地图;

		
		public MapObject 技能目标;

		
		public Point 技能锚点;

		
		public Point 释放位置;

		
		public DateTime 释放时间;

		
		public 技能实例 父类技能;

		
		public bool 目标借位;

		
		public Dictionary<int, 命中详情> 命中列表;

		
		public int 飞行耗时;

		
		public int 攻速缩减;

		
		public bool 经验增加;

		
		public DateTime 处理计时;

		
		public DateTime 预约时间;

		
		public SortedDictionary<int, SkillTask> Nodes;
	}
}
