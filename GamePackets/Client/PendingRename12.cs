using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 1006, Length = 6, Description = "进入游戏")]
	public sealed class 客户进入游戏 : GamePacket
	{
		
		public 客户进入游戏()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
