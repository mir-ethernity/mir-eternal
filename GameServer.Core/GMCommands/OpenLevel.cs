using System;

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
				SEnvir.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, the level is lower than the current OpenLevelCommand");
				return;
			}
			Config.MaxLevel = this.最高等级;
			SEnvir.AddCommandLog(string.Format("<= @{0} The command has been executed, the current OpenLevelCommand: {1}", base.GetType().Name, Config.MaxLevel));
		}

		
		public OpenLevel()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public byte 最高等级;
	}
}
