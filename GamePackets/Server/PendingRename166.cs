using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 80, Length = 10, Description = "同步PK惩罚值", Broadcast = true)]
	public sealed class 同步对象惩罚 : GamePacket
	{
		
		public 同步对象惩罚()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int PK值惩罚;
	}
}
