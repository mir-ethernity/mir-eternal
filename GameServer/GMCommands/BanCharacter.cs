using System;
using GameServer.Data;
using GameServer.Networking;

namespace GameServer
{
	
	public sealed class BanCharacter : GMCommand
	{
		
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002865 File Offset: 0x00000A65
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
					客户网络 网络连接 = CharacterData.ActiveConnection;
					if (网络连接 != null)
					{
						网络连接.尝试断开连接(new Exception("角色被封禁, 强制下线"));
					}
					MainForm.添加命令日志(string.Format("<= @{0} command executed, blocking expiry time: {1}", base.GetType().Name, CharacterData.封禁日期));
					return;
				}
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, role does not exist");
		}

		
		public BanCharacter()
		{
			
			
		}

		
		[FieldAttribute(0, 排序 = 0)]
		public string CharName;

		
		[FieldAttribute(0, 排序 = 1)]
		public float 封禁天数;
	}
}
