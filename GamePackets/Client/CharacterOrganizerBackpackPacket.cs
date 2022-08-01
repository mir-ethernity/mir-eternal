using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 58, 长度 = 3, 注释 = "CharacterOrganizerBackpackPacket")]
	public sealed class CharacterOrganizerBackpackPacket : GamePacket
	{
		
		public CharacterOrganizerBackpackPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 背包类型;
	}
}
