using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 74, 长度 = 7, 注释 = "CharacterLevelUpPacket", Broadcast = true)]
	public sealed class CharacterLevelUpPacket : GamePacket
	{
		
		public CharacterLevelUpPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 对象等级;
	}
}
