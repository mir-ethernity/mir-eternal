using System;

namespace GameServer.Data
{
	
	public enum MemorandumType
	{
		
		创建公会 = 1,
		
		加入公会,
		
		离开公会,
		
		逐出公会,
		
		变更职位,
		
		建筑升级,
		
		会长传位 = 8,
		
		行会结盟,
		
		行会敌对,
		
		建造建筑 = 12,
		
		建筑被毁,
		
		建筑拆除,
		
		Boss刷新,
		
		战争获胜,
		
		战争失败,
		
		防守胜利,
		
		防守失败,
		
		取消结盟 = 21,
		
		取消敌对
	}
}
