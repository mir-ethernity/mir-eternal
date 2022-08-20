using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 547, Length = 0, Description = "申请发送邮件")]
	public sealed class 申请发送邮件 : GamePacket
	{
		
		public 申请发送邮件()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 0)]
		public byte[] 字节数据;
	}
}
