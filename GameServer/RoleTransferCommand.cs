using System;
using GameServer.Data;

namespace GameServer
{
	// Token: 0x0200001B RID: 27
	public sealed class RoleTransferCommand : GMCommand
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002865 File Offset: 0x00000A65
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00008A48 File Offset: 0x00006C48
		public override void 执行命令()
		{
			GameData GameData;
			if (GameDataGateway.CharacterDataTable.Keyword.TryGetValue(this.角色名字, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null)
				{
					if (!CharacterData.所属账号.V.角色列表.Contains(CharacterData))
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 角色处于删除状态");
						return;
					}
					if (CharacterData.封禁日期.V > DateTime.Now)
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 角色处于封禁状态");
						return;
					}
					if (CharacterData.所属账号.V.封禁日期.V > DateTime.Now)
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 原账号处于封禁状态");
						return;
					}
					GameData GameData2;
					if (GameDataGateway.AccountData表.Keyword.TryGetValue(this.新账号名, out GameData2))
					{
						AccountData AccountData = GameData2 as AccountData;
						if (AccountData != null)
						{
							if (AccountData.封禁日期.V > DateTime.Now)
							{
								MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 转移账号处于封禁状态");
								return;
							}
							if (AccountData.角色列表.Count >= 4)
							{
								MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 转移的账号角色数量已达上限");
								return;
							}
							if (CharacterData.所属账号.V.网络连接 == null && AccountData.网络连接 == null)
							{
								CharacterData.所属账号.V.角色列表.Remove(CharacterData);
								CharacterData.所属账号.V = AccountData;
								AccountData.角色列表.Add(CharacterData);
								MainForm.添加命令日志(string.Format("<= @{0} 命令已经执行, 角色当前账号:{1}", base.GetType().Name, CharacterData.所属账号));
								return;
							}
							MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 双方账号必须下线");
							return;
						}
					}
					MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 转移账号不存在或从未登录");
					return;
				}
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " 命令执行失败, 角色不存在");
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002858 File Offset: 0x00000A58
		public RoleTransferCommand()
		{
			
			
		}

		// Token: 0x04000028 RID: 40
		[FieldAttribute(0, 排序 = 0)]
		public string 角色名字;

		// Token: 0x04000029 RID: 41
		[FieldAttribute(0, 排序 = 1)]
		public string 新账号名;
	}
}
