using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 568, Length = 29, Description = "申请行会外交")]
	public sealed class 申请行会外交 : GamePacket
	{
		
		public 申请行会外交()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 外交类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 外交时间;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 25)]
		public string GuildName;
	}
}
