using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 97, 长度 = 28, 注释 = "触发命中特效(技能信息,目标,血量,反馈)")]
	public sealed class 触发命中特效 : GamePacket
	{
		
		public 触发命中特效()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 1)]
		public byte SkillLevel;

		
		[WrappingFieldAttribute(SubScript = 9, Length = 1)]
		public byte 技能铭文;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 1)]
		public byte 动作编号;

		
		[WrappingFieldAttribute(SubScript = 13, Length = 4)]
		public int 目标编号;

		
		[WrappingFieldAttribute(SubScript = 17, Length = 4)]
		public int 技能伤害;

		
		[WrappingFieldAttribute(SubScript = 21, Length = 2)]
		public ushort 招架伤害;

		
		[WrappingFieldAttribute(SubScript = 25, Length = 2)]
		public ushort 技能反馈;
	}
}
