using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 167, 长度 = 0, 注释 = "Npcc交互结果")]
	public sealed class 同步交互结果 : GamePacket
	{
		
		public 同步交互结果()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 0)]
		public byte[] 交互文本;
	}
}
