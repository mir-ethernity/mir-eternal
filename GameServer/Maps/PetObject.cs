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

		
		public override int 处理间隔
		{
			get
			{
				return 10;
			}
		}

		
		public override DateTime 忙碌时间
		{
			get
			{
				return base.忙碌时间;
			}
			set
			{
				if (base.忙碌时间 < value)
				{
					this.硬直时间 = value;
					base.忙碌时间 = value;
				}
			}
		}

		
		public override DateTime 硬直时间
		{
			get
			{
				return base.硬直时间;
			}
			set
			{
				if (base.硬直时间 < value)
				{
					base.硬直时间 = value;
				}
			}
		}

		
		public override int CurrentStamina
		{
			get
			{
				return this.PetData.CurrentStamina.V;
			}
			set
			{
				value = ComputingClass.ValueLimit(0, value, this[GameObjectStats.MaxPhysicalStrength]);
				if (this.PetData.CurrentStamina.V != value)
				{
					this.PetData.CurrentStamina.V = value;
					base.SendPacket(new SyncObjectHP
					{
						ObjectId = this.ObjectId,
						CurrentHP = this.CurrentStamina,
						MaxHP = this[GameObjectStats.MaxPhysicalStrength]
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

		
		public override GameDirection 当前方向
		{
			get
			{
				return base.当前方向;
			}
			set
			{
				if (this.当前方向 != value)
				{
					base.当前方向 = value;
					base.SendPacket(new ObjectRotationDirectionPacket
					{
						转向耗时 = 100,
						对象编号 = this.ObjectId,
						对象朝向 = (ushort)this.当前方向
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

		
		public override string 对象名字
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
				return GameObjectType.宠物;
			}
		}

		
		public override MonsterSize 对象体型
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
				return this.对象模板.Id;
			}
		}

		
		public ushort 升级经验
		{
			get
			{
				ushort[] 宠物升级经验 = 角色成长.宠物升级经验;
				int? num = (宠物升级经验 != null) ? new int?(宠物升级经验.Length) : null;
				int 宠物等级 = (int)this.宠物等级;
				if (!(num.GetValueOrDefault() > 宠物等级 & num != null))
				{
					return 10;
				}
				return 角色成长.宠物升级经验[(int)this.宠物等级];
			}
		}

		
		public int MobInterval
		{
			get
			{
				return (int)this.对象模板.MoveInterval;
			}
		}

		
		public int RoamingInterval
		{
			get
			{
				return (int)this.对象模板.RoamInterval;
			}
		}

		
		public int CorpsePreservation
		{
			get
			{
				return (int)this.对象模板.CorpsePreservationDuration;
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

		
		public MonsterRaceType 宠物种族
		{
			get
			{
				return this.对象模板.Race;
			}
		}

		
		public MonsterLevelType 宠物级别
		{
			get
			{
				return this.对象模板.Category;
			}
		}

		
		public Dictionary<GameObjectStats, int> 基础Stat
		{
			get
			{
				Dictionary<GameObjectStats, int>[] GrowthStat = this.对象模板.GrowStats;
				int? num = (GrowthStat != null) ? new int?(GrowthStat.Length) : null;
				int 宠物等级 = (int)this.宠物等级;
				if (!(num.GetValueOrDefault() > 宠物等级 & num != null))
				{
					return this.对象模板.BasicStats;
				}
				return this.对象模板.GrowStats[(int)this.宠物等级];
			}
		}

		
		public PetObject(PlayerObject 宠物主人, PetData 对象数据)
		{
			
			
			this.PlayerOwner = 宠物主人;
			this.PetData = 对象数据;
			this.对象模板 = Monsters.DataSheet[对象数据.PetName.V];
			this.CurrentCoords = 宠物主人.CurrentCoords;
			this.CurrentMap = 宠物主人.CurrentMap;
			this.当前方向 = ComputingClass.随机方向();
			this.Stat加成[this] = this.基础Stat;
			this.Stat加成[宠物主人.CharacterData] = new Dictionary<GameObjectStats, int>();
			if (this.对象模板.InheritsStats != null)
			{
				foreach (InheritStat InheritStat in this.对象模板.InheritsStats)
				{
					this.Stat加成[宠物主人.CharacterData][InheritStat.ConvertStat] = (int)((float)宠物主人[InheritStat.InheritsStats] * InheritStat.Ratio);
				}
			}
			this.更新对象Stat();
			base.恢复时间 = MainProcess.CurrentTime.AddSeconds(5.0);
			this.Attack时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)(MainProcess.RandomNumber.Next(5000) + this.RoamingInterval));
			this.HateObject = new HateObject();
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
			this.ObjectId = ++MapGatewayProcess.对象编号;
			MapGatewayProcess.添加MapObject(this);
			this.激活对象 = true;
			MapGatewayProcess.添加激活对象(this);
			this.阻塞网格 = true;
			this.宠物召回处理();
		}

		
		public PetObject(PlayerObject 宠物主人, Monsters 召唤宠物, byte 初始等级, byte GradeCap, bool BoundWeapons)
		{
			
			
			this.PlayerOwner = 宠物主人;
			this.对象模板 = 召唤宠物;
			this.PetData = new PetData(召唤宠物.MonsterName, 初始等级, GradeCap, BoundWeapons, DateTime.MaxValue);
			this.CurrentCoords = 宠物主人.CurrentCoords;
			this.CurrentMap = 宠物主人.CurrentMap;
			this.当前方向 = ComputingClass.随机方向();
			this.ObjectId = ++MapGatewayProcess.对象编号;
			this.Stat加成[this] = this.基础Stat;
			this.Stat加成[宠物主人.CharacterData] = new Dictionary<GameObjectStats, int>();
			if (this.对象模板.InheritsStats != null)
			{
				foreach (InheritStat InheritStat in this.对象模板.InheritsStats)
				{
					this.Stat加成[宠物主人.CharacterData][InheritStat.ConvertStat] = (int)((float)宠物主人[InheritStat.InheritsStats] * InheritStat.Ratio);
				}
			}
			this.更新对象Stat();
			this.CurrentStamina = this[GameObjectStats.MaxPhysicalStrength];
			base.恢复时间 = MainProcess.CurrentTime.AddSeconds(5.0);
			this.Attack时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)(MainProcess.RandomNumber.Next(5000) + this.RoamingInterval));
			this.HateObject = new HateObject();
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
			this.激活对象 = true;
			MapGatewayProcess.添加激活对象(this);
			this.阻塞网格 = true;
			this.宠物召回处理();
		}

		
		public PetObject(PlayerObject 宠物主人, MonsterObject 诱惑怪物, byte 初始等级, bool BoundWeapons, int 宠物时长)
		{
			
			
			this.PlayerOwner = 宠物主人;
			this.对象模板 = 诱惑怪物.对象模板;
			this.PetData = new PetData(诱惑怪物.对象名字, 初始等级, 7, BoundWeapons, MainProcess.CurrentTime.AddMinutes((double)宠物时长));
			this.CurrentCoords = 诱惑怪物.CurrentCoords;
			this.CurrentMap = 诱惑怪物.CurrentMap;
			this.当前方向 = 诱惑怪物.当前方向;
			this.Stat加成[this] = this.基础Stat;
			this.更新对象Stat();
			this.CurrentStamina = Math.Min(诱惑怪物.CurrentStamina, this[GameObjectStats.MaxPhysicalStrength]);
			base.恢复时间 = MainProcess.CurrentTime.AddSeconds(5.0);
			this.Attack时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.忙碌时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.RoamingInterval);
			this.HateObject = new HateObject();
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
			诱惑怪物.怪物诱惑处理();
			this.ObjectId = ++MapGatewayProcess.对象编号;
			this.阻塞网格 = true;
			base.绑定网格();
			MapGatewayProcess.添加MapObject(this);
			this.激活对象 = true;
			MapGatewayProcess.添加激活对象(this);
			base.更新邻居时处理();
		}

		
		public PetObject(PlayerObject 宠物主人, PetObject 诱惑宠物, byte 初始等级, bool BoundWeapons, int 宠物时长)
		{
			
			
			this.PlayerOwner = 宠物主人;
			this.对象模板 = 诱惑宠物.对象模板;
			this.PetData = new PetData(诱惑宠物.对象名字, 初始等级, 7, BoundWeapons, MainProcess.CurrentTime.AddMinutes((double)宠物时长));
			this.CurrentCoords = 诱惑宠物.CurrentCoords;
			this.CurrentMap = 诱惑宠物.CurrentMap;
			this.当前方向 = 诱惑宠物.当前方向;
			this.Stat加成[this] = this.基础Stat;
			this.更新对象Stat();
			this.CurrentStamina = Math.Min(诱惑宠物.CurrentStamina, this[GameObjectStats.MaxPhysicalStrength]);
			base.恢复时间 = MainProcess.CurrentTime.AddSeconds(5.0);
			this.Attack时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.忙碌时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.RoamingInterval);
			this.HateObject = new HateObject();
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
			诱惑宠物.ItSelf死亡处理(null, false);
			this.阻塞网格 = true;
			base.绑定网格();
			this.ObjectId = ++MapGatewayProcess.对象编号;
			MapGatewayProcess.添加MapObject(this);
			this.激活对象 = true;
			MapGatewayProcess.添加激活对象(this);
			base.更新邻居时处理();
		}

		
		public override void 处理对象数据()
		{
			if (MainProcess.CurrentTime < base.预约时间)
			{
				return;
			}
			if (this.Died)
			{
				if (!this.尸体消失 && MainProcess.CurrentTime >= this.消失时间)
				{
					base.删除对象();
				}
			}
			else if (this.MutinyTime != default(DateTime) && MainProcess.CurrentTime > this.MutinyTime)
			{
				new MonsterObject(this);
			}
			else
			{
				foreach (KeyValuePair<ushort, BuffData> keyValuePair in this.Buff列表.ToList<KeyValuePair<ushort, BuffData>>())
				{
					base.轮询Buff时处理(keyValuePair.Value);
				}
				foreach (SkillInstance 技能实例 in this.SkillTasks.ToList<SkillInstance>())
				{
					技能实例.Process();
				}
				if (MainProcess.CurrentTime > base.恢复时间)
				{
					if (!this.CheckStatus(GameObjectState.Poisoned))
					{
						this.CurrentStamina += this[GameObjectStats.体力恢复];
					}
					base.恢复时间 = MainProcess.CurrentTime.AddSeconds(5.0);
				}
				if (MainProcess.CurrentTime > base.治疗时间 && base.治疗次数 > 0)
				{
					int 治疗次数 = base.治疗次数;
					base.治疗次数 = 治疗次数 - 1;
					base.治疗时间 = MainProcess.CurrentTime.AddMilliseconds(500.0);
					this.CurrentStamina += base.治疗基数;
				}
				if (this.EnterCombatSkills != null && !base.战斗姿态 && this.HateObject.仇恨列表.Count != 0)
				{
					new SkillInstance(this, EnterCombatSkills, null, 动作编号++, this.CurrentMap, this.CurrentCoords, null, this.CurrentCoords, null, null, false);
					base.战斗姿态 = true;
					base.脱战时间 = MainProcess.CurrentTime.AddSeconds(10.0);
				}
				else if (this.ExitCombatSkills != null && base.战斗姿态 && this.HateObject.仇恨列表.Count == 0 && MainProcess.CurrentTime > base.脱战时间)
				{
					new SkillInstance(this, ExitCombatSkills, null, 动作编号++, this.CurrentMap, this.CurrentCoords, null, this.CurrentCoords, null, null, false);
					base.战斗姿态 = false;
				}
				else if (this.PlayerOwner.PetMode == PetMode.Attack && MainProcess.CurrentTime > this.忙碌时间 && MainProcess.CurrentTime > this.硬直时间)
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
			base.处理对象数据();
		}

		
		public override void ItSelf死亡处理(MapObject 对象, bool 技能击杀)
		{
			if (this.DeathReleaseSkill != null && 对象 != null)
			{
				new SkillInstance(this, DeathReleaseSkill, null, 动作编号++, this.CurrentMap, this.CurrentCoords, null, this.CurrentCoords, null, null, false).Process();
			}
			base.ItSelf死亡处理(对象, 技能击杀);
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
				PlayerObject3.宠物列表.Remove(this);
			}
			PlayerObject PlayerObject4 = this.PlayerOwner;
			byte? b = (PlayerObject4 != null) ? new byte?(PlayerObject4.宠物数量) : null;
			int? num = (b != null) ? new int?((int)b.GetValueOrDefault()) : null;
			if (num.GetValueOrDefault() == 0 & num != null)
			{
				PlayerObject PlayerObject5 = this.PlayerOwner;
				if (PlayerObject5 != null)
				{
					PlayerObject5.ActiveConnection.发送封包(new GameErrorMessagePacket
					{
						错误代码 = 9473
					});
				}
			}
			this.Buff列表.Clear();
			PetData PetData = this.PetData;
			if (PetData != null)
			{
				PetData.Delete();
			}
			this.次要对象 = true;
			MapGatewayProcess.添加次要对象(this);
			this.激活对象 = false;
			MapGatewayProcess.移除激活对象(this);
		}

		
		public void 宠物智能跟随()
		{
			if (!this.能否走动())
			{
				return;
			}
			if (this.Neighbors.Contains(this.PlayerOwner))
			{
				Point point = ComputingClass.前方坐标(this.PlayerOwner.CurrentCoords, ComputingClass.TurnAround(this.PlayerOwner.当前方向, 4), 2);
				if (base.网格距离(this.PlayerOwner) > 2 || base.网格距离(point) > 2)
				{
					GameDirection GameDirection = ComputingClass.计算方向(this.CurrentCoords, point);
					for (int i = 0; i < 8; i++)
					{
						Point point2 = ComputingClass.前方坐标(this.CurrentCoords, GameDirection, 1);
						if (this.CurrentMap.能否通行(point2))
						{
							this.忙碌时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.行走耗时);
							this.行走时间 = MainProcess.CurrentTime.AddMilliseconds((double)(this.行走耗时 + this.MobInterval));
							this.当前方向 = ComputingClass.计算方向(this.CurrentCoords, point2);
							base.ItSelf移动时处理(point2);
							base.SendPacket(new ObjectCharacterWalkPacket
							{
								对象编号 = this.ObjectId,
								移动坐标 = this.CurrentCoords,
								移动速度 = base.行走速度
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
					Point point3 = ComputingClass.前方坐标(this.CurrentCoords, ComputingClass.随机方向(), 1);
					if (this.CurrentMap.能否通行(point3))
					{
						this.忙碌时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.行走耗时);
						this.行走时间 = MainProcess.CurrentTime.AddMilliseconds((double)(this.行走耗时 + this.MobInterval));
						this.当前方向 = ComputingClass.计算方向(this.CurrentCoords, point3);
						base.ItSelf移动时处理(point3);
						base.SendPacket(new ObjectCharacterWalkPacket
						{
							对象编号 = this.ObjectId,
							移动坐标 = this.CurrentCoords,
							移动速度 = base.行走速度
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
			if (this.ProbabilityTriggerSkills != null && (!this.Coolings.ContainsKey((int)this.NormalAttackSkills.OwnSkillId | 16777216) || MainProcess.CurrentTime > this.Coolings[(int)this.NormalAttackSkills.OwnSkillId | 16777216]) && ComputingClass.计算概率(this.ProbabilityTriggerSkills.CalculateLuckyProbability ? ComputingClass.计算幸运(this[GameObjectStats.幸运等级]) : this.ProbabilityTriggerSkills.CalculateTriggerProbability))
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
			if (base.网格距离(this.HateObject.当前目标) > (int)游戏技能.MaxDistance)
			{
				if (this.能否走动())
				{
					GameDirection GameDirection = ComputingClass.计算方向(this.CurrentCoords, this.HateObject.当前目标.CurrentCoords);
					bool flag = false;
					int i = 0;
					while (i < 10)
					{
						Point point = ComputingClass.前方坐标(this.CurrentCoords, GameDirection, 1);
						if (!this.CurrentMap.能否通行(point))
						{
							GameDirection = ComputingClass.TurnAround(GameDirection, (MainProcess.RandomNumber.Next(2) == 0) ? -1 : 1);
							i++;
						}
						else
						{
							this.忙碌时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.行走耗时);
							this.行走时间 = MainProcess.CurrentTime.AddMilliseconds((double)(this.行走耗时 + this.MobInterval));
							this.当前方向 = ComputingClass.计算方向(this.CurrentCoords, point);
							base.ItSelf移动时处理(point);
							base.SendPacket(new ObjectCharacterWalkPacket
							{
								对象编号 = this.ObjectId,
								移动坐标 = point,
								移动速度 = base.行走速度
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
					new SkillInstance(this, 游戏技能, null, 动作编号++, this.CurrentMap, this.CurrentCoords, this.HateObject.当前目标, this.HateObject.当前目标.CurrentCoords, null, null, false);
					this.Attack时间 = MainProcess.CurrentTime.AddMilliseconds((double)(ComputingClass.ValueLimit(0, 10 - this[GameObjectStats.AttackSpeed], 10) * 500));
					return;
				}
				if (this.能否转动())
				{
					this.当前方向 = ComputingClass.计算方向(this.CurrentCoords, this.HateObject.当前目标.CurrentCoords);
				}
			}
		}

		
		public void 宠物经验增加()
		{
			if (this.宠物等级 >= this.GradeCap)
			{
				return;
			}
			if (++this.宠物经验 >= (int)this.升级经验)
			{
				this.宠物等级 += 1;
				this.宠物经验 = 0;
				this.Stat加成[this] = this.基础Stat;
				this.更新对象Stat();
				this.CurrentStamina = this[GameObjectStats.MaxPhysicalStrength];
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
			Point point = this.PlayerOwner.CurrentCoords;
			for (int i = 1; i <= 120; i++)
			{
				Point point2 = ComputingClass.螺旋坐标(point, i);
				if (this.PlayerOwner.CurrentMap.能否通行(point2))
				{
					point = point2;
					IL_38:
					this.清空宠物仇恨();
					base.清空邻居时处理();
					base.解绑网格();
					this.CurrentCoords = point;
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
					base.绑定网格();
					base.更新邻居时处理();
					return;
				}
			}
			//goto IL_38;
		}

		
		public void 宠物沉睡处理()
		{
			this.SkillTasks.Clear();
			this.Buff列表.Clear();
			this.Died = true;
			base.删除对象();
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
			else if (base.网格距离(this.HateObject.当前目标) > this.RangeHate && MainProcess.CurrentTime > this.HateObject.仇恨列表[this.HateObject.当前目标].仇恨时间)
			{
				this.HateObject.移除仇恨(this.HateObject.当前目标);
			}
			else if (base.网格距离(this.HateObject.当前目标) <= this.RangeHate)
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

		
		public Monsters 对象模板;

		
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
