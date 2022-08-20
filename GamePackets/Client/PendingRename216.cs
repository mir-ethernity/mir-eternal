using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 25, Length = 2, Description = "跳过剧情动画")]
	public sealed class 跳过剧情动画 : GamePacket
	{
		
		public 跳过剧情动画()
		{
			
			
		}
	}
}
