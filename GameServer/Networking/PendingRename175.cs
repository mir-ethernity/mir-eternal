using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 575, 长度 = 674, 注释 = "查询邮件内容")]
	public sealed class 同步邮件内容 : GamePacket
	{
		
		public 同步邮件内容()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 672)]
		public byte[] 字节数据;
	}
}
