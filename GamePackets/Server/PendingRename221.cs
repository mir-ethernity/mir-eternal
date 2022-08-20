using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 616, Length = 6, Description = "仓库移动应答")]
	public sealed class 仓库移动应答 : GamePacket
	{
		
		public 仓库移动应答()
		{
			
			
		}
	}
}
