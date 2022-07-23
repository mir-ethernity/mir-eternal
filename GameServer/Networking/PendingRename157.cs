using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 606, 长度 = 0, 注释 = "查看结盟申请")]
	public sealed class 同步结盟申请 : GamePacket
	{
		
		public 同步结盟申请()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节描述;
	}
}
