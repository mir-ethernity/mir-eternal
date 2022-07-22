using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameServer.Data;

namespace GameServer
{
	// Token: 0x0200000A RID: 10
	public sealed class SortDataCommand : GMCommand
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
		public override void 执行命令()
		{
			if (MessageBox.Show("SortDataCommand需要重新排序所有客户数据以便节省ID资源\r\n\r\n此操作不可逆, 请做好数据备份\r\n\r\n确定要执行吗?", "危险操作", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
			{
				MainForm.添加命令日志("<= @" + base.GetType().Name + " 开始执行命令, 过程中请勿关闭窗口");
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
		public SortDataCommand()
		{
			
			
		}
	}
}
