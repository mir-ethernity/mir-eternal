using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 606, 长度 = 0, 注释 = "查看结盟申请")]
	public sealed class 同步结盟申请 : GamePacket
	{
		
		public 同步结盟申请()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
