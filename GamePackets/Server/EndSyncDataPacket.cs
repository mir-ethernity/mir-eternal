using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 33, 长度 = 6, 注释 = "同步GameData结束")]
	public sealed class EndSyncDataPacket : GamePacket
	{
		
		public EndSyncDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
