using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 98, 长度 = 13, 注释 = "技能释放中断")]
	public sealed class 技能释放中断 : GamePacket
	{
		
		public 技能释放中断()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 1)]
		public byte 技能等级;

		
		[WrappingFieldAttribute(SubScript = 9, Length = 1)]
		public byte 技能铭文;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 1)]
		public byte 动作编号;

		
		[WrappingFieldAttribute(SubScript = 11, Length = 1)]
		public byte 技能分段;
	}
}
