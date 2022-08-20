using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 673, Length = 0, Description = "同步珍宝数量")]
	public sealed class 同步珍宝数量 : GamePacket
	{
		
		public 同步珍宝数量()
		{
			
			
		}
	}
}
