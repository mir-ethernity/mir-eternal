using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 545, Length = 0, Description = "CongratsToApprenticeForUpgradePacket(已弃用)")]
	public sealed class CongratsToApprenticeForUpgradePacket : GamePacket
	{
		
		public CongratsToApprenticeForUpgradePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 0)]
		public byte[] 字节数据;
	}
}
