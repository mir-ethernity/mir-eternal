using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 542, 长度 = 0, 注释 = "查询线路信息")]
	public sealed class 查询线路信息 : GamePacket
	{
		
		public 查询线路信息()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
