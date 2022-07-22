using System;
using GameServer.Data;
using GameServer.Networking;

namespace GameServer
{
	// Token: 0x02000020 RID: 32
	public sealed class DeductCoins : GMCommand
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00009090 File Offset: 0x00007290
		public override void 执行命令()
		{
			GameData GameData;
			if (GameDataGateway.CharacterDataTable.Keyword.TryGetValue(this.角色名字, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null)
				{
					CharacterData.金币数量 = Math.Max(0, CharacterData.金币数量 - this.金币数量);
					客户网络 网络连接 = CharacterData.网络连接;
					if (网络连接 != null)
					{
						网络连接.发送封包(new 货币数量变动
						{
							货币类型 = 1,
							货币数量 = CharacterData.金币数量
						});
					}
					MainForm.添加命令日志(string.Format("<= @{0} 命令已经执行, 当前金币数量: {1}", base.GetType().Name, CharacterData.金币数量));
					return;
				}
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 角色不存在");
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002858 File Offset: 0x00000A58
		public DeductCoins()
		{
			
			
		}

		// Token: 0x04000032 RID: 50
		[FieldAttribute(0, 排序 = 0)]
		public string 角色名字;

		// Token: 0x04000033 RID: 51
		[FieldAttribute(0, 排序 = 1)]
		public int 金币数量;
	}
}
