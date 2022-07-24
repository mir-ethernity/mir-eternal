using System;

namespace GameServer.Templates
{
	[Flags]
	public enum GameObjectState
	{
		Normal = 0,
		Stiff = 1,
		BusyGreen = 2,
		Poisoned = 4,
		Disabled = 8,
		Inmobilized = 16,
		Paralyzed = 32,
		Hegemony = 64,
		Invencible = 128,
		Invisibility = 256,
		StealthStatus = 512,
		Absence = 1024,
		Exposed = 2048
	}
}
