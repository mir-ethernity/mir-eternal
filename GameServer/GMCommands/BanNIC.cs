using System;
using System.Text.RegularExpressions;
using GameServer.Data;

namespace GameServer
{
	
	public sealed class BanNIC : GMCommand
	{
		
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		
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

		
		public BanNIC()
		{
			
			
		}

		
		[FieldAttribute(0, 排序 = 0)]
		public string 物理地址;

		
		[FieldAttribute(0, 排序 = 1)]
		public float 封禁天数;
	}
}
