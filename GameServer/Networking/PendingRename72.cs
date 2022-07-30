using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 161, 长度 = 0, 注释 = "申请创建行会")]
	public sealed class 申请创建行会 : GamePacket
	{
		
		public 申请创建行会()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 0)]
		public byte[] 字节数据;
	}
}
