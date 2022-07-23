using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 622, 长度 = 27, 注释 = "加入行会公告")]
	public sealed class 加入行会公告 : GamePacket
	{
		
		public 加入行会公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 25)]
		public string 行会名字;
	}
}
