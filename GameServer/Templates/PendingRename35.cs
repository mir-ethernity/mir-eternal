using System;

namespace GameServer.Templates
{
	
	public class 怪物掉落
	{
		
		public override string ToString()
		{
			return string.Format("{0} - {1} - {2} - {3}/{4}", new object[]
			{
				this.怪物名字,
				this.物品名字,
				this.掉落概率,
				this.最小数量,
				this.最大数量
			});
		}

		
		public 怪物掉落()
		{
			
			
		}

		
		public string 物品名字;

		
		public string 怪物名字;

		
		public int 掉落概率;

		
		public int 最小数量;

		
		public int 最大数量;
	}
}
