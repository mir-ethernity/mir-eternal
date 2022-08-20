using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 584, Length = 28, Description = "申请行会Hostility")]
	public sealed class 申请行会Hostility : GamePacket
	{
		
		public 申请行会Hostility()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte Hostility时间;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 25)]
		public string GuildName;
	}
}
