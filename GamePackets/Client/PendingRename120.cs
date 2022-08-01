using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 527, 长度 = 6, 注释 = "添加仇人")]
	public sealed class 玩家添加仇人 : GamePacket
	{
		
		public 玩家添加仇人()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
