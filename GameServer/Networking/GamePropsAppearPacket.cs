using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 152, 长度 = 19, 注释 = "GamePropsAppearPacket")]
	public sealed class GamePropsAppearPacket : GamePacket
	{
		
		public GamePropsAppearPacket()
		{
			
			
		}
	}
}
