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
		
		// (get) Token: 0x060007D8 RID: 2008 RVA: 0x0000683A File Offset: 0x00004A3A
		// (set) Token: 0x060007D9 RID: 2009 RVA: 0x00006842 File Offset: 0x00004A42
		public bool 尸体消失 { get; set; }

		
		// (get) Token: 0x060007DA RID: 2010 RVA: 0x0000684B File Offset: 0x00004A4B
		// (set) Token: 0x060007DB RID: 2011 RVA: 0x00006853 File Offset: 0x00004A53
		public DateTime 攻击时间 { get; set; }

		
		// (get) Token: 0x060007DC RID: 2012 RVA: 0x0000685C File Offset: 0x00004A5C
		// (set) Token: 0x060007DD RID: 2013 RVA: 0x00006864 File Offset: 0x00004A64
		public DateTime 漫游时间 { get; set; }

		
		// (get) Token: 0x060007DE RID: 2014 RVA: 0x0000686D File Offset: 0x00004A6D
		// (set) Token: 0x060007DF RID: 2015 RVA: 0x00006875 File Offset: 0x00004A75
		public DateTime 复活时间 { get; set; }

		
		// (get) Token: 0x060007E0 RID: 2016 RVA: 0x0000687E File Offset: 0x00004A7E
		// (set) Token: 0x060007E1 RID: 2017 RVA: 0x00006886 File Offset: 0x00004A86
		public DateTime 消失时间 { get; set; }

		
		// (get) Token: 0x060007E2 RID: 2018 RVA: 0x0000688F File Offset: 0x00004A8F
		// (set) Token: 0x060007E3 RID: 2019 RVA: 0x000068A1 File Offset: 0x00004AA1
		public int 宠物经验
		{
			get
			{
				return this.PetData.当前经验.V;
			}
			set
			{
				if (this.PetData.当前经验.V != value)
				{
					this.PetData.当前经验.V = value;
				}
			}
		}

		
		// (get) Token: 0x060007E4 RID: 2020 RVA: 0x000068C7 File Offset: 0x00004AC7
		// (set) Token: 0x060007E5 RID: 2021 RVA: 0x000068D9 File Offset: 0x00004AD9
		public byte 宠物等级
		{
			get
			{
				return this.PetData.当前等级.V;
			}
			set
			{
				if (this.PetData.当前等级.V != value)
				{
					this.PetData.当前等级.V = value;
				}
			}
		}

		
		// (get) Token: 0x060007E6 RID: 2022 RVA: 0x000068FF File Offset: 0x00004AFF
		// (set) Token: 0x060007E7 RID: 2023 RVA: 0x00006911 File Offset: 0x00004B11
		public byte 等级上限
		{
			get
			{
				return this.PetData.等级上限.V;
			}
			set
			{
				if (this.PetData.等级上限.V != value)
				{
					this.PetData.等级上限.V = value;
				}
			}
		}

		
		// (get) Token: 0x060007E8 RID: 2024 RVA: 0x00006937 File Offset: 0x00004B37
		// (set) Token: 0x060007E9 RID: 2025 RVA: 0x00006949 File Offset: 0x00004B49
		public bool 绑定武器
		{
			get
			{
				return this.PetData.绑定武器.V;
			}
			set
			{
				if (this.PetData.绑定武器.V != value)
				{
					this.PetData.绑定武器.V = value;
				}
			}
		}

		
		// (get) Token: 0x060007EA RID: 2026 RVA: 0x0000696F File Offset: 0x00004B6F
		// (set) Token: 0x060007EB RID: 2027 RVA: 0x00006981 File Offset: 0x00004B81
		public DateTime 叛变时间
		{
			get
			{
				return this.PetData.叛变时间.V;
			}
			set
			{
				if (this.PetData.叛变时间.V != value)
				{
					this.PetData.叛变时间.V = value;
				}
			}
		}

		
		// (get) Token: 0x060007EC RID: 2028 RVA: 0x00006134 File Offset: 0x00004334
		public override int 处理间隔
		{
			get
			{
				return 10;
			}
		}

		
		// (get) Token: 0x060007ED RID: 2029 RVA: 0x00006138 File Offset: 0x00004338
		// (set) Token: 0x060007EE RID: 2030 RVA: 0x00036440 File Offset: 0x00034640
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

		
		// (get) Token: 0x060007EF RID: 2031 RVA: 0x00006140 File Offset: 0x00004340
		// (set) Token: 0x060007F0 RID: 2032 RVA: 0x00006148 File Offset: 0x00004348
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

		
		// (get) Token: 0x060007F1 RID: 2033 RVA: 0x000069AC File Offset: 0x00004BAC
		// (set) Token: 0x060007F2 RID: 2034 RVA: 0x0003F694 File Offset: 0x0003D894
		public override int 当前体力
		{
			get
			{
				return this.PetData.当前体力.V;
			}
			set
			{
				value = ComputingClass.数值限制(0, value, this[GameObjectProperties.最大体力]);
				if (this.PetData.当前体力.V != value)
				{
					this.PetData.当前体力.V = value;
					base.发送封包(new 同步对象体力
					{
						对象编号 = this.MapId,
						当前体力 = this.当前体力,
						体力上限 = this[GameObjectProperties.最大体力]
					});
				}
			}
		}

		
		// (get) Token: 0x060007F3 RID: 2035 RVA: 0x00006167 File Offset: 0x00004367
		// (set) Token: 0x060007F4 RID: 2036 RVA: 0x0000616F File Offset: 0x0000436F
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

		
		// (get) Token: 0x060007F5 RID: 2037 RVA: 0x0000619F File Offset: 0x0000439F
		// (set) Token: 0x060007F6 RID: 2038 RVA: 0x000069BE File Offset: 0x00004BBE
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
						对象朝向 = (ushort)this.当前方向
					});
				}
			}
		}

		
		// (get) Token: 0x060007F7 RID: 2039 RVA: 0x000069FC File Offset: 0x00004BFC
		public override byte 当前等级
		{
			get
			{
				return this.对象模板.怪物等级;
			}
		}

		
		// (get) Token: 0x060007F8 RID: 2040 RVA: 0x00006A09 File Offset: 0x00004C09
		public override string 对象名字
		{
			get
			{
				return this.对象模板.MonsterName;
			}
		}

		
		// (get) Token: 0x060007F9 RID: 2041 RVA: 0x00002940 File Offset: 0x00000B40
		public override GameObjectType 对象类型
		{
			get
			{
				return GameObjectType.宠物;
			}
		}

		
		// (get) Token: 0x060007FA RID: 2042 RVA: 0x00006A16 File Offset: 0x00004C16
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

		
		// (get) Token: 0x060007FD RID: 2045 RVA: 0x00006A23 File Offset: 0x00004C23
		public int 仇恨范围
		{
			get
			{
				return 4;
			}
		}

		
		// (get) Token: 0x060007FE RID: 2046 RVA: 0x00006A26 File Offset: 0x00004C26
		public int 仇恨时长
		{
			get
			{
				return 15000;
			}
		}

		
		// (get) Token: 0x060007FF RID: 2047 RVA: 0x00006A2D File Offset: 0x00004C2D
		public int 切换间隔
		{
			get
			{
				return 5000;
			}
		}

		
		// (get) Token: 0x06000800 RID: 2048 RVA: 0x00006A34 File Offset: 0x00004C34
		public ushort 模板编号
		{
			get
			{
				return this.对象模板.怪物编号;
			}
		}

		
		// (get) Token: 0x06000801 RID: 2049 RVA: 0x0003F708 File Offset: 0x0003D908
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

		
		// (get) Token: 0x06000802 RID: 2050 RVA: 0x00006A41 File Offset: 0x00004C41
		public int 移动间隔
		{
			get
			{
				return (int)this.对象模板.怪物移动间隔;
			}
		}

		
		// (get) Token: 0x06000803 RID: 2051 RVA: 0x00006A4E File Offset: 0x00004C4E
		public int 漫游间隔
		{
			get
			{
				return (int)this.对象模板.怪物漫游间隔;
			}
		}

		
		// (get) Token: 0x06000804 RID: 2052 RVA: 0x00006A5B File Offset: 0x00004C5B
		public int 尸体保留
		{
			get
			{
				return (int)this.对象模板.尸体保留时长;
			}
		}

		
		// (get) Token: 0x06000805 RID: 2053 RVA: 0x00006A68 File Offset: 0x00004C68
		public bool 可被技能诱惑
		{
			get
			{
				return this.对象模板.可被技能诱惑;
			}
		}

		
		// (get) Token: 0x06000806 RID: 2054 RVA: 0x00006A75 File Offset: 0x00004C75
		public float 基础诱惑概率
		{
			get
			{
				return this.对象模板.基础诱惑概率;
			}
		}

		
		// (get) Token: 0x06000807 RID: 2055 RVA: 0x00006A82 File Offset: 0x00004C82
		public MonsterRaceType 宠物种族
		{
			get
			{
				return this.对象模板.怪物分类;
			}
		}

		
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x00006A8F File Offset: 0x00004C8F
		public MonsterLevelType 宠物级别
		{
			get
			{
				return this.对象模板.怪物级别;
			}
		}

		
		// (get) Token: 0x06000809 RID: 2057 RVA: 0x0003F75C File Offset: 0x0003D95C
		public Dictionary<GameObjectProperties, int> 基础属性
		{
			get
			{
				Dictionary<GameObjectProperties, int>[] 成长属性 = this.对象模板.成长属性;
				int? num = (成长属性 != null) ? new int?(成长属性.Length) : null;
				int 宠物等级 = (int)this.宠物等级;
				if (!(num.GetValueOrDefault() > 宠物等级 & num != null))
				{
					return this.对象模板.基础属性;
				}
				return this.对象模板.成长属性[(int)this.宠物等级];
			}
		}

		
		public PetObject(PlayerObject 宠物主人, PetData 对象数据)
		{
			
			
			this.宠物主人 = 宠物主人;
			this.PetData = 对象数据;
			this.对象模板 = 游戏怪物.DataSheet[对象数据.宠物名字.V];
			this.当前坐标 = 宠物主人.当前坐标;
			this.当前地图 = 宠物主人.当前地图;
			this.当前方向 = ComputingClass.随机方向();
			this.属性加成[this] = this.基础属性;
			this.属性加成[宠物主人.CharacterData] = new Dictionary<GameObjectProperties, int>();
			if (this.对象模板.继承属性 != null)
			{
				foreach (属性继承 属性继承 in this.对象模板.继承属性)
				{
					this.属性加成[宠物主人.CharacterData][属性继承.转换属性] = (int)((float)宠物主人[属性继承.继承属性] * 属性继承.继承比例);
				}
			}
			this.更新对象属性();
			base.恢复时间 = MainProcess.CurrentTime.AddSeconds(5.0);
			this.攻击时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)(MainProcess.RandomNumber.Next(5000) + this.漫游间隔));
			this.HateObject = new HateObject();
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
			this.MapId = ++MapGatewayProcess.对象编号;
			MapGatewayProcess.添加MapObject(this);
			this.激活对象 = true;
			MapGatewayProcess.添加激活对象(this);
			this.阻塞网格 = true;
			this.宠物召回处理();
		}

		
		public PetObject(PlayerObject 宠物主人, 游戏怪物 召唤宠物, byte 初始等级, byte 等级上限, bool 绑定武器)
		{
			
			
			this.宠物主人 = 宠物主人;
			this.对象模板 = 召唤宠物;
			this.PetData = new PetData(召唤宠物.MonsterName, 初始等级, 等级上限, 绑定武器, DateTime.MaxValue);
			this.当前坐标 = 宠物主人.当前坐标;
			this.当前地图 = 宠物主人.当前地图;
			this.当前方向 = ComputingClass.随机方向();
			this.MapId = ++MapGatewayProcess.对象编号;
			this.属性加成[this] = this.基础属性;
			this.属性加成[宠物主人.CharacterData] = new Dictionary<GameObjectProperties, int>();
			if (this.对象模板.继承属性 != null)
			{
				foreach (属性继承 属性继承 in this.对象模板.继承属性)
				{
					this.属性加成[宠物主人.CharacterData][属性继承.转换属性] = (int)((float)宠物主人[属性继承.继承属性] * 属性继承.继承比例);
				}
			}
			this.更新对象属性();
			this.当前体力 = this[GameObjectProperties.最大体力];
			base.恢复时间 = MainProcess.CurrentTime.AddSeconds(5.0);
			this.攻击时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)(MainProcess.RandomNumber.Next(5000) + this.漫游间隔));
			this.HateObject = new HateObject();
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
			this.激活对象 = true;
			MapGatewayProcess.添加激活对象(this);
			this.阻塞网格 = true;
			this.宠物召回处理();
		}

		
		public PetObject(PlayerObject 宠物主人, MonsterObject 诱惑怪物, byte 初始等级, bool 绑定武器, int 宠物时长)
		{
			
			
			this.宠物主人 = 宠物主人;
			this.对象模板 = 诱惑怪物.对象模板;
			this.PetData = new PetData(诱惑怪物.对象名字, 初始等级, 7, 绑定武器, MainProcess.CurrentTime.AddMinutes((double)宠物时长));
			this.当前坐标 = 诱惑怪物.当前坐标;
			this.当前地图 = 诱惑怪物.当前地图;
			this.当前方向 = 诱惑怪物.当前方向;
			this.属性加成[this] = this.基础属性;
			this.更新对象属性();
			this.当前体力 = Math.Min(诱惑怪物.当前体力, this[GameObjectProperties.最大体力]);
			base.恢复时间 = MainProcess.CurrentTime.AddSeconds(5.0);
			this.攻击时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.忙碌时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.漫游间隔);
			this.HateObject = new HateObject();
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
			诱惑怪物.怪物诱惑处理();
			this.MapId = ++MapGatewayProcess.对象编号;
			this.阻塞网格 = true;
			base.绑定网格();
			MapGatewayProcess.添加MapObject(this);
			this.激活对象 = true;
			MapGatewayProcess.添加激活对象(this);
			base.更新邻居时处理();
		}

		
		public PetObject(PlayerObject 宠物主人, PetObject 诱惑宠物, byte 初始等级, bool 绑定武器, int 宠物时长)
		{
			
			
			this.宠物主人 = 宠物主人;
			this.对象模板 = 诱惑宠物.对象模板;
			this.PetData = new PetData(诱惑宠物.对象名字, 初始等级, 7, 绑定武器, MainProcess.CurrentTime.AddMinutes((double)宠物时长));
			this.当前坐标 = 诱惑宠物.当前坐标;
			this.当前地图 = 诱惑宠物.当前地图;
			this.当前方向 = 诱惑宠物.当前方向;
			this.属性加成[this] = this.基础属性;
			this.更新对象属性();
			this.当前体力 = Math.Min(诱惑宠物.当前体力, this[GameObjectProperties.最大体力]);
			base.恢复时间 = MainProcess.CurrentTime.AddSeconds(5.0);
			this.攻击时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.忙碌时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.漫游间隔);
			this.HateObject = new HateObject();
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
			诱惑宠物.自身死亡处理(null, false);
			this.阻塞网格 = true;
			base.绑定网格();
			this.MapId = ++MapGatewayProcess.对象编号;
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
			if (this.对象死亡)
			{
				if (!this.尸体消失 && MainProcess.CurrentTime >= this.消失时间)
				{
					base.删除对象();
				}
			}
			else if (this.叛变时间 != default(DateTime) && MainProcess.CurrentTime > this.叛变时间)
			{
				new MonsterObject(this);
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
				else if (this.宠物主人.PetMode == PetMode.攻击 && MainProcess.CurrentTime > this.忙碌时间 && MainProcess.CurrentTime > this.硬直时间)
				{
					if (this.HateObject.当前目标 == null && !this.邻居列表.Contains(this.宠物主人))
					{
						this.宠物智能跟随();
					}
					else if (this.更新HateObject())
					{
						this.宠物智能攻击();
					}
					else
					{
						this.宠物智能跟随();
					}
				}
			}
			base.处理对象数据();
		}

		
		public override void 自身死亡处理(MapObject 对象, bool 技能击杀)
		{
			if (this.死亡释放技能 != null && 对象 != null)
			{
				游戏技能 技能模板 = this.死亡释放技能;
				SkillData SkillData = null;
				byte 动作编号 = base.动作编号;
				base.动作编号 = (byte)(动作编号 + 1);
				new 技能实例(this, 技能模板, SkillData, 动作编号, this.当前地图, this.当前坐标, null, this.当前坐标, null, null, false).处理任务();
			}
			base.自身死亡处理(对象, 技能击杀);
			this.消失时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.尸体保留);
			this.清空宠物仇恨();
			PlayerObject PlayerObject = this.宠物主人;
			if (PlayerObject != null)
			{
				PlayerObject.宠物死亡处理(this);
			}
			PlayerObject PlayerObject2 = this.宠物主人;
			if (PlayerObject2 != null)
			{
				PlayerObject2.PetData.Remove(this.PetData);
			}
			PlayerObject PlayerObject3 = this.宠物主人;
			if (PlayerObject3 != null)
			{
				PlayerObject3.宠物列表.Remove(this);
			}
			PlayerObject PlayerObject4 = this.宠物主人;
			byte? b = (PlayerObject4 != null) ? new byte?(PlayerObject4.宠物数量) : null;
			int? num = (b != null) ? new int?((int)b.GetValueOrDefault()) : null;
			if (num.GetValueOrDefault() == 0 & num != null)
			{
				PlayerObject PlayerObject5 = this.宠物主人;
				if (PlayerObject5 != null)
				{
					PlayerObject5.网络连接.发送封包(new GameErrorMessagePacket
					{
						错误代码 = 9473
					});
				}
			}
			this.Buff列表.Clear();
			PetData PetData = this.PetData;
			if (PetData != null)
			{
				PetData.删除数据();
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
			if (this.邻居列表.Contains(this.宠物主人))
			{
				Point point = ComputingClass.前方坐标(this.宠物主人.当前坐标, ComputingClass.旋转方向(this.宠物主人.当前方向, 4), 2);
				if (base.网格距离(this.宠物主人) > 2 || base.网格距离(point) > 2)
				{
					GameDirection GameDirection = ComputingClass.计算方向(this.当前坐标, point);
					for (int i = 0; i < 8; i++)
					{
						Point point2 = ComputingClass.前方坐标(this.当前坐标, GameDirection, 1);
						if (this.当前地图.能否通行(point2))
						{
							this.忙碌时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.行走耗时);
							this.行走时间 = MainProcess.CurrentTime.AddMilliseconds((double)(this.行走耗时 + this.移动间隔));
							this.当前方向 = ComputingClass.计算方向(this.当前坐标, point2);
							base.自身移动时处理(point2);
							base.发送封包(new ObjectCharacterWalkPacket
							{
								对象编号 = this.MapId,
								移动坐标 = this.当前坐标,
								移动速度 = base.行走速度
							});
							return;
						}
						GameDirection = ComputingClass.旋转方向(GameDirection, (MainProcess.RandomNumber.Next(2) == 0) ? -1 : 1);
					}
					return;
				}
				if (MainProcess.CurrentTime > this.漫游时间)
				{
					this.漫游时间 = MainProcess.CurrentTime.AddMilliseconds((double)(this.漫游间隔 + MainProcess.RandomNumber.Next(5000)));
					Point point3 = ComputingClass.前方坐标(this.当前坐标, ComputingClass.随机方向(), 1);
					if (this.当前地图.能否通行(point3))
					{
						this.忙碌时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.行走耗时);
						this.行走时间 = MainProcess.CurrentTime.AddMilliseconds((double)(this.行走耗时 + this.移动间隔));
						this.当前方向 = ComputingClass.计算方向(this.当前坐标, point3);
						base.自身移动时处理(point3);
						base.发送封包(new ObjectCharacterWalkPacket
						{
							对象编号 = this.MapId,
							移动坐标 = this.当前坐标,
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

		
		public void 宠物智能攻击()
		{
			if (this.检查状态(游戏对象状态.麻痹状态 | 游戏对象状态.失神状态))
			{
				return;
			}
			游戏技能 游戏技能;
			if (this.概率触发技能 != null && (!this.冷却记录.ContainsKey((int)this.普通攻击技能.自身技能编号 | 16777216) || MainProcess.CurrentTime > this.冷却记录[(int)this.普通攻击技能.自身技能编号 | 16777216]) && ComputingClass.计算概率(this.概率触发技能.计算幸运概率 ? ComputingClass.计算幸运(this[GameObjectProperties.幸运等级]) : this.概率触发技能.计算触发概率))
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
			if (base.网格距离(this.HateObject.当前目标) > (int)游戏技能.技能最远距离)
			{
				if (this.能否走动())
				{
					GameDirection GameDirection = ComputingClass.计算方向(this.当前坐标, this.HateObject.当前目标.当前坐标);
					bool flag = false;
					int i = 0;
					while (i < 10)
					{
						Point point = ComputingClass.前方坐标(this.当前坐标, GameDirection, 1);
						if (!this.当前地图.能否通行(point))
						{
							GameDirection = ComputingClass.旋转方向(GameDirection, (MainProcess.RandomNumber.Next(2) == 0) ? -1 : 1);
							i++;
						}
						else
						{
							this.忙碌时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.行走耗时);
							this.行走时间 = MainProcess.CurrentTime.AddMilliseconds((double)(this.行走耗时 + this.移动间隔));
							this.当前方向 = ComputingClass.计算方向(this.当前坐标, point);
							base.自身移动时处理(point);
							base.发送封包(new ObjectCharacterWalkPacket
							{
								对象编号 = this.MapId,
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
				if (this.能否转动())
				{
					this.当前方向 = ComputingClass.计算方向(this.当前坐标, this.HateObject.当前目标.当前坐标);
				}
			}
		}

		
		public void 宠物经验增加()
		{
			if (this.宠物等级 >= this.等级上限)
			{
				return;
			}
			if (++this.宠物经验 >= (int)this.升级经验)
			{
				this.宠物等级 += 1;
				this.宠物经验 = 0;
				this.属性加成[this] = this.基础属性;
				this.更新对象属性();
				this.当前体力 = this[GameObjectProperties.最大体力];
				base.发送封包(new ObjectTransformTypePacket
				{
					改变类型 = 2,
					对象编号 = this.MapId
				});
				base.发送封包(new SyncPetLevelPacket
				{
					宠物编号 = this.MapId,
					宠物等级 = this.宠物等级
				});
			}
		}

		
		public void 宠物召回处理()
		{
			Point point = this.宠物主人.当前坐标;
			for (int i = 1; i <= 120; i++)
			{
				Point point2 = ComputingClass.螺旋坐标(point, i);
				if (this.宠物主人.当前地图.能否通行(point2))
				{
					point = point2;
					IL_38:
					this.清空宠物仇恨();
					base.清空邻居时处理();
					base.解绑网格();
					this.当前坐标 = point;
					PlayerObject PlayerObject = this.宠物主人;
					MapInstance 当前地图;
					if (PlayerObject != null)
					{
						if ((当前地图 = PlayerObject.当前地图) != null)
						{
							goto IL_69;
						}
					}
					当前地图 = null;
					IL_69:
					this.当前地图 = 当前地图;
					base.绑定网格();
					base.更新邻居时处理();
					return;
				}
			}
			//goto IL_38;
		}

		
		public void 宠物沉睡处理()
		{
			this.技能任务.Clear();
			this.Buff列表.Clear();
			this.对象死亡 = true;
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
			else if (this.宠物主人.对象关系(this.HateObject.当前目标) != 游戏对象关系.敌对)
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

		
		public void 清空宠物仇恨()
		{
			this.HateObject.当前目标 = null;
			this.HateObject.仇恨列表.Clear();
		}

		
		public PlayerObject 宠物主人;

		
		public 游戏怪物 对象模板;

		
		public HateObject HateObject;

		
		public 游戏技能 普通攻击技能;

		
		public 游戏技能 概率触发技能;

		
		public 游戏技能 进入战斗技能;

		
		public 游戏技能 退出战斗技能;

		
		public 游戏技能 死亡释放技能;

		
		public 游戏技能 移动释放技能;

		
		public 游戏技能 出生释放技能;

		
		public PetData PetData;
	}
}
