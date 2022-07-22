using System;
using System.Net;
using GameServer.Data;

namespace GameServer
{
	// Token: 0x0200000E RID: 14
	public sealed class BanIP : GMCommand
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00008070 File Offset: 0x00006270
		public override void 执行命令()
		{
			IPAddress ipaddress;
			if (IPAddress.TryParse(this.网络地址, out ipaddress))
			{
				SystemData.数据.BanIPCommand(this.网络地址, DateTime.Now.AddDays((double)this.封禁天数));
				MainForm.添加命令日志(string.Format("<= @{0} 命令已经执行, 封禁到期时间: {1}", base.GetType().Name, DateTime.Now.AddDays((double)this.封禁天数)));
				return;
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 地址格式错误");
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002858 File Offset: 0x00000A58
		public BanIP()
		{
			
			
		}

		// Token: 0x04000016 RID: 22
		[FieldAttribute(0, 排序 = 0)]
		public string 网络地址;

		// Token: 0x04000017 RID: 23
		[FieldAttribute(0, 排序 = 1)]
		public float 封禁天数;
	}
}
