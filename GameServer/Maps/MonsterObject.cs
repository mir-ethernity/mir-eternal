using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameServer.Data;
using GameServer.Templates;
using GameServer.Networking;

namespace GameServer.Maps
{
	
	public sealed class MonsterObject : MapObject
	{
		
		public bool 禁止复活 { get; set; }

		
		public bool 尸体消失 { get; set; }

		
		public DateTime Attack时间 { get; set; }

		
		public DateTime 漫游时间 { get; set; }

		
		public DateTime 复活时间 { get; set; }

		
		public DateTime 消失时间 { get; set; }

		
		public DateTime 存活时间 { get; set; }

		
		public override int ProcessInterval
		{
			get
			{
				return 10;
			}
		}

		
		public override DateTime BusyTime
		{
			get
			{
				return base.BusyTime;
			}
			set
			{
				if (base.BusyTime < value)
				{
					this.HardTime = value;
					base.BusyTime = value;
				}
			}
		}

		
		public override DateTime HardTime
		{
			get
			{
				return base.HardTime;
			}
			set
			{
				if (base.HardTime < value)
				{
					base.HardTime = value;
				}
			}
		}

		
		public override int CurrentHP
		{
			get
			{
				return base.CurrentHP;
			}
			set
			{
				value = ComputingClass.ValueLimit(0, value, this[GameObjectStats.MaxHP]);
				if (base.CurrentHP != value)
				{
					base.CurrentHP = value;
					base.SendPacket(new SyncObjectHP
					{
						ObjectId = this.ObjectId,
						CurrentHP = this.CurrentHP,
						MaxHP = this[GameObjectStats.MaxHP]
					});
				}
			}
		}

		
		public override MapInstance CurrentMap
		{
			get
			{
				return base.CurrentMap;
			}
			set
			{
				if (this.CurrentMap != value)
				{
					MapInstance CurrentMap = base.CurrentMap;
					if (CurrentMap != null)
					{
						CurrentMap.移除对象(this);
					}
					base.CurrentMap = value;
					base.CurrentMap.添加对象(this);
				}
			}
		}

		
		public override GameDirection CurrentDirection
		{
			get
			{
				return base.CurrentDirection;
			}
			set
			{
				if (this.CurrentDirection != value)
				{
					base.CurrentDirection = value;
					base.SendPacket(new ObjectRotationDirectionPacket
					{
						转向耗时 = 100,
						对象编号 = this.ObjectId,
						对象朝向 = (ushort)value
					});
				}
			}
		}

		
		public override byte CurrentRank
		{
			get
			{
				return this.对象模板.Level;
			}
		}

		
		public override string ObjectName
		{
			get
			{
				return this.对象模板.MonsterName;
			}
		}

		
		public override GameObjectType ObjectType
		{
			get
			{
				return GameObjectType.Monster;
			}
		}

		
		public override ObjectSize ObjectSize
		{
			get
			{
				return this.对象模板.Size;
			}
		}

		
		public override int this[GameObjectStats Stat]
		{
			get
			{
				return base[Stat];
			}
			set
			{
				base[Stat] = value;
			}
		}

		
		public MonsterRaceType 怪物种族
		{
			get
			{
				return this.对象模板.Race;
			}
		}

		
		public MonsterLevelType Category
		{
			get
			{
				return this.对象模板.Category;
			}
		}

		
		public List<MonsterDrop> 怪物掉落
		{
			get
			{
				return this.对象模板.Drops;
			}
		}

		
		public ushort MonsterId
		{
			get
			{
				return this.对象模板.Id;
			}
		}

		
		public int 怪物经验
		{
			get
			{
				return (int)this.对象模板.ProvideExperience;
			}
		}

		
		public int RangeHate
		{
			get
			{
				if (this.CurrentMap.MapId != 80)
				{
					return (int)this.对象模板.RangeHate;
				}
				return 25;
			}
		}

		
		public int MobInterval
		{
			get
			{
				return (int)this.对象模板.MoveInterval;
			}
		}

		
		public int 切换间隔
		{
			get
			{
				return 5000;
			}
		}

		
		public int RoamingInterval
		{
			get
			{
				return (int)this.对象模板.RoamInterval;
			}
		}

		
		public int HateTime
		{
			get
			{
				return (int)this.对象模板.HateTime;
			}
		}

		
		public int CorpsePreservation
		{
			get
			{
				return (int)this.对象模板.CorpsePreservationDuration;
			}
		}

		
		public bool ForbbidenMove
		{
			get
			{
				return this.对象模板.ForbbidenMove;
			}
		}

		
		public bool CanBeDrivenBySkills
		{
			get
			{
				return this.对象模板.CanBeDrivenBySkills;
			}
		}

		
		public bool VisibleStealthTargets
		{
			get
			{
				return this.对象模板.VisibleStealthTargets;
			}
		}

		
		public bool CanBeControlledBySkills
		{
			get
			{
				return this.对象模板.CanBeControlledBySkills;
			}
		}

		
		public bool CanBeSeducedBySkills
		{
			get
			{
				return this.对象模板.CanBeSeducedBySkills;
			}
		}

		
		public float BaseTemptationProbability
		{
			get
			{
				return this.对象模板.BaseTemptationProbability;
			}
		}

		
		public bool ActiveAttackTarget
		{
			get
			{
				return this.对象模板.ActiveAttackTarget;
			}
		}

		
		public MonsterObject(PetObject 对应宠物)
		{
			
			
			this.ObjectId = ++MapGatewayProcess.对象编号;
			this.对象模板 = 对应宠物.Template;
			this.CurrentMap = 对应宠物.CurrentMap;
			this.CurrentPosition = 对应宠物.CurrentPosition;
			this.CurrentDirection = 对应宠物.CurrentDirection;
			this.宠物等级 = 对应宠物.宠物等级;
			this.禁止复活 = true;
			this.HateObject = new HateObject();
			this.存活时间 = MainProcess.CurrentTime.AddHours(2.0);
			base.RecoveryTime = MainProcess.CurrentTime.AddSeconds(5.0);
			this.Attack时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.RoamingInterval);
			this.StatsBonus[this] = 对应宠物.基础Stat;
			this.RefreshStats();
			this.CurrentHP = Math.Min(对应宠物.CurrentHP, this[GameObjectStats.MaxHP]);
			string text = this.对象模板.NormalAttackSkills;
			if (text != null && text.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.对象模板.NormalAttackSkills, out this.NormalAttackSkills);
			}
			string text2 = this.对象模板.ProbabilityTriggerSkills;
			if (text2 != null && text2.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.对象模板.ProbabilityTriggerSkills, out this.ProbabilityTriggerSkills);
			}
			string text3 = this.对象模板.EnterCombatSkills;
			if (text3 != null && text3.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.对象模板.EnterCombatSkills, out this.EnterCombatSkills);
			}
			string text4 = this.对象模板.ExitCombatSkills;
			if (text4 != null && text4.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.对象模板.ExitCombatSkills, out this.ExitCombatSkills);
			}
			string text5 = this.对象模板.DeathReleaseSkill;
			if (text5 != null && text5.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.对象模板.DeathReleaseSkill, out this.DeathReleaseSkill);
			}
			string text6 = this.对象模板.MoveReleaseSkill;
			if (text6 != null && text6.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.对象模板.MoveReleaseSkill, out this.MoveReleaseSkill);
			}
			string text7 = this.对象模板.BirthReleaseSkill;
			if (text7 != null && text7.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.对象模板.BirthReleaseSkill, out this.BirthReleaseSkill);
			}
			对应宠物.Dies(null, false);
			对应宠物.Delete();
			this.Died = false;
			base.FightingStance = false;
			this.Blocking = true;
			base.BindGrid();
			base.更新邻居时处理();
			MapGatewayProcess.添加MapObject(this);
		}

		
		public MonsterObject(Monsters 对应模板, MapInstance 出生地图, int RevivalInterval, Point[] 出生范围, bool 禁止复活, bool 立即刷新)
		{
			this.对象模板 = 对应模板;
			this.出生地图 = 出生地图;
			this.CurrentMap = 出生地图;
			this.RevivalInterval = RevivalInterval;
			this.出生范围 = 出生范围;
			this.禁止复活 = 禁止复活;
			this.ObjectId = ++MapGatewayProcess.对象编号;
			this.StatsBonus[this] = 对应模板.BasicStats;
			string text = this.对象模板.NormalAttackSkills;
			if (text != null && text.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.对象模板.NormalAttackSkills, out this.NormalAttackSkills);
			}
			string text2 = this.对象模板.ProbabilityTriggerSkills;
			if (text2 != null && text2.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.对象模板.ProbabilityTriggerSkills, out this.ProbabilityTriggerSkills);
			}
			string text3 = this.对象模板.EnterCombatSkills;
			if (text3 != null && text3.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.对象模板.EnterCombatSkills, out this.EnterCombatSkills);
			}
			string text4 = this.对象模板.ExitCombatSkills;
			if (text4 != null && text4.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.对象模板.ExitCombatSkills, out this.ExitCombatSkills);
			}
			string text5 = this.对象模板.DeathReleaseSkill;
			if (text5 != null && text5.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.对象模板.DeathReleaseSkill, out this.DeathReleaseSkill);
			}
			string text6 = this.对象模板.MoveReleaseSkill;
			if (text6 != null && text6.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.对象模板.MoveReleaseSkill, out this.MoveReleaseSkill);
			}
			string text7 = this.对象模板.BirthReleaseSkill;
			if (text7 != null && text7.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.对象模板.BirthReleaseSkill, out this.BirthReleaseSkill);
			}
			MapGatewayProcess.添加MapObject(this);
			if (!禁止复活)
			{
				this.CurrentMap.TotalMobs += 1U;
				MainForm.更新地图数据(this.CurrentMap, "TotalMobs", this.CurrentMap.TotalMobs);
			}
			if (立即刷新)
			{
				this.怪物复活处理(false);
				return;
			}
			this.复活时间 = MainProcess.CurrentTime.AddMilliseconds((double)RevivalInterval);
			this.Blocking = false;
			this.尸体消失 = true;
			this.Died = true;
			this.SecondaryObject = true;
			MapGatewayProcess.添加次要对象(this);
		}

		
		public override void Process()
		{
			if (MainProcess.CurrentTime < base.ProcessTime)
			{
				return;
			}
			if (this.禁止复活 && MainProcess.CurrentTime >= this.存活时间)
			{
				base.Delete();
			}
			else if (this.Died)
			{
				if (!this.尸体消失 && MainProcess.CurrentTime >= this.消失时间)
				{
					if (this.禁止复活)
					{
						base.Delete();
					}
					else
					{
						this.尸体消失 = true;
						base.NotifyNeightborClear();
						base.UnbindGrid();
					}
				}
				if (!this.禁止复活 && MainProcess.CurrentTime >= this.复活时间)
				{
					base.NotifyNeightborClear();
					base.UnbindGrid();
					this.怪物复活处理(true);
				}
			}
			else
			{
				foreach (KeyValuePair<ushort, BuffData> keyValuePair in this.Buffs.ToList<KeyValuePair<ushort, BuffData>>())
				{
					base.轮询Buff时处理(keyValuePair.Value);
				}
				foreach (SkillInstance 技能实例 in this.SkillTasks.ToList<SkillInstance>())
				{
					技能实例.Process();
				}
				if (MainProcess.CurrentTime > base.RecoveryTime)
				{
					if (!this.CheckStatus(GameObjectState.Poisoned))
					{
						this.CurrentHP += this[GameObjectStats.体力恢复];
					}
					base.RecoveryTime = MainProcess.CurrentTime.AddSeconds(5.0);
				}
				if (MainProcess.CurrentTime > base.HealTime && base.TreatmentCount > 0)
				{
					int 治疗次数 = base.TreatmentCount;
					base.TreatmentCount = 治疗次数 - 1;
					base.HealTime = MainProcess.CurrentTime.AddMilliseconds(500.0);
					this.CurrentHP += base.TreatmentBase;
				}
				if (MainProcess.CurrentTime > this.BusyTime && MainProcess.CurrentTime > this.HardTime)
				{
					if (this.EnterCombatSkills != null && !base.FightingStance && this.HateObject.仇恨列表.Count != 0)
					{
						new SkillInstance(this, EnterCombatSkills, null, ActionId++, this.CurrentMap, this.CurrentPosition, null, this.CurrentPosition, null, null, false);
						base.FightingStance = true;
						base.TimeoutTime = MainProcess.CurrentTime.AddSeconds(10.0);
					}
					else if (this.ExitCombatSkills != null && base.FightingStance && this.HateObject.仇恨列表.Count == 0 && MainProcess.CurrentTime > base.TimeoutTime)
					{
						new SkillInstance(this, ExitCombatSkills, null, ActionId++, this.CurrentMap, this.CurrentPosition, null, this.CurrentPosition, null, null, false);
						FightingStance = false;
					}
					else if (this.对象模板.OutWarAutomaticPetrochemical && !base.FightingStance && this.HateObject.仇恨列表.Count != 0)
					{
						base.FightingStance = true;
						base.移除Buff时处理(this.对象模板.PetrochemicalStatusId);
						base.TimeoutTime = MainProcess.CurrentTime.AddSeconds(10.0);
					}
					else if (this.对象模板.OutWarAutomaticPetrochemical && base.FightingStance && this.HateObject.仇恨列表.Count == 0 && MainProcess.CurrentTime > base.TimeoutTime)
					{
						base.FightingStance = false;
						base.OnAddBuff(this.对象模板.PetrochemicalStatusId, this);
					}
					else if ((this.Category == MonsterLevelType.Boss) ? this.更新最近仇恨() : this.更新HateObject())
					{
						this.怪物智能Attack();
					}
					else
					{
						this.怪物随机漫游();
					}
				}
			}
			base.Process();
		}

		
		public override void Dies(MapObject 对象, bool 技能击杀)
		{
			foreach (SkillInstance 技能实例 in this.SkillTasks)
			{
				技能实例.SkillAbort();
			}
			base.Dies(对象, 技能击杀);
			if (this.DeathReleaseSkill != null && 对象 != null)
			{
				new SkillInstance(this, DeathReleaseSkill, null, ActionId++, this.CurrentMap, this.CurrentPosition, null, this.CurrentPosition, null, null, false).Process();
			}
			if (this.CurrentMap.CopyMap || !this.禁止复活)
			{
				this.CurrentMap.MobsAlive -= 1U;
				MainForm.更新地图数据(this.CurrentMap, "MobsAlive", -1);
			}
			this.尸体消失 = false;
			this.消失时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.CorpsePreservation);
			this.复活时间 = MainProcess.CurrentTime.AddMilliseconds((double)Math.Max(this.RevivalInterval, this.CorpsePreservation + 5000));
			PetObject PetObject = 对象 as PetObject;
			if (PetObject != null)
			{
				PetObject.宠物经验增加();
			}
			PlayerObject PlayerObject;
			if (this.更新怪物归属(out PlayerObject))
			{
				if (this.CurrentMap.MapId == 80)
				{
					int num = 0;
					GameItems 物品模板;
					if (GameItems.DataSheetByName.TryGetValue("强效金创药", out 物品模板))
					{
						int num2 = (this.Category == MonsterLevelType.Normal) ? 15 : 1;
						int num3 = Math.Max(1, num2 - (int)Math.Round(num2 * Config.怪物额外爆率));
						if (MainProcess.RandomNumber.Next(num3) == num3 / 2)
						{
							num++;
							new ItemObject(物品模板, null, this.CurrentMap, this.CurrentPosition, new HashSet<CharacterData>(), 1, false, this);
						}
					}
					GameItems 物品模板2;
					if (GameItems.DataSheetByName.TryGetValue("强效Magic药", out 物品模板2))
					{
						int num4 = (this.Category == MonsterLevelType.Normal) ? 20 : 1;
						int num5 = Math.Max(1, num4 - (int)Math.Round(num4 * Config.怪物额外爆率));
						if (MainProcess.RandomNumber.Next(num5) == num5 / 2)
						{
							num++;
							new ItemObject(物品模板2, null, this.CurrentMap, this.CurrentPosition, new HashSet<CharacterData>(), 1, false, this);
						}
					}
					GameItems 物品模板3;
					if (GameItems.DataSheetByName.TryGetValue("疗伤药", out 物品模板3))
					{
						int num6 = (this.Category == MonsterLevelType.Normal) ? 100 : 1;
						int num7 = Math.Max(1, num6 - (int)Math.Round(num6 * Config.怪物额外爆率));
						if (MainProcess.RandomNumber.Next(num7) == num7 / 2)
						{
							num++;
							new ItemObject(物品模板3, null, this.CurrentMap, this.CurrentPosition, new HashSet<CharacterData>(), 1, false, this);
						}
					}
					GameItems 物品模板4;
					if (GameItems.DataSheetByName.TryGetValue("祝福油", out 物品模板4))
					{
						int num8 = (this.Category == MonsterLevelType.Normal) ? 1000 : ((this.Category == MonsterLevelType.Elite) ? 50 : 10);
						int num9 = Math.Max(1, num8 - (int)Math.Round(num8 * Config.怪物额外爆率));
						if (MainProcess.RandomNumber.Next(num9) == num9 / 2)
						{
							num++;
							new ItemObject(物品模板4, null, this.CurrentMap, this.CurrentPosition, new HashSet<CharacterData>(), 1, false, this);
							NetworkServiceGateway.发送公告(string.Concat(new string[]
							{
								"[",
								this.ObjectName,
								"] 被 [",
								PlayerObject.ObjectName,
								"] 击杀, 掉落了[祝福油]"
							}), false);
						}
					}
					if (num > 0)
					{
						MainForm.更新地图数据(this.CurrentMap, "MobsDrops", num);
					}
					using (HashSet<PlayerObject>.Enumerator enumerator2 = this.CurrentMap.NrPlayers.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							PlayerObject PlayerObject2 = enumerator2.Current;
							PlayerObject2.玩家增加经验(this, (int)((float)this.怪物经验 * 1.5f));
						}
						goto IL_840;
					}
				}
				HashSet<CharacterData> hashSet;
				if (PlayerObject.所属队伍 != null)
				{
					hashSet = new HashSet<CharacterData>(PlayerObject.所属队伍.队伍成员);
				}
				else
				{
					(hashSet = new HashSet<CharacterData>()).Add(PlayerObject.CharacterData);
				}
				HashSet<CharacterData> 物品归属 = hashSet;
				float num10 = ComputingClass.收益衰减((int)PlayerObject.CurrentRank, (int)this.CurrentRank);
				int num11 = 0;
				int num12 = 0;
				if (num10 < 1f)
				{
					foreach (MonsterDrop 怪物掉落 in this.怪物掉落)
					{
						GameItems 游戏物品;
						if (GameItems.DataSheetByName.TryGetValue(怪物掉落.Name, out 游戏物品) && !ComputingClass.计算概率(num10) && (PlayerObject.CurrentPrivileges != 0 || this.Category == MonsterLevelType.Boss || 游戏物品.Type == ItemType.可用药剂 || !ComputingClass.计算概率(0.5f)) && (PlayerObject.CurrentPrivileges != 3 || this.Category == MonsterLevelType.Boss || 游戏物品.Type == ItemType.可用药剂 || !ComputingClass.计算概率(0.25f)))
						{
							int num13 = Math.Max(1, 怪物掉落.Probability - (int)Math.Round(怪物掉落.Probability * Config.怪物额外爆率));
							if (MainProcess.RandomNumber.Next(num13) == num13 / 2)
							{
								int num14 = MainProcess.RandomNumber.Next(怪物掉落.MinAmount, 怪物掉落.MaxAmount + 1);
								if (num14 != 0)
								{
									if (游戏物品.MaxDura == 0)
									{
										new ItemObject(游戏物品, null, this.CurrentMap, this.CurrentPosition, 物品归属, num14, false, this);
										if (游戏物品.Id == 1)
										{
											this.CurrentMap.MobGoldDrop += (long)num14;
											num11 = num14;
										}
										this.对象模板.DropStats[游戏物品] = (this.对象模板.DropStats.ContainsKey(游戏物品) ? this.对象模板.DropStats[游戏物品] : 0L) + (long)num14;
									}
									else
									{
										for (int i = 0; i < num14; i++)
										{
											new ItemObject(游戏物品, null, this.CurrentMap, this.CurrentPosition, 物品归属, 1, false, this);
										}
										this.CurrentMap.MobsDrops += (long)num14;
										num12++;
										this.对象模板.DropStats[游戏物品] = (this.对象模板.DropStats.ContainsKey(游戏物品) ? this.对象模板.DropStats[游戏物品] : 0L) + (long)num14;
									}
									if (游戏物品.ValuableObjects)
									{
										NetworkServiceGateway.发送公告(string.Concat(new string[]
										{
											"[",
											this.ObjectName,
											"] 被 [",
											PlayerObject.ObjectName,
											"] 击杀, 掉落了[",
											游戏物品.Name,
											"]"
										}), false);
									}
								}
							}
						}
					}
				}
				if (num11 > 0)
				{
					MainForm.更新地图数据(this.CurrentMap, "MobGoldDrop", num11);
				}
				if (num12 > 0)
				{
					MainForm.更新地图数据(this.CurrentMap, "MobsDrops", num12);
				}
				if (num11 > 0 || num12 > 0)
				{
					MainForm.更新DropStats(this.对象模板, this.对象模板.DropStats.ToList<KeyValuePair<GameItems, long>>());
				}
				if (PlayerObject.所属队伍 == null)
				{
					PlayerObject.玩家增加经验(this, this.怪物经验);
				}
				else
				{
					List<PlayerObject> list = new List<PlayerObject>
					{
						PlayerObject
					};
					foreach (MapObject MapObject in this.NeighborsImportant)
					{
						if (MapObject != PlayerObject)
						{
							PlayerObject PlayerObject3 = MapObject as PlayerObject;
							if (PlayerObject3 != null && PlayerObject3.所属队伍 == PlayerObject.所属队伍)
							{
								list.Add(PlayerObject3);
							}
						}
					}
					float num15 = (float)this.怪物经验 * (1f + (float)(list.Count - 1) * 0.2f);
					float num16 = (float)list.Sum((PlayerObject x) => (int)x.CurrentRank);
					foreach (PlayerObject PlayerObject4 in list)
					{
						PlayerObject4.玩家增加经验(this, (int)(num15 * (float)PlayerObject4.CurrentRank / num16));
					}
				}
			}
			IL_840:
			this.Buffs.Clear();
			this.SecondaryObject = true;
			MapGatewayProcess.添加次要对象(this);
			if (this.ActiveObject)
			{
				this.ActiveObject = false;
				MapGatewayProcess.RemoveActiveObject(this);
			}
		}

		
		public void 怪物随机漫游()
		{
			if (!this.ForbbidenMove && !(MainProcess.CurrentTime < this.漫游时间))
			{
				if (this.CanMove())
				{
					Point point = ComputingClass.前方坐标(this.CurrentPosition, ComputingClass.随机方向(), 1);
					if (this.CurrentMap.CanPass(point))
					{
						this.BusyTime = MainProcess.CurrentTime.AddMilliseconds((double)this.WalkInterval);
						this.WalkTime = MainProcess.CurrentTime.AddMilliseconds((double)(this.WalkInterval + this.MobInterval));
						this.CurrentDirection = ComputingClass.GetDirection(this.CurrentPosition, point);
						base.ItSelf移动时处理(point);
						if (!this.Died)
						{
							base.SendPacket(new ObjectCharacterWalkPacket
							{
								对象编号 = this.ObjectId,
								移动坐标 = this.CurrentPosition,
								移动速度 = base.WalkSpeed
							});
						}
					}
				}
				this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)(this.RoamingInterval + MainProcess.RandomNumber.Next(5000)));
				return;
			}
		}

		
		public void 怪物智能Attack()
		{
			base.TimeoutTime = MainProcess.CurrentTime.AddSeconds(10.0);
			GameSkills 游戏技能;
			if (this.ProbabilityTriggerSkills != null && (!this.Coolings.ContainsKey((int)this.ProbabilityTriggerSkills.OwnSkillId | 16777216) || MainProcess.CurrentTime > this.Coolings[(int)this.ProbabilityTriggerSkills.OwnSkillId | 16777216]) && ComputingClass.计算概率(this.ProbabilityTriggerSkills.CalculateTriggerProbability))
			{
				游戏技能 = this.ProbabilityTriggerSkills;
			}
			else
			{
				if (this.NormalAttackSkills == null || (this.Coolings.ContainsKey((int)this.NormalAttackSkills.OwnSkillId | 16777216) && !(MainProcess.CurrentTime > this.Coolings[(int)this.NormalAttackSkills.OwnSkillId | 16777216])))
				{
					return;
				}
				游戏技能 = this.NormalAttackSkills;
			}
			if (this.CheckStatus(GameObjectState.BusyGreen | GameObjectState.Paralyzed | GameObjectState.Absence))
			{
				return;
			}
			if (base.GetDistance(this.HateObject.当前目标) > (int)游戏技能.MaxDistance)
			{
				if (!this.ForbbidenMove && this.CanMove())
				{
					GameDirection GameDirection = ComputingClass.GetDirection(this.CurrentPosition, this.HateObject.当前目标.CurrentPosition);
					Point point = default(Point);
					for (int i = 0; i < 8; i++)
					{
						if (this.CurrentMap.CanPass(point = ComputingClass.前方坐标(this.CurrentPosition, GameDirection, 1)))
						{
							this.BusyTime = MainProcess.CurrentTime.AddMilliseconds((double)this.WalkInterval);
							this.WalkTime = MainProcess.CurrentTime.AddMilliseconds((double)(this.WalkInterval + this.MobInterval));
							this.CurrentDirection = ComputingClass.GetDirection(this.CurrentPosition, point);
							base.SendPacket(new ObjectCharacterWalkPacket
							{
								对象编号 = this.ObjectId,
								移动坐标 = point,
								移动速度 = base.WalkSpeed
							});
							base.ItSelf移动时处理(point);
							return;
						}
						GameDirection = ComputingClass.TurnAround(GameDirection, (MainProcess.RandomNumber.Next(2) == 0) ? -1 : 1);
					}
					return;
				}
			}
			else if (游戏技能.NeedMoveForward && !ComputingClass.直线方向(this.CurrentPosition, this.HateObject.当前目标.CurrentPosition))
			{
				if (!this.ForbbidenMove && this.CanMove())
				{
					GameDirection GameDirection2 = ComputingClass.正向方向(this.CurrentPosition, this.HateObject.当前目标.CurrentPosition);
					Point point2 = default(Point);
					for (int j = 0; j < 8; j++)
					{
						if (this.CurrentMap.CanPass(point2 = ComputingClass.前方坐标(this.CurrentPosition, GameDirection2, 1)))
						{
							this.CurrentDirection = ComputingClass.GetDirection(this.CurrentPosition, point2);
							this.BusyTime = MainProcess.CurrentTime.AddMilliseconds((double)this.WalkInterval);
							this.WalkTime = MainProcess.CurrentTime.AddMilliseconds((double)(this.WalkInterval + this.MobInterval));
							base.ItSelf移动时处理(point2);
							if (!this.Died)
							{
								base.SendPacket(new ObjectCharacterWalkPacket
								{
									对象编号 = this.ObjectId,
									移动坐标 = point2,
									移动速度 = base.WalkSpeed
								});
							}
							return;
						}
						GameDirection2 = ComputingClass.TurnAround(GameDirection2, (MainProcess.RandomNumber.Next(2) == 0) ? -1 : 1);
					}
					return;
				}
			}
			else
			{
				if (MainProcess.CurrentTime > this.Attack时间)
				{
					new SkillInstance(this, 游戏技能, null, ActionId++, this.CurrentMap, this.CurrentPosition, this.HateObject.当前目标, this.HateObject.当前目标.CurrentPosition, null, null, false);
					this.Attack时间 = MainProcess.CurrentTime.AddMilliseconds((double)(ComputingClass.ValueLimit(0, 10 - this[GameObjectStats.AttackSpeed], 10) * 500));
					return;
				}
				if (!this.ForbbidenMove && this.CanBeTurned())
				{
					this.CurrentDirection = ComputingClass.GetDirection(this.CurrentPosition, this.HateObject.当前目标.CurrentPosition);
				}
			}
		}

		
		public void 怪物复活处理(bool 计算复活)
		{
			if (this.CurrentMap.CopyMap || !this.禁止复活)
			{
				this.CurrentMap.MobsAlive += 1U;
				MainForm.更新地图数据(this.CurrentMap, "MobsAlive", 1);
				if (计算复活)
				{
					this.CurrentMap.MobsRespawned += 1U;
					MainForm.更新地图数据(this.CurrentMap, "MobsRespawned", 1);
				}
			}
			this.RefreshStats();
			this.CurrentMap = this.出生地图;
			this.CurrentDirection = ComputingClass.随机方向();
			this.CurrentHP = this[GameObjectStats.MaxHP];
			this.CurrentPosition = this.出生范围[MainProcess.RandomNumber.Next(0, this.出生范围.Length)];
			Point CurrentCoords = this.CurrentPosition;
			for (int i = 0; i < 100; i++)
			{
				if (!this.CurrentMap.CellBlocked(CurrentCoords = ComputingClass.螺旋坐标(this.CurrentPosition, i)))
				{
					this.CurrentPosition = CurrentCoords;
					IL_F1:
					this.Attack时间 = MainProcess.CurrentTime.AddSeconds(1.0);
					base.RecoveryTime = MainProcess.CurrentTime.AddMilliseconds((double)MainProcess.RandomNumber.Next(5000));
					this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)(MainProcess.RandomNumber.Next(5000) + this.RoamingInterval));
					this.HateObject = new HateObject();
					this.SecondaryObject = false;
					this.Died = false;
					base.FightingStance = false;
					this.Blocking = true;
					base.BindGrid();
					base.更新邻居时处理();
					if (!this.ActiveObject)
					{
						if (this.对象模板.OutWarAutomaticPetrochemical)
						{
							base.OnAddBuff(this.对象模板.PetrochemicalStatusId, this);
						}
						if (this.ExitCombatSkills != null)
						{
							new SkillInstance(this, ExitCombatSkills, null, ActionId++, this.CurrentMap, this.CurrentPosition, null, this.CurrentPosition, null, null, false).Process();
						}
					}
					return;
				}
			}
			//goto IL_F1;
		}

		
		public void 怪物诱惑处理()
		{
			this.Buffs.Clear();
			this.尸体消失 = true;
			this.Died = true;
			this.Blocking = false;
			if (this.禁止复活)
			{
				base.Delete();
				return;
			}
			base.NotifyNeightborClear();
			base.UnbindGrid();
			this.复活时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.RevivalInterval);
			this.SecondaryObject = true;
			MapGatewayProcess.添加次要对象(this);
			this.ActiveObject = false;
			MapGatewayProcess.RemoveActiveObject(this);
		}

		
		public void 怪物沉睡处理()
		{
			if (this.ActiveObject)
			{
				this.ActiveObject = false;
				this.SkillTasks.Clear();
				MapGatewayProcess.RemoveActiveObject(this);
			}
			if (this.禁止复活 && !this.SecondaryObject)
			{
				this.SecondaryObject = true;
				this.SkillTasks.Clear();
				MapGatewayProcess.添加次要对象(this);
			}
		}

		
		public void 怪物激活处理()
		{
			if (!this.ActiveObject)
			{
				this.SecondaryObject = false;
				this.ActiveObject = true;
				MapGatewayProcess.添加激活对象(this);
				int num = (int)Math.Max(0.0, (MainProcess.CurrentTime - base.RecoveryTime).TotalSeconds / 5.0);
				base.CurrentHP = Math.Min(this[GameObjectStats.MaxHP], this.CurrentHP + num * this[GameObjectStats.体力恢复]);
				base.RecoveryTime = base.RecoveryTime.AddSeconds(5.0);
				this.Attack时间 = MainProcess.CurrentTime.AddSeconds(1.0);
				this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)(MainProcess.RandomNumber.Next(5000) + this.RoamingInterval));
			}
		}

		
		public bool 更新HateObject()
		{
			if (this.HateObject.仇恨列表.Count == 0)
			{
				return false;
			}
			if (this.HateObject.当前目标 == null)
			{
				this.HateObject.切换时间 = default(DateTime);
			}
			else if (this.HateObject.当前目标.Died)
			{
				this.HateObject.移除仇恨(this.HateObject.当前目标);
			}
			else if (!this.Neighbors.Contains(this.HateObject.当前目标))
			{
				this.HateObject.移除仇恨(this.HateObject.当前目标);
			}
			else if (!this.HateObject.仇恨列表.ContainsKey(this.HateObject.当前目标))
			{
				this.HateObject.移除仇恨(this.HateObject.当前目标);
			}
			else if (base.GetDistance(this.HateObject.当前目标) > this.RangeHate && MainProcess.CurrentTime > this.HateObject.仇恨列表[this.HateObject.当前目标].仇恨时间)
			{
				this.HateObject.移除仇恨(this.HateObject.当前目标);
			}
			else if (base.GetDistance(this.HateObject.当前目标) <= this.RangeHate)
			{
				this.HateObject.仇恨列表[this.HateObject.当前目标].仇恨时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.HateTime);
			}
			if (this.HateObject.切换时间 < MainProcess.CurrentTime && this.HateObject.切换仇恨(this))
			{
				this.HateObject.切换时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.切换间隔);
			}
			return this.HateObject.当前目标 != null || this.更新HateObject();
		}

		
		public bool 更新最近仇恨()
		{
			if (this.HateObject.仇恨列表.Count == 0)
			{
				return false;
			}
			if (this.HateObject.当前目标 == null)
			{
				this.HateObject.切换时间 = default(DateTime);
			}
			else if (this.HateObject.当前目标.Died)
			{
				this.HateObject.移除仇恨(this.HateObject.当前目标);
			}
			else if (!this.Neighbors.Contains(this.HateObject.当前目标))
			{
				this.HateObject.移除仇恨(this.HateObject.当前目标);
			}
			else if (!this.HateObject.仇恨列表.ContainsKey(this.HateObject.当前目标))
			{
				this.HateObject.移除仇恨(this.HateObject.当前目标);
			}
			else if (base.GetDistance(this.HateObject.当前目标) > this.RangeHate && MainProcess.CurrentTime > this.HateObject.仇恨列表[this.HateObject.当前目标].仇恨时间)
			{
				this.HateObject.移除仇恨(this.HateObject.当前目标);
			}
			else if (base.GetDistance(this.HateObject.当前目标) <= this.RangeHate)
			{
				this.HateObject.仇恨列表[this.HateObject.当前目标].仇恨时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.HateTime);
			}
			if (this.HateObject.切换时间 < MainProcess.CurrentTime && this.HateObject.最近仇恨(this))
			{
				this.HateObject.切换时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.切换间隔);
			}
			return this.HateObject.当前目标 != null || this.更新HateObject();
		}

		
		public void 清空怪物仇恨()
		{
			this.HateObject.当前目标 = null;
			this.HateObject.仇恨列表.Clear();
		}

		
		public bool 更新怪物归属(out PlayerObject 归属玩家)
		{
			foreach (KeyValuePair<MapObject, HateObject.仇恨详情> keyValuePair in this.HateObject.仇恨列表.ToList<KeyValuePair<MapObject, HateObject.仇恨详情>>())
			{
				PetObject PetObject = keyValuePair.Key as PetObject;
				if (PetObject != null)
				{
					if (keyValuePair.Value.仇恨Value > 0)
					{
						this.HateObject.添加仇恨(PetObject.PlayerOwner, keyValuePair.Value.仇恨时间, keyValuePair.Value.仇恨Value);
					}
					this.HateObject.移除仇恨(keyValuePair.Key);
				}
				else if (!(keyValuePair.Key is PlayerObject))
				{
					this.HateObject.移除仇恨(keyValuePair.Key);
				}
			}
			MapObject MapObject = (from x in this.HateObject.仇恨列表.Keys.ToList<MapObject>()
			orderby this.HateObject.仇恨列表[x].仇恨Value descending
			select x).FirstOrDefault<MapObject>();
			PlayerObject PlayerObject2;
			if (MapObject != null)
			{
				PlayerObject PlayerObject = MapObject as PlayerObject;
				if (PlayerObject != null)
				{
					PlayerObject2 = PlayerObject;
					goto IL_FF;
				}
			}
			PlayerObject2 = null;
			IL_FF:
			归属玩家 = PlayerObject2;
			return 归属玩家 != null;
		}

		
		public byte 宠物等级;

		
		public Monsters 对象模板;

		
		public int RevivalInterval;

		
		public HateObject HateObject;

		
		public Point[] 出生范围;

		
		public MapInstance 出生地图;

		
		public GameSkills NormalAttackSkills;

		
		public GameSkills ProbabilityTriggerSkills;

		
		public GameSkills EnterCombatSkills;

		
		public GameSkills ExitCombatSkills;

		
		public GameSkills DeathReleaseSkill;

		
		public GameSkills MoveReleaseSkill;

		
		public GameSkills BirthReleaseSkill;
	}
}
