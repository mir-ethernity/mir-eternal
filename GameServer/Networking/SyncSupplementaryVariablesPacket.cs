using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 187, 长度 = 13, 注释 = "SyncClientVariablesPacket")]
	public sealed class SyncSupplementaryVariablesPacket : GamePacket
	{
		
		public SyncSupplementaryVariablesPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 变量类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 2)]
		public ushort 变量索引;

		
		[WrappingFieldAttribute(下标 = 5, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 9, 长度 = 4)]
		public int 变量内容;
	}
}
