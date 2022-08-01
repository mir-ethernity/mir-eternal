using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 94, 长度 = 2, 注释 = "随身特修全部")]
	public sealed class 随身特修全部 : GamePacket
	{
		
		public 随身特修全部()
		{
			
			
		}
	}
}
