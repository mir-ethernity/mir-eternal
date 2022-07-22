using System;
using GameServer.Data;

namespace GameServer
{
	// Token: 0x02000014 RID: 20
	public sealed class UnblockCharacter : GMCommand
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00008434 File Offset: 0x00006634
		public override void 执行命令()
		{
			GameData GameData;
			if (GameDataGateway.CharacterDataTable.Keyword.TryGetValue(this.角色名字, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null)
				{
					CharacterData.封禁日期.V = default(DateTime);
					MainForm.添加命令日志(string.Format("<= @{0} 命令已经执行, 封禁到期时间: {1}", base.GetType().Name, CharacterData.封禁日期));
					return;
				}
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 角色不存在");
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002858 File Offset: 0x00000A58
		public UnblockCharacter()
		{
			
			
		}

		// Token: 0x04000020 RID: 32
		[FieldAttribute(0, 排序 = 0)]
		public string 角色名字;
	}
}
