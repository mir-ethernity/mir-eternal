using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 523, 长度 = 7, 注释 = "同步队员状态")]
	public sealed class 同步队员状态 : GamePacket
	{
		
		public 同步队员状态()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 状态编号;
	}
}
