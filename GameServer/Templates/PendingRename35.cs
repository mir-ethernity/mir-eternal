using System;

namespace GameServer.Templates
{
	
	public class 怪物掉落
	{
		
		public override string ToString()
		{
			return string.Format("{0} - {1} - {2} - {3}/{4}", new object[]
			{
				this.MonsterName,
				this.Name,
				this.掉落概率,
				this.最小数量,
				this.最大数量
			});
		}

		
		public 怪物掉落()
		{
			
			
		}

		
		public string Name;

		
		public string MonsterName;

		
		public int 掉落概率;

		
		public int 最小数量;

		
		public int 最大数量;
	}
}
