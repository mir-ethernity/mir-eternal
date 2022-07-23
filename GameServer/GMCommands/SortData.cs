using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameServer.Data;

namespace GameServer
{
	// Token: 0x0200000A RID: 10
	public sealed class SortData : GMCommand
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002868 File Offset: 0x00000A68
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.只能空闲执行;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00007F48 File Offset: 0x00006148
		public override void Execute()
		{
			if (MessageBox.Show("SortDataCommand needs to re-sort all customer data to save ID resources \r\n\r\nThis operation is irreversible, please make a data backup \r\n\r\n sure you want to do it?", "Dangerous operations", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
			{
				MainForm.添加命令日志("<= @" + base.GetType().Name + " Start the command, do not close the window during the execution");
				MainForm.Singleton.BeginInvoke(new MethodInvoker(delegate()
				{
					Control 下方控件页 = MainForm.Singleton.下方控件页;
					MainForm.Singleton.tabConfig.Enabled = false;
					下方控件页.Enabled = false;
				}));
				Task.Run(delegate()
				{
					GameDataGateway.SortDataCommand(true);
					MainForm.Singleton.BeginInvoke(new MethodInvoker(delegate()
					{
						Control 下方控件页 = MainForm.Singleton.下方控件页;
						MainForm.Singleton.tabConfig.Enabled = true;
						下方控件页.Enabled = true;
					}));
				});
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002858 File Offset: 0x00000A58
		public SortData()
		{
			
			
		}
	}
}
