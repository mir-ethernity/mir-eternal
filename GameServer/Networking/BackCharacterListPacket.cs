using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1004, 长度 = 849, 注释 = "同步角色列表")]
	public sealed class BackCharacterListPacket : GamePacket
	{
		
		public BackCharacterListPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 846)]
		public byte[] 列表描述;
	}
}
