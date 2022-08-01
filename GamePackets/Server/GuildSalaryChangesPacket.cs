using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 619, 长度 = 6, 注释 = "GuildSalaryChangesPacket")]
	public sealed class GuildSalaryChangesPacket : GamePacket
	{
		
		public GuildSalaryChangesPacket()
		{
			
			
		}
	}
}
