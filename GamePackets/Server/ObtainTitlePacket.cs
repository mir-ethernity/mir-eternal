using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 213, Length = 7, Description = "玩家获得称号")]
	public sealed class ObtainTitlePacket : GamePacket
	{
		
		public ObtainTitlePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte Id;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int ExpireTime;
	}
}
