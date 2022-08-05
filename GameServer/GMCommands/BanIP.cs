using System;
using System.Net;
using GameServer.Data;

namespace GameServer
{
	
	public sealed class BanIP : GMCommand
	{
		
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002865 File Offset: 0x00000A65
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
				MainForm.添加命令日志(string.Format("<= @{0} command executed, blocking expiry time: {1}", base.GetType().Name, DateTime.Now.AddDays((double)this.封禁天数)));
				return;
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, address format error");
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
