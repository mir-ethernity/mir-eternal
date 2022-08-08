using System;
using System.Text.RegularExpressions;
using GameServer.Data;

namespace GameServer
{
	
	public sealed class BanNIC : GMCommand
	{
		
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		
		public override void Execute()
		{
			if (Regex.IsMatch(this.MacAddress, "^([0-9a-fA-F]{2}(?:[:-]?[0-9a-fA-F]{2}){5})$"))
			{
				SystemData.Data.BanNICCommand(this.MacAddress, DateTime.Now.AddDays((double)this.封禁天数));
				MainForm.AddCommandLog(string.Format("<= @{0} command executed, blocking expiry time: {1}", base.GetType().Name, DateTime.Now.AddDays((double)this.封禁天数)));
				return;
			}
			MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, address format error");
		}

		
		public BanNIC()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public string MacAddress;

		
		[FieldAttribute(0, Position = 1)]
		public float 封禁天数;
	}
}
