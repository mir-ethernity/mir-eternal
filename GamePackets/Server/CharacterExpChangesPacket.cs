using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 75, 长度 = 46, 注释 = "CharacterExpChangesPacket")]
	public sealed class CharacterExpChangesPacket : GamePacket
	{
		
		public CharacterExpChangesPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 经验增加;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 今日增加;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 4)]
		public int 经验上限;

		
		[WrappingFieldAttribute(SubScript = 14, Length = 4)]
		public int DoubleExp;

		
		[WrappingFieldAttribute(SubScript = 18, Length = 4)]
		public int CurrentExp;

		
		[WrappingFieldAttribute(SubScript = 26, Length = 4)]
		public int 升级所需;
	}
}
