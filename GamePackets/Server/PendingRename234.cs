using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 597, Length = 0, Description = "更改行会公告")]
	public sealed class 变更行会公告 : GamePacket
	{
		
		public 变更行会公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
