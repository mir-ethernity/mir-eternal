using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 85, 长度 = 8, 注释 = "泡泡提示")]
	public sealed class 同步气泡提示 : GamePacket
	{
		
		public 同步气泡提示()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 泡泡类型;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 泡泡参数;
	}
}
