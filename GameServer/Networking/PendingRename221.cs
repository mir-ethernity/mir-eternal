using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 616, 长度 = 6, 注释 = "仓库移动应答")]
	public sealed class 仓库移动应答 : GamePacket
	{
		
		public 仓库移动应答()
		{
			
			
		}
	}
}
