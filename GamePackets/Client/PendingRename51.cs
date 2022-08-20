using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 523, Length = 6, Description = "取消好友关注")]
	public sealed class 取消好友关注 : GamePacket
	{
		
		public 取消好友关注()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
