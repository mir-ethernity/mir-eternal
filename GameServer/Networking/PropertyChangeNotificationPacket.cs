using System;

namespace GameServer.Networking
{
	// Token: 0x0200020E RID: 526
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 604, 长度 = 10, 注释 = "PropertyChangeNotificationPacket")]
	public sealed class PropertyChangeNotificationPacket : GamePacket
	{
		// Token: 0x060002F7 RID: 759 RVA: 0x0000344A File Offset: 0x0000164A
		public PropertyChangeNotificationPacket()
		{
			
			
		}

		// Token: 0x04000770 RID: 1904
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 属性类型;

		// Token: 0x04000771 RID: 1905
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 属性数值;
	}
}
