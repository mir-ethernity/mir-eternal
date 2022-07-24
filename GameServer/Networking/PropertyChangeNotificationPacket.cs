using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 604, 长度 = 10, 注释 = "PropertyChangeNotificationPacket")]
	public sealed class PropertyChangeNotificationPacket : GamePacket
	{
		
		public PropertyChangeNotificationPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int Stat类型;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int Value;
	}
}
