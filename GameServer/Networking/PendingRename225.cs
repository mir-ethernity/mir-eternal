using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 95, 长度 = 0, 注释 = "触发技能扩展(技能信息,目标,反馈,耗时)")]
	public sealed class 触发技能扩展 : GamePacket
	{
		
		public 触发技能扩展()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 1)]
		public byte 技能等级;

		
		[WrappingFieldAttribute(下标 = 11, 长度 = 1)]
		public byte 技能铭文;

		
		[WrappingFieldAttribute(下标 = 12, 长度 = 1)]
		public byte 动作编号;

		
		[WrappingFieldAttribute(下标 = 13, 长度 = 1)]
		public byte 技能分段;

		
		[WrappingFieldAttribute(下标 = 14, 长度 = 1)]
		public byte 未知参数;

		
		[WrappingFieldAttribute(下标 = 15, 长度 = 0)]
		public byte[] 命中描述;
	}
}
