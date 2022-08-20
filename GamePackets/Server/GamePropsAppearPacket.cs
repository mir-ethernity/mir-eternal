using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 152, Length = 19, Description = "GamePropsAppearPacket")]
	public sealed class GamePropsAppearPacket : GamePacket
	{
		
		public GamePropsAppearPacket()
		{
			
			
		}
	}
}
