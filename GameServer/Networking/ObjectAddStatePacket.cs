using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 116, 长度 = 21, 注释 = "添加BUFF")]
	public sealed class ObjectAddStatePacket : GamePacket
	{
		
		public ObjectAddStatePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort Buff编号;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int Buff索引;

		
		[WrappingFieldAttribute(下标 = 12, 长度 = 4)]
		public int Buff来源;

		
		[WrappingFieldAttribute(下标 = 16, 长度 = 4)]
		public int 持续时间;

		
		[WrappingFieldAttribute(下标 = 20, 长度 = 1)]
		public byte Buff层数;
	}
}
