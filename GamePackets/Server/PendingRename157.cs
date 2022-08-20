using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 606, Length = 0, Description = "查看结盟申请")]
	public sealed class 同步结盟申请 : GamePacket
	{
		
		public 同步结盟申请()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
