using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 117, Length = 10, Description = "移除BUFF", Broadcast = true)]
	public sealed class ObjectRemovalStatusPacket : GamePacket
	{
		
		public ObjectRemovalStatusPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int Buff索引;
	}
}
