using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 20, Length = 22, Description = "查看玩家装备, 右键头像查看资料时触发")]
	public sealed class 查看玩家装备 : GamePacket
	{
		
		public 查看玩家装备()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
