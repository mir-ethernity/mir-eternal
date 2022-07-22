using System;

namespace GameServer.Networking
{
	// Token: 0x020001BC RID: 444
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 322, 长度 = 0, 注释 = "SyncPrivilegedInfoPacket")]
	public sealed class SyncPrivilegedInfoPacket : GamePacket
	{
		// Token: 0x060002A5 RID: 677 RVA: 0x0000354C File Offset: 0x0000174C
		public SyncPrivilegedInfoPacket()
		{
			
			this.字节数组 = new byte[]
			{
				2
			};
			
		}

		// Token: 0x040006E8 RID: 1768
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节数组;
	}
}
