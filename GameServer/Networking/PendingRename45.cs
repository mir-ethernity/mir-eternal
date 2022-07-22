using System;

namespace GameServer.Networking
{
	// Token: 0x02000220 RID: 544
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 622, 长度 = 27, 注释 = "加入行会公告")]
	public sealed class 加入行会公告 : GamePacket
	{
		// Token: 0x06000309 RID: 777 RVA: 0x0000344A File Offset: 0x0000164A
		public 加入行会公告()
		{
			
			
		}

		// Token: 0x04000785 RID: 1925
		[WrappingFieldAttribute(下标 = 2, 长度 = 25)]
		public string 行会名字;
	}
}
