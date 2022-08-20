using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 87, Length = 94, Description = "SyncMasterRewardPacket(师徒通用)")]
	public sealed class SyncMasterRewardPacket : GamePacket
	{
		
		public SyncMasterRewardPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 92)]
		public byte[] 字节数据;
	}
}
