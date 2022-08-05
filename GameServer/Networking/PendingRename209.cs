using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 583, 长度 = 27, 注释 = "创建行会应答")]
	public sealed class 创建行会应答 : GamePacket
	{
		
		public 创建行会应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 25)]
		public string GuildName;
	}
}
