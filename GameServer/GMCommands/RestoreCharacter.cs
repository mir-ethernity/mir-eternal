using System;
using GameServer.Data;

namespace GameServer
{
	// Token: 0x02000019 RID: 25
	public sealed class RestoreCharacter : GMCommand
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00008758 File Offset: 0x00006958
		public override void 执行命令()
		{
			GameData GameData;
			if (GameDataGateway.CharacterDataTable.Keyword.TryGetValue(this.CharacterName, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null)
				{
					if (CharacterData.删除日期.V == default(DateTime) || !CharacterData.所属账号.V.删除列表.Contains(CharacterData))
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, character not deleted");
						return;
					}
					if (CharacterData.所属账号.V.角色列表.Count >= 4)
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, character list is full");
						return;
					}
					if (CharacterData.所属账号.V.网络连接 != null)
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, account must be offline");
						return;
					}
					DataMonitor<DateTime> 删除日期 = CharacterData.删除日期;
					DataMonitor<DateTime> 冻结日期 = CharacterData.冻结日期;
					DateTime v = default(DateTime);
					冻结日期.V = v;
					删除日期.V = v;
					CharacterData.所属账号.V.删除列表.Remove(CharacterData);
					CharacterData.所属账号.V.角色列表.Add(CharacterData);
					MainForm.添加命令日志("<= @" + base.GetType().Name + " Command executed, character restored successfully");
					return;
				}
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, character does not exist");
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002858 File Offset: 0x00000A58
		public RestoreCharacter()
		{
			
			
		}

		// Token: 0x04000025 RID: 37
		[FieldAttribute(0, 排序 = 0)]
		public string CharacterName;
	}
}
