using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameServer.Data;
using GameServer.Templates;
using GameServer.Networking;

namespace GameServer.Maps
{
	
	public sealed class TrapObject : MapObject
	{
		
		public ushort 陷阱GroupId
		{
			get
			{
				return this.陷阱模板.GroupId;
			}
		}

		
		public ushort ActivelyTriggerInterval
		{
			get
			{
				return this.陷阱模板.ActivelyTriggerInterval;
			}
		}

		
		public ushort ActivelyTriggerDelay
		{
			get
			{
				return this.陷阱模板.ActivelyTriggerDelay;
			}
		}

		
		public ushort 陷阱剩余时间
		{
			get
			{
				return (ushort)Math.Ceiling((this.消失时间 - MainProcess.CurrentTime).TotalMilliseconds / 62.5);
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

		
		public override int ProcessInterval
		{
			get
			{
				return 10;
			}
		}

		
		public override byte CurrentLevel
		{
			get
			{
				return this.TrapSource.CurrentLevel;
			}
			set
			{
				this.TrapSource.CurrentLevel = value;
			}
		}

		
		public override bool Blocking
		{
			get
			{
				return false;
			}
			set
			{
				base.Blocking = value;
			}
		}

		
		public override bool CanBeHit
		{
			get
			{
				return false;
			}
		}

		
		public override string ObjectName
		{
			get
			{
				return this.陷阱模板.Name;
			}
		}

		
		public override GameObjectType ObjectType
		{
			get
			{
				return GameObjectType.Trap;
			}
		}

		
		public override ObjectSize ObjectSize
		{
			get
			{
				return this.陷阱模板.Size;
			}
		}

		
		public override Dictionary<GameObjectStats, int> Stats
		{
			get
			{
				return base.Stats;
			}
		}

		
		public TrapObject(MapObject 来源, SkillTraps 模板, MapInstance 地图, Point 坐标)
		{
			
			
			this.TrapSource = 来源;
			this.陷阱模板 = 模板;
			this.CurrentMap = 地图;
			this.CurrentPosition = 坐标;
			this.WalkTime = MainProcess.CurrentTime;
			this.放置时间 = MainProcess.CurrentTime;
			this.Id = 模板.Id;
			this.CurrentDirection = this.TrapSource.CurrentDirection;
			this.被动触发列表 = new HashSet<MapObject>();
			this.消失时间 = this.放置时间 + TimeSpan.FromMilliseconds((double)this.陷阱模板.Duration);
			this.触发时间 = this.放置时间 + TimeSpan.FromMilliseconds((double)this.陷阱模板.ActivelyTriggerDelay);
			PlayerObject PlayerObject = 来源 as PlayerObject;
			if (PlayerObject != null)
			{
				SkillData SkillData;
				if (this.陷阱模板.BindingLevel != 0 && PlayerObject.MainSkills表.TryGetValue(this.陷阱模板.BindingLevel, out SkillData))
				{
					this.陷阱等级 = SkillData.SkillLevel.V;
				}
				if (this.陷阱模板.ExtendedDuration && this.陷阱模板.SkillLevelDelay)
				{
					this.消失时间 += TimeSpan.FromMilliseconds((double)((int)this.陷阱等级 * this.陷阱模板.ExtendedTimePerLevel));
				}
				if (this.陷阱模板.ExtendedDuration && this.陷阱模板.PlayerStatDelay)
				{
					this.消失时间 += TimeSpan.FromMilliseconds((double)((float)PlayerObject[this.陷阱模板.BoundPlayerStat] * this.陷阱模板.StatDelayFactor));
				}
				SkillData SkillData2;
				if (this.陷阱模板.ExtendedDuration && this.陷阱模板.HasSpecificInscriptionDelay && PlayerObject.MainSkills表.TryGetValue((ushort)(this.陷阱模板.SpecificInscriptionSkills / 10), out SkillData2) && (int)SkillData2.Id == this.陷阱模板.SpecificInscriptionSkills % 10)
				{
					this.消失时间 += TimeSpan.FromMilliseconds((double)this.陷阱模板.InscriptionExtendedTime);
				}
			}
			this.ActivelyTriggerSkills = ((this.陷阱模板.ActivelyTriggerSkills == null || !GameSkills.DataSheet.ContainsKey(this.陷阱模板.ActivelyTriggerSkills)) ? null : GameSkills.DataSheet[this.陷阱模板.ActivelyTriggerSkills]);
			this.PassiveTriggerSkill = ((this.陷阱模板.PassiveTriggerSkill == null || !GameSkills.DataSheet.ContainsKey(this.陷阱模板.PassiveTriggerSkill)) ? null : GameSkills.DataSheet[this.陷阱模板.PassiveTriggerSkill]);
			this.ObjectId = ++MapGatewayProcess.Id;
			base.BindGrid();
			base.更新邻居时处理();
			MapGatewayProcess.添加MapObject(this);
			this.ActiveObject = true;
			MapGatewayProcess.添加激活对象(this);
		}

		
		public override void Process()
		{
			if (MainProcess.CurrentTime < base.ProcessTime)
			{
				return;
			}
			if (MainProcess.CurrentTime > this.消失时间)
			{
				this.陷阱消失处理();
			}
			else
			{
				foreach (SkillInstance 技能实例 in this.SkillTasks.ToList<SkillInstance>())
				{
					技能实例.Process();
				}
				if (this.ActivelyTriggerSkills != null && MainProcess.CurrentTime > this.触发时间)
				{
					this.主动触发陷阱();
				}
				if (this.陷阱模板.CanMove && this.陷阱移动次数 < this.陷阱模板.LimitMoveSteps && MainProcess.CurrentTime > this.WalkTime)
				{
					if (this.陷阱模板.MoveInCurrentDirection)
					{
						base.ItSelf移动时处理(ComputingClass.前方坐标(this.CurrentPosition, this.CurrentDirection, 1));
						base.SendPacket(new TrapMoveLocationPacket
						{
							Id = this.ObjectId,
							移动坐标 = this.CurrentPosition,
							移动高度 = this.CurrentAltitude,
							移动速度 = this.陷阱模板.MoveSpeed
						});
					}
					if (this.PassiveTriggerSkill != null)
					{
						foreach (Point 坐标 in ComputingClass.GetLocationRange(this.CurrentPosition, this.CurrentDirection, this.ObjectSize))
						{
							foreach (MapObject 对象 in this.CurrentMap[坐标].ToList<MapObject>())
							{
								this.被动触发陷阱(对象);
							}
						}
					}
					this.陷阱移动次数 += 1;
					this.WalkTime = this.WalkTime.AddMilliseconds((double)(this.陷阱模板.MoveSpeed * 60));
				}
			}
			base.Process();
		}

		
		public void 被动触发陷阱(MapObject 对象)
		{
			if (MainProcess.CurrentTime > this.消失时间)
			{
				return;
			}
			if (this.PassiveTriggerSkill != null && !对象.Died && (对象.ObjectType & this.陷阱模板.PassiveObjectType) != (GameObjectType)0 && 对象.IsSpecificType(this.TrapSource, this.陷阱模板.PassiveTargetType) && (this.TrapSource.GetRelationship(对象) & this.陷阱模板.PassiveType) != (GameObjectRelationship)0 && (!this.陷阱模板.RetriggeringIsProhibited || this.被动触发列表.Add(对象)))
			{
				new SkillInstance(this, this.PassiveTriggerSkill, null, 0, this.CurrentMap, this.CurrentPosition, 对象, 对象.CurrentPosition, null, null, false);
			}
		}

		
		public void 主动触发陷阱()
		{
			if (MainProcess.CurrentTime > this.消失时间)
			{
				return;
			}
			new SkillInstance(this, this.ActivelyTriggerSkills, null, 0, this.CurrentMap, this.CurrentPosition, null, this.CurrentPosition, null, null, false);
			this.触发时间 += TimeSpan.FromMilliseconds((double)this.ActivelyTriggerInterval);
		}

		
		public void 陷阱消失处理()
		{
			base.Delete();
		}

		
		public byte 陷阱等级;

		
		public ushort Id;

		
		public DateTime 放置时间;

		
		public DateTime 消失时间;

		
		public DateTime 触发时间;

		
		public MapObject TrapSource;

		
		public SkillTraps 陷阱模板;

		
		public HashSet<MapObject> 被动触发列表;

		
		public byte 陷阱移动次数;

		
		public GameSkills PassiveTriggerSkill;

		
		public GameSkills ActivelyTriggerSkills;
	}
}
