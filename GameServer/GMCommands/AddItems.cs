using System;
using GameServer.Data;
using GameServer.Templates;
using GameServer.Networking;

namespace GameServer
{
	
	public sealed class AddItems : GMCommand
	{
		
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		
		public override void Execute()
		{
			GameData GameData;
			if (GameDataGateway.CharacterDataTable.Keyword.TryGetValue(this.CharName, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null)
				{
					GameItems 游戏物品;
					if (!GameItems.DataSheetByName.TryGetValue(this.Name, out 游戏物品))
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, item does not exist");
						return;
					}
					if (CharacterData.角色背包.Count >= (int)CharacterData.背包大小.V)
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, character's bag is full");
						return;
					}
					if (游戏物品.MaxDurability == 0)
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
							EquipmentItem 游戏装备 = 游戏物品 as EquipmentItem;
							if (游戏装备 != null)
							{
								CharacterData.角色背包[b] = new EquipmentData(游戏装备, CharacterData, 1, b, true);
							}
							else if (游戏物品.PersistType == PersistentItemType.容器)
							{
								CharacterData.角色背包[b] = new ItemData(游戏物品, CharacterData, 1, b, 0);
							}
							else if (游戏物品.PersistType == PersistentItemType.堆叠)
							{
								CharacterData.角色背包[b] = new ItemData(游戏物品, CharacterData, 1, b, 1);
							}
							else
							{
								CharacterData.角色背包[b] = new ItemData(游戏物品, CharacterData, 1, b, 游戏物品.MaxDurability);
							}
							客户网络 网络连接 = CharacterData.ActiveConnection;
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

		
		public AddItems()
		{
			
			
		}

		
		[FieldAttribute(0, 排序 = 0)]
		public string CharName;

		
		[FieldAttribute(0, 排序 = 1)]
		public string Name;
	}
}
