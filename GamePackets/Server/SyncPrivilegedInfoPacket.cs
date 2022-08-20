using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 322, Length = 0, Description = "SyncPrivilegedInfoPacket")]
	public sealed class SyncPrivilegedInfoPacket : GamePacket
	{
		
		public SyncPrivilegedInfoPacket()
		{
			
			this.字节数组 = new byte[]
			{
				2
			};
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数组;
	}
}
