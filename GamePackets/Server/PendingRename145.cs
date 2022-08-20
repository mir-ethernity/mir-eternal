using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 167, Length = 0, Description = "Npcc交互结果")]
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
