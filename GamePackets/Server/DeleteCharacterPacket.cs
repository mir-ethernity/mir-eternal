using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1008, Length = 6, Description = "DeleteCharacterPacket回应")]
	public sealed class DeleteCharacterPacket : GamePacket
	{
		
		public DeleteCharacterPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
