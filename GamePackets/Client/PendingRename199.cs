using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 598, Length = 2, Description = "打开角色背包")]
	public sealed class 打开角色背包 : GamePacket
	{
		
		public 打开角色背包()
		{
			
			
		}
	}
}
