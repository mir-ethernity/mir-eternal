using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 246, 长度 = 10, 注释 = "开始战场演武")]
	public sealed class 开始战场演武 : GamePacket
	{
		
		public 开始战场演武()
		{
			
			
		}
	}
}
