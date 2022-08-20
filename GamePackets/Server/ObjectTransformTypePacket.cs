using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 73, Length = 7, Description = "Npc变换类型", Broadcast = true)]
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
