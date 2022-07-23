using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 543, 长度 = 3, 注释 = "收徒推送应答")]
	public sealed class 收徒推送应答 : GamePacket
	{
		
		public 收徒推送应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public bool 收徒推送;
	}
}
