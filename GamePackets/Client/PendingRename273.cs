using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 190, Length = 3, Description = "更改PetMode")]
	public sealed class 更改PetMode : GamePacket
	{
		
		public 更改PetMode()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte PetMode;
	}
}
