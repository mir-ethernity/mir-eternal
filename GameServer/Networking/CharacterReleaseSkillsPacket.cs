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

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 动作编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 目标编号;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 4)]
		public Point 锚点坐标;

		
		[WrappingFieldAttribute(SubScript = 14, Length = 2)]
		public ushort 锚点高度;
	}
}
