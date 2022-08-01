using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 21, 长度 = 6, 注释 = "同步角色战力")]
	public sealed class 同步角色战力 : GamePacket
	{
		
		public 同步角色战力()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
