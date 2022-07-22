using System;

namespace GameServer.Networking
{
	// Token: 0x0200011F RID: 287
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 1002, 长度 = 40, 注释 = "创建角色")]
	public sealed class 客户创建角色 : GamePacket
	{
		// Token: 0x06000208 RID: 520 RVA: 0x0000344A File Offset: 0x0000164A
		public 客户创建角色()
		{
			
			
		}

		// Token: 0x04000570 RID: 1392
		[WrappingFieldAttribute(下标 = 2, 长度 = 32)]
		public string 名字;

		// Token: 0x04000571 RID: 1393
		[WrappingFieldAttribute(下标 = 34, 长度 = 1)]
		public byte 性别;

		// Token: 0x04000572 RID: 1394
		[WrappingFieldAttribute(下标 = 35, 长度 = 1)]
		public byte 职业;

		// Token: 0x04000573 RID: 1395
		[WrappingFieldAttribute(下标 = 36, 长度 = 1)]
		public byte 发型;

		// Token: 0x04000574 RID: 1396
		[WrappingFieldAttribute(下标 = 37, 长度 = 1)]
		public byte 发色;

		// Token: 0x04000575 RID: 1397
		[WrappingFieldAttribute(下标 = 38, 长度 = 1)]
		public byte 脸型;
	}
}
