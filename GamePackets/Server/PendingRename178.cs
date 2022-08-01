using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 120, 长度 = 0, 注释 = "同步BUFF列表")]
	public sealed class 同步状态列表 : GamePacket
	{
		
		public 同步状态列表()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
