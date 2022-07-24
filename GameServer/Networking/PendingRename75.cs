using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 642, 长度 = 10, 注释 = "申请Hostility应答")]
	public sealed class 申请Hostility应答 : GamePacket
	{
		
		public 申请Hostility应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 需要资金;
	}
}
