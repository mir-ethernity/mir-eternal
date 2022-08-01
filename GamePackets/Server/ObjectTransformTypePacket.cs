using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 73, 长度 = 7, 注释 = "Npc变换类型")]
	public sealed class ObjectTransformTypePacket : GamePacket
	{
		
		public ObjectTransformTypePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 改变类型;
	}
}
