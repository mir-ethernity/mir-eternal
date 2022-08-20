using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 607, Length = 6, Description = "处理结盟申请")]
	public sealed class AffiliateAppResponsePacket : GamePacket
	{
		
		public AffiliateAppResponsePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;
	}
}
