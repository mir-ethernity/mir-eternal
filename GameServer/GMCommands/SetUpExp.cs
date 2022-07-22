using System;
using System.Windows.Forms;
using GameServer.Properties;

namespace GameServer
{
	// Token: 0x02000016 RID: 22
	public sealed class SetUpExp : GMCommand
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002940 File Offset: 0x00000B40
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.只能后台执行;
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00008584 File Offset: 0x00006784
		public override void 执行命令()
		{
			if (this.经验倍率 <= 0m)
			{
				MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, experience multiplier too low");
				return;
			}
			if (this.经验倍率 > 1000000m)
			{
				MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, experience multiplier too high");
				return;
			}
			Settings.Default.怪物经验倍率 = (CustomClass.怪物经验倍率 = this.经验倍率);
			Settings.Default.Save();
			MainForm.Singleton.BeginInvoke(new MethodInvoker(delegate()
			{
				MainForm.Singleton.S_怪物经验倍率.Value = this.经验倍率;
			}));
			MainForm.添加命令日志(string.Format("<= @{0} The command has been executed, current experience multiplier: {1}", base.GetType().Name, CustomClass.怪物经验倍率));
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002858 File Offset: 0x00000A58
		public SetUpExp()
		{
			
			
		}

		// Token: 0x04000022 RID: 34
		[FieldAttribute(0, 排序 = 0)]
		public decimal 经验倍率;
	}
}
