using System;
using GameServer.Data;

namespace GameServer
{
	
	public sealed class TransferCharacter : GMCommand
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
			if (GameDataGateway.CharacterDataTable.Keyword.TryGetValue(this.Character, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null)
				{
					if (!CharacterData.AccNumber.V.角色列表.Contains(CharacterData))
					{
						MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, character is already deleted");
						return;
					}
					if (CharacterData.封禁日期.V > DateTime.Now)
					{
						MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, character is on ban list");
						return;
					}
					if (CharacterData.AccNumber.V.封禁日期.V > DateTime.Now)
					{
						MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, the original account is on ban list");
						return;
					}
					GameData GameData2;
					if (GameDataGateway.AccountData表.Keyword.TryGetValue(this.NewAccount, out GameData2))
					{
						AccountData AccountData = GameData2 as AccountData;
						if (AccountData != null)
						{
							if (AccountData.封禁日期.V > DateTime.Now)
							{
								MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, transfer account in blocked status");
								return;
							}
							if (AccountData.角色列表.Count >= 4)
							{
								MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, the maximum number of characters transferred has been reached");
								return;
							}
							if (CharacterData.AccNumber.V.网络连接 == null && AccountData.网络连接 == null)
							{
								CharacterData.AccNumber.V.角色列表.Remove(CharacterData);
								CharacterData.AccNumber.V = AccountData;
								AccountData.角色列表.Add(CharacterData);
								MainForm.AddCommandLog(string.Format("<= @{0} The command has been executed, the character's current account:{1}", base.GetType().Name, CharacterData.AccNumber));
								return;
							}
							MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution fails, both accounts must be offline");
							return;
						}
					}
					MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, transfer account does not exist or never logged in");
					return;
				}
			}
			MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, character does not exist");
		}

		
		public TransferCharacter()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public string Character;

		
		[FieldAttribute(0, Position = 1)]
		public string NewAccount;
	}
}
