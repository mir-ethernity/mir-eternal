using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 604, 长度 = 10, 注释 = "PropertyChangeNotificationPacket")]
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
