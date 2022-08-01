using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 88, 长度 = 3, 注释 = "领取师门奖励(已经弃用, 出师时自动结算)")]
	public sealed class 领取师门奖励 : GamePacket
	{
		
		public 领取师门奖励()
		{
			
			
		}
	}
}
