using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 338, 长度 = 0, 注释 = "同步奖励找回")]
	public sealed class 同步奖励找回 : GamePacket
	{
		
		public 同步奖励找回()
		{
			
			
		}
	}
}
