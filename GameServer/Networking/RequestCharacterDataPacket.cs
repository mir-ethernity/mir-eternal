using System;

namespace GameServer.Networking
{
	// Token: 0x020000D3 RID: 211
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 515, 长度 = 10, 注释 = "RequestCharacterDataPacket")]
	public sealed class RequestCharacterDataPacket : GamePacket
	{
		// Token: 0x060001BA RID: 442 RVA: 0x0000344A File Offset: 0x0000164A
		public RequestCharacterDataPacket()
		{
			
			
		}

		// Token: 0x04000521 RID: 1313
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;
	}
}
