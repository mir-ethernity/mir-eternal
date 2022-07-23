using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 547, 长度 = 0, 注释 = "查询师门成员(师徒通用)")]
	public sealed class SyncGuildMemberPacket : GamePacket
	{
		
		public SyncGuildMemberPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节数据;
	}
}
