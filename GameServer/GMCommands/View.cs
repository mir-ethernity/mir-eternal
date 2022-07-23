using System;
using System.Collections.Generic;

namespace GameServer
{
	
	public sealed class View : GMCommand
	{
		
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00002855 File Offset: 0x00000A55
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.前台立即执行;
			}
		}

		
		public override void Execute()
		{
			MainForm.添加命令日志("All available GM Commands are listed below:");
			foreach (KeyValuePair<string, string> keyValuePair in GMCommand.命令格式)
			{
				MainForm.添加命令日志(keyValuePair.Value);
			}
		}

		
		public View()
		{
			
			
		}
	}
}
