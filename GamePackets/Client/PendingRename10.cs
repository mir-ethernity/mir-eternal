using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 1005, 长度 = 6, 注释 = "客户GetBackCharacterPacket")]
	public sealed class 客户GetBackCharacterPacket : GamePacket
	{
		
		public 客户GetBackCharacterPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
