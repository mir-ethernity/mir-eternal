using System;
using GameServer.Data;

namespace GameServer
{
	
	public sealed class RestoreCharacter : GMCommand
	{
		
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		
		public override void Execute()
		{
			GameData GameData;
			if (GameDataGateway.CharacterDataTable.Keyword.TryGetValue(this.CharacterName, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null)
				{
					if (CharacterData.DateDelete.V == default(DateTime) || !CharacterData.AccNumber.V.删除列表.Contains(CharacterData))
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, character not deleted");
						return;
					}
					if (CharacterData.AccNumber.V.角色列表.Count >= 4)
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, character list is full");
						return;
					}
					if (CharacterData.AccNumber.V.网络连接 != null)
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, account must be offline");
						return;
					}
					DataMonitor<DateTime> DateDelete = CharacterData.DateDelete;
					DataMonitor<DateTime> FreezeDate = CharacterData.FreezeDate;
					DateTime v = default(DateTime);
					FreezeDate.V = v;
					DateDelete.V = v;
					CharacterData.AccNumber.V.删除列表.Remove(CharacterData);
					CharacterData.AccNumber.V.角色列表.Add(CharacterData);
					MainForm.添加命令日志("<= @" + base.GetType().Name + " Command executed, character restored successfully");
					return;
				}
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, character does not exist");
		}

		
		public RestoreCharacter()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public string CharacterName;
	}
}
