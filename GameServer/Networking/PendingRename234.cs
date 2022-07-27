using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 597, 长度 = 0, 注释 = "更改行会公告")]
	public sealed class 变更行会公告 : GamePacket
	{
		
		public 变更行会公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
