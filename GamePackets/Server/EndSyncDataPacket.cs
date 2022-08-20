using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 33, Length = 6, Description = "同步GameData结束")]
	public sealed class EndSyncDataPacket : GamePacket
	{
		
		public EndSyncDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
