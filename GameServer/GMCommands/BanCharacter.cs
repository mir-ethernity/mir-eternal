using System;
using GameServer.Data;
using GameServer.Networking;

namespace GameServer
{
	// Token: 0x02000011 RID: 17
	public sealed class BanCharacter : GMCommand
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00008248 File Offset: 0x00006448
		public override void 执行命令()
		{
			GameData GameData;
			if (GameDataGateway.CharacterDataTable.Keyword.TryGetValue(this.角色名字, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null)
				{
					CharacterData.封禁日期.V = DateTime.Now.AddDays((double)this.封禁天数);
					客户网络 网络连接 = CharacterData.网络连接;
					if (网络连接 != null)
					{
						网络连接.尝试断开连接(new Exception("角色被封禁, 强制下线"));
					}
					MainForm.添加命令日志(string.Format("<= @{0} 命令已经执行, 封禁到期时间: {1}", base.GetType().Name, CharacterData.封禁日期));
					return;
				}
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 角色不存在");
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002858 File Offset: 0x00000A58
		public BanCharacter()
		{
			
			
		}

		// Token: 0x0400001C RID: 28
		[FieldAttribute(0, 排序 = 0)]
		public string 角色名字;

		// Token: 0x0400001D RID: 29
		[FieldAttribute(0, 排序 = 1)]
		public float 封禁天数;
	}
}
