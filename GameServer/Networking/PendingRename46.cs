using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 588, 长度 = 6, 注释 = "加入行会回应")]
	public sealed class 加入行会应答 : GamePacket
	{
		
		public 加入行会应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;
	}
}
