using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 105, 长度 = 2, 注释 = "玩家开始摆摊")]
	public sealed class 玩家开始摆摊 : GamePacket
	{
		
		public 玩家开始摆摊()
		{
			
			
		}
	}
}
