using System;
using System.Text;
using GameServer.Data;

namespace GameServer
{
	
	public sealed class RenameCharacter : GMCommand
	{
		
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002865 File Offset: 0x00000A65
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
			if (GameDataGateway.CharacterDataTable.Keyword.TryGetValue(this.CurrentCharacterName, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null)
				{
					if (CharacterData.ActiveConnection != null || CharacterData.所属账号.V.网络连接 != null)
					{
						MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, account must be taken offline");
						return;
					}
					if (Encoding.UTF8.GetBytes(this.NewCharacterName).Length > 24)
					{
						MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, character name too long");
						return;
					}
					if (GameDataGateway.CharacterDataTable.Keyword.ContainsKey(this.NewCharacterName))
					{
						MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, name already registered");
						return;
					}
					GameDataGateway.CharacterDataTable.Keyword.Remove(CharacterData.CharName.V);
					CharacterData.CharName.V = this.NewCharacterName;
					GameDataGateway.CharacterDataTable.Keyword.Add(CharacterData.CharName.V, CharacterData);
					MainForm.AddCommandLog(string.Format("<= @{0} command has been executed, with the current name of the character: {1}", base.GetType().Name, CharacterData));
					return;
				}
			}
			MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, role does not exist");
		}

		
		public RenameCharacter()
		{
		}

		
		[FieldAttribute(0, Position = 0)]
		public string CurrentCharacterName;

		
		[FieldAttribute(0, Position = 1)]
		public string NewCharacterName;
	}
}
