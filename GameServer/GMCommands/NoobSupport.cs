using System;
using System.Windows.Forms;
using GameServer.Properties;

namespace GameServer
{
	
	public sealed class NoobSupport : GMCommand
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
			Settings.Default.NoobSupportCommand等级 = (Config.NoobSupportCommand等级 = this.扶持等级);
			Settings.Default.Save();
			MainForm.Singleton.BeginInvoke(new MethodInvoker(delegate()
			{
				MainForm.Singleton.S_NoobSupportCommand等级.Value = this.扶持等级;
			}));
			MainForm.AddCommandLog(string.Format("<= @{0} command has been executed, current support level: {1}", base.GetType().Name, Config.NoobSupportCommand等级));
		}

		
		public NoobSupport()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public byte 扶持等级;
	}
}
