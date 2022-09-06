using System;

namespace GameServer
{
	
	public enum GameObjectType  //游戏对象类型
	{
		Player = 1,   //玩家
		Pet = 2,   //宠物
		Monster = 4,  //怪物
		NPC = 8,  
		Item = 16,  //物品
		Trap = 32,  //陷阱
		Chest = 64,  //宝盒
	}
}
