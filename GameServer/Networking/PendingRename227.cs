using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 97, 长度 = 28, 注释 = "触发命中特效(技能信息,目标,血量,反馈)")]
	public sealed class 触发命中特效 : GamePacket
	{
		
		public 触发命中特效()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 1)]
		public byte 技能等级;

		
		[WrappingFieldAttribute(下标 = 9, 长度 = 1)]
		public byte 技能铭文;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 1)]
		public byte 动作编号;

		
		[WrappingFieldAttribute(下标 = 13, 长度 = 4)]
		public int 目标编号;

		
		[WrappingFieldAttribute(下标 = 17, 长度 = 4)]
		public int 技能伤害;

		
		[WrappingFieldAttribute(下标 = 21, 长度 = 2)]
		public ushort 招架伤害;

		
		[WrappingFieldAttribute(下标 = 25, 长度 = 2)]
		public ushort 技能反馈;
	}
}
