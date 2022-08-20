using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1011, Length = 38, Description = "更改角色姓名")]
	public sealed class CharacterRenamingAnswerPacket : GamePacket
	{
		
		public CharacterRenamingAnswerPacket()
		{
			
			
		}
	}
}
