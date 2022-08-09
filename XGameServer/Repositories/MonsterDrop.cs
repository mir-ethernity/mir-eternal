using System;

namespace GameServer.Templates
{
	public class MonsterDrop
	{
		public string Name;
		public string MonsterName;
		public int Probability;
		public int MinAmount;
		public int MaxAmount;

		public override string ToString()
		{
			return string.Format("{0} - {1} - {2} - {3}/{4}", new object[]
			{
				this.MonsterName,
				this.Name,
				this.Probability,
				this.MinAmount,
				this.MaxAmount
			});
		}
	}
}
