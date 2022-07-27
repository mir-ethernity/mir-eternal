using System;
using System.Windows.Forms;
using GameServer.Properties;

namespace GameServer
{
	
	public sealed class SetBurstRate : GMCommand
	{
		
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002940 File Offset: 0x00000B40
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.只能后台执行;
			}
		}

		
		public override void Execute()
		{
			if (this.额外爆率 < 0m)
			{
				MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, extra burst rate too low");
				return;
			}
			if (this.额外爆率 >= 1m)
			{
				MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, extra burst rate too high");
				return;
			}
			Settings.Default.怪物额外爆率 = (Config.怪物额外爆率 = this.额外爆率);
			Settings.Default.Save();
			MainForm.Singleton.BeginInvoke(new MethodInvoker(delegate()
			{
				MainForm.Singleton.S_怪物额外爆率.Value = this.额外爆率;
			}));
			MainForm.添加命令日志(string.Format("<= @{0} The command has been executed, with the current additional burst rate: {1}", base.GetType().Name, Config.怪物额外爆率));
		}

		
		public SetBurstRate()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public decimal 额外爆率;
	}
}
