using System;
using System.Collections.Generic;

namespace GameServer
{
	// Token: 0x02000008 RID: 8
	public sealed class ViewCommand : GMCommand
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00002855 File Offset: 0x00000A55
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.前台立即执行;
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00007E40 File Offset: 0x00006040
		public override void Execute()
		{
			MainForm.添加命令日志("All available GM Commands are listed below:");
			foreach (KeyValuePair<string, string> keyValuePair in GMCommand.命令格式)
			{
				MainForm.添加命令日志(keyValuePair.Value);
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002858 File Offset: 0x00000A58
		public ViewCommand()
		{
			
			
		}
	}
}
