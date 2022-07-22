using System;
using System.Collections.Generic;
using System.Linq;
using GameServer.Data;
using GameServer.Networking;

namespace GameServer.Maps
{
	// Token: 0x020002E9 RID: 745
	public sealed class PlayerDeals
	{
		// Token: 0x060009ED RID: 2541 RVA: 0x00062480 File Offset: 0x00060680
		public PlayerDeals(PlayerObject 申请方, PlayerObject 接收方)
		{
			
			
			this.申请方物品 = new Dictionary<byte, ItemData>();
			this.接收方物品 = new Dictionary<byte, ItemData>();
			this.交易申请方 = 申请方;
			this.交易接收方 = 接收方;
			this.申请方状态 = 1;
			this.接收方状态 = 2;
			this.发送封包(new TransactionStatusChangePacket
			{
				对象编号 = this.交易申请方.地图编号,
				交易状态 = this.申请方状态,
				对象等级 = (int)this.交易申请方.当前等级
			});
			this.发送封包(new TransactionStatusChangePacket
			{
				对象编号 = this.交易接收方.地图编号,
				交易状态 = this.接收方状态,
				对象等级 = (int)this.交易接收方.当前等级
			});
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x0006253C File Offset: 0x0006073C
		public void 结束交易()
		{
			客户网络 网络连接 = this.交易申请方.网络连接;
			if (网络连接 != null)
			{
				网络连接.发送封包(new TransactionStatusChangePacket
				{
					对象编号 = this.交易申请方.地图编号,
					交易状态 = 0,
					对象等级 = (int)this.交易申请方.当前等级
				});
			}
			客户网络 网络连接2 = this.交易接收方.网络连接;
			if (网络连接2 != null)
			{
				网络连接2.发送封包(new TransactionStatusChangePacket
				{
					对象编号 = this.交易接收方.地图编号,
					交易状态 = 0,
					对象等级 = (int)this.交易接收方.当前等级
				});
			}
			this.交易申请方.当前交易 = (this.交易接收方.当前交易 = null);
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x000625EC File Offset: 0x000607EC
		public void 交换物品()
		{
			if (this.接收方金币 > 0)
			{
				this.交易接收方.金币数量 -= (int)Math.Ceiling((double)((float)this.接收方金币 * 1.04f));
				this.交易接收方.CharacterData.转出金币.V += (long)this.接收方金币;
			}
			if (this.申请方金币 > 0)
			{
				this.交易申请方.金币数量 -= (int)Math.Ceiling((double)((float)this.申请方金币 * 1.04f));
				this.交易申请方.CharacterData.转出金币.V += (long)this.申请方金币;
			}
			foreach (ItemData ItemData in this.接收方物品.Values)
			{
				if (ItemData.物品编号 == 80207)
				{
					this.交易接收方.CharacterData.转出金币.V += 1000000L;
				}
				else if (ItemData.物品编号 == 80209)
				{
					this.交易接收方.CharacterData.转出金币.V += 5000000L;
				}
				this.交易接收方.角色背包.Remove(ItemData.物品位置.V);
				客户网络 网络连接 = this.交易接收方.网络连接;
				if (网络连接 != null)
				{
					网络连接.发送封包(new 删除玩家物品
					{
						背包类型 = 1,
						物品位置 = ItemData.物品位置.V
					});
				}
			}
			foreach (ItemData ItemData2 in this.申请方物品.Values)
			{
				if (ItemData2.物品编号 == 80207)
				{
					this.交易申请方.CharacterData.转出金币.V += 1000000L;
				}
				else if (ItemData2.物品编号 == 80209)
				{
					this.交易申请方.CharacterData.转出金币.V += 5000000L;
				}
				this.交易申请方.角色背包.Remove(ItemData2.物品位置.V);
				客户网络 网络连接2 = this.交易申请方.网络连接;
				if (网络连接2 != null)
				{
					网络连接2.发送封包(new 删除玩家物品
					{
						背包类型 = 1,
						物品位置 = ItemData2.物品位置.V
					});
				}
			}
			foreach (ItemData ItemData3 in this.申请方物品.Values)
			{
				byte b = 0;
				while (b < this.交易接收方.背包大小)
				{
					if (this.交易接收方.角色背包.ContainsKey(b))
					{
						b += 1;
					}
					else
					{
						this.交易接收方.角色背包.Add(b, ItemData3);
						ItemData3.物品容器.V = 1;
						ItemData3.物品位置.V = b;
						客户网络 网络连接3 = this.交易接收方.网络连接;
						if (网络连接3 == null)
						{
							break;
						}
						网络连接3.发送封包(new 玩家物品变动
						{
							物品描述 = ItemData3.字节描述()
						});
						break;
					}
				}
			}
			foreach (ItemData ItemData4 in this.接收方物品.Values)
			{
				byte b2 = 0;
				while (b2 < this.交易申请方.背包大小)
				{
					if (this.交易申请方.角色背包.ContainsKey(b2))
					{
						b2 += 1;
					}
					else
					{
						this.交易申请方.角色背包.Add(b2, ItemData4);
						ItemData4.物品容器.V = 1;
						ItemData4.物品位置.V = b2;
						客户网络 网络连接4 = this.交易申请方.网络连接;
						if (网络连接4 == null)
						{
							break;
						}
						网络连接4.发送封包(new 玩家物品变动
						{
							物品描述 = ItemData4.字节描述()
						});
						break;
					}
				}
			}
			if (this.申请方金币 > 0)
			{
				this.交易接收方.金币数量 += this.申请方金币;
			}
			if (this.接收方金币 > 0)
			{
				this.交易申请方.金币数量 += this.接收方金币;
			}
			this.更改状态(6, null);
			this.结束交易();
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x00062A84 File Offset: 0x00060C84
		public void 更改状态(byte 状态, PlayerObject 玩家 = null)
		{
			if (玩家 == null)
			{
				this.接收方状态 = 状态;
				this.申请方状态 = 状态;
				this.发送封包(new TransactionStatusChangePacket
				{
					对象编号 = this.交易申请方.地图编号,
					交易状态 = this.申请方状态,
					对象等级 = (int)this.交易申请方.当前等级
				});
				this.发送封包(new TransactionStatusChangePacket
				{
					对象编号 = this.交易接收方.地图编号,
					交易状态 = this.接收方状态,
					对象等级 = (int)this.交易接收方.当前等级
				});
				return;
			}
			if (玩家 == this.交易申请方)
			{
				this.申请方状态 = 状态;
				this.发送封包(new TransactionStatusChangePacket
				{
					对象编号 = 玩家.地图编号,
					交易状态 = 玩家.交易状态,
					对象等级 = (int)玩家.当前等级
				});
				return;
			}
			if (玩家 == this.交易接收方)
			{
				this.接收方状态 = 状态;
				this.发送封包(new TransactionStatusChangePacket
				{
					对象编号 = 玩家.地图编号,
					交易状态 = 玩家.交易状态,
					对象等级 = (int)玩家.当前等级
				});
				return;
			}
			this.结束交易();
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x00062BA0 File Offset: 0x00060DA0
		public void 放入金币(PlayerObject 玩家, int 数量)
		{
			if (玩家 == this.交易申请方)
			{
				this.申请方金币 = 数量;
				this.发送封包(new PutInTradingCoins
				{
					对象编号 = 玩家.地图编号,
					金币数量 = 数量
				});
				return;
			}
			if (玩家 == this.交易接收方)
			{
				this.接收方金币 = 数量;
				this.发送封包(new PutInTradingCoins
				{
					对象编号 = 玩家.地图编号,
					金币数量 = 数量
				});
				return;
			}
			this.结束交易();
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x00062C14 File Offset: 0x00060E14
		public void 放入物品(PlayerObject 玩家, ItemData 物品, byte 位置)
		{
			if (玩家 == this.交易申请方)
			{
				this.申请方物品.Add(位置, 物品);
				this.发送封包(new PutInTradeItemsPacket
				{
					对象编号 = 玩家.地图编号,
					放入位置 = 位置,
					放入物品 = 1,
					物品描述 = 物品.字节描述()
				});
				return;
			}
			if (玩家 == this.交易接收方)
			{
				this.接收方物品.Add(位置, 物品);
				this.发送封包(new PutInTradeItemsPacket
				{
					对象编号 = 玩家.地图编号,
					放入位置 = 位置,
					放入物品 = 1,
					物品描述 = 物品.字节描述()
				});
				return;
			}
			this.结束交易();
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x00062CB8 File Offset: 0x00060EB8
		public bool 背包已满(out PlayerObject 玩家)
		{
			玩家 = null;
			if ((int)this.交易申请方.背包剩余 < this.接收方物品.Count)
			{
				玩家 = this.交易申请方;
				return true;
			}
			if ((int)this.交易接收方.背包剩余 < this.申请方物品.Count)
			{
				玩家 = this.交易接收方;
				return true;
			}
			return false;
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x0000791E File Offset: 0x00005B1E
		public bool 金币重复(PlayerObject 玩家)
		{
			if (玩家 == this.交易申请方)
			{
				return this.申请方金币 != 0;
			}
			return 玩家 != this.交易接收方 || this.接收方金币 != 0;
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x00062D10 File Offset: 0x00060F10
		public bool 物品重复(PlayerObject 玩家, ItemData 物品)
		{
			if (玩家 == this.交易申请方)
			{
				return this.申请方物品.Values.FirstOrDefault((ItemData O) => O == 物品) != null;
			}
			return 玩家 != this.交易接收方 || this.接收方物品.Values.FirstOrDefault((ItemData O) => O == 物品) != null;
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x00007947 File Offset: 0x00005B47
		public bool 物品重复(PlayerObject 玩家, byte 位置)
		{
			if (玩家 == this.交易申请方)
			{
				return this.申请方物品.ContainsKey(位置);
			}
			return 玩家 != this.交易接收方 || this.接收方物品.ContainsKey(位置);
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x00007976 File Offset: 0x00005B76
		public byte 对方状态(PlayerObject 玩家)
		{
			if (玩家 == this.交易接收方)
			{
				return this.申请方状态;
			}
			if (玩家 == this.交易申请方)
			{
				return this.接收方状态;
			}
			return 0;
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x00007999 File Offset: 0x00005B99
		public void 发送封包(GamePacket 封包)
		{
			客户网络 网络连接 = this.交易接收方.网络连接;
			if (网络连接 != null)
			{
				网络连接.发送封包(封包);
			}
			客户网络 网络连接2 = this.交易申请方.网络连接;
			if (网络连接2 == null)
			{
				return;
			}
			网络连接2.发送封包(封包);
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x000079C8 File Offset: 0x00005BC8
		public PlayerObject 对方玩家(PlayerObject 玩家)
		{
			if (玩家 == this.交易接收方)
			{
				return this.交易申请方;
			}
			return this.交易接收方;
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x000079E0 File Offset: 0x00005BE0
		public Dictionary<byte, ItemData> 对方物品(PlayerObject 玩家)
		{
			if (玩家 == this.交易接收方)
			{
				return this.申请方物品;
			}
			if (玩家 == this.交易申请方)
			{
				return this.接收方物品;
			}
			return null;
		}

		// Token: 0x04000D53 RID: 3411
		public PlayerObject 交易申请方;

		// Token: 0x04000D54 RID: 3412
		public PlayerObject 交易接收方;

		// Token: 0x04000D55 RID: 3413
		public byte 申请方状态;

		// Token: 0x04000D56 RID: 3414
		public byte 接收方状态;

		// Token: 0x04000D57 RID: 3415
		public int 申请方金币;

		// Token: 0x04000D58 RID: 3416
		public int 接收方金币;

		// Token: 0x04000D59 RID: 3417
		public Dictionary<byte, ItemData> 申请方物品;

		// Token: 0x04000D5A RID: 3418
		public Dictionary<byte, ItemData> 接收方物品;
	}
}
