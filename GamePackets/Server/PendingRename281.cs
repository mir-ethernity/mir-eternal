using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 624, 长度 = 4, 注释 = "更新行会福利")]
	public sealed class 更新行会福利 : GamePacket
	{
		
		public 更新行会福利()
		{
			
			
		}
	}
}
