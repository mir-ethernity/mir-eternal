using System;

namespace GameServer.Templates
{
	[Flags]
	public enum GameObjectRelationship
	{
		ItSelf = 1,
		Friendly = 2,
		Hostility = 4
	}
}
