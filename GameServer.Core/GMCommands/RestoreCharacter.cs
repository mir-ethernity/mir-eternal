using System;
using GameServer.Data;

namespace GameServer
{
	
	public sealed class RestoreCharacter : GMCommand
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
			GameData GameData;
			if (GameDataGateway.CharacterDataTable.Keyword.TryGetValue(this.CharacterName, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null)
				{
					if (CharacterData.DateDelete.V == default(DateTime) || !CharacterData.AccNumber.V.删除列表.Contains(CharacterData))
					{
						SEnvir.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, character not deleted");
						return;
					}
					if (CharacterData.AccNumber.V.角色列表.Count >= 4)
					{
						SEnvir.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, character list is full");
						return;
					}
					if (CharacterData.AccNumber.V.网络连接 != null)
					{
						SEnvir.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, account must be offline");
						return;
					}
					CharacterData.FreezeDate.V = default(DateTime);
					CharacterData.DateDelete.V = default(DateTime);
					CharacterData.AccNumber.V.删除列表.Remove(CharacterData);
					CharacterData.AccNumber.V.角色列表.Add(CharacterData);
					SEnvir.AddCommandLog("<= @" + base.GetType().Name + " Command executed, character restored successfully");
					return;
				}
			}
			SEnvir.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, character does not exist");
		}

		
		public RestoreCharacter()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public string CharacterName;
	}
}
