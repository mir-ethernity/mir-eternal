using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 188, 长度 = 2, 注释 = "查询问卷调查")]
	public sealed class 查询问卷调查 : GamePacket
	{
		
		public 查询问卷调查()
		{
			
			
		}
	}
}
