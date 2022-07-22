using System;
using System.Collections.Generic;

namespace GameServer.Templates
{
	// Token: 0x0200029B RID: 667
	public sealed class C_04_计算目标诱惑 : 技能任务
	{
		// Token: 0x060006AC RID: 1708 RVA: 0x00005F01 File Offset: 0x00004101
		public C_04_计算目标诱惑()
		{
			
			
		}

		// Token: 0x04000A51 RID: 2641
		public bool 检查铭文技能;

		// Token: 0x04000A52 RID: 2642
		public int 检查铭文编号;

		// Token: 0x04000A53 RID: 2643
		public ushort 瘫痪状态编号;

		// Token: 0x04000A54 RID: 2644
		public ushort 狂暴状态编号;

		// Token: 0x04000A55 RID: 2645
		public byte[] 基础诱惑数量;

		// Token: 0x04000A56 RID: 2646
		public byte 额外诱惑数量;

		// Token: 0x04000A57 RID: 2647
		public int 额外诱惑时长;

		// Token: 0x04000A58 RID: 2648
		public float 额外诱惑概率;

		// Token: 0x04000A59 RID: 2649
		public byte[] 初始宠物等级;

		// Token: 0x04000A5A RID: 2650
		public HashSet<string> 特定诱惑列表;

		// Token: 0x04000A5B RID: 2651
		public float 特定诱惑概率;
	}
}
