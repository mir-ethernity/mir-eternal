using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 545, 长度 = 0, 注释 = "CongratsToApprenticeForUpgradePacket(已弃用)")]
	public sealed class CongratsToApprenticeForUpgradePacket : GamePacket
	{
		
		public CongratsToApprenticeForUpgradePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 0)]
		public byte[] 字节数据;
	}
}
