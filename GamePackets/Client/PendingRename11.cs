using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 22, Length = 6, Description = "进入传送门触发")]
	public sealed class 客户进入法阵 : GamePacket
	{
		
		public 客户进入法阵()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int TeleportGateNumber;
	}
}
