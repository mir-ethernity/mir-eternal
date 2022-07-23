using System;
using System.Collections.Generic;
using System.Linq;
using GameServer.Data;
using GameServer.Networking;

namespace GameServer.Maps
{
	
	public sealed class PlayerDeals
	{
		
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
				对象编号 = this.交易申请方.MapId,
				交易状态 = this.申请方状态,
				对象等级 = (int)this.交易申请方.当前等级
			});
			this.发送封包(new TransactionStatusChangePacket
			{
				对象编号 = this.交易接收方.MapId,
				交易状态 = this.接收方状态,
				对象等级 = (int)this.交易接收方.当前等级
			});
		}

		
		public void 结束交易()
		{
			客户网络 网络连接 = this.交易申请方.网络连接;
			if (网络连接 != null)
			{
				网络连接.发送封包(new TransactionStatusChangePacket
				{
					对象编号 = this.交易申请方.MapId,
					交易状态 = 0,
					对象等级 = (int)this.交易申请方.当前等级
				});
			}
			客户网络 网络连接2 = this.交易接收方.网络连接;
			if (网络连接2 != null)
			{
				网络连接2.发送封包(new TransactionStatusChangePacket
				{
					对象编号 = this.交易接收方.MapId,
					交易状态 = 0,
					对象等级 = (int)this.交易接收方.当前等级
				});
			}
			this.交易申请方.当前交易 = (this.交易接收方.当前交易 = null);
		}

		
		public void 交换物品()
		{
			if (this.接收方金币 > 0)
			{
				this.交易接收方.NumberGoldCoins -= (int)Math.Ceiling((double)((float)this.接收方金币 * 1.04f));
				this.交易接收方.CharacterData.转出金币.V += (long)this.接收方金币;
			}
			if (this.申请方金币 > 0)
			{
				this.交易申请方.NumberGoldCoins -= (int)Math.Ceiling((double)((float)this.申请方金币 * 1.04f));
				this.交易申请方.CharacterData.转出金币.V += (long)this.申请方金币;
			}
			foreach (ItemData ItemData in this.接收方物品.Values)
			{
				if (ItemData.Id == 80207)
				{
					this.交易接收方.CharacterData.转出金币.V += 1000000L;
				}
				else if (ItemData.Id == 80209)
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
				if (ItemData2.Id == 80207)
				{
					this.交易申请方.CharacterData.转出金币.V += 1000000L;
				}
				else if (ItemData2.Id == 80209)
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
				this.交易接收方.NumberGoldCoins += this.申请方金币;
			}
			if (this.接收方金币 > 0)
			{
				this.交易申请方.NumberGoldCoins += this.接收方金币;
			}
			this.更改状态(6, null);
			this.结束交易();
		}

		
		public void 更改状态(byte 状态, PlayerObject 玩家 = null)
		{
			if (玩家 == null)
			{
				this.接收方状态 = 状态;
				this.申请方状态 = 状态;
				this.发送封包(new TransactionStatusChangePacket
				{
					对象编号 = this.交易申请方.MapId,
					交易状态 = this.申请方状态,
					对象等级 = (int)this.交易申请方.当前等级
				});
				this.发送封包(new TransactionStatusChangePacket
				{
					对象编号 = this.交易接收方.MapId,
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
					对象编号 = 玩家.MapId,
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
					对象编号 = 玩家.MapId,
					交易状态 = 玩家.交易状态,
					对象等级 = (int)玩家.当前等级
				});
				return;
			}
			this.结束交易();
		}

		
		public void 放入金币(PlayerObject 玩家, int 数量)
		{
			if (玩家 == this.交易申请方)
			{
				this.申请方金币 = 数量;
				this.发送封包(new PutInTradingCoins
				{
					对象编号 = 玩家.MapId,
					NumberGoldCoins = 数量
				});
				return;
			}
			if (玩家 == this.交易接收方)
			{
				this.接收方金币 = 数量;
				this.发送封包(new PutInTradingCoins
				{
					对象编号 = 玩家.MapId,
					NumberGoldCoins = 数量
				});
				return;
			}
			this.结束交易();
		}

		
		public void 放入物品(PlayerObject 玩家, ItemData 物品, byte 位置)
		{
			if (玩家 == this.交易申请方)
			{
				this.申请方物品.Add(位置, 物品);
				this.发送封包(new PutInTradeItemsPacket
				{
					对象编号 = 玩家.MapId,
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
					对象编号 = 玩家.MapId,
					放入位置 = 位置,
					放入物品 = 1,
					物品描述 = 物品.字节描述()
				});
				return;
			}
			this.结束交易();
		}

		
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

		
		public bool 金币重复(PlayerObject 玩家)
		{
			if (玩家 == this.交易申请方)
			{
				return this.申请方金币 != 0;
			}
			return 玩家 != this.交易接收方 || this.接收方金币 != 0;
		}

		
		public bool 物品重复(PlayerObject 玩家, ItemData 物品)
		{
			if (玩家 == this.交易申请方)
			{
				return this.申请方物品.Values.FirstOrDefault((ItemData O) => O == 物品) != null;
			}
			return 玩家 != this.交易接收方 || this.接收方物品.Values.FirstOrDefault((ItemData O) => O == 物品) != null;
		}

		
		public bool 物品重复(PlayerObject 玩家, byte 位置)
		{
			if (玩家 == this.交易申请方)
			{
				return this.申请方物品.ContainsKey(位置);
			}
			return 玩家 != this.交易接收方 || this.接收方物品.ContainsKey(位置);
		}

		
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

		
		public PlayerObject 对方玩家(PlayerObject 玩家)
		{
			if (玩家 == this.交易接收方)
			{
				return this.交易申请方;
			}
			return this.交易接收方;
		}

		
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

		
		public PlayerObject 交易申请方;

		
		public PlayerObject 交易接收方;

		
		public byte 申请方状态;

		
		public byte 接收方状态;

		
		public int 申请方金币;

		
		public int 接收方金币;

		
		public Dictionary<byte, ItemData> 申请方物品;

		
		public Dictionary<byte, ItemData> 接收方物品;
	}
}
