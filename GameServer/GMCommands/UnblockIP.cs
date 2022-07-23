using System;
using GameServer.Data;

namespace GameServer
{
	
	public sealed class UnblockIP : GMCommand
	{
		
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		
		public override void Execute()
		{
			if (SystemData.数据.网络封禁.ContainsKey(this.对应地址))
			{
				SystemData.数据.解封网络(this.对应地址);
				MainForm.添加命令日志("<= @" + base.GetType().Name + " The command has been executed, the address has been unblocked");
				return;
			}
			if (SystemData.数据.网卡封禁.ContainsKey(this.对应地址))
			{
				SystemData.数据.解封网卡(this.对应地址);
				MainForm.添加命令日志("<= @" + base.GetType().Name + " The command has been executed, the address has been unblocked");
				return;
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, the corresponding address is not blocked");
		}

		
		public UnblockIP()
		{
			
			
		}

		
		[FieldAttribute(0, 排序 = 0)]
		public string 对应地址;
	}
}
