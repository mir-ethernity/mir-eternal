using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 20, 长度 = 22, 注释 = "查看玩家装备, 右键头像查看资料时触发")]
	public sealed class 查看玩家装备 : GamePacket
	{
		
		public 查看玩家装备()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
