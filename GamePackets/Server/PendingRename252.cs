using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 542, Length = 0, Description = "查询线路信息")]
	public sealed class 查询线路信息 : GamePacket
	{
		
		public 查询线路信息()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
