using System;
using GameServer.Data;

namespace GameServer
{
	
	public sealed class UnblockAccount : GMCommand
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
			GameData GameData;
			if (GameDataGateway.AccountData表.Keyword.TryGetValue(this.Account, out GameData))
			{
				AccountData AccountData = GameData as AccountData;
				if (AccountData != null)
				{
					AccountData.封禁日期.V = default(DateTime);
					MainForm.AddCommandLog(string.Format("<= @{0} The order has been executed, and the blocking time has expired: {1}", base.GetType().Name, AccountData.封禁日期));
					return;
				}
			}
			MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, account does not exist");
		}

		
		public UnblockAccount()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public string Account;
	}
}
