using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 565, Length = 7, Description = "变更会员职位")]
	public sealed class 变更会员职位 : GamePacket
	{
		
		public 变更会员职位()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 对象职位;
	}
}
