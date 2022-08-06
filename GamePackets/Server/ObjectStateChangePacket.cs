using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 118, 长度 = 21, 注释 = "BUFF变动", Broadcast = true)]
	public sealed class ObjectStateChangePacket : GamePacket
	{
		
		public ObjectStateChangePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort Id;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public int Buff索引;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 1)]
		public byte 当前层数;

		
		[WrappingFieldAttribute(SubScript = 13, Length = 4)]
		public int 剩余时间;

		
		[WrappingFieldAttribute(SubScript = 17, Length = 4)]
		public int 持续时间;
	}
}
