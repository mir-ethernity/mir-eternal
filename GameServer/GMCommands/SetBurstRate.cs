using System;
using System.Windows.Forms;
using GameServer.Properties;

namespace GameServer
{
	// Token: 0x02000015 RID: 21
	public sealed class SetBurstRate : GMCommand
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002940 File Offset: 0x00000B40
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.只能后台执行;
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000084B8 File Offset: 0x000066B8
		public override void 执行命令()
		{
			if (this.额外爆率 < 0m)
			{
				MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 额外爆率太低");
				return;
			}
			if (this.额外爆率 >= 1m)
			{
				MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 额外爆率太高");
				return;
			}
			Settings.Default.怪物额外爆率 = (CustomClass.怪物额外爆率 = this.额外爆率);
			Settings.Default.Save();
			MainForm.Singleton.BeginInvoke(new MethodInvoker(delegate()
			{
				MainForm.Singleton.S_怪物额外爆率.Value = this.额外爆率;
			}));
			MainForm.添加命令日志(string.Format("<= @{0} 命令已经执行, 当前额外爆率:{1}", base.GetType().Name, CustomClass.怪物额外爆率));
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002858 File Offset: 0x00000A58
		public SetBurstRate()
		{
			
			
		}

		// Token: 0x04000021 RID: 33
		[FieldAttribute(0, 排序 = 0)]
		public decimal 额外爆率;
	}
}
