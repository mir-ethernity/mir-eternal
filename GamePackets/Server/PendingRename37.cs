using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 154, Length = 12, Description = "开始操作道具")]
	public sealed class 开始操作道具 : GamePacket
	{
		
		public 开始操作道具()
		{
			
			
		}
	}
}
