using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 71, 长度 = 36, 注释 = "同步对象Buff")]
	public sealed class 同步对象Buff : GamePacket
	{
		
		public 同步对象Buff()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 34)]
		public byte[] 字节描述;
	}
}
