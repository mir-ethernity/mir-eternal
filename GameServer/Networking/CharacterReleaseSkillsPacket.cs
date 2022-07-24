using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 34, 长度 = 16, 注释 = "释放技能")]
	public sealed class CharacterReleaseSkillsPacket : GamePacket
	{
		
		public CharacterReleaseSkillsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 动作编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 目标编号;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public Point 锚点坐标;

		
		[WrappingFieldAttribute(下标 = 14, 长度 = 2)]
		public ushort 锚点高度;
	}
}
