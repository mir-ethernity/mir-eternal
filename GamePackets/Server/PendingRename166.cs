using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 80, 长度 = 10, 注释 = "同步PK惩罚值")]
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
