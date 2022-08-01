using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 70, 长度 = 11, 注释 = "同步道具次数")]
	public sealed class 同步道具次数 : GamePacket
	{
		
		public 同步道具次数()
		{
			
			
		}
	}
}
