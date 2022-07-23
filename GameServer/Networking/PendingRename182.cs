using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 585, 长度 = 7, 注释 = "更多行会信息")]
	public sealed class 同步行会详情 : GamePacket
	{
		
		public 同步行会详情()
		{
			
			
		}
	}
}
