using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 605, 长度 = 6, 注释 = "申请结盟应答")]
	public sealed class 申请结盟应答 : GamePacket
	{
		
		public 申请结盟应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;
	}
}
