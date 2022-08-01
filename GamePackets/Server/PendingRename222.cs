using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 615, 长度 = 4, 注释 = "仓库转出应答")]
	public sealed class 仓库转出应答 : GamePacket
	{
		
		public 仓库转出应答()
		{
			
			
		}
	}
}
