using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 343, Length = 3, Description = "FixMaxPersistentPacket")]
	public sealed class FixMaxPersistentPacket : GamePacket
	{
		
		public FixMaxPersistentPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public bool 修复失败;
	}
}
