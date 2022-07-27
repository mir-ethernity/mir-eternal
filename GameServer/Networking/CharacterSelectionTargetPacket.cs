using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 31, 长度 = 6, 注释 = "CharacterSelectionTargetPacket")]
	public sealed class CharacterSelectionTargetPacket : GamePacket
	{
		
		public CharacterSelectionTargetPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
