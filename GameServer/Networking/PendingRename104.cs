using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 135, 长度 = 0, 注释 = "拾取物品")]
	public sealed class 玩家拾取物品 : GamePacket
	{
		
		public 玩家拾取物品()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 角色编号;

		
		[WrappingFieldAttribute(下标 = 17, 长度 = 4)]
		public byte[] 物品描述;
	}
}
