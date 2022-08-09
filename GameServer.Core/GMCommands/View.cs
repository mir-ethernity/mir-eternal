using System;
using System.Collections.Generic;

namespace GameServer
{
	
	public sealed class View : GMCommand
	{
		
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.前台立即执行;
			}
		}

		
		public override void Execute()
		{
			SEnvir.AddCommandLog("All available GM Commands are listed below:");
			foreach (KeyValuePair<string, string> keyValuePair in GMCommand.命令格式)
			{
				SEnvir.AddCommandLog(keyValuePair.Value);
			}
		}

		
		public View()
		{
			
			
		}
	}
}
