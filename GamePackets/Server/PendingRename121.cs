using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 532, Length = 39, Description = "添加关注")]
	public sealed class 玩家添加关注 : GamePacket
	{
		
		public 玩家添加关注()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 32)]
		public string 对象名字;

		
		[WrappingFieldAttribute(SubScript = 38, Length = 1)]
		public bool 是否好友;
	}
}
