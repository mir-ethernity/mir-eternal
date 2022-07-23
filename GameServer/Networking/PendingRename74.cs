using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 547, 长度 = 0, 注释 = "申请发送邮件")]
	public sealed class 申请发送邮件 : GamePacket
	{
		
		public 申请发送邮件()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 0)]
		public byte[] 字节数据;
	}
}
