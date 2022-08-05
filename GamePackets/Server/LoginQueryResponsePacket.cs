using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 1010, 长度 = 6, 注释 = "Synchronous gateway ping", NoDebug = true)]
	public sealed class LoginQueryResponsePacket : GamePacket
	{
		
		public LoginQueryResponsePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 当前时间;
	}
}
