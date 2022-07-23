using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 112, 长度 = 6, 注释 = "离开战斗姿态")]
	public sealed class 离开战斗姿态 : GamePacket
	{
		
		public 离开战斗姿态()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
