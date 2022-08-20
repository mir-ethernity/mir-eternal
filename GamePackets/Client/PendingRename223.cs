using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 12, Length = 10, Description = "场景加载完成")]
	public sealed class 场景加载完成 : GamePacket
	{
		
		public 场景加载完成()
		{
			
			
		}
	}
}
