using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 279, 长度 = 4, 注释 = "更换角色计时")]
	public sealed class 更换角色计时 : GamePacket
	{
		
		public 更换角色计时()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public bool 成功;
	}
}
