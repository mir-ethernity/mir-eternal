using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 251, Length = 6, Description = "UnblockPlayerPacket")]
	public sealed class UnblockPlayerPacket : GamePacket
	{
		
		public UnblockPlayerPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
