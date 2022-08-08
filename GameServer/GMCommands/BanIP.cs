using System;
using System.Net;
using GameServer.Data;

namespace GameServer
{
	
	public sealed class BanIP : GMCommand
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
			IPAddress ipaddress;
			if (IPAddress.TryParse(this.NetAddress, out ipaddress))
			{
				SystemData.Data.BanIPCommand(this.NetAddress, DateTime.Now.AddDays((double)this.封禁天数));
				MainForm.AddCommandLog(string.Format("<= @{0} command executed, blocking expiry time: {1}", base.GetType().Name, DateTime.Now.AddDays((double)this.封禁天数)));
				return;
			}
			MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, address format error");
		}

		
		public BanIP()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public string NetAddress;

		
		[FieldAttribute(0, Position = 1)]
		public float 封禁天数;
	}
}
