using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 119, 长度 = 22, 注释 = "Effect")]
	public sealed class 触发状态效果 : GamePacket
	{
		
		public 触发状态效果()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort Id;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public int Buff来源;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 4)]
		public int Buff目标;

		
		[WrappingFieldAttribute(SubScript = 16, Length = 4)]
		public int 血量变化;
	}
}
