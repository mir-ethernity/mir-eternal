using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 288, 长度 = 5, 注释 = "同步签到信息")]
	public sealed class 同步签到信息 : GamePacket
	{
		
		public 同步签到信息()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public bool 能否签到;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 签到次数;
	}
}
