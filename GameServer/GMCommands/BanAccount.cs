using System;
using GameServer.Data;
using GameServer.Networking;

namespace GameServer
{
	// Token: 0x02000010 RID: 16
	public sealed class BanAccount : GMCommand
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x0000819C File Offset: 0x0000639C
		public override void 执行命令()
		{
			GameData GameData;
			if (GameDataGateway.AccountData表.Keyword.TryGetValue(this.账号名字, out GameData))
			{
				AccountData AccountData = GameData as AccountData;
				if (AccountData != null)
				{
					AccountData.封禁日期.V = DateTime.Now.AddDays((double)this.封禁天数);
					客户网络 网络连接 = AccountData.网络连接;
					if (网络连接 != null)
					{
						网络连接.尝试断开连接(new Exception("账号被封禁, 强制下线"));
					}
					MainForm.添加命令日志(string.Format("<= @{0} command executed, blocking expiry time: {1}", base.GetType().Name, AccountData.封禁日期));
					return;
				}
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, account does not exist");
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002858 File Offset: 0x00000A58
		public BanAccount()
		{
			
			
		}

		// Token: 0x0400001A RID: 26
		[FieldAttribute(0, 排序 = 0)]
		public string 账号名字;

		// Token: 0x0400001B RID: 27
		[FieldAttribute(0, 排序 = 1)]
		public float 封禁天数;
	}
}
