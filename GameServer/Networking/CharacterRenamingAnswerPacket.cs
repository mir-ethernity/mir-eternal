using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1011, 长度 = 38, 注释 = "更改角色姓名")]
	public sealed class CharacterRenamingAnswerPacket : GamePacket
	{
		
		public CharacterRenamingAnswerPacket()
		{
			
			
		}
	}
}
