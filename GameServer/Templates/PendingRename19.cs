using System;

namespace GameServer.Templates
{
	
	public sealed class B_03_前摇结束通知 : 技能任务
	{
		
		public B_03_前摇结束通知()
		{
			
			
		}

		
		public bool 发送结束通知;

		
		public bool 计算攻速缩减;

		
		public int 角色硬直时间;

		
		public int 禁止行走时间;

		
		public int 禁止奔跑时间;

		
		public bool 解除技能陷阱;
	}
}
