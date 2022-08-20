using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 563, Length = 0, Description = "更改行会宣言")]
	public sealed class 更改行会宣言 : GamePacket
	{
		
		public 更改行会宣言()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 0)]
		public byte[] 行会宣言;
	}
}
