using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 33, 长度 = 6, 注释 = "同步GameData结束")]
	public sealed class EndSyncDataPacket : GamePacket
	{
		
		public EndSyncDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;
	}
}
