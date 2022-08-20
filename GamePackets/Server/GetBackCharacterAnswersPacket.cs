using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1007, Length = 6, Description = "GetBackCharacterCommand回应")]
	public sealed class GetBackCharacterAnswersPacket : GamePacket
	{
		
		public GetBackCharacterAnswersPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
