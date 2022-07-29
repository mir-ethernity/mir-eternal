using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 515, 长度 = 10, 注释 = "RequestCharacterDataPacket")]
	public sealed class RequestCharacterDataPacket : GamePacket
	{
		
		public RequestCharacterDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
