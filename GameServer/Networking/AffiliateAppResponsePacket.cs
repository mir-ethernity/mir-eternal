using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 607, 长度 = 6, 注释 = "处理结盟申请")]
	public sealed class AffiliateAppResponsePacket : GamePacket
	{
		
		public AffiliateAppResponsePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;
	}
}
