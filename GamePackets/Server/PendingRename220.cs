using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 612, 长度 = 0, 注释 = "仓库刷新应答")]
	public sealed class 仓库刷新应答 : GamePacket
	{
		
		public 仓库刷新应答()
		{
			
			
		}
	}
}
