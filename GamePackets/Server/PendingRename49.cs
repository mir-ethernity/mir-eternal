using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 625, Length = 6, Description = "取消升级福利")]
	public sealed class 取消升级福利 : GamePacket
	{
		
		public 取消升级福利()
		{
			
			
		}
	}
}
