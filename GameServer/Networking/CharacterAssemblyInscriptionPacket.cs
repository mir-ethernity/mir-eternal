using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 101, 长度 = 6, 注释 = "CharacterAssemblyInscriptionPacket")]
	public sealed class CharacterAssemblyInscriptionPacket : GamePacket
	{
		
		public CharacterAssemblyInscriptionPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 技能编号;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 铭文编号;

		
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 技能等级;
	}
}
