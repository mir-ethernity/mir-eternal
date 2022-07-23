using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 154, 长度 = 12, 注释 = "开始操作道具")]
	public sealed class 开始操作道具 : GamePacket
	{
		
		public 开始操作道具()
		{
			
			
		}
	}
}
