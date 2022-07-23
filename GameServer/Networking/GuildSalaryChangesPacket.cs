using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 619, 长度 = 6, 注释 = "GuildSalaryChangesPacket")]
	public sealed class GuildSalaryChangesPacket : GamePacket
	{
		
		public GuildSalaryChangesPacket()
		{
			
			
		}
	}
}
