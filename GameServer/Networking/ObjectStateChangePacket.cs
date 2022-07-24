using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 118, 长度 = 21, 注释 = "BUFF变动")]
	public sealed class ObjectStateChangePacket : GamePacket
	{
		
		public ObjectStateChangePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort Id;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int Buff索引;

		
		[WrappingFieldAttribute(下标 = 12, 长度 = 1)]
		public byte 当前层数;

		
		[WrappingFieldAttribute(下标 = 13, 长度 = 4)]
		public int 剩余时间;

		
		[WrappingFieldAttribute(下标 = 17, 长度 = 4)]
		public int 持续时间;
	}
}
