using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 69, Length = 5, Description = "玩家拆除灵石")]
	public sealed class 玩家拆除灵石 : GamePacket
	{
		
		public 玩家拆除灵石()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 装备类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 装备位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 装备孔位;
	}
}
