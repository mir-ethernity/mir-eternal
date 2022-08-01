using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 94, 长度 = 25, 注释 = "开始释放技能(技能信息,目标,坐标,速率)")]
	public sealed class 开始释放技能 : GamePacket
	{
		
		public 开始释放技能()
		{
			
			this.加速率一 = 10000;
			this.加速率二 = 10000;
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 1)]
		public byte 技能等级;

		
		[WrappingFieldAttribute(SubScript = 9, Length = 1)]
		public byte 技能铭文;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 4)]
		public int 目标编号;

		
		[WrappingFieldAttribute(SubScript = 14, Length = 4)]
		public Point 锚点坐标;

		
		[WrappingFieldAttribute(SubScript = 18, Length = 2)]
		public ushort 锚点高度;

		
		[WrappingFieldAttribute(SubScript = 20, Length = 2)]
		public ushort 加速率一;

		
		[WrappingFieldAttribute(SubScript = 22, Length = 2)]
		public ushort 加速率二;

		
		[WrappingFieldAttribute(SubScript = 24, Length = 1)]
		public byte 动作编号;
	}
}
