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
		
		// (get) Token: 0x0600083D RID: 2109 RVA: 0x00006BFE File Offset: 0x00004DFE
		// (set) Token: 0x0600083E RID: 2110 RVA: 0x00006C06 File Offset: 0x00004E06
		public bool 禁止复活 { get; set; }

		
		// (get) Token: 0x0600083F RID: 2111 RVA: 0x00006C0F File Offset: 0x00004E0F
		// (set) Token: 0x06000840 RID: 2112 RVA: 0x00006C17 File Offset: 0x00004E17
		public bool 尸体消失 { get; set; }

		
		// (get) Token: 0x06000841 RID: 2113 RVA: 0x00006C20 File Offset: 0x00004E20
		// (set) Token: 0x06000842 RID: 2114 RVA: 0x00006C28 File Offset: 0x00004E28
		public DateTime 攻击时间 { get; set; }

		
		// (get) Token: 0x06000843 RID: 2115 RVA: 0x00006C31 File Offset: 0x00004E31
		// (set) Token: 0x06000844 RID: 2116 RVA: 0x00006C39 File Offset: 0x00004E39
		public DateTime 漫游时间 { get; set; }

		
		// (get) Token: 0x06000845 RID: 2117 RVA: 0x00006C42 File Offset: 0x00004E42
		// (set) Token: 0x06000846 RID: 2118 RVA: 0x00006C4A File Offset: 0x00004E4A
		public DateTime 复活时间 { get; set; }

		
		// (get) Token: 0x06000847 RID: 2119 RVA: 0x00006C53 File Offset: 0x00004E53
		// (set) Token: 0x06000848 RID: 2120 RVA: 0x00006C5B File Offset: 0x00004E5B
		public DateTime 消失时间 { get; set; }

		
		// (get) Token: 0x06000849 RID: 2121 RVA: 0x00006C64 File Offset: 0x00004E64
		// (set) Token: 0x0600084A RID: 2122 RVA: 0x00006C6C File Offset: 0x00004E6C
		public DateTime 存活时间 { get; set; }

		
		// (get) Token: 0x0600084B RID: 2123 RVA: 0x00006134 File Offset: 0x00004334
		public override int 处理间隔
		{
			get
			{
				return 10;
			}
		}

		
		// (get) Token: 0x0600084C RID: 2124 RVA: 0x00006138 File Offset: 0x00004338
		// (set) Token: 0x0600084D RID: 2125 RVA: 0x00036440 File Offset: 0x00034640
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

		
		// (get) Token: 0x0600084E RID: 2126 RVA: 0x00006140 File Offset: 0x00004340
		// (set) Token: 0x0600084F RID: 2127 RVA: 0x00006148 File Offset: 0x00004348
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

		
		// (get) Token: 0x06000850 RID: 2128 RVA: 0x0000615F File Offset: 0x0000435F
		// (set) Token: 0x06000851 RID: 2129 RVA: 0x0003646C File Offset: 0x0003466C
		public override int 当前体力
		{
			get
			{
				return base.当前体力;
			}
			set
			{
				value = ComputingClass.数值限制(0, value, this[GameObjectProperties.最大体力]);
				if (base.当前体力 != value)
				{
					base.当前体力 = value;
					base.发送封包(new 同步对象体力
					{
						对象编号 = this.MapId,
						当前体力 = this.当前体力,
						体力上限 = this[GameObjectProperties.最大体力]
					});
				}
			}
		}

		
		// (get) Token: 0x06000852 RID: 2130 RVA: 0x00006167 File Offset: 0x00004367
		// (set) Token: 0x06000853 RID: 2131 RVA: 0x0000616F File Offset: 0x0000436F
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

		
		// (get) Token: 0x06000854 RID: 2132 RVA: 0x0000619F File Offset: 0x0000439F
		// (set) Token: 0x06000855 RID: 2133 RVA: 0x000061A7 File Offset: 0x000043A7
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
					base.发送封包(new ObjectRotationDirectionPacket
					{
						转向耗时 = 100,
						对象编号 = this.MapId,
						对象朝向 = (ushort)value
					});
				}
			}
		}

		
		// (get) Token: 0x06000856 RID: 2134 RVA: 0x00006C75 File Offset: 0x00004E75
		public override byte 当前等级
		{
			get
			{
				return this.对象模板.怪物等级;
			}
		}

		
		// (get) Token: 0x06000857 RID: 2135 RVA: 0x00006C82 File Offset: 0x00004E82
		public override string 对象名字
		{
			get
			{
				return this.对象模板.怪物名字;
			}
		}

		
		// (get) Token: 0x06000858 RID: 2136 RVA: 0x00006A23 File Offset: 0x00004C23
		public override GameObjectType 对象类型
		{
			get
			{
				return GameObjectType.怪物;
			}
		}

		
		// (get) Token: 0x06000859 RID: 2137 RVA: 0x00006C8F File Offset: 0x00004E8F
		public override 技能范围类型 对象体型
		{
			get
			{
				return this.对象模板.怪物体型;
			}
		}

		
		public override int this[GameObjectProperties 属性]
		{
			get
			{
				return base[属性];
			}
			set
			{
				base[属性] = value;
			}
		}

		
		// (get) Token: 0x0600085C RID: 2140 RVA: 0x00006C9C File Offset: 0x00004E9C
		public MonsterRaceType 怪物种族
		{
			get
			{
				return this.对象模板.怪物分类;
			}
		}

		
		// (get) Token: 0x0600085D RID: 2141 RVA: 0x00006CA9 File Offset: 0x00004EA9
		public MonsterLevelType 怪物级别
		{
			get
			{
				return this.对象模板.怪物级别;
			}
		}

		
		// (get) Token: 0x0600085E RID: 2142 RVA: 0x00006CB6 File Offset: 0x00004EB6
		public List<怪物掉落> 怪物掉落
		{
			get
			{
				return this.对象模板.怪物掉落物品;
			}
		}

		
		// (get) Token: 0x0600085F RID: 2143 RVA: 0x00006CC3 File Offset: 0x00004EC3
		public ushort 模板编号
		{
			get
			{
				return this.对象模板.怪物编号;
			}
		}

		
		// (get) Token: 0x06000860 RID: 2144 RVA: 0x00006CD0 File Offset: 0x00004ED0
		public int 怪物经验
		{
			get
			{
				return (int)this.对象模板.怪物提供经验;
			}
		}

		
		// (get) Token: 0x06000861 RID: 2145 RVA: 0x00006CDD File Offset: 0x00004EDD
		public int 仇恨范围
		{
			get
			{
				if (this.当前地图.MapId != 80)
				{
					return (int)this.对象模板.怪物仇恨范围;
				}
				return 25;
			}
		}

		
		// (get) Token: 0x06000862 RID: 2146 RVA: 0x00006CFC File Offset: 0x00004EFC
		public int 移动间隔
		{
			get
			{
				return (int)this.对象模板.怪物移动间隔;
			}
		}

		
		// (get) Token: 0x06000863 RID: 2147 RVA: 0x00006A2D File Offset: 0x00004C2D
		public int 切换间隔
		{
			get
			{
				return 5000;
			}
		}

		
		// (get) Token: 0x06000864 RID: 2148 RVA: 0x00006D09 File Offset: 0x00004F09
		public int 漫游间隔
		{
			get
			{
				return (int)this.对象模板.怪物漫游间隔;
			}
		}

		
		// (get) Token: 0x06000865 RID: 2149 RVA: 0x00006D16 File Offset: 0x00004F16
		public int 仇恨时长
		{
			get
			{
				return (int)this.对象模板.怪物仇恨时间;
			}
		}

		
		// (get) Token: 0x06000866 RID: 2150 RVA: 0x00006D23 File Offset: 0x00004F23
		public int 尸体保留
		{
			get
			{
				return (int)this.对象模板.尸体保留时长;
			}
		}

		
		// (get) Token: 0x06000867 RID: 2151 RVA: 0x00006D30 File Offset: 0x00004F30
		public bool 怪物禁止移动
		{
			get
			{
				return this.对象模板.怪物禁止移动;
			}
		}

		
		// (get) Token: 0x06000868 RID: 2152 RVA: 0x00006D3D File Offset: 0x00004F3D
		public bool 可被技能推动
		{
			get
			{
				return this.对象模板.可被技能推动;
			}
		}

		
		// (get) Token: 0x06000869 RID: 2153 RVA: 0x00006D4A File Offset: 0x00004F4A
		public bool 可见隐身目标
		{
			get
			{
				return this.对象模板.可见隐身目标;
			}
		}

		
		// (get) Token: 0x0600086A RID: 2154 RVA: 0x00006D57 File Offset: 0x00004F57
		public bool 可被技能控制
		{
			get
			{
				return this.对象模板.可被技能控制;
			}
		}

		
		// (get) Token: 0x0600086B RID: 2155 RVA: 0x00006D64 File Offset: 0x00004F64
		public bool 可被技能诱惑
		{
			get
			{
				return this.对象模板.可被技能诱惑;
			}
		}

		
		// (get) Token: 0x0600086C RID: 2156 RVA: 0x00006D71 File Offset: 0x00004F71
		public float 基础诱惑概率
		{
			get
			{
				return this.对象模板.基础诱惑概率;
			}
		}

		
		// (get) Token: 0x0600086D RID: 2157 RVA: 0x00006D7E File Offset: 0x00004F7E
		public bool 主动攻击目标
		{
			get
			{
				return this.对象模板.主动攻击目标;
			}
		}

		
		public MonsterObject(PetObject 对应宠物)
		{
			
			
			this.MapId = ++MapGatewayProcess.对象编号;
			this.对象模板 = 对应宠物.对象模板;
			this.当前地图 = 对应宠物.当前地图;
			this.当前坐标 = 对应宠物.当前坐标;
			this.当前方向 = 对应宠物.当前方向;
			this.宠物等级 = 对应宠物.宠物等级;
			this.禁止复活 = true;
			this.HateObject = new HateObject();
			this.存活时间 = MainProcess.CurrentTime.AddHours(2.0);
			base.恢复时间 = MainProcess.CurrentTime.AddSeconds(5.0);
			this.攻击时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.漫游间隔);
			this.属性加成[this] = 对应宠物.基础属性;
			this.更新对象属性();
			this.当前体力 = Math.Min(对应宠物.当前体力, this[GameObjectProperties.最大体力]);
			string text = this.对象模板.普通攻击技能;
			if (text != null && text.Length > 0)
			{
				游戏技能.DataSheet.TryGetValue(this.对象模板.普通攻击技能, out this.普通攻击技能);
			}
			string text2 = this.对象模板.概率触发技能;
			if (text2 != null && text2.Length > 0)
			{
				游戏技能.DataSheet.TryGetValue(this.对象模板.概率触发技能, out this.概率触发技能);
			}
			string text3 = this.对象模板.进入战斗技能;
			if (text3 != null && text3.Length > 0)
			{
				游戏技能.DataSheet.TryGetValue(this.对象模板.进入战斗技能, out this.进入战斗技能);
			}
			string text4 = this.对象模板.退出战斗技能;
			if (text4 != null && text4.Length > 0)
			{
				游戏技能.DataSheet.TryGetValue(this.对象模板.退出战斗技能, out this.退出战斗技能);
			}
			string text5 = this.对象模板.死亡释放技能;
			if (text5 != null && text5.Length > 0)
			{
				游戏技能.DataSheet.TryGetValue(this.对象模板.死亡释放技能, out this.死亡释放技能);
			}
			string text6 = this.对象模板.移动释放技能;
			if (text6 != null && text6.Length > 0)
			{
				游戏技能.DataSheet.TryGetValue(this.对象模板.移动释放技能, out this.移动释放技能);
			}
			string text7 = this.对象模板.出生释放技能;
			if (text7 != null && text7.Length > 0)
			{
				游戏技能.DataSheet.TryGetValue(this.对象模板.出生释放技能, out this.出生释放技能);
			}
			对应宠物.自身死亡处理(null, false);
			对应宠物.删除对象();
			this.对象死亡 = false;
			base.战斗姿态 = false;
			this.阻塞网格 = true;
			base.绑定网格();
			base.更新邻居时处理();
			MapGatewayProcess.添加MapObject(this);
		}

		
		public MonsterObject(游戏怪物 对应模板, MapInstance 出生地图, int 复活间隔, Point[] 出生范围, bool 禁止复活, bool 立即刷新)
		{
			
			
			this.对象模板 = 对应模板;
			this.出生地图 = 出生地图;
			this.当前地图 = 出生地图;
			this.复活间隔 = 复活间隔;
			this.出生范围 = 出生范围;
			this.禁止复活 = 禁止复活;
			this.MapId = ++MapGatewayProcess.对象编号;
			this.属性加成[this] = 对应模板.基础属性;
			string text = this.对象模板.普通攻击技能;
			if (text != null && text.Length > 0)
			{
				游戏技能.DataSheet.TryGetValue(this.对象模板.普通攻击技能, out this.普通攻击技能);
			}
			string text2 = this.对象模板.概率触发技能;
			if (text2 != null && text2.Length > 0)
			{
				游戏技能.DataSheet.TryGetValue(this.对象模板.概率触发技能, out this.概率触发技能);
			}
			string text3 = this.对象模板.进入战斗技能;
			if (text3 != null && text3.Length > 0)
			{
				游戏技能.DataSheet.TryGetValue(this.对象模板.进入战斗技能, out this.进入战斗技能);
			}
			string text4 = this.对象模板.退出战斗技能;
			if (text4 != null && text4.Length > 0)
			{
				游戏技能.DataSheet.TryGetValue(this.对象模板.退出战斗技能, out this.退出战斗技能);
			}
			string text5 = this.对象模板.死亡释放技能;
			if (text5 != null && text5.Length > 0)
			{
				游戏技能.DataSheet.TryGetValue(this.对象模板.死亡释放技能, out this.死亡释放技能);
			}
			string text6 = this.对象模板.移动释放技能;
			if (text6 != null && text6.Length > 0)
			{
				游戏技能.DataSheet.TryGetValue(this.对象模板.移动释放技能, out this.移动释放技能);
			}
			string text7 = this.对象模板.出生释放技能;
			if (text7 != null && text7.Length > 0)
			{
				游戏技能.DataSheet.TryGetValue(this.对象模板.出生释放技能, out this.出生释放技能);
			}
			MapGatewayProcess.添加MapObject(this);
			if (!禁止复活)
			{
				this.当前地图.固定怪物总数 += 1U;
				MainForm.更新地图数据(this.当前地图, "固定怪物总数", this.当前地图.固定怪物总数);
			}
			if (立即刷新)
			{
				this.怪物复活处理(false);
				return;
			}
			this.复活时间 = MainProcess.CurrentTime.AddMilliseconds((double)复活间隔);
			this.阻塞网格 = false;
			this.尸体消失 = true;
			this.对象死亡 = true;
			this.次要对象 = true;
			MapGatewayProcess.添加次要对象(this);
		}

		
		public override void 处理对象数据()
		{
			if (MainProcess.CurrentTime < base.预约时间)
			{
				return;
			}
			if (this.禁止复活 && MainProcess.CurrentTime >= this.存活时间)
			{
				base.删除对象();
			}
			else if (this.对象死亡)
			{
				if (!this.尸体消失 && MainProcess.CurrentTime >= this.消失时间)
				{
					if (this.禁止复活)
					{
						base.删除对象();
					}
					else
					{
						this.尸体消失 = true;
						base.清空邻居时处理();
						base.解绑网格();
					}
				}
				if (!this.禁止复活 && MainProcess.CurrentTime >= this.复活时间)
				{
					base.清空邻居时处理();
					base.解绑网格();
					this.怪物复活处理(true);
				}
			}
			else
			{
				foreach (KeyValuePair<ushort, BuffData> keyValuePair in this.Buff列表.ToList<KeyValuePair<ushort, BuffData>>())
				{
					base.轮询Buff时处理(keyValuePair.Value);
				}
				foreach (技能实例 技能实例 in this.技能任务.ToList<技能实例>())
				{
					技能实例.处理任务();
				}
				if (MainProcess.CurrentTime > base.恢复时间)
				{
					if (!this.检查状态(游戏对象状态.中毒状态))
					{
						this.当前体力 += this[GameObjectProperties.体力恢复];
					}
					base.恢复时间 = MainProcess.CurrentTime.AddSeconds(5.0);
				}
				if (MainProcess.CurrentTime > base.治疗时间 && base.治疗次数 > 0)
				{
					int 治疗次数 = base.治疗次数;
					base.治疗次数 = 治疗次数 - 1;
					base.治疗时间 = MainProcess.CurrentTime.AddMilliseconds(500.0);
					this.当前体力 += base.治疗基数;
				}
				if (MainProcess.CurrentTime > this.忙碌时间 && MainProcess.CurrentTime > this.硬直时间)
				{
					if (this.进入战斗技能 != null && !base.战斗姿态 && this.HateObject.仇恨列表.Count != 0)
					{
						游戏技能 技能模板 = this.进入战斗技能;
						SkillData SkillData = null;
						byte 动作编号 = base.动作编号;
						base.动作编号 = (byte)(动作编号 + 1);
						new 技能实例(this, 技能模板, SkillData, 动作编号, this.当前地图, this.当前坐标, null, this.当前坐标, null, null, false);
						base.战斗姿态 = true;
						base.脱战时间 = MainProcess.CurrentTime.AddSeconds(10.0);
					}
					else if (this.退出战斗技能 != null && base.战斗姿态 && this.HateObject.仇恨列表.Count == 0 && MainProcess.CurrentTime > base.脱战时间)
					{
						游戏技能 技能模板2 = this.退出战斗技能;
						SkillData SkillData2 = null;
						byte 动作编号 = base.动作编号;
						base.动作编号 = (byte)(动作编号 + 1);
						new 技能实例(this, 技能模板2, SkillData2, 动作编号, this.当前地图, this.当前坐标, null, this.当前坐标, null, null, false);
						base.战斗姿态 = false;
					}
					else if (this.对象模板.脱战自动石化 && !base.战斗姿态 && this.HateObject.仇恨列表.Count != 0)
					{
						base.战斗姿态 = true;
						base.移除Buff时处理(this.对象模板.石化状态编号);
						base.脱战时间 = MainProcess.CurrentTime.AddSeconds(10.0);
					}
					else if (this.对象模板.脱战自动石化 && base.战斗姿态 && this.HateObject.仇恨列表.Count == 0 && MainProcess.CurrentTime > base.脱战时间)
					{
						base.战斗姿态 = false;
						base.添加Buff时处理(this.对象模板.石化状态编号, this);
					}
					else if ((this.怪物级别 == MonsterLevelType.头目首领) ? this.更新最近仇恨() : this.更新HateObject())
					{
						this.怪物智能攻击();
					}
					else
					{
						this.怪物随机漫游();
					}
				}
			}
			base.处理对象数据();
		}

		
		public override void 自身死亡处理(MapObject 对象, bool 技能击杀)
		{
			foreach (技能实例 技能实例 in this.技能任务)
			{
				技能实例.技能中断();
			}
			base.自身死亡处理(对象, 技能击杀);
			if (this.死亡释放技能 != null && 对象 != null)
			{
				游戏技能 技能模板 = this.死亡释放技能;
				SkillData SkillData = null;
				byte 动作编号 = base.动作编号;
				base.动作编号 = (byte)(动作编号 + 1);
				new 技能实例(this, 技能模板, SkillData, 动作编号, this.当前地图, this.当前坐标, null, this.当前坐标, null, null, false).处理任务();
			}
			if (this.当前地图.CopyMap || !this.禁止复活)
			{
				this.当前地图.存活怪物总数 -= 1U;
				MainForm.更新地图数据(this.当前地图, "存活怪物总数", -1);
			}
			this.尸体消失 = false;
			this.消失时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.尸体保留);
			this.复活时间 = MainProcess.CurrentTime.AddMilliseconds((double)Math.Max(this.复活间隔, this.尸体保留 + 5000));
			PetObject PetObject = 对象 as PetObject;
			if (PetObject != null)
			{
				PetObject.宠物经验增加();
			}
			PlayerObject PlayerObject;
			if (this.更新怪物归属(out PlayerObject))
			{
				if (this.当前地图.MapId == 80)
				{
					int num = 0;
					游戏物品 物品模板;
					if (游戏物品.检索表.TryGetValue("强效金创药", out 物品模板))
					{
						int num2 = (this.怪物级别 == MonsterLevelType.普通怪物) ? 15 : 1;
						int num3 = Math.Max(1, num2 - (int)Math.Round(num2 * CustomClass.怪物额外爆率));
						if (MainProcess.RandomNumber.Next(num3) == num3 / 2)
						{
							num++;
							new ItemObject(物品模板, null, this.当前地图, this.当前坐标, new HashSet<CharacterData>(), 1, false);
						}
					}
					游戏物品 物品模板2;
					if (游戏物品.检索表.TryGetValue("强效魔法药", out 物品模板2))
					{
						int num4 = (this.怪物级别 == MonsterLevelType.普通怪物) ? 20 : 1;
						int num5 = Math.Max(1, num4 - (int)Math.Round(num4 * CustomClass.怪物额外爆率));
						if (MainProcess.RandomNumber.Next(num5) == num5 / 2)
						{
							num++;
							new ItemObject(物品模板2, null, this.当前地图, this.当前坐标, new HashSet<CharacterData>(), 1, false);
						}
					}
					游戏物品 物品模板3;
					if (游戏物品.检索表.TryGetValue("疗伤药", out 物品模板3))
					{
						int num6 = (this.怪物级别 == MonsterLevelType.普通怪物) ? 100 : 1;
						int num7 = Math.Max(1, num6 - (int)Math.Round(num6 * CustomClass.怪物额外爆率));
						if (MainProcess.RandomNumber.Next(num7) == num7 / 2)
						{
							num++;
							new ItemObject(物品模板3, null, this.当前地图, this.当前坐标, new HashSet<CharacterData>(), 1, false);
						}
					}
					游戏物品 物品模板4;
					if (游戏物品.检索表.TryGetValue("祝福油", out 物品模板4))
					{
						int num8 = (this.怪物级别 == MonsterLevelType.普通怪物) ? 1000 : ((this.怪物级别 == MonsterLevelType.精英干将) ? 50 : 10);
						int num9 = Math.Max(1, num8 - (int)Math.Round(num8 * CustomClass.怪物额外爆率));
						if (MainProcess.RandomNumber.Next(num9) == num9 / 2)
						{
							num++;
							new ItemObject(物品模板4, null, this.当前地图, this.当前坐标, new HashSet<CharacterData>(), 1, false);
							NetworkServiceGateway.发送公告(string.Concat(new string[]
							{
								"[",
								this.对象名字,
								"] 被 [",
								PlayerObject.对象名字,
								"] 击杀, 掉落了[祝福油]"
							}), false);
						}
					}
					if (num > 0)
					{
						MainForm.更新地图数据(this.当前地图, "怪物掉落次数", num);
					}
					using (HashSet<PlayerObject>.Enumerator enumerator2 = this.当前地图.玩家列表.GetEnumerator())
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
				float num10 = ComputingClass.收益衰减((int)PlayerObject.当前等级, (int)this.当前等级);
				int num11 = 0;
				int num12 = 0;
				if (num10 < 1f)
				{
					foreach (怪物掉落 怪物掉落 in this.怪物掉落)
					{
						游戏物品 游戏物品;
						if (游戏物品.检索表.TryGetValue(怪物掉落.物品名字, out 游戏物品) && !ComputingClass.计算概率(num10) && (PlayerObject.本期特权 != 0 || this.怪物级别 == MonsterLevelType.头目首领 || 游戏物品.物品分类 == ItemUsageType.可用药剂 || !ComputingClass.计算概率(0.5f)) && (PlayerObject.本期特权 != 3 || this.怪物级别 == MonsterLevelType.头目首领 || 游戏物品.物品分类 == ItemUsageType.可用药剂 || !ComputingClass.计算概率(0.25f)))
						{
							int num13 = Math.Max(1, 怪物掉落.掉落概率 - (int)Math.Round(怪物掉落.掉落概率 * CustomClass.怪物额外爆率));
							if (MainProcess.RandomNumber.Next(num13) == num13 / 2)
							{
								int num14 = MainProcess.RandomNumber.Next(怪物掉落.最小数量, 怪物掉落.最大数量 + 1);
								if (num14 != 0)
								{
									if (游戏物品.物品持久 == 0)
									{
										new ItemObject(游戏物品, null, this.当前地图, this.当前坐标, 物品归属, num14, false);
										if (游戏物品.物品编号 == 1)
										{
											this.当前地图.金币掉落总数 += (long)num14;
											num11 = num14;
										}
										this.对象模板.掉落统计[游戏物品] = (this.对象模板.掉落统计.ContainsKey(游戏物品) ? this.对象模板.掉落统计[游戏物品] : 0L) + (long)num14;
									}
									else
									{
										for (int i = 0; i < num14; i++)
										{
											new ItemObject(游戏物品, null, this.当前地图, this.当前坐标, 物品归属, 1, false);
										}
										this.当前地图.怪物掉落次数 += (long)num14;
										num12++;
										this.对象模板.掉落统计[游戏物品] = (this.对象模板.掉落统计.ContainsKey(游戏物品) ? this.对象模板.掉落统计[游戏物品] : 0L) + (long)num14;
									}
									if (游戏物品.贵重物品)
									{
										NetworkServiceGateway.发送公告(string.Concat(new string[]
										{
											"[",
											this.对象名字,
											"] 被 [",
											PlayerObject.对象名字,
											"] 击杀, 掉落了[",
											游戏物品.物品名字,
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
					MainForm.更新地图数据(this.当前地图, "金币掉落总数", num11);
				}
				if (num12 > 0)
				{
					MainForm.更新地图数据(this.当前地图, "怪物掉落次数", num12);
				}
				if (num11 > 0 || num12 > 0)
				{
					MainForm.更新掉落统计(this.对象模板, this.对象模板.掉落统计.ToList<KeyValuePair<游戏物品, long>>());
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
					foreach (MapObject MapObject in this.重要邻居)
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
					float num16 = (float)list.Sum((PlayerObject x) => (int)x.当前等级);
					foreach (PlayerObject PlayerObject4 in list)
					{
						PlayerObject4.玩家增加经验(this, (int)(num15 * (float)PlayerObject4.当前等级 / num16));
					}
				}
			}
			IL_840:
			this.Buff列表.Clear();
			this.次要对象 = true;
			MapGatewayProcess.添加次要对象(this);
			if (this.激活对象)
			{
				this.激活对象 = false;
				MapGatewayProcess.移除激活对象(this);
			}
		}

		
		public void 怪物随机漫游()
		{
			if (!this.怪物禁止移动 && !(MainProcess.CurrentTime < this.漫游时间))
			{
				if (this.能否走动())
				{
					Point point = ComputingClass.前方坐标(this.当前坐标, ComputingClass.随机方向(), 1);
					if (this.当前地图.能否通行(point))
					{
						this.忙碌时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.行走耗时);
						this.行走时间 = MainProcess.CurrentTime.AddMilliseconds((double)(this.行走耗时 + this.移动间隔));
						this.当前方向 = ComputingClass.计算方向(this.当前坐标, point);
						base.自身移动时处理(point);
						if (!this.对象死亡)
						{
							base.发送封包(new ObjectCharacterWalkPacket
							{
								对象编号 = this.MapId,
								移动坐标 = this.当前坐标,
								移动速度 = base.行走速度
							});
						}
					}
				}
				this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)(this.漫游间隔 + MainProcess.RandomNumber.Next(5000)));
				return;
			}
		}

		
		public void 怪物智能攻击()
		{
			base.脱战时间 = MainProcess.CurrentTime.AddSeconds(10.0);
			游戏技能 游戏技能;
			if (this.概率触发技能 != null && (!this.冷却记录.ContainsKey((int)this.概率触发技能.自身技能编号 | 16777216) || MainProcess.CurrentTime > this.冷却记录[(int)this.概率触发技能.自身技能编号 | 16777216]) && ComputingClass.计算概率(this.概率触发技能.计算触发概率))
			{
				游戏技能 = this.概率触发技能;
			}
			else
			{
				if (this.普通攻击技能 == null || (this.冷却记录.ContainsKey((int)this.普通攻击技能.自身技能编号 | 16777216) && !(MainProcess.CurrentTime > this.冷却记录[(int)this.普通攻击技能.自身技能编号 | 16777216])))
				{
					return;
				}
				游戏技能 = this.普通攻击技能;
			}
			if (this.检查状态(游戏对象状态.忙绿状态 | 游戏对象状态.麻痹状态 | 游戏对象状态.失神状态))
			{
				return;
			}
			if (base.网格距离(this.HateObject.当前目标) > (int)游戏技能.技能最远距离)
			{
				if (!this.怪物禁止移动 && this.能否走动())
				{
					GameDirection GameDirection = ComputingClass.计算方向(this.当前坐标, this.HateObject.当前目标.当前坐标);
					Point point = default(Point);
					for (int i = 0; i < 8; i++)
					{
						if (this.当前地图.能否通行(point = ComputingClass.前方坐标(this.当前坐标, GameDirection, 1)))
						{
							this.忙碌时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.行走耗时);
							this.行走时间 = MainProcess.CurrentTime.AddMilliseconds((double)(this.行走耗时 + this.移动间隔));
							this.当前方向 = ComputingClass.计算方向(this.当前坐标, point);
							base.发送封包(new ObjectCharacterWalkPacket
							{
								对象编号 = this.MapId,
								移动坐标 = point,
								移动速度 = base.行走速度
							});
							base.自身移动时处理(point);
							return;
						}
						GameDirection = ComputingClass.旋转方向(GameDirection, (MainProcess.RandomNumber.Next(2) == 0) ? -1 : 1);
					}
					return;
				}
			}
			else if (游戏技能.需要正向走位 && !ComputingClass.直线方向(this.当前坐标, this.HateObject.当前目标.当前坐标))
			{
				if (!this.怪物禁止移动 && this.能否走动())
				{
					GameDirection GameDirection2 = ComputingClass.正向方向(this.当前坐标, this.HateObject.当前目标.当前坐标);
					Point point2 = default(Point);
					for (int j = 0; j < 8; j++)
					{
						if (this.当前地图.能否通行(point2 = ComputingClass.前方坐标(this.当前坐标, GameDirection2, 1)))
						{
							this.当前方向 = ComputingClass.计算方向(this.当前坐标, point2);
							this.忙碌时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.行走耗时);
							this.行走时间 = MainProcess.CurrentTime.AddMilliseconds((double)(this.行走耗时 + this.移动间隔));
							base.自身移动时处理(point2);
							if (!this.对象死亡)
							{
								base.发送封包(new ObjectCharacterWalkPacket
								{
									对象编号 = this.MapId,
									移动坐标 = point2,
									移动速度 = base.行走速度
								});
							}
							return;
						}
						GameDirection2 = ComputingClass.旋转方向(GameDirection2, (MainProcess.RandomNumber.Next(2) == 0) ? -1 : 1);
					}
					return;
				}
			}
			else
			{
				if (MainProcess.CurrentTime > this.攻击时间)
				{
					游戏技能 技能模板 = 游戏技能;
					SkillData SkillData = null;
					byte 动作编号 = base.动作编号;
					base.动作编号 = (byte)(动作编号 + 1);
					new 技能实例(this, 技能模板, SkillData, 动作编号, this.当前地图, this.当前坐标, this.HateObject.当前目标, this.HateObject.当前目标.当前坐标, null, null, false);
					this.攻击时间 = MainProcess.CurrentTime.AddMilliseconds((double)(ComputingClass.数值限制(0, 10 - this[GameObjectProperties.攻击速度], 10) * 500));
					return;
				}
				if (!this.怪物禁止移动 && this.能否转动())
				{
					this.当前方向 = ComputingClass.计算方向(this.当前坐标, this.HateObject.当前目标.当前坐标);
				}
			}
		}

		
		public void 怪物复活处理(bool 计算复活)
		{
			if (this.当前地图.CopyMap || !this.禁止复活)
			{
				this.当前地图.存活怪物总数 += 1U;
				MainForm.更新地图数据(this.当前地图, "存活怪物总数", 1);
				if (计算复活)
				{
					this.当前地图.怪物复活次数 += 1U;
					MainForm.更新地图数据(this.当前地图, "怪物复活次数", 1);
				}
			}
			this.更新对象属性();
			this.当前地图 = this.出生地图;
			this.当前方向 = ComputingClass.随机方向();
			this.当前体力 = this[GameObjectProperties.最大体力];
			this.当前坐标 = this.出生范围[MainProcess.RandomNumber.Next(0, this.出生范围.Length)];
			Point 当前坐标 = this.当前坐标;
			for (int i = 0; i < 100; i++)
			{
				if (!this.当前地图.空间阻塞(当前坐标 = ComputingClass.螺旋坐标(this.当前坐标, i)))
				{
					this.当前坐标 = 当前坐标;
					IL_F1:
					this.攻击时间 = MainProcess.CurrentTime.AddSeconds(1.0);
					base.恢复时间 = MainProcess.CurrentTime.AddMilliseconds((double)MainProcess.RandomNumber.Next(5000));
					this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)(MainProcess.RandomNumber.Next(5000) + this.漫游间隔));
					this.HateObject = new HateObject();
					this.次要对象 = false;
					this.对象死亡 = false;
					base.战斗姿态 = false;
					this.阻塞网格 = true;
					base.绑定网格();
					base.更新邻居时处理();
					if (!this.激活对象)
					{
						if (this.对象模板.脱战自动石化)
						{
							base.添加Buff时处理(this.对象模板.石化状态编号, this);
						}
						if (this.退出战斗技能 != null)
						{
							游戏技能 技能模板 = this.退出战斗技能;
							SkillData SkillData = null;
							byte 动作编号 = base.动作编号;
							base.动作编号 = (byte)(动作编号 + 1);
							new 技能实例(this, 技能模板, SkillData, 动作编号, this.当前地图, this.当前坐标, null, this.当前坐标, null, null, false).处理任务();
						}
					}
					return;
				}
			}
			//goto IL_F1;
		}

		
		public void 怪物诱惑处理()
		{
			this.Buff列表.Clear();
			this.尸体消失 = true;
			this.对象死亡 = true;
			this.阻塞网格 = false;
			if (this.禁止复活)
			{
				base.删除对象();
				return;
			}
			base.清空邻居时处理();
			base.解绑网格();
			this.复活时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.复活间隔);
			this.次要对象 = true;
			MapGatewayProcess.添加次要对象(this);
			this.激活对象 = false;
			MapGatewayProcess.移除激活对象(this);
		}

		
		public void 怪物沉睡处理()
		{
			if (this.激活对象)
			{
				this.激活对象 = false;
				this.技能任务.Clear();
				MapGatewayProcess.移除激活对象(this);
			}
			if (this.禁止复活 && !this.次要对象)
			{
				this.次要对象 = true;
				this.技能任务.Clear();
				MapGatewayProcess.添加次要对象(this);
			}
		}

		
		public void 怪物激活处理()
		{
			if (!this.激活对象)
			{
				this.次要对象 = false;
				this.激活对象 = true;
				MapGatewayProcess.添加激活对象(this);
				int num = (int)Math.Max(0.0, (MainProcess.CurrentTime - base.恢复时间).TotalSeconds / 5.0);
				base.当前体力 = Math.Min(this[GameObjectProperties.最大体力], this.当前体力 + num * this[GameObjectProperties.体力恢复]);
				base.恢复时间 = base.恢复时间.AddSeconds(5.0);
				this.攻击时间 = MainProcess.CurrentTime.AddSeconds(1.0);
				this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)(MainProcess.RandomNumber.Next(5000) + this.漫游间隔));
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
			else if (this.HateObject.当前目标.对象死亡)
			{
				this.HateObject.移除仇恨(this.HateObject.当前目标);
			}
			else if (!this.邻居列表.Contains(this.HateObject.当前目标))
			{
				this.HateObject.移除仇恨(this.HateObject.当前目标);
			}
			else if (!this.HateObject.仇恨列表.ContainsKey(this.HateObject.当前目标))
			{
				this.HateObject.移除仇恨(this.HateObject.当前目标);
			}
			else if (base.网格距离(this.HateObject.当前目标) > this.仇恨范围 && MainProcess.CurrentTime > this.HateObject.仇恨列表[this.HateObject.当前目标].仇恨时间)
			{
				this.HateObject.移除仇恨(this.HateObject.当前目标);
			}
			else if (base.网格距离(this.HateObject.当前目标) <= this.仇恨范围)
			{
				this.HateObject.仇恨列表[this.HateObject.当前目标].仇恨时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.仇恨时长);
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
			else if (this.HateObject.当前目标.对象死亡)
			{
				this.HateObject.移除仇恨(this.HateObject.当前目标);
			}
			else if (!this.邻居列表.Contains(this.HateObject.当前目标))
			{
				this.HateObject.移除仇恨(this.HateObject.当前目标);
			}
			else if (!this.HateObject.仇恨列表.ContainsKey(this.HateObject.当前目标))
			{
				this.HateObject.移除仇恨(this.HateObject.当前目标);
			}
			else if (base.网格距离(this.HateObject.当前目标) > this.仇恨范围 && MainProcess.CurrentTime > this.HateObject.仇恨列表[this.HateObject.当前目标].仇恨时间)
			{
				this.HateObject.移除仇恨(this.HateObject.当前目标);
			}
			else if (base.网格距离(this.HateObject.当前目标) <= this.仇恨范围)
			{
				this.HateObject.仇恨列表[this.HateObject.当前目标].仇恨时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.仇恨时长);
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
					if (keyValuePair.Value.仇恨数值 > 0)
					{
						this.HateObject.添加仇恨(PetObject.宠物主人, keyValuePair.Value.仇恨时间, keyValuePair.Value.仇恨数值);
					}
					this.HateObject.移除仇恨(keyValuePair.Key);
				}
				else if (!(keyValuePair.Key is PlayerObject))
				{
					this.HateObject.移除仇恨(keyValuePair.Key);
				}
			}
			MapObject MapObject = (from x in this.HateObject.仇恨列表.Keys.ToList<MapObject>()
			orderby this.HateObject.仇恨列表[x].仇恨数值 descending
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

		
		public 游戏怪物 对象模板;

		
		public int 复活间隔;

		
		public HateObject HateObject;

		
		public Point[] 出生范围;

		
		public MapInstance 出生地图;

		
		public 游戏技能 普通攻击技能;

		
		public 游戏技能 概率触发技能;

		
		public 游戏技能 进入战斗技能;

		
		public 游戏技能 退出战斗技能;

		
		public 游戏技能 死亡释放技能;

		
		public 游戏技能 移动释放技能;

		
		public 游戏技能 出生释放技能;
	}
}
