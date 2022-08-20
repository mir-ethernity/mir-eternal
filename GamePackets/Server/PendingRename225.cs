using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 95, Length = 0, Description = "触发技能扩展(技能信息,目标,反馈,耗时)", Broadcast = true)]
	public sealed class 触发技能扩展 : GamePacket
	{
		
		public 触发技能扩展()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 1)]
		public byte SkillLevel;

		
		[WrappingFieldAttribute(SubScript = 11, Length = 1)]
		public byte 技能铭文;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 1)]
		public byte 动作编号;

		
		[WrappingFieldAttribute(SubScript = 13, Length = 1)]
		public byte 技能分段;

		
		[WrappingFieldAttribute(SubScript = 14, Length = 1)]
		public byte 未知参数;

		
		[WrappingFieldAttribute(SubScript = 15, Length = 0)]
		public byte[] 命中描述;
	}
}
