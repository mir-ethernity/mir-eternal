using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 71, 长度 = 6, 注释 = "传承武器铭文")]
	public sealed class 传承武器铭文 : GamePacket
	{
		
		public 传承武器铭文()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 来源类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 来源位置;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 目标类型;

		
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 目标位置;
	}
}
