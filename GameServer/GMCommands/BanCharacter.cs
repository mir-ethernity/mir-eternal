using System;
using GameServer.Data;
using GameServer.Networking;

namespace GameServer
{
	
	public sealed class BanCharacter : GMCommand
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
			if (GameDataGateway.CharacterDataTable.Keyword.TryGetValue(this.CharName, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null)
				{
					CharacterData.封禁日期.V = DateTime.Now.AddDays((double)this.封禁天数);
					SConnection 网络连接 = CharacterData.ActiveConnection;
					if (网络连接 != null)
					{
						网络连接.CallExceptionEventHandler(new Exception("角色被封禁, 强制下线"));
					}
					MainForm.AddCommandLog(string.Format("<= @{0} command executed, blocking expiry time: {1}", base.GetType().Name, CharacterData.封禁日期));
					return;
				}
			}
			MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, role does not exist");
		}

		
		public BanCharacter()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public string CharName;

		
		[FieldAttribute(0, Position = 1)]
		public float 封禁天数;
	}
}
