using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 625, 长度 = 6, 注释 = "取消升级福利")]
	public sealed class 取消升级福利 : GamePacket
	{
		
		public 取消升级福利()
		{
			
			
		}
	}
}
