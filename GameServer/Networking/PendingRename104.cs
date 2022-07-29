using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 135, 长度 = 0, 注释 = "拾取物品")]
	public sealed class 玩家拾取物品 : GamePacket
	{
		
		public 玩家拾取物品()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 角色编号;

		
		[WrappingFieldAttribute(SubScript = 17, Length = 4)]
		public byte[] 物品描述;
	}
}
