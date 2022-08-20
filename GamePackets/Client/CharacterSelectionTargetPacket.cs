using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 31, Length = 6, Description = "CharacterSelectionTargetPacket")]
	public sealed class CharacterSelectionTargetPacket : GamePacket
	{
		
		public CharacterSelectionTargetPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
