using System;

namespace GameServer.Data
{
	
	public sealed class PetData : GameData
	{
		
		public PetData()
		{
			
			
		}

		
		public PetData(string PetName, byte CurrentRank, byte GradeCap, bool BoundWeapons, DateTime MutinyTime)
		{
			
			
			this.PetName.V = PetName;
			this.CurrentRank.V = CurrentRank;
			this.GradeCap.V = GradeCap;
			this.BoundWeapons.V = BoundWeapons;
			this.MutinyTime.V = MutinyTime;
			GameDataGateway.PetDataTable.AddData(this, true);
		}

		
		public readonly DataMonitor<string> PetName;

		
		public readonly DataMonitor<int> CurrentStamina;

		
		public readonly DataMonitor<int> CurrentExp;

		
		public readonly DataMonitor<byte> CurrentRank;

		
		public readonly DataMonitor<byte> GradeCap;

		
		public readonly DataMonitor<bool> BoundWeapons;

		
		public readonly DataMonitor<DateTime> MutinyTime;
	}
}
