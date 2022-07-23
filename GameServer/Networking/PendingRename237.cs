using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 20, 长度 = 22, 注释 = "查看玩家装备, 右键头像查看资料时触发")]
	public sealed class 查看玩家装备 : GamePacket
	{
		
		public 查看玩家装备()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
