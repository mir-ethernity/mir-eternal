using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 642, 长度 = 10, 注释 = "申请Hostility应答")]
	public sealed class 申请Hostility应答 : GamePacket
	{
		
		public 申请Hostility应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 需要资金;
	}
}
