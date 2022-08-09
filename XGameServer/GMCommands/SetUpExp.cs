using System;

namespace GameServer
{
	
	public sealed class SetUpExp : GMCommand
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
			if (this.经验倍率 <= 0m)
			{
				SEnvir.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, experience multiplier too low");
				return;
			}
			if (this.经验倍率 > 1000000m)
			{
				SEnvir.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, experience multiplier too high");
				return;
			}
			
			Config.ExpRate = 经验倍率;
			
			SEnvir.AddCommandLog(string.Format("<= @{0} The command has been executed, current experience multiplier: {1}", base.GetType().Name, Config.ExpRate));
		}

		
		[FieldAttribute(0, Position = 0)]
		public decimal 经验倍率;
	}
}
