using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 71, 长度 = 36, 注释 = "同步对象Buff")]
	public sealed class 同步对象Buff : GamePacket
	{
		
		public 同步对象Buff()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 34)]
		public byte[] 字节描述;
	}
}
