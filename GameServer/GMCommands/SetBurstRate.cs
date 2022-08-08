using System;
using System.Windows.Forms;
using GameServer.Properties;

namespace GameServer
{
	
	public sealed class SetBurstRate : GMCommand
	{
		
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
				MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, extra burst rate too low");
				return;
			}
			if (this.额外爆率 >= 1m)
			{
				MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, extra burst rate too high");
				return;
			}
			Settings.Default.ExtraDropRate = (Config.ExtraDropRate = this.额外爆率);
			Settings.Default.Save();
			MainForm.Singleton.BeginInvoke(new MethodInvoker(delegate()
			{
				MainForm.Singleton.S_怪物额外爆率.Value = this.额外爆率;
			}));
			MainForm.AddCommandLog(string.Format("<= @{0} The command has been executed, with the current additional burst rate: {1}", base.GetType().Name, Config.ExtraDropRate));
		}

		
		public SetBurstRate()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public decimal 额外爆率;
	}
}
