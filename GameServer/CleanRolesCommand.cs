using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameServer.Data;

namespace GameServer
{
	// Token: 0x0200000C RID: 12
	public sealed class CleanRolesCommand : GMCommand
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002868 File Offset: 0x00000A68
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.只能空闲执行;
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00007FD8 File Offset: 0x000061D8
		public override void 执行命令()
		{
			if (MessageBox.Show(string.Format("即将永久删除所有等级小于[{0}]级且[{1}]天内未登录的CharacterData\r\n\r\n此操作不可逆, 请做好数据备份\r\n\r\n确定要执行吗?", this.限制等级, this.限制天数), "危险操作", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
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
					GameDataGateway.CleanRolesCommand(this.限制等级, this.限制天数);
					MainForm.Singleton.BeginInvoke(new MethodInvoker(delegate()
					{
						Control 下方控件页 = MainForm.Singleton.下方控件页;
						MainForm.Singleton.tabConfig.Enabled = true;
						下方控件页.Enabled = true;
					}));
				});
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002858 File Offset: 0x00000A58
		public CleanRolesCommand()
		{
			
			
		}

		// Token: 0x04000011 RID: 17
		[FieldAttribute(0, 排序 = 0)]
		public int 限制等级;

		// Token: 0x04000012 RID: 18
		[FieldAttribute(0, 排序 = 1)]
		public int 限制天数;
	}
}
