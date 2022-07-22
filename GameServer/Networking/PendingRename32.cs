using System;

namespace GameServer.Networking
{
	// Token: 0x020000A4 RID: 164
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 119, 长度 = 6, 注释 = "提交选项继续NPC对话")]
	public sealed class 继续Npcc对话 : GamePacket
	{
		// Token: 0x0600018B RID: 395 RVA: 0x0000344A File Offset: 0x0000164A
		public 继续Npcc对话()
		{
			
			
		}

		// Token: 0x040004F6 RID: 1270
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对话编号;
	}
}
