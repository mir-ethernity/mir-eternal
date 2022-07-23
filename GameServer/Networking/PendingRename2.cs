using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 99, 长度 = 5, 注释 = "释放完成, 可以释放下一个技能")]
	public sealed class 技能释放完成 : GamePacket
	{
		
		public 技能释放完成()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 技能编号;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 动作编号;
	}
}
