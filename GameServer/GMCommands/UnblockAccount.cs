using System;
using GameServer.Data;

namespace GameServer
{
	// Token: 0x02000013 RID: 19
	public sealed class UnblockAccount : GMCommand
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000083B0 File Offset: 0x000065B0
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

		// Token: 0x06000039 RID: 57 RVA: 0x00002858 File Offset: 0x00000A58
		public UnblockAccount()
		{
			
			
		}

		// Token: 0x0400001F RID: 31
		[FieldAttribute(0, 排序 = 0)]
		public string 账号名字;
	}
}
