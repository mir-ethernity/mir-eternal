using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 257, Length = 2, Description = "取回升级武器")]
	public sealed class 取回升级武器 : GamePacket
	{
		
		public 取回升级武器()
		{
			
			
		}
	}
}
