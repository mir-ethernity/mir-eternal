using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 87, 长度 = 94, 注释 = "SyncMasterRewardPacket(师徒通用)")]
	public sealed class SyncMasterRewardPacket : GamePacket
	{
		
		public SyncMasterRewardPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 92)]
		public byte[] 字节数据;
	}
}
