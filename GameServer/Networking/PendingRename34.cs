using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 94, 长度 = 25, 注释 = "开始释放技能(技能信息,目标,坐标,速率)")]
	public sealed class 开始释放技能 : GamePacket
	{
		
		public 开始释放技能()
		{
			
			this.加速率一 = 10000;
			this.加速率二 = 10000;
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 1)]
		public byte 技能等级;

		
		[WrappingFieldAttribute(下标 = 9, 长度 = 1)]
		public byte 技能铭文;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 目标编号;

		
		[WrappingFieldAttribute(下标 = 14, 长度 = 4)]
		public Point 锚点坐标;

		
		[WrappingFieldAttribute(下标 = 18, 长度 = 2)]
		public ushort 锚点高度;

		
		[WrappingFieldAttribute(下标 = 20, 长度 = 2)]
		public ushort 加速率一;

		
		[WrappingFieldAttribute(下标 = 22, 长度 = 2)]
		public ushort 加速率二;

		
		[WrappingFieldAttribute(下标 = 24, 长度 = 1)]
		public byte 动作编号;
	}
}
