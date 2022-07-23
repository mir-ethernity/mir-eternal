using System;
using GameServer.Data;

namespace GameServer
{
	
	public sealed class UnblockAccount : GMCommand
	{
		
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00002865 File Offset: 0x00000A65
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
			if (GameDataGateway.AccountData表.Keyword.TryGetValue(this.账号名字, out GameData))
			{
				AccountData AccountData = GameData as AccountData;
				if (AccountData != null)
				{
					AccountData.封禁日期.V = default(DateTime);
					MainForm.添加命令日志(string.Format("<= @{0} The order has been executed, and the blocking time has expired: {1}", base.GetType().Name, AccountData.封禁日期));
					return;
				}
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, account does not exist");
		}

		
		public UnblockAccount()
		{
			
			
		}

		
		[FieldAttribute(0, 排序 = 0)]
		public string 账号名字;
	}
}
