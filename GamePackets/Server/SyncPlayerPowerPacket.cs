using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 86, Length = 10, Description = "同步战力")]
	public sealed class SyncPlayerPowerPacket : GamePacket
	{
		
		public SyncPlayerPowerPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 角色战力;
	}
}
