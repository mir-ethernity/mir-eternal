using System;
using System.Collections.Generic;
using GameServer.Data;

namespace GameServer
{
	
	public sealed class ViewData : GMCommand
	{
		
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		
		public override void Execute()
		{
			SEnvir.AddCommandLog("<= @" + base.GetType().Name + " The command has been executed and the database details are as follows:");
			foreach (KeyValuePair<Type, DataTableBase> keyValuePair in GameDataGateway.Data型表)
			{
				SEnvir.AddCommandLog(string.Format("{0}  Quantity: {1}", keyValuePair.Value.DataType.Name, keyValuePair.Value.DataSheet.Count));
			}
		}

		
		public ViewData()
		{
			
			
		}
	}
}
