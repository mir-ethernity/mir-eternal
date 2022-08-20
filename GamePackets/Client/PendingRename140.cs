using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 93, Length = 8, Description = "随身修理单件")]
	public sealed class 随身修理单件 : GamePacket
	{
		
		public 随身修理单件()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 物品容器;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int Id;
	}
}
