using System;
using System.Collections.Generic;
using GameServer.Data;

namespace GameServer
{
	// Token: 0x02000009 RID: 9
	public sealed class ViewData : GMCommand
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00007EA4 File Offset: 0x000060A4
		public override void Execute()
		{
			MainForm.添加命令日志("<= @" + base.GetType().Name + " The command has been executed and the database details are as follows:");
			foreach (KeyValuePair<Type, DataTableBase> keyValuePair in GameDataGateway.Data型表)
			{
				MainForm.添加命令日志(string.Format("{0}  Quantity: {1}", keyValuePair.Value.DataType.Name, keyValuePair.Value.DataSheet.Count));
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002858 File Offset: 0x00000A58
		public ViewData()
		{
			
			
		}
	}
}
