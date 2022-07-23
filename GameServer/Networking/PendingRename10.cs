using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 1005, 长度 = 6, 注释 = "客户GetBackCharacterPacket")]
	public sealed class 客户GetBackCharacterPacket : GamePacket
	{
		
		public 客户GetBackCharacterPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;
	}
}
