using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameServer.Data;

namespace GameServer
{
	
	public sealed class CleanCharacters : GMCommand
	{
		
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002868 File Offset: 0x00000A68
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.只能空闲执行;
			}
		}

		
		public override void Execute()
		{
			if (MessageBox.Show(string.Format("We are about to permanently delete all CharacterData that are less than [{0}] level and have not logged in for [{1}] days \r\n\r\nThis operation is irreversible, please make a backup of your data \r\n\r\n sure you want to do this?", this.MinLevel, this.限制天数), "Dangerous operations", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
			{
				MainForm.添加命令日志("<= @" + base.GetType().Name + " Start the command, do not close the window during the execution");
				MainForm.Singleton.BeginInvoke(new MethodInvoker(delegate()
				{
					Control 下方控件页 = MainForm.Singleton.下方控件页;
					MainForm.Singleton.tabConfig.Enabled = false;
					下方控件页.Enabled = false;
				}));
				Task.Run(delegate()
				{
					GameDataGateway.CleanCharacters(this.MinLevel, this.限制天数);
					MainForm.Singleton.BeginInvoke(new MethodInvoker(delegate()
					{
						Control 下方控件页 = MainForm.Singleton.下方控件页;
						MainForm.Singleton.tabConfig.Enabled = true;
						下方控件页.Enabled = true;
					}));
				});
			}
		}

		
		public CleanCharacters()
		{
			
			
		}

		
		[FieldAttribute(0, 排序 = 0)]
		public int MinLevel;

		
		[FieldAttribute(0, 排序 = 1)]
		public int 限制天数;
	}
}
