using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 525, 长度 = 40, 注释 = "上传社交信息(已屏蔽)")]
	public sealed class 上传社交信息 : GamePacket
	{
		
		public 上传社交信息()
		{
			
			
		}
	}
}
