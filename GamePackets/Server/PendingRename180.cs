using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 584, Length = 0, Description = "查看行会列表")]
	public sealed class 同步行会列表 : GamePacket
	{
		
		public 同步行会列表()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
