using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 80, 长度 = 10, 注释 = "同步PK惩罚值")]
	public sealed class 同步对象惩罚 : GamePacket
	{
		
		public 同步对象惩罚()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int PK值惩罚;
	}
}
