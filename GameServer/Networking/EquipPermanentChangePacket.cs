using System;

namespace GameServer.Networking
{
	// Token: 0x02000185 RID: 389
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 143, 长度 = 8, 注释 = "EquipPermanentChangePacket")]
	public sealed class EquipPermanentChangePacket : GamePacket
	{
		// Token: 0x0600026E RID: 622 RVA: 0x0000344A File Offset: 0x0000164A
		public EquipPermanentChangePacket()
		{
			
			
		}

		// Token: 0x04000696 RID: 1686
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备容器;

		// Token: 0x04000697 RID: 1687
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;

		// Token: 0x04000698 RID: 1688
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 当前持久;
	}
}
