using System;
using GameServer.Data;
using GameServer.Networking;

namespace GameServer
{
	
	public sealed class BanAccount : GMCommand
	{
		
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002865 File Offset: 0x00000A65
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
					AccountData.封禁日期.V = DateTime.Now.AddDays((double)this.封禁天数);
					SConnection 网络连接 = AccountData.网络连接;
					if (网络连接 != null)
					{
						网络连接.CallExceptionEventHandler(new Exception("账号被封禁, 强制下线"));
					}
					MainForm.AddCommandLog(string.Format("<= @{0} command executed, blocking expiry time: {1}", base.GetType().Name, AccountData.封禁日期));
					return;
				}
			}
			MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, account does not exist");
		}

		
		public BanAccount()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public string Account;

		
		[FieldAttribute(0, Position = 1)]
		public float 封禁天数;
	}
}
