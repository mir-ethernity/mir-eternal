using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 119, 长度 = 22, 注释 = "BUFF效果")]
	public sealed class 触发状态效果 : GamePacket
	{
		
		public 触发状态效果()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort Buff编号;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int Buff来源;

		
		[WrappingFieldAttribute(下标 = 12, 长度 = 4)]
		public int Buff目标;

		
		[WrappingFieldAttribute(下标 = 16, 长度 = 4)]
		public int 血量变化;
	}
}
