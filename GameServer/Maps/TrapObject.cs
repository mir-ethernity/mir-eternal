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
		
		// (get) Token: 0x06000817 RID: 2071 RVA: 0x00006ADF File Offset: 0x00004CDF
		public ushort 陷阱GroupId
		{
			get
			{
				return this.陷阱模板.GroupId;
			}
		}

		
		// (get) Token: 0x06000818 RID: 2072 RVA: 0x00006AEC File Offset: 0x00004CEC
		public ushort 主动触发间隔
		{
			get
			{
				return this.陷阱模板.主动触发间隔;
			}
		}

		
		// (get) Token: 0x06000819 RID: 2073 RVA: 0x00006AF9 File Offset: 0x00004CF9
		public ushort 主动触发延迟
		{
			get
			{
				return this.陷阱模板.主动触发延迟;
			}
		}

		
		// (get) Token: 0x0600081A RID: 2074 RVA: 0x00041084 File Offset: 0x0003F284
		public ushort 陷阱剩余时间
		{
			get
			{
				return (ushort)Math.Ceiling((this.消失时间 - MainProcess.CurrentTime).TotalMilliseconds / 62.5);
			}
		}

		
		// (get) Token: 0x0600081B RID: 2075 RVA: 0x00006167 File Offset: 0x00004367
		// (set) Token: 0x0600081C RID: 2076 RVA: 0x0000616F File Offset: 0x0000436F
		public override MapInstance 当前地图
		{
			get
			{
				return base.当前地图;
			}
			set
			{
				if (this.当前地图 != value)
				{
					MapInstance 当前地图 = base.当前地图;
					if (当前地图 != null)
					{
						当前地图.移除对象(this);
					}
					base.当前地图 = value;
					base.当前地图.添加对象(this);
				}
			}
		}

		
		// (get) Token: 0x0600081D RID: 2077 RVA: 0x00006134 File Offset: 0x00004334
		public override int 处理间隔
		{
			get
			{
				return 10;
			}
		}

		
		// (get) Token: 0x0600081E RID: 2078 RVA: 0x00006B06 File Offset: 0x00004D06
		// (set) Token: 0x0600081F RID: 2079 RVA: 0x00006B13 File Offset: 0x00004D13
		public override byte 当前等级
		{
			get
			{
				return this.陷阱来源.当前等级;
			}
			set
			{
				this.陷阱来源.当前等级 = value;
			}
		}

		
		// (get) Token: 0x06000820 RID: 2080 RVA: 0x00002855 File Offset: 0x00000A55
		// (set) Token: 0x06000821 RID: 2081 RVA: 0x00006B21 File Offset: 0x00004D21
		public override bool 阻塞网格
		{
			get
			{
				return false;
			}
			set
			{
				base.阻塞网格 = value;
			}
		}

		
		// (get) Token: 0x06000822 RID: 2082 RVA: 0x00002855 File Offset: 0x00000A55
		public override bool 能被命中
		{
			get
			{
				return false;
			}
		}

		
		// (get) Token: 0x06000823 RID: 2083 RVA: 0x00006B2A File Offset: 0x00004D2A
		public override string 对象名字
		{
			get
			{
				return this.陷阱模板.陷阱名字;
			}
		}

		
		// (get) Token: 0x06000824 RID: 2084 RVA: 0x00006B37 File Offset: 0x00004D37
		public override GameObjectType 对象类型
		{
			get
			{
				return GameObjectType.陷阱;
			}
		}

		
		// (get) Token: 0x06000825 RID: 2085 RVA: 0x00006B3B File Offset: 0x00004D3B
		public override MonsterSize 对象体型
		{
			get
			{
				return this.陷阱模板.陷阱体型;
			}
		}

		
		// (get) Token: 0x06000826 RID: 2086 RVA: 0x00006B48 File Offset: 0x00004D48
		public override Dictionary<GameObjectStats, int> 当前Stat
		{
			get
			{
				return base.当前Stat;
			}
		}

		
		public TrapObject(MapObject 来源, 技能陷阱 模板, MapInstance 地图, Point 坐标)
		{
			
			
			this.陷阱来源 = 来源;
			this.陷阱模板 = 模板;
			this.当前地图 = 地图;
			this.当前坐标 = 坐标;
			this.行走时间 = MainProcess.CurrentTime;
			this.放置时间 = MainProcess.CurrentTime;
			this.陷阱编号 = 模板.陷阱编号;
			this.当前方向 = this.陷阱来源.当前方向;
			this.被动触发列表 = new HashSet<MapObject>();
			this.消失时间 = this.放置时间 + TimeSpan.FromMilliseconds((double)this.陷阱模板.陷阱持续时间);
			this.触发时间 = this.放置时间 + TimeSpan.FromMilliseconds((double)this.陷阱模板.主动触发延迟);
			PlayerObject PlayerObject = 来源 as PlayerObject;
			if (PlayerObject != null)
			{
				SkillData SkillData;
				if (this.陷阱模板.绑定等级 != 0 && PlayerObject.MainSkills表.TryGetValue(this.陷阱模板.绑定等级, out SkillData))
				{
					this.陷阱等级 = SkillData.技能等级.V;
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
			this.主动触发技能 = ((this.陷阱模板.主动触发技能 == null || !GameSkills.DataSheet.ContainsKey(this.陷阱模板.主动触发技能)) ? null : GameSkills.DataSheet[this.陷阱模板.主动触发技能]);
			this.被动触发技能 = ((this.陷阱模板.被动触发技能 == null || !GameSkills.DataSheet.ContainsKey(this.陷阱模板.被动触发技能)) ? null : GameSkills.DataSheet[this.陷阱模板.被动触发技能]);
			this.MapId = ++MapGatewayProcess.陷阱编号;
			base.绑定网格();
			base.更新邻居时处理();
			MapGatewayProcess.添加MapObject(this);
			this.激活对象 = true;
			MapGatewayProcess.添加激活对象(this);
		}

		
		public override void 处理对象数据()
		{
			if (MainProcess.CurrentTime < base.预约时间)
			{
				return;
			}
			if (MainProcess.CurrentTime > this.消失时间)
			{
				this.陷阱消失处理();
			}
			else
			{
				foreach (技能实例 技能实例 in this.技能任务.ToList<技能实例>())
				{
					技能实例.处理任务();
				}
				if (this.主动触发技能 != null && MainProcess.CurrentTime > this.触发时间)
				{
					this.主动触发陷阱();
				}
				if (this.陷阱模板.陷阱能否移动 && this.陷阱移动次数 < this.陷阱模板.限制移动次数 && MainProcess.CurrentTime > this.行走时间)
				{
					if (this.陷阱模板.当前方向移动)
					{
						base.自身移动时处理(ComputingClass.前方坐标(this.当前坐标, this.当前方向, 1));
						base.发送封包(new TrapMoveLocationPacket
						{
							陷阱编号 = this.MapId,
							移动坐标 = this.当前坐标,
							移动高度 = this.当前高度,
							移动速度 = this.陷阱模板.陷阱移动速度
						});
					}
					if (this.被动触发技能 != null)
					{
						foreach (Point 坐标 in ComputingClass.技能范围(this.当前坐标, this.当前方向, this.对象体型))
						{
							foreach (MapObject 对象 in this.当前地图[坐标].ToList<MapObject>())
							{
								this.被动触发陷阱(对象);
							}
						}
					}
					this.陷阱移动次数 += 1;
					this.行走时间 = this.行走时间.AddMilliseconds((double)(this.陷阱模板.陷阱移动速度 * 60));
				}
			}
			base.处理对象数据();
		}

		
		public void 被动触发陷阱(MapObject 对象)
		{
			if (MainProcess.CurrentTime > this.消失时间)
			{
				return;
			}
			if (this.被动触发技能 != null && !对象.对象死亡 && (对象.对象类型 & this.陷阱模板.被动限定类型) != (GameObjectType)0 && 对象.特定类型(this.陷阱来源, this.陷阱模板.被动指定类型) && (this.陷阱来源.对象关系(对象) & this.陷阱模板.被动限定关系) != (游戏对象关系)0 && (!this.陷阱模板.禁止重复触发 || this.被动触发列表.Add(对象)))
			{
				new 技能实例(this, this.被动触发技能, null, 0, this.当前地图, this.当前坐标, 对象, 对象.当前坐标, null, null, false);
			}
		}

		
		public void 主动触发陷阱()
		{
			if (MainProcess.CurrentTime > this.消失时间)
			{
				return;
			}
			new 技能实例(this, this.主动触发技能, null, 0, this.当前地图, this.当前坐标, null, this.当前坐标, null, null, false);
			this.触发时间 += TimeSpan.FromMilliseconds((double)this.主动触发间隔);
		}

		
		public void 陷阱消失处理()
		{
			base.删除对象();
		}

		
		public byte 陷阱等级;

		
		public ushort 陷阱编号;

		
		public DateTime 放置时间;

		
		public DateTime 消失时间;

		
		public DateTime 触发时间;

		
		public MapObject 陷阱来源;

		
		public 技能陷阱 陷阱模板;

		
		public HashSet<MapObject> 被动触发列表;

		
		public byte 陷阱移动次数;

		
		public GameSkills 被动触发技能;

		
		public GameSkills 主动触发技能;
	}
}
