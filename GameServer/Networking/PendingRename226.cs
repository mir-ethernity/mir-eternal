using System;

namespace GameServer.Networking
{
	
	[PacketInfo(来源 = PacketSource.服务器, 编号 = 96, 长度 = 0, 注释 = "触发技能正常(技能信息,目标,反馈,耗时)")]
	public sealed class SkillHitNormal : GamePacket
	{
		public SkillHitNormal()
		{
			SkillSegment = 1;
			HitDescription = new byte[1];
		}

		[WrappingField(SubScript = 4, Length = 4)]
		public int ObjectId;

		
		[WrappingField(SubScript = 8, Length = 2)]
		public ushort SkillId;

		
		[WrappingField(SubScript = 10, Length = 1)]
		public byte SkillLevel;

		
		[WrappingField(SubScript = 11, Length = 1)]
		public byte SkillInscription;

		
		[WrappingField(SubScript = 12, Length = 1)]
		public byte ActionId;

		
		[WrappingField(SubScript = 13, Length = 1)]
		public byte SkillSegment;

		
		[WrappingField(SubScript = 14, Length = 0)]
		public byte[] HitDescription;
	}
}
