using System;

namespace GameServer.Templates
{
	
	[Flags]
	public enum SpecifyTargetType
	{
		None = 0,
		LowLevelTarget = 1,
		ShieldMage = 2,
		LowLevelMonster = 4,
		LowBloodMonster = 8,
		Normal = 16,
		AllMonsters = 32,
		Undead = 64,
		ZergCreature = 128,
		WomaMonster = 256,
		PigMonster = 512,
		ZumaMonster = 1024,
		EliteMonsters = 2048,
		AllPets = 4096,
		Backstab = 8192,
		DragonMonster = 16384,
		AllPlayers = 32768
	}
}
