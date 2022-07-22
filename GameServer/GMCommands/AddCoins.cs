using System;
using GameServer.Data;
using GameServer.Networking;

namespace GameServer
{
	// Token: 0x0200001D RID: 29
	public sealed class AddCoins : GMCommand
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00008D34 File Offset: 0x00006F34
		public override void 执行命令()
		{
			GameData GameData;
			if (GameDataGateway.CharacterDataTable.Keyword.TryGetValue(this.角色名字, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null)
				{
					CharacterData.金币数量 += this.金币数量;
					客户网络 网络连接 = CharacterData.网络连接;
					if (网络连接 != null)
					{
						网络连接.发送封包(new 货币数量变动
						{
							货币类型 = 1,
							货币数量 = CharacterData.金币数量
						});
					}
					MainForm.添加命令日志(string.Format("<= @{0} command has been executed, current coin count: {1}", base.GetType().Name, CharacterData.金币数量));
					return;
				}
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, role does not exist");
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002858 File Offset: 0x00000A58
		public AddCoins()
		{
			
			
		}

		// Token: 0x0400002C RID: 44
		[FieldAttribute(0, 排序 = 0)]
		public string 角色名字;

		// Token: 0x0400002D RID: 45
		[FieldAttribute(0, 排序 = 1)]
		public int 金币数量;
	}
}
