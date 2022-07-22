using System;

namespace GameServer.Networking
{
	// Token: 0x02000130 RID: 304
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 25, 长度 = 8, 注释 = "SyncTeacherInfoPacket")]
	public sealed class SyncTeacherInfoPacket : GamePacket
	{
		// Token: 0x06000219 RID: 537 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncTeacherInfoPacket()
		{
			
			
		}

		// Token: 0x04000599 RID: 1433
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 限制时间;

		// Token: 0x0400059A RID: 1434
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 师门参数;

		// Token: 0x0400059B RID: 1435
		[WrappingFieldAttribute(下标 = 7, 长度 = 1)]
		public byte 师门推送;
	}
}
