using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 287, 长度 = 1282, 注释 = "查询问卷调查")]
	public sealed class 问卷调查应答 : GamePacket
	{
		
		public 问卷调查应答()
		{
			
			
		}
	}
}
