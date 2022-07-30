using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 187, 长度 = 13, 注释 = "SyncClientVariablesPacket")]
	public sealed class SyncSupplementaryVariablesPacket : GamePacket
	{
		
		public SyncSupplementaryVariablesPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 变量类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 2)]
		public ushort 变量索引;

		
		[WrappingFieldAttribute(SubScript = 5, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 9, Length = 4)]
		public int 变量内容;
	}
}
