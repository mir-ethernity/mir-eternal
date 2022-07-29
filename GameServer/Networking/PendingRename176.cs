using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 574, 长度 = 0, 注释 = "QueryMailboxContentPacket")]
	public sealed class 同步邮箱内容 : GamePacket
	{
		
		public 同步邮箱内容()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
