using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameServer.Data;
using GameServer.Templates;
using GameServer.Networking;

namespace GameServer.Maps
{
	
	public sealed class PetObject : MapObject
	{
		
		public bool 尸体消失 { get; set; }

		
		public DateTime Attack时间 { get; set; }

		
		public DateTime 漫游时间 { get; set; }

		
		public DateTime 复活时间 { get; set; }

		
		public DateTime 消失时间 { get; set; }

		
		public int 宠物经验
		{
			get
			{
				return this.PetData.CurrentExp.V;
			}
			set
			{
				if (this.PetData.CurrentExp.V != value)
				{
					this.PetData.CurrentExp.V = value;
				}
			}
		}

		
		public byte 宠物等级
		{
			get
			{
				return this.PetData.CurrentRank.V;
			}
			set
			{
				if (this.PetData.CurrentRank.V != value)
				{
					this.PetData.CurrentRank.V = value;
				}
			}
		}

		
		public byte GradeCap
		{
			get
			{
				return this.PetData.GradeCap.V;
			}
			set
			{
				if (this.PetData.GradeCap.V != value)
				{
					this.PetData.GradeCap.V = value;
				}
			}
		}

		
		public bool BoundWeapons
		{
			get
			{
				return this.PetData.BoundWeapons.V;
			}
			set
			{
				if (this.PetData.BoundWeapons.V != value)
				{
					this.PetData.BoundWeapons.V = value;
				}
			}
		}

		
		public DateTime MutinyTime
		{
			get
			{
				return this.PetData.MutinyTime.V;
			}
			set
			{
				if (this.PetData.MutinyTime.V != value)
				{
					this.PetData.MutinyTime.V = value;
				}
			}
		}

		
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
				return this.PetData.CurrentHP.V;
			}
			set
			{
				value = ComputingClass.ValueLimit(0, value, this[GameObjectStats.MaxHP]);
				if (this.PetData.CurrentHP.V != value)
				{
					this.PetData.CurrentHP.V = value;
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
						对象朝向 = (ushort)this.CurrentDirection
					});
				}
			}
		}

		
		public override byte CurrentLevel
		{
			get
			{
				return this.Template.Level;
			}
		}

		
		public override string ObjectName
		{
			get
			{
				return this.Template.MonsterName;
			}
		}

		
		public override GameObjectType ObjectType
		{
			get
			{
				return GameObjectType.Pet;
			}
		}

		
		public override ObjectSize ObjectSize
		{
			get
			{
				return this.Template.Size;
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

		
		public int RangeHate
		{
			get
			{
				return 4;
			}
		}

		
		public int HateTime
		{
			get
			{
				return 15000;
			}
		}

		
		public int 切换间隔
		{
			get
			{
				return 5000;
			}
		}

		
		public ushort MobId
		{
			get
			{
				return this.Template.Id;
			}
		}

		
		public ushort 升级经验
		{
			get
			{
				ushort[] 宠物升级经验 = CharacterProgression.宠物升级经验;
				int? num = (宠物升级经验 != null) ? new int?(宠物升级经验.Length) : null;
				int 宠物等级 = (int)this.宠物等级;
				if (!(num.GetValueOrDefault() > 宠物等级 & num != null))
				{
					return 10;
				}
				return CharacterProgression.宠物升级经验[(int)this.宠物等级];
			}
		}

		
		public int MobInterval
		{
			get
			{
				return (int)this.Template.MoveInterval;
			}
		}

		
		public int RoamingInterval
		{
			get
			{
				return (int)this.Template.RoamInterval;
			}
		}

		
		public int CorpsePreservation
		{
			get
			{
				return (int)this.Template.CorpsePreservationDuration;
			}
		}

		
		public bool CanBeSeducedBySkills
		{
			get
			{
				return this.Template.CanBeSeducedBySkills;
			}
		}

		
		public float BaseTemptationProbability
		{
			get
			{
				return this.Template.BaseTemptationProbability;
			}
		}

		
		public MonsterRaceType 宠物种族
		{
			get
			{
				return this.Template.Race;
			}
		}

		
		public MonsterLevelType 宠物级别
		{
			get
			{
				return this.Template.Category;
			}
		}

		
		public Dictionary<GameObjectStats, int> 基础Stat
		{
			get
			{
				Dictionary<GameObjectStats, int>[] GrowthStat = this.Template.GrowStats;
				int? num = (GrowthStat != null) ? new int?(GrowthStat.Length) : null;
				int 宠物等级 = (int)this.宠物等级;
				if (!(num.GetValueOrDefault() > 宠物等级 & num != null))
				{
					return this.Template.BasicStats;
				}
				return this.Template.GrowStats[(int)this.宠物等级];
			}
		}

		
		public PetObject(PlayerObject 宠物主人, PetData 对象数据)
		{
			
			
			this.PlayerOwner = 宠物主人;
			this.PetData = 对象数据;
			this.Template = Monsters.DataSheet[对象数据.PetName.V];
			this.CurrentPosition = 宠物主人.CurrentPosition;
			this.CurrentMap = 宠物主人.CurrentMap;
			this.CurrentDirection = ComputingClass.随机方向();
			this.StatsBonus[this] = this.基础Stat;
			this.StatsBonus[宠物主人.CharacterData] = new Dictionary<GameObjectStats, int>();
			if (this.Template.InheritsStats != null)
			{
				foreach (InheritStat InheritStat in this.Template.InheritsStats)
				{
					this.StatsBonus[宠物主人.CharacterData][InheritStat.ConvertStat] = (int)((float)宠物主人[InheritStat.InheritsStats] * InheritStat.Ratio);
				}
			}
			this.RefreshStats();
			base.RecoveryTime = MainProcess.CurrentTime.AddSeconds(5.0);
			this.Attack时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)(MainProcess.RandomNumber.Next(5000) + this.RoamingInterval));
			this.HateObject = new HateObject();
			string text = this.Template.NormalAttackSkills;
			if (text != null && text.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.NormalAttackSkills, out this.NormalAttackSkills);
			}
			string text2 = this.Template.ProbabilityTriggerSkills;
			if (text2 != null && text2.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.ProbabilityTriggerSkills, out this.ProbabilityTriggerSkills);
			}
			string text3 = this.Template.EnterCombatSkills;
			if (text3 != null && text3.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.EnterCombatSkills, out this.EnterCombatSkills);
			}
			string text4 = this.Template.ExitCombatSkills;
			if (text4 != null && text4.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.ExitCombatSkills, out this.ExitCombatSkills);
			}
			string text5 = this.Template.DeathReleaseSkill;
			if (text5 != null && text5.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.DeathReleaseSkill, out this.DeathReleaseSkill);
			}
			string text6 = this.Template.MoveReleaseSkill;
			if (text6 != null && text6.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.MoveReleaseSkill, out this.MoveReleaseSkill);
			}
			string text7 = this.Template.BirthReleaseSkill;
			if (text7 != null && text7.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.BirthReleaseSkill, out this.BirthReleaseSkill);
			}
			this.ObjectId = ++MapGatewayProcess.对象编号;
			MapGatewayProcess.添加MapObject(this);
			this.ActiveObject = true;
			MapGatewayProcess.添加激活对象(this);
			this.Blocking = true;
			this.宠物召回处理();
		}

		
		public PetObject(PlayerObject 宠物主人, Monsters 召唤宠物, byte 初始等级, byte GradeCap, bool BoundWeapons)
		{
			
			
			this.PlayerOwner = 宠物主人;
			this.Template = 召唤宠物;
			this.PetData = new PetData(召唤宠物.MonsterName, 初始等级, GradeCap, BoundWeapons, DateTime.MaxValue);
			this.CurrentPosition = 宠物主人.CurrentPosition;
			this.CurrentMap = 宠物主人.CurrentMap;
			this.CurrentDirection = ComputingClass.随机方向();
			this.ObjectId = ++MapGatewayProcess.对象编号;
			this.StatsBonus[this] = this.基础Stat;
			this.StatsBonus[宠物主人.CharacterData] = new Dictionary<GameObjectStats, int>();
			if (this.Template.InheritsStats != null)
			{
				foreach (InheritStat InheritStat in this.Template.InheritsStats)
				{
					this.StatsBonus[宠物主人.CharacterData][InheritStat.ConvertStat] = (int)((float)宠物主人[InheritStat.InheritsStats] * InheritStat.Ratio);
				}
			}
			this.RefreshStats();
			this.CurrentHP = this[GameObjectStats.MaxHP];
			base.RecoveryTime = MainProcess.CurrentTime.AddSeconds(5.0);
			this.Attack时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)(MainProcess.RandomNumber.Next(5000) + this.RoamingInterval));
			this.HateObject = new HateObject();
			string text = this.Template.NormalAttackSkills;
			if (text != null && text.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.NormalAttackSkills, out this.NormalAttackSkills);
			}
			string text2 = this.Template.ProbabilityTriggerSkills;
			if (text2 != null && text2.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.ProbabilityTriggerSkills, out this.ProbabilityTriggerSkills);
			}
			string text3 = this.Template.EnterCombatSkills;
			if (text3 != null && text3.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.EnterCombatSkills, out this.EnterCombatSkills);
			}
			string text4 = this.Template.ExitCombatSkills;
			if (text4 != null && text4.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.ExitCombatSkills, out this.ExitCombatSkills);
			}
			string text5 = this.Template.DeathReleaseSkill;
			if (text5 != null && text5.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.DeathReleaseSkill, out this.DeathReleaseSkill);
			}
			string text6 = this.Template.MoveReleaseSkill;
			if (text6 != null && text6.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.MoveReleaseSkill, out this.MoveReleaseSkill);
			}
			string text7 = this.Template.BirthReleaseSkill;
			if (text7 != null && text7.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.BirthReleaseSkill, out this.BirthReleaseSkill);
			}
			MapGatewayProcess.添加MapObject(this);
			this.ActiveObject = true;
			MapGatewayProcess.添加激活对象(this);
			this.Blocking = true;
			this.宠物召回处理();
		}

		
		public PetObject(PlayerObject 宠物主人, MonsterObject 诱惑怪物, byte 初始等级, bool BoundWeapons, int 宠物时长)
		{
			
			
			this.PlayerOwner = 宠物主人;
			this.Template = 诱惑怪物.Template;
			this.PetData = new PetData(诱惑怪物.ObjectName, 初始等级, 7, BoundWeapons, MainProcess.CurrentTime.AddMinutes((double)宠物时长));
			this.CurrentPosition = 诱惑怪物.CurrentPosition;
			this.CurrentMap = 诱惑怪物.CurrentMap;
			this.CurrentDirection = 诱惑怪物.CurrentDirection;
			this.StatsBonus[this] = this.基础Stat;
			this.RefreshStats();
			this.CurrentHP = Math.Min(诱惑怪物.CurrentHP, this[GameObjectStats.MaxHP]);
			base.RecoveryTime = MainProcess.CurrentTime.AddSeconds(5.0);
			this.Attack时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.BusyTime = MainProcess.CurrentTime.AddSeconds(1.0);
			this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.RoamingInterval);
			this.HateObject = new HateObject();
			string text = this.Template.NormalAttackSkills;
			if (text != null && text.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.NormalAttackSkills, out this.NormalAttackSkills);
			}
			string text2 = this.Template.ProbabilityTriggerSkills;
			if (text2 != null && text2.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.ProbabilityTriggerSkills, out this.ProbabilityTriggerSkills);
			}
			string text3 = this.Template.EnterCombatSkills;
			if (text3 != null && text3.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.EnterCombatSkills, out this.EnterCombatSkills);
			}
			string text4 = this.Template.ExitCombatSkills;
			if (text4 != null && text4.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.ExitCombatSkills, out this.ExitCombatSkills);
			}
			string text5 = this.Template.DeathReleaseSkill;
			if (text5 != null && text5.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.DeathReleaseSkill, out this.DeathReleaseSkill);
			}
			string text6 = this.Template.MoveReleaseSkill;
			if (text6 != null && text6.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.MoveReleaseSkill, out this.MoveReleaseSkill);
			}
			string text7 = this.Template.BirthReleaseSkill;
			if (text7 != null && text7.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.BirthReleaseSkill, out this.BirthReleaseSkill);
			}
			诱惑怪物.怪物诱惑处理();
			this.ObjectId = ++MapGatewayProcess.对象编号;
			this.Blocking = true;
			base.BindGrid();
			MapGatewayProcess.添加MapObject(this);
			this.ActiveObject = true;
			MapGatewayProcess.添加激活对象(this);
			base.更新邻居时处理();
		}

		
		public PetObject(PlayerObject 宠物主人, PetObject 诱惑宠物, byte 初始等级, bool BoundWeapons, int 宠物时长)
		{
			
			
			this.PlayerOwner = 宠物主人;
			this.Template = 诱惑宠物.Template;
			this.PetData = new PetData(诱惑宠物.ObjectName, 初始等级, 7, BoundWeapons, MainProcess.CurrentTime.AddMinutes((double)宠物时长));
			this.CurrentPosition = 诱惑宠物.CurrentPosition;
			this.CurrentMap = 诱惑宠物.CurrentMap;
			this.CurrentDirection = 诱惑宠物.CurrentDirection;
			this.StatsBonus[this] = this.基础Stat;
			this.RefreshStats();
			this.CurrentHP = Math.Min(诱惑宠物.CurrentHP, this[GameObjectStats.MaxHP]);
			base.RecoveryTime = MainProcess.CurrentTime.AddSeconds(5.0);
			this.Attack时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.BusyTime = MainProcess.CurrentTime.AddSeconds(1.0);
			this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.RoamingInterval);
			this.HateObject = new HateObject();
			string text = this.Template.NormalAttackSkills;
			if (text != null && text.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.NormalAttackSkills, out this.NormalAttackSkills);
			}
			string text2 = this.Template.ProbabilityTriggerSkills;
			if (text2 != null && text2.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.ProbabilityTriggerSkills, out this.ProbabilityTriggerSkills);
			}
			string text3 = this.Template.EnterCombatSkills;
			if (text3 != null && text3.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.EnterCombatSkills, out this.EnterCombatSkills);
			}
			string text4 = this.Template.ExitCombatSkills;
			if (text4 != null && text4.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.ExitCombatSkills, out this.ExitCombatSkills);
			}
			string text5 = this.Template.DeathReleaseSkill;
			if (text5 != null && text5.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.DeathReleaseSkill, out this.DeathReleaseSkill);
			}
			string text6 = this.Template.MoveReleaseSkill;
			if (text6 != null && text6.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.MoveReleaseSkill, out this.MoveReleaseSkill);
			}
			string text7 = this.Template.BirthReleaseSkill;
			if (text7 != null && text7.Length > 0)
			{
				GameSkills.DataSheet.TryGetValue(this.Template.BirthReleaseSkill, out this.BirthReleaseSkill);
			}
			诱惑宠物.Dies(null, false);
			this.Blocking = true;
			base.BindGrid();
			this.ObjectId = ++MapGatewayProcess.对象编号;
			MapGatewayProcess.添加MapObject(this);
			this.ActiveObject = true;
			MapGatewayProcess.添加激活对象(this);
			base.更新邻居时处理();
		}

		
		public override void Process()
		{
			if (MainProcess.CurrentTime < base.ProcessTime)
			{
				return;
			}
			if (this.Died)
			{
				if (!this.尸体消失 && MainProcess.CurrentTime >= this.消失时间)
				{
					base.Delete();
				}
			}
			else if (this.MutinyTime != default(DateTime) && MainProcess.CurrentTime > this.MutinyTime)
			{
				new MonsterObject(this);
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
				if (this.EnterCombatSkills != null && !base.FightingStance && this.HateObject.仇恨列表.Count != 0)
				{
					new SkillInstance(this, EnterCombatSkills, null, ActionId++, this.CurrentMap, this.CurrentPosition, null, this.CurrentPosition, null, null, false);
					base.FightingStance = true;
					base.TimeoutTime = MainProcess.CurrentTime.AddSeconds(10.0);
				}
				else if (this.ExitCombatSkills != null && base.FightingStance && this.HateObject.仇恨列表.Count == 0 && MainProcess.CurrentTime > base.TimeoutTime)
				{
					new SkillInstance(this, ExitCombatSkills, null, ActionId++, this.CurrentMap, this.CurrentPosition, null, this.CurrentPosition, null, null, false);
					base.FightingStance = false;
				}
				else if (this.PlayerOwner.PetMode == PetMode.Attack && MainProcess.CurrentTime > this.BusyTime && MainProcess.CurrentTime > this.HardTime)
				{
					if (this.HateObject.当前目标 == null && !this.Neighbors.Contains(this.PlayerOwner))
					{
						this.宠物智能跟随();
					}
					else if (this.更新HateObject())
					{
						this.宠物智能Attack();
					}
					else
					{
						this.宠物智能跟随();
					}
				}
			}
			base.Process();
		}

		
		public override void Dies(MapObject 对象, bool 技能击杀)
		{
			if (this.DeathReleaseSkill != null && 对象 != null)
			{
				new SkillInstance(this, DeathReleaseSkill, null, ActionId++, this.CurrentMap, this.CurrentPosition, null, this.CurrentPosition, null, null, false).Process();
			}
			base.Dies(对象, 技能击杀);
			this.消失时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.CorpsePreservation);
			this.清空宠物仇恨();
			PlayerObject PlayerObject = this.PlayerOwner;
			if (PlayerObject != null)
			{
				PlayerObject.宠物死亡处理(this);
			}
			PlayerObject PlayerObject2 = this.PlayerOwner;
			if (PlayerObject2 != null)
			{
				PlayerObject2.PetData.Remove(this.PetData);
			}
			PlayerObject PlayerObject3 = this.PlayerOwner;
			if (PlayerObject3 != null)
			{
				PlayerObject3.Pets.Remove(this);
			}
			PlayerObject PlayerObject4 = this.PlayerOwner;
			byte? b = (PlayerObject4 != null) ? new byte?(PlayerObject4.宠物数量) : null;
			int? num = (b != null) ? new int?((int)b.GetValueOrDefault()) : null;
			if (num.GetValueOrDefault() == 0 & num != null)
			{
				PlayerObject PlayerObject5 = this.PlayerOwner;
				if (PlayerObject5 != null)
				{
					PlayerObject5.ActiveConnection.SendPacket(new GameErrorMessagePacket
					{
						错误代码 = 9473
					});
				}
			}
			this.Buffs.Clear();
			PetData PetData = this.PetData;
			if (PetData != null)
			{
				PetData.Delete();
			}
			this.SecondaryObject = true;
			MapGatewayProcess.AddSecondaryObject(this);
			this.ActiveObject = false;
			MapGatewayProcess.RemoveActiveObject(this);
		}

		
		public void 宠物智能跟随()
		{
			if (!this.CanMove())
			{
				return;
			}
			if (this.Neighbors.Contains(this.PlayerOwner))
			{
				Point point = ComputingClass.前方坐标(this.PlayerOwner.CurrentPosition, ComputingClass.TurnAround(this.PlayerOwner.CurrentDirection, 4), 2);
				if (base.GetDistance(this.PlayerOwner) > 2 || base.GetDistance(point) > 2)
				{
					GameDirection GameDirection = ComputingClass.GetDirection(this.CurrentPosition, point);
					for (int i = 0; i < 8; i++)
					{
						Point point2 = ComputingClass.前方坐标(this.CurrentPosition, GameDirection, 1);
						if (this.CurrentMap.CanPass(point2))
						{
							this.BusyTime = MainProcess.CurrentTime.AddMilliseconds((double)this.WalkInterval);
							this.WalkTime = MainProcess.CurrentTime.AddMilliseconds((double)(this.WalkInterval + this.MobInterval));
							this.CurrentDirection = ComputingClass.GetDirection(this.CurrentPosition, point2);
							base.ItSelf移动时处理(point2);
							base.SendPacket(new ObjectCharacterWalkPacket
							{
								对象编号 = this.ObjectId,
								移动坐标 = this.CurrentPosition,
								移动速度 = base.WalkSpeed
							});
							return;
						}
						GameDirection = ComputingClass.TurnAround(GameDirection, (MainProcess.RandomNumber.Next(2) == 0) ? -1 : 1);
					}
					return;
				}
				if (MainProcess.CurrentTime > this.漫游时间)
				{
					this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)(this.RoamingInterval + MainProcess.RandomNumber.Next(5000)));
					Point point3 = ComputingClass.前方坐标(this.CurrentPosition, ComputingClass.随机方向(), 1);
					if (this.CurrentMap.CanPass(point3))
					{
						this.BusyTime = MainProcess.CurrentTime.AddMilliseconds((double)this.WalkInterval);
						this.WalkTime = MainProcess.CurrentTime.AddMilliseconds((double)(this.WalkInterval + this.MobInterval));
						this.CurrentDirection = ComputingClass.GetDirection(this.CurrentPosition, point3);
						base.ItSelf移动时处理(point3);
						base.SendPacket(new ObjectCharacterWalkPacket
						{
							对象编号 = this.ObjectId,
							移动坐标 = this.CurrentPosition,
							移动速度 = base.WalkSpeed
						});
						return;
					}
				}
			}
			else
			{
				this.宠物召回处理();
			}
		}

		
		public void 宠物智能Attack()
		{
			if (this.CheckStatus(GameObjectState.Paralyzed | GameObjectState.Absence))
			{
				return;
			}
			GameSkills 游戏技能;
			if (this.ProbabilityTriggerSkills != null && (!this.Coolings.ContainsKey((int)this.NormalAttackSkills.OwnSkillId | 16777216) || MainProcess.CurrentTime > this.Coolings[(int)this.NormalAttackSkills.OwnSkillId | 16777216]) && ComputingClass.CheckProbability(this.ProbabilityTriggerSkills.CalculateLuckyProbability ? ComputingClass.计算幸运(this[GameObjectStats.Luck]) : this.ProbabilityTriggerSkills.CalculateTriggerProbability))
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
			if (base.GetDistance(this.HateObject.当前目标) > (int)游戏技能.MaxDistance)
			{
				if (this.CanMove())
				{
					GameDirection GameDirection = ComputingClass.GetDirection(this.CurrentPosition, this.HateObject.当前目标.CurrentPosition);
					bool flag = false;
					int i = 0;
					while (i < 10)
					{
						Point point = ComputingClass.前方坐标(this.CurrentPosition, GameDirection, 1);
						if (!this.CurrentMap.CanPass(point))
						{
							GameDirection = ComputingClass.TurnAround(GameDirection, (MainProcess.RandomNumber.Next(2) == 0) ? -1 : 1);
							i++;
						}
						else
						{
							this.BusyTime = MainProcess.CurrentTime.AddMilliseconds((double)this.WalkInterval);
							this.WalkTime = MainProcess.CurrentTime.AddMilliseconds((double)(this.WalkInterval + this.MobInterval));
							this.CurrentDirection = ComputingClass.GetDirection(this.CurrentPosition, point);
							base.ItSelf移动时处理(point);
							base.SendPacket(new ObjectCharacterWalkPacket
							{
								对象编号 = this.ObjectId,
								移动坐标 = point,
								移动速度 = base.WalkSpeed
							});
							flag = true;
							IL_1F9:
							if (!flag)
							{
								this.HateObject.移除仇恨(this.HateObject.当前目标);
								return;
							}
							return;
						}
					}
					//goto IL_1F9;
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
				if (this.CanBeTurned())
				{
					this.CurrentDirection = ComputingClass.GetDirection(this.CurrentPosition, this.HateObject.当前目标.CurrentPosition);
				}
			}
		}

		
		public void IncreasePetExp()
		{
			if (this.宠物等级 >= this.GradeCap)
			{
				return;
			}
			if (++this.宠物经验 >= (int)this.升级经验)
			{
				this.宠物等级 += 1;
				this.宠物经验 = 0;
				this.StatsBonus[this] = this.基础Stat;
				this.RefreshStats();
				this.CurrentHP = this[GameObjectStats.MaxHP];
				base.SendPacket(new ObjectTransformTypePacket
				{
					改变类型 = 2,
					对象编号 = this.ObjectId
				});
				base.SendPacket(new SyncPetLevelPacket
				{
					宠物编号 = this.ObjectId,
					宠物等级 = this.宠物等级
				});
			}
		}

		
		public void 宠物召回处理()
		{
			Point point = this.PlayerOwner.CurrentPosition;
			for (int i = 1; i <= 120; i++)
			{
				Point point2 = ComputingClass.螺旋坐标(point, i);
				if (this.PlayerOwner.CurrentMap.CanPass(point2))
				{
					point = point2;
					IL_38:
					this.清空宠物仇恨();
					base.NotifyNeightborClear();
					base.UnbindGrid();
					this.CurrentPosition = point;
					PlayerObject PlayerObject = this.PlayerOwner;
					MapInstance CurrentMap;
					if (PlayerObject != null)
					{
						if ((CurrentMap = PlayerObject.CurrentMap) != null)
						{
							goto IL_69;
						}
					}
					CurrentMap = null;
					IL_69:
					this.CurrentMap = CurrentMap;
					base.BindGrid();
					base.更新邻居时处理();
					return;
				}
			}
			//goto IL_38;
		}

		
		public void 宠物沉睡处理()
		{
			this.SkillTasks.Clear();
			this.Buffs.Clear();
			this.Died = true;
			base.Delete();
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
			else if (this.PlayerOwner.GetRelationship(this.HateObject.当前目标) != GameObjectRelationship.Hostility)
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

		
		public void 清空宠物仇恨()
		{
			this.HateObject.当前目标 = null;
			this.HateObject.仇恨列表.Clear();
		}

		
		public PlayerObject PlayerOwner;

		
		public Monsters Template;

		
		public HateObject HateObject;

		
		public GameSkills NormalAttackSkills;

		
		public GameSkills ProbabilityTriggerSkills;

		
		public GameSkills EnterCombatSkills;

		
		public GameSkills ExitCombatSkills;

		
		public GameSkills DeathReleaseSkill;

		
		public GameSkills MoveReleaseSkill;

		
		public GameSkills BirthReleaseSkill;

		
		public PetData PetData;
	}
}
