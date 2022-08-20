using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 247, Length = 2, Description = "刷新演武挑战")]
	public sealed class 刷新演武挑战 : GamePacket
	{
		
		public 刷新演武挑战()
		{
			
			
		}
	}
}
