using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 332, 长度 = 3, 注释 = "SyncMarfaPrivilegesPacket")]
	public sealed class SyncMarfaPrivilegesPacket : GamePacket
	{
		
		public SyncMarfaPrivilegesPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 玛法特权;
	}
}
