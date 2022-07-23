using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 75, 长度 = 46, 注释 = "CharacterExpChangesPacket")]
	public sealed class CharacterExpChangesPacket : GamePacket
	{
		
		public CharacterExpChangesPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 经验增加;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 今日增加;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 经验上限;

		
		[WrappingFieldAttribute(下标 = 14, 长度 = 4)]
		public int 双倍经验;

		
		[WrappingFieldAttribute(下标 = 18, 长度 = 4)]
		public int 当前经验;

		
		[WrappingFieldAttribute(下标 = 26, 长度 = 4)]
		public int 升级所需;
	}
}
