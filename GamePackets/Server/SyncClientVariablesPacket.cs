using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 186, Length = 514, Description = "SyncClientVariablesPacket(物品快捷键)")]
	public sealed class SyncClientVariablesPacket : GamePacket
	{
		
		public SyncClientVariablesPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 512)]
		public byte[] 字节数据;
	}
}
