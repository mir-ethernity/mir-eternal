using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 1004, 长度 = 849, 注释 = "同步角色列表")]
	public sealed class BackCharacterListPacket : GamePacket
	{
		
		public BackCharacterListPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 846)]
		public byte[] 列表描述;
	}
}
