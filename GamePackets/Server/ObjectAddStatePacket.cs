using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 116, 长度 = 21, 注释 = "添加BUFF")]
	public sealed class ObjectAddStatePacket : GamePacket
	{
		
		public ObjectAddStatePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort Id;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public int Buff索引;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 4)]
		public int Buff来源;

		
		[WrappingFieldAttribute(SubScript = 16, Length = 4)]
		public int 持续时间;

		
		[WrappingFieldAttribute(SubScript = 20, Length = 1)]
		public byte Buff层数;
	}
}
