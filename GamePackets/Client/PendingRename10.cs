using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 1005, Length = 6, Description = "客户GetBackCharacterPacket")]
	public sealed class 客户GetBackCharacterPacket : GamePacket
	{
		
		public 客户GetBackCharacterPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
