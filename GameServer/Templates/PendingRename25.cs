using System;
using System.Collections.Generic;

namespace GameServer.Templates
{
	
	public sealed class C_04_计算目标诱惑 : 技能任务
	{
		
		public C_04_计算目标诱惑()
		{
			
			
		}

		
		public bool 检查铭文技能;

		
		public int 检查铭文编号;

		
		public ushort 瘫痪状态编号;

		
		public ushort 狂暴状态编号;

		
		public byte[] 基础诱惑数量;

		
		public byte 额外诱惑数量;

		
		public int 额外诱惑时长;

		
		public float 额外诱惑概率;

		
		public byte[] 初始宠物等级;

		
		public HashSet<string> 特定诱惑列表;

		
		public float 特定诱惑概率;
	}
}
