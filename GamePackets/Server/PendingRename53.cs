using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 258, Length = 3, Description = "武器升级结果")]
	public sealed class 武器升级结果 : GamePacket
	{
		
		public 武器升级结果()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 升级结果;
	}
}
