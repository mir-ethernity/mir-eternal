using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 561, 长度 = 2, 注释 = "申请解散行会")]
	public sealed class 申请解散行会 : GamePacket
	{
		
		public 申请解散行会()
		{
			
			
		}
	}
}
