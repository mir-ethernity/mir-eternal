using System;
using System.Windows.Forms;
using GameServer.Properties;

namespace GameServer
{
	
	public sealed class OpenLevel : GMCommand
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
			if (this.最高等级 <= Config.MaxLevel)
			{
				MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, the level is lower than the current OpenLevelCommand");
				return;
			}
			Settings.Default.游戏OpenLevelCommand = (Config.MaxLevel = this.最高等级);
			Settings.Default.Save();
			MainForm.Singleton.BeginInvoke(new MethodInvoker(delegate()
			{
				MainForm.Singleton.S_游戏OpenLevelCommand.Value = this.最高等级;
			}));
			MainForm.AddCommandLog(string.Format("<= @{0} The command has been executed, the current OpenLevelCommand: {1}", base.GetType().Name, Config.MaxLevel));
		}

		
		public OpenLevel()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public byte 最高等级;
	}
}
