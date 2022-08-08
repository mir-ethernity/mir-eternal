using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameServer.Data;

namespace GameServer
{
	
	public sealed class SortData : GMCommand
	{
		
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.只能空闲执行;
			}
		}

		
		public override void Execute()
		{
			if (MessageBox.Show("SortDataCommand needs to re-sort all customer data to save ID resources \r\n\r\nThis operation is irreversible, please make a data backup \r\n\r\n sure you want to do it?", "Dangerous operations", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
			{
				MainForm.AddCommandLog("<= @" + base.GetType().Name + " Start the command, do not close the window during the execution");
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

		
		public SortData()
		{
			
			
		}
	}
}
