using System;
using GameServer.Data;
using GameServer.Templates;
using GameServer.Networking;

namespace GameServer
{
	// Token: 0x0200001E RID: 30
	public sealed class AddItems : GMCommand
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00008DE8 File Offset: 0x00006FE8
		public override void Execute()
		{
			GameData GameData;
			if (GameDataGateway.CharacterDataTable.Keyword.TryGetValue(this.角色名字, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null)
				{
					游戏物品 游戏物品;
					if (!游戏物品.检索表.TryGetValue(this.物品名字, out 游戏物品))
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, item does not exist");
						return;
					}
					if (CharacterData.角色背包.Count >= (int)CharacterData.背包大小.V)
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, character's bag is full");
						return;
					}
					if (游戏物品.物品持久 == 0)
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, cannot AddItemsCommand");
						return;
					}
					byte b = byte.MaxValue;
					for (byte b2 = 0; b2 < CharacterData.背包大小.V; b2 += 1)
					{
						if (!CharacterData.角色背包.ContainsKey(b2))
						{
							b = b2;
							IL_F4:
							游戏装备 游戏装备 = 游戏物品 as 游戏装备;
							if (游戏装备 != null)
							{
								CharacterData.角色背包[b] = new EquipmentData(游戏装备, CharacterData, 1, b, true);
							}
							else if (游戏物品.持久类型 == PersistentItemType.容器)
							{
								CharacterData.角色背包[b] = new ItemData(游戏物品, CharacterData, 1, b, 0);
							}
							else if (游戏物品.持久类型 == PersistentItemType.堆叠)
							{
								CharacterData.角色背包[b] = new ItemData(游戏物品, CharacterData, 1, b, 1);
							}
							else
							{
								CharacterData.角色背包[b] = new ItemData(游戏物品, CharacterData, 1, b, 游戏物品.物品持久);
							}
							客户网络 网络连接 = CharacterData.网络连接;
							if (网络连接 != null)
							{
								网络连接.发送封包(new 玩家物品变动
								{
									物品描述 = CharacterData.角色背包[b].字节描述()
								});
							}
							MainForm.添加命令日志("<= @" + base.GetType().Name + " The command has been executed and the item has been added to the character's bag");
							return;
						}
					}
					//goto IL_F4;
				}
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, role does not exist");
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002858 File Offset: 0x00000A58
		public AddItems()
		{
			
			
		}

		// Token: 0x0400002E RID: 46
		[FieldAttribute(0, 排序 = 0)]
		public string 角色名字;

		// Token: 0x0400002F RID: 47
		[FieldAttribute(0, 排序 = 1)]
		public string 物品名字;
	}
}
