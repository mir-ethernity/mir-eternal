using System;
using GameServer.Data;

namespace GameServer
{
	// Token: 0x02000012 RID: 18
	public sealed class UnblockIP : GMCommand
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000082F4 File Offset: 0x000064F4
		public override void 执行命令()
		{
			if (SystemData.数据.网络封禁.ContainsKey(this.对应地址))
			{
				SystemData.数据.解封网络(this.对应地址);
				MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令已经执行, 地址已经解除封禁");
				return;
			}
			if (SystemData.数据.网卡封禁.ContainsKey(this.对应地址))
			{
				SystemData.数据.解封网卡(this.对应地址);
				MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令已经执行, 地址已经解除封禁");
				return;
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 对应地址未处于封禁状态");
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002858 File Offset: 0x00000A58
		public UnblockIP()
		{
			
			
		}

		// Token: 0x0400001E RID: 30
		[FieldAttribute(0, 排序 = 0)]
		public string 对应地址;
	}
}
