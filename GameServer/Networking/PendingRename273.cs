using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 190, 长度 = 3, 注释 = "更改PetMode")]
	public sealed class 更改PetMode : GamePacket
	{
		
		public 更改PetMode()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte PetMode;
	}
}
