using System;
using System.Windows.Forms;
using GameServer.Properties;

namespace GameServer
{
	
	public sealed class NoobSupport : GMCommand
	{
		
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002940 File Offset: 0x00000B40
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
			MainForm.添加命令日志(string.Format("<= @{0} command has been executed, current support level: {1}", base.GetType().Name, Config.NoobSupportCommand等级));
		}

		
		public NoobSupport()
		{
			
			
		}

		
		[FieldAttribute(0, 排序 = 0)]
		public byte 扶持等级;
	}
}
