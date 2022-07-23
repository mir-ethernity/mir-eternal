using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 65, 长度 = 16, 注释 = "同步Npcc数据")]
	public sealed class 同步Npcc数据 : GamePacket
	{
		
		public 同步Npcc数据()
		{
			
			this.对象质量 = 3;
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 对象模板;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 1)]
		public byte 对象质量;

		
		[WrappingFieldAttribute(下标 = 11, 长度 = 1)]
		public byte 对象等级;

		
		[WrappingFieldAttribute(下标 = 12, 长度 = 4)]
		public int 体力上限;
	}
}
