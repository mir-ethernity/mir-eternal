using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 612, Length = 0, Description = "仓库刷新应答")]
	public sealed class 仓库刷新应答 : GamePacket
	{
		
		public 仓库刷新应答()
		{
			
			
		}
	}
}
