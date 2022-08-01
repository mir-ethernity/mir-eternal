using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 538, 长度 = 7, 注释 = "玩家申请收徒")]
	public sealed class 玩家申请收徒 : GamePacket
	{
		
		public 玩家申请收徒()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 对象编号;
	}
}
