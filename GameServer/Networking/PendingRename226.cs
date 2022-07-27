using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 96, 长度 = 0, 注释 = "触发技能正常(技能信息,目标,反馈,耗时)")]
	public sealed class 触发技能正常 : GamePacket
	{
		
		public 触发技能正常()
		{
			
			this.技能分段 = 1;
			this.命中描述 = new byte[1];
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 1)]
		public byte 技能等级;

		
		[WrappingFieldAttribute(SubScript = 11, Length = 1)]
		public byte 技能铭文;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 1)]
		public byte 动作编号;

		
		[WrappingFieldAttribute(SubScript = 13, Length = 1)]
		public byte 技能分段;

		
		[WrappingFieldAttribute(SubScript = 14, Length = 0)]
		public byte[] 命中描述;
	}
}
