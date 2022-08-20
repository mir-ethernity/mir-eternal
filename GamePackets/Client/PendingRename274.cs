using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 562, Length = 0, Description = "更改行会公告")]
	public sealed class 更改行会公告 : GamePacket
	{
		
		public 更改行会公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 0)]
		public byte[] 行会公告;
	}
}
