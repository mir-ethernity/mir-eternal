using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 279, 长度 = 4, 注释 = "更换角色计时")]
	public sealed class 更换角色计时 : GamePacket
	{
		
		public 更换角色计时()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public bool 成功;
	}
}
