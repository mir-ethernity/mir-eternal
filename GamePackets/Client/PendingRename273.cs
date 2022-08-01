using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 190, 长度 = 3, 注释 = "更改PetMode")]
	public sealed class 更改PetMode : GamePacket
	{
		
		public 更改PetMode()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte PetMode;
	}
}
