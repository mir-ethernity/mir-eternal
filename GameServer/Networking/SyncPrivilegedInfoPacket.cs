using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 322, 长度 = 0, 注释 = "SyncPrivilegedInfoPacket")]
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
