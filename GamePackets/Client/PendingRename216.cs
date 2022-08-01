using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 25, 长度 = 2, 注释 = "跳过剧情动画")]
	public sealed class 跳过剧情动画 : GamePacket
	{
		
		public 跳过剧情动画()
		{
			
			
		}
	}
}
