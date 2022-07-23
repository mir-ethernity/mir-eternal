using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 73, 长度 = 7, 注释 = "Npc变换类型")]
	public sealed class ObjectTransformTypePacket : GamePacket
	{
		
		public ObjectTransformTypePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 改变类型;
	}
}
