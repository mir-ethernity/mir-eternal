using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 62, Length = 7, Description = "对象消失")]
	public sealed class ObjectOutOfViewPacket : GamePacket
	{
		
		public ObjectOutOfViewPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 消失方式;
	}
}
