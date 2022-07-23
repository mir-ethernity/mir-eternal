using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 617, 长度 = 23, 注释 = "AddGuildMemoPacket")]
	public sealed class AddGuildMemoPacket : GamePacket
	{
		
		public AddGuildMemoPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte MemorandumType;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 第一参数;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public int 第二参数;

		
		[WrappingFieldAttribute(下标 = 11, 长度 = 4)]
		public int 第三参数;

		
		[WrappingFieldAttribute(下标 = 15, 长度 = 4)]
		public int 第四参数;

		
		[WrappingFieldAttribute(下标 = 19, 长度 = 4)]
		public int 事记时间;
	}
}
