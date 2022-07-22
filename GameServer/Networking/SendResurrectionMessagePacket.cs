using System;

namespace GameServer.Networking
{
	// Token: 0x02000140 RID: 320
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 57, 长度 = 55, 注释 = "复活信息(无此封包不会弹出复活框)")]
	public sealed class SendResurrectionMessagePacket : GamePacket
	{
		// Token: 0x06000229 RID: 553 RVA: 0x000034A8 File Offset: 0x000016A8
		public SendResurrectionMessagePacket()
		{
			
			this.复活描述 = new byte[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				161,
				134,
				1,
				0,
				1,
				0,
				0,
				0,
				2,
				1,
				0,
				0,
				0,
				100,
				0,
				0,
				0,
				3,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			
		}

		// Token: 0x040005C1 RID: 1473
		public byte[] 复活描述;
	}
}
