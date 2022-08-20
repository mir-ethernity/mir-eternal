using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 119, Length = 22, Description = "Effect", Broadcast = true)]
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
