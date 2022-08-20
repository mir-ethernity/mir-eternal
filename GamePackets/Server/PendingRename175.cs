using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 575, Length = 674, Description = "查询邮件内容")]
	public sealed class 同步邮件内容 : GamePacket
	{
		
		public 同步邮件内容()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 672)]
		public byte[] 字节数据;
	}
}
