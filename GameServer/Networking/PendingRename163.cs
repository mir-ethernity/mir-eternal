using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 81, 长度 = 13, 注释 = "发送PK的结果")]
	public sealed class 同步对战结果 : GamePacket
	{
		
		public 同步对战结果()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 击杀方式;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 胜方编号;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public int 败方编号;

		
		[WrappingFieldAttribute(下标 = 11, 长度 = 2)]
		public ushort PK值惩罚;
	}
}
