using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 515, Length = 10, Description = "RequestCharacterDataPacket")]
	public sealed class RequestCharacterDataPacket : GamePacket
	{
		
		public RequestCharacterDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
