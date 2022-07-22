using System;

namespace GameServer.Networking
{
	// Token: 0x020000C3 RID: 195
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 190, 长度 = 3, 注释 = "更改PetMode")]
	public sealed class 更改PetMode : GamePacket
	{
		// Token: 0x060001AA RID: 426 RVA: 0x0000344A File Offset: 0x0000164A
		public 更改PetMode()
		{
			
			
		}

		// Token: 0x04000515 RID: 1301
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte PetMode;
	}
}
