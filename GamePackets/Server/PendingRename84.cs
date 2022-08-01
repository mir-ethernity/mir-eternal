using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 543, 长度 = 3, 注释 = "收徒推送应答")]
	public sealed class 收徒推送应答 : GamePacket
	{
		
		public 收徒推送应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public bool 收徒推送;
	}
}
