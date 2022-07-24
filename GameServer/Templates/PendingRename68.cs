using System;

namespace GameServer.Templates
{
	
	[Flags]
	public enum 指定目标类型
	{
		
		无 = 0,
		
		低级目标 = 1,
		
		带盾法师 = 2,
		
		低级怪物 = 4,
		
		低血怪物 = 8,
		
		Normal = 16,
		
		所有怪物 = 32,
		
		Undead = 64,
		
		ZergCreature = 128,
		
		WomaMonster = 256,
		
		PigMonster = 512,
		
		ZumaMonster = 1024,
		
		精英怪物 = 2048,
		
		所有宠物 = 4096,
		
		背刺目标 = 8192,
		
		DragonMonster = 16384,
		
		所有玩家 = 32768
	}
}
