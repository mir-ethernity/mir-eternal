using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 98, 长度 = 13, 注释 = "技能释放中断")]
	public sealed class 技能释放中断 : GamePacket
	{
		
		public 技能释放中断()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 技能编号;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 1)]
		public byte 技能等级;

		
		[WrappingFieldAttribute(下标 = 9, 长度 = 1)]
		public byte 技能铭文;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 1)]
		public byte 动作编号;

		
		[WrappingFieldAttribute(下标 = 11, 长度 = 1)]
		public byte 技能分段;
	}
}
