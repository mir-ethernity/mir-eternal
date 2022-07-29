using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 584, 长度 = 0, 注释 = "查看行会列表")]
	public sealed class 同步行会列表 : GamePacket
	{
		
		public 同步行会列表()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
