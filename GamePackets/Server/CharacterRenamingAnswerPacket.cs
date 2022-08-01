using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 1011, 长度 = 38, 注释 = "更改角色姓名")]
	public sealed class CharacterRenamingAnswerPacket : GamePacket
	{
		
		public CharacterRenamingAnswerPacket()
		{
			
			
		}
	}
}
