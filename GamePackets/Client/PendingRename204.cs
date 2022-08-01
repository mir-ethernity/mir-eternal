using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 613, 长度 = 4, 注释 = "购买玛法特权")]
	public sealed class 购买玛法特权 : GamePacket
	{
		
		public 购买玛法特权()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 特权类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 购买数量;
	}
}
