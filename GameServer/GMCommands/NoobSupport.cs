using System;
using System.Windows.Forms;
using GameServer.Properties;

namespace GameServer
{
	// Token: 0x02000018 RID: 24
	public sealed class NoobSupport : GMCommand
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002940 File Offset: 0x00000B40
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.只能后台执行;
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000086F0 File Offset: 0x000068F0
		public override void 执行命令()
		{
			Settings.Default.NoobSupportCommand等级 = (CustomClass.NoobSupportCommand等级 = this.扶持等级);
			Settings.Default.Save();
			MainForm.Singleton.BeginInvoke(new MethodInvoker(delegate()
			{
				MainForm.Singleton.S_NoobSupportCommand等级.Value = this.扶持等级;
			}));
			MainForm.添加命令日志(string.Format("<= @{0} 命令已经执行, 当前扶持等级:{1}", base.GetType().Name, CustomClass.NoobSupportCommand等级));
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002858 File Offset: 0x00000A58
		public NoobSupport()
		{
			
			
		}

		// Token: 0x04000024 RID: 36
		[FieldAttribute(0, 排序 = 0)]
		public byte 扶持等级;
	}
}
