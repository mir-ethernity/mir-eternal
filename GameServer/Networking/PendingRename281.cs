using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 624, 长度 = 4, 注释 = "更新行会福利")]
	public sealed class 更新行会福利 : GamePacket
	{
		
		public 更新行会福利()
		{
			
			
		}
	}
}
