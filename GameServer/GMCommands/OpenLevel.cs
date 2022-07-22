using System;
using System.Windows.Forms;
using GameServer.Properties;

namespace GameServer
{
	// Token: 0x02000017 RID: 23
	public sealed class OpenLevel : GMCommand
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00002940 File Offset: 0x00000B40
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.只能后台执行;
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00008658 File Offset: 0x00006858
		public override void 执行命令()
		{
			if (this.最高等级 <= CustomClass.游戏OpenLevelCommand)
			{
				MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 等级低于当前已OpenLevelCommand");
				return;
			}
			Settings.Default.游戏OpenLevelCommand = (CustomClass.游戏OpenLevelCommand = this.最高等级);
			Settings.Default.Save();
			MainForm.Singleton.BeginInvoke(new MethodInvoker(delegate()
			{
				MainForm.Singleton.S_游戏OpenLevelCommand.Value = this.最高等级;
			}));
			MainForm.添加命令日志(string.Format("<= @{0} 命令已经执行, 当前OpenLevelCommand:{1}", base.GetType().Name, CustomClass.游戏OpenLevelCommand));
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002858 File Offset: 0x00000A58
		public OpenLevel()
		{
			
			
		}

		// Token: 0x04000023 RID: 35
		[FieldAttribute(0, 排序 = 0)]
		public byte 最高等级;
	}
}
