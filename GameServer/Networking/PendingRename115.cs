using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 68, 长度 = 7, 注释 = "玩家镶嵌灵石")]
	public sealed class 玩家镶嵌灵石 : GamePacket
	{
		
		public 玩家镶嵌灵石()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 装备孔位;

		
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 灵石类型;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 灵石位置;
	}
}
