using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 87, 长度 = 94, 注释 = "SyncMasterRewardPacket(师徒通用)")]
	public sealed class SyncMasterRewardPacket : GamePacket
	{
		
		public SyncMasterRewardPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 92)]
		public byte[] 字节数据;
	}
}
