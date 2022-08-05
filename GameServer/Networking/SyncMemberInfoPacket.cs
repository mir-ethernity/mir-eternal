using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 646, 长度 = 11, 注释 = "SyncMemberInfoPacket")]
	public sealed class SyncMemberInfoPacket : GamePacket
	{
		
		public SyncMemberInfoPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 对象信息;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 1)]
		public byte 当前等级;
	}
}
