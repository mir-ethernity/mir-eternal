using System;
using GameServer.Data;
using GameServer.Networking;

namespace GameServer
{
	
	public sealed class AddIngots : GMCommand
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
					CharacterData.Ingots += this.Ingots;
					SConnection 网络连接 = CharacterData.ActiveConnection;
					if (网络连接 != null)
					{
						网络连接.SendPacket(new 同步Ingots
						{
							Ingots = CharacterData.Ingots
						});
					}
					MainForm.AddCommandLog(string.Format("<= @{0} command has been executed, current amount of treasure: {1}", base.GetType().Name, CharacterData.Ingots));
					return;
				}
			}
			MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, role does not exist");
		}

		
		public AddIngots()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public string CharName;

		
		[FieldAttribute(0, Position = 1)]
		public int Ingots;
	}
}
