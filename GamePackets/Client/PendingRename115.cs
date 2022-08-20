using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 68, Length = 7, Description = "玩家镶嵌灵石")]
	public sealed class 玩家镶嵌灵石 : GamePacket
	{
		
		public 玩家镶嵌灵石()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 装备类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 装备位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 装备孔位;

		
		[WrappingFieldAttribute(SubScript = 5, Length = 1)]
		public byte 灵石类型;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 灵石位置;
	}
}
