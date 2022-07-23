using System;
using System.Text.RegularExpressions;
using GameServer.Data;

namespace GameServer
{
	// Token: 0x0200000F RID: 15
	public sealed class BanNIC : GMCommand
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00008104 File Offset: 0x00006304
		public override void Execute()
		{
			if (Regex.IsMatch(this.物理地址, "^([0-9a-fA-F]{2}(?:[:-]?[0-9a-fA-F]{2}){5})$"))
			{
				SystemData.数据.BanNICCommand(this.物理地址, DateTime.Now.AddDays((double)this.封禁天数));
				MainForm.添加命令日志(string.Format("<= @{0} command executed, blocking expiry time: {1}", base.GetType().Name, DateTime.Now.AddDays((double)this.封禁天数)));
				return;
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, address format error");
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002858 File Offset: 0x00000A58
		public BanNIC()
		{
			
			
		}

		// Token: 0x04000018 RID: 24
		[FieldAttribute(0, 排序 = 0)]
		public string 物理地址;

		// Token: 0x04000019 RID: 25
		[FieldAttribute(0, 排序 = 1)]
		public float 封禁天数;
	}
}
