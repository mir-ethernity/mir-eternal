using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 112, 长度 = 6, 注释 = "离开战斗姿态")]
	public sealed class 离开战斗姿态 : GamePacket
	{
		
		public 离开战斗姿态()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
