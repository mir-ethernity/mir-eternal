using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 10, 长度 = 6, 注释 = "更换角色")]
	public sealed class 客户更换角色 : GamePacket
	{
		
		public 客户更换角色()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 编号;
	}
}
