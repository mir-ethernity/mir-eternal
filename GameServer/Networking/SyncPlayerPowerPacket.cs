using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 86, 长度 = 10, 注释 = "同步战力")]
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
