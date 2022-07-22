using System;

namespace GameServer.Networking
{
	// Token: 0x02000129 RID: 297
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 14, 长度 = 0, 注释 = "同步角色属性")]
	public sealed class 同步角色属性 : GamePacket
	{
		// Token: 0x06000212 RID: 530 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步角色属性()
		{
			
			
		}

		// Token: 0x04000590 RID: 1424
		[WrappingFieldAttribute(下标 = 6, 长度 = 0)]
		public byte[] 属性描述;
	}
}
