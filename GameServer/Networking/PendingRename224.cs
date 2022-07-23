using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 665, 长度 = 34, 注释 = "攻城获胜公告")]
	public sealed class 攻城获胜公告 : GamePacket
	{
		
		public 攻城获胜公告()
		{
			
			
		}
	}
}
