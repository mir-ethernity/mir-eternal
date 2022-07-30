using System;

namespace GameServer.Templates
{
	
	[Flags]
	public enum SkillHitFeedback
	{
		
		正常 = 0,
		
		喷血 = 1,
		
		格挡 = 2,
		
		Miss = 4,
		
		招架 = 8,
		
		丢失 = 16,
		
		后仰 = 32,
		
		免疫 = 64,
		
		死亡 = 128,
		
		特效 = 256
	}
}
