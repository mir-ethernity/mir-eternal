using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 120, Length = 0, Description = "同步BUFF列表")]
	public sealed class 同步状态列表 : GamePacket
	{
		
		public 同步状态列表()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
