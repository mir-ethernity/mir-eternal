using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 64, 长度 = 129, 注释 = "SyncPlayerAppearancePacket")]
	public sealed class SyncPlayerAppearancePacket : GamePacket
	{
		
		public SyncPlayerAppearancePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 1)]
		public byte 对象职业;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 1)]
		public byte 对象性别;

		
		[WrappingFieldAttribute(下标 = 9, 长度 = 1)]
		public byte 对象发型;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 1)]
		public byte 对象发色;

		
		[WrappingFieldAttribute(下标 = 11, 长度 = 1)]
		public byte 对象脸型;

		
		[WrappingFieldAttribute(下标 = 14, 长度 = 1)]
		public int 对象PK值;

		
		[WrappingFieldAttribute(下标 = 19, 长度 = 1)]
		public byte 武器等级;

		
		[WrappingFieldAttribute(下标 = 20, 长度 = 4)]
		public int 身上武器;

		
		[WrappingFieldAttribute(下标 = 24, 长度 = 4)]
		public int 身上衣服;

		
		[WrappingFieldAttribute(下标 = 28, 长度 = 4)]
		public int 身上披风;

		
		[WrappingFieldAttribute(下标 = 32, 长度 = 4)]
		public int 当前体力;

		
		[WrappingFieldAttribute(下标 = 36, 长度 = 4)]
		public int 当前魔力;

		
		[WrappingFieldAttribute(下标 = 46, 长度 = 4)]
		public int 外观时间;

		
		[WrappingFieldAttribute(下标 = 50, 长度 = 1)]
		public byte 摆摊状态;

		
		[WrappingFieldAttribute(下标 = 51, 长度 = 0)]
		public string 摊位名字;

		
		[WrappingFieldAttribute(下标 = 84, 长度 = 45)]
		public string 对象名字;

		
		[WrappingFieldAttribute(下标 = 118, 长度 = 4)]
		public int 行会编号;
	}
}
