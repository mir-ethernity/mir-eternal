using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 623, 长度 = 7, 注释 = "提升行会福利")]
	public sealed class 提升行会福利 : GamePacket
	{
		
		public 提升行会福利()
		{
			
			
		}
	}
}
