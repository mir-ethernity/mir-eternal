using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 656, 长度 = 6, 注释 = "同步NumberDollars")]
	public sealed class 同步NumberDollars : GamePacket
	{
		
		public 同步NumberDollars()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int NumberDollars;
	}
}
