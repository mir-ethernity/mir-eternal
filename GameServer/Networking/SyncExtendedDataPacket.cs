using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 66, 长度 = 58, 注释 = "同步Npcc数据扩展(宠物)")]
	public sealed class SyncExtendedDataPacket : GamePacket
	{
		
		public SyncExtendedDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 模板编号;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 1)]
		public byte 对象质量;

		
		[WrappingFieldAttribute(下标 = 11, 长度 = 1)]
		public byte 对象等级;

		
		[WrappingFieldAttribute(下标 = 12, 长度 = 4)]
		public int 最大体力;

		
		[WrappingFieldAttribute(下标 = 16, 长度 = 1)]
		public byte 对象类型;

		
		[WrappingFieldAttribute(下标 = 17, 长度 = 1)]
		public byte 当前等级;

		
		[WrappingFieldAttribute(下标 = 18, 长度 = 4)]
		public int 主人编号;

		
		[WrappingFieldAttribute(下标 = 22, 长度 = 36)]
		public string 主人名字;
	}
}
