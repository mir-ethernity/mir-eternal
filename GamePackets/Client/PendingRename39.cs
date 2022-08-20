using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 79, Length = 14, Description = "升级武器普通")]
	public sealed class 升级武器普通 : GamePacket
	{
		
		public 升级武器普通()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 6)]
		public byte[] 首饰组;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 6)]
		public byte[] 材料组;
	}
}
