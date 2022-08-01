using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 12, 长度 = 10, 注释 = "场景加载完成")]
	public sealed class 场景加载完成 : GamePacket
	{
		
		public 场景加载完成()
		{
			
			
		}
	}
}
