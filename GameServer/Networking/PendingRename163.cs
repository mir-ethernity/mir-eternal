using System;

namespace GameServer.Networking
{
	// Token: 0x02000154 RID: 340
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 81, 长度 = 13, 注释 = "发送PK的结果")]
	public sealed class 同步对战结果 : GamePacket
	{
		// Token: 0x0600023D RID: 573 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步对战结果()
		{
			
			
		}

		// Token: 0x04000603 RID: 1539
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 击杀方式;

		// Token: 0x04000604 RID: 1540
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 胜方编号;

		// Token: 0x04000605 RID: 1541
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public int 败方编号;

		// Token: 0x04000606 RID: 1542
		[WrappingFieldAttribute(下标 = 11, 长度 = 2)]
		public ushort PK值惩罚;
	}
}
