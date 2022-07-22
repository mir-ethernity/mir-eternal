using System;
using System.Text;
using GameServer.Data;

namespace GameServer
{
	// Token: 0x0200001A RID: 26
	public sealed class RenameCharacter : GMCommand
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000088E0 File Offset: 0x00006AE0
		public override void 执行命令()
		{
			GameData GameData;
			if (GameDataGateway.CharacterDataTable.Keyword.TryGetValue(this.CurrentCharacterName, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null)
				{
					if (CharacterData.网络连接 != null || CharacterData.所属账号.V.网络连接 != null)
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 账号必须下线");
						return;
					}
					if (Encoding.UTF8.GetBytes(this.NewCharacterName).Length > 24)
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 角色名字太长");
						return;
					}
					if (GameDataGateway.CharacterDataTable.Keyword.ContainsKey(this.NewCharacterName))
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 名字已被注册");
						return;
					}
					GameDataGateway.CharacterDataTable.Keyword.Remove(CharacterData.角色名字.V);
					CharacterData.角色名字.V = this.NewCharacterName;
					GameDataGateway.CharacterDataTable.Keyword.Add(CharacterData.角色名字.V, CharacterData);
					MainForm.添加命令日志(string.Format("<= @{0} 命令已经执行, 角色当前名字: {1}", base.GetType().Name, CharacterData));
					return;
				}
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 角色不存在");
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002858 File Offset: 0x00000A58
		public RenameCharacter()
		{
			
			
		}

		// Token: 0x04000026 RID: 38
		[FieldAttribute(0, 排序 = 0)]
		public string CurrentCharacterName;

		// Token: 0x04000027 RID: 39
		[FieldAttribute(0, 排序 = 1)]
		public string NewCharacterName;
	}
}
