using System;

namespace GameServer.Networking
{
	// Token: 0x020000A6 RID: 166
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 134, 长度 = 3, 注释 = "ToggleMapRoutePacket")]
	public sealed class ToggleMapRoutePacket : GamePacket
	{
		// Token: 0x0600018D RID: 397 RVA: 0x0000344A File Offset: 0x0000164A
		public ToggleMapRoutePacket()
		{
			
			
		}

		// Token: 0x040004F8 RID: 1272
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 地图路线;
	}
}
