using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 223, Length = 10, Description = "同步对象行会", Broadcast = true)]
	public sealed class 同步对象行会 : GamePacket
	{
		
		public 同步对象行会()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 行会编号;
	}
}
