using System;

namespace GameServer.Data
{
	// Token: 0x0200025A RID: 602
	public sealed class PetData : GameData
	{
		// Token: 0x0600047A RID: 1146 RVA: 0x0000429F File Offset: 0x0000249F
		public PetData()
		{
			
			
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00021A38 File Offset: 0x0001FC38
		public PetData(string 宠物名字, byte 当前等级, byte 等级上限, bool 绑定武器, DateTime 叛变时间)
		{
			
			
			this.宠物名字.V = 宠物名字;
			this.当前等级.V = 当前等级;
			this.等级上限.V = 等级上限;
			this.绑定武器.V = 绑定武器;
			this.叛变时间.V = 叛变时间;
			GameDataGateway.PetData表.AddData(this, true);
		}

		// Token: 0x04000805 RID: 2053
		public readonly DataMonitor<string> 宠物名字;

		// Token: 0x04000806 RID: 2054
		public readonly DataMonitor<int> 当前体力;

		// Token: 0x04000807 RID: 2055
		public readonly DataMonitor<int> 当前经验;

		// Token: 0x04000808 RID: 2056
		public readonly DataMonitor<byte> 当前等级;

		// Token: 0x04000809 RID: 2057
		public readonly DataMonitor<byte> 等级上限;

		// Token: 0x0400080A RID: 2058
		public readonly DataMonitor<bool> 绑定武器;

		// Token: 0x0400080B RID: 2059
		public readonly DataMonitor<DateTime> 叛变时间;
	}
}
