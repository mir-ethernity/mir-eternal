using System;

namespace GameServer.Data
{
	
	public sealed class PetData : GameData
	{
		
		public PetData()
		{
			
			
		}

		
		public PetData(string 宠物名字, byte 当前等级, byte 等级上限, bool 绑定武器, DateTime 叛变时间)
		{
			
			
			this.宠物名字.V = 宠物名字;
			this.当前等级.V = 当前等级;
			this.等级上限.V = 等级上限;
			this.绑定武器.V = 绑定武器;
			this.叛变时间.V = 叛变时间;
			GameDataGateway.PetData表.AddData(this, true);
		}

		
		public readonly DataMonitor<string> 宠物名字;

		
		public readonly DataMonitor<int> 当前体力;

		
		public readonly DataMonitor<int> 当前经验;

		
		public readonly DataMonitor<byte> 当前等级;

		
		public readonly DataMonitor<byte> 等级上限;

		
		public readonly DataMonitor<bool> 绑定武器;

		
		public readonly DataMonitor<DateTime> 叛变时间;
	}
}
