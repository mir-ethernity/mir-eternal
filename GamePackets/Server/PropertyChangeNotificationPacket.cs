using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 604, Length = 10, Description = "PropertyChangeNotificationPacket")]
	public sealed class PropertyChangeNotificationPacket : GamePacket
	{
		
		public PropertyChangeNotificationPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int Stat类型;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int Value;
	}
}
