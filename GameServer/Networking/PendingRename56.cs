using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 564, 长度 = 6, 注释 = "离开师门提示")]
	public sealed class 离开师门提示 : GamePacket
	{
		
		public 离开师门提示()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
