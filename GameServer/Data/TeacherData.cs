using System;
using System.Collections.Generic;
using System.IO;
using GameServer.Networking;

namespace GameServer.Data
{
	// Token: 0x02000253 RID: 595
	public sealed class TeacherData : GameData
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x000044A0 File Offset: 0x000026A0
		public int 师父编号
		{
			get
			{
				return this.师父数据.角色编号;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600044E RID: 1102 RVA: 0x000044AD File Offset: 0x000026AD
		public int 徒弟数量
		{
			get
			{
				return this.师门成员.Count;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600044F RID: 1103 RVA: 0x000044BA File Offset: 0x000026BA
		public CharacterData 师父数据
		{
			get
			{
				return this.师门师父.V;
			}
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x000044C7 File Offset: 0x000026C7
		public TeacherData()
		{
			
			this.申请列表 = new Dictionary<int, DateTime>();
			this.邀请列表 = new Dictionary<int, DateTime>();
			
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x000044EA File Offset: 0x000026EA
		public TeacherData(CharacterData 师父数据)
		{
			
			this.申请列表 = new Dictionary<int, DateTime>();
			this.邀请列表 = new Dictionary<int, DateTime>();
			
			this.师门师父.V = 师父数据;
			GameDataGateway.TeacherData表.AddData(this, true);
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00004525 File Offset: 0x00002725
		public override string ToString()
		{
			CharacterData 师父数据 = this.师父数据;
			if (师父数据 == null)
			{
				return null;
			}
			return 师父数据.ToString();
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00020C70 File Offset: 0x0001EE70
		public override void 删除数据()
		{
			this.师父数据.所属师门.V = null;
			foreach (CharacterData CharacterData in this.师门成员)
			{
				CharacterData.所属师门.V = null;
			}
			base.删除数据();
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00020CD8 File Offset: 0x0001EED8
		public int 徒弟提供经验(CharacterData 角色)
		{
			int result;
			if (!this.师父经验.TryGetValue(角色, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00020CF8 File Offset: 0x0001EEF8
		public int 徒弟提供金币(CharacterData 角色)
		{
			int result;
			if (!this.师父金币.TryGetValue(角色, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00020D18 File Offset: 0x0001EF18
		public int 徒弟提供声望(CharacterData 角色)
		{
			int result;
			if (!this.师父声望.TryGetValue(角色, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x00020D38 File Offset: 0x0001EF38
		public int 徒弟出师经验(CharacterData 角色)
		{
			int result;
			if (!this.徒弟经验.TryGetValue(角色, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00020D58 File Offset: 0x0001EF58
		public int 徒弟出师金币(CharacterData 角色)
		{
			int result;
			if (!this.徒弟金币.TryGetValue(角色, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00020D78 File Offset: 0x0001EF78
		public void 发送封包(GamePacket P)
		{
			foreach (CharacterData CharacterData in this.师门成员)
			{
				客户网络 网络连接 = CharacterData.网络连接;
				if (网络连接 != null)
				{
					网络连接.发送封包(P);
				}
			}
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00020DD0 File Offset: 0x0001EFD0
		public void 添加徒弟(CharacterData 角色)
		{
			this.师门成员.Add(角色);
			this.徒弟经验.Add(角色, 0);
			this.徒弟金币.Add(角色, 0);
			this.师父经验.Add(角色, 0);
			this.师父金币.Add(角色, 0);
			this.师父声望.Add(角色, 0);
			角色.当前师门 = this;
			foreach (CharacterData CharacterData in this.师门成员)
			{
				if (CharacterData != null)
				{
					CharacterData.网络连接.发送封包(new SyncGuildMemberPacket
					{
						字节数据 = this.成员数据()
					});
				}
			}
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00020E8C File Offset: 0x0001F08C
		public void 移除徒弟(CharacterData 角色)
		{
			this.师门成员.Remove(角色);
			this.徒弟经验.Remove(角色);
			this.徒弟金币.Remove(角色);
			this.师父经验.Remove(角色);
			this.师父金币.Remove(角色);
			this.师父声望.Remove(角色);
			foreach (CharacterData CharacterData in this.师门成员)
			{
				if (CharacterData != null)
				{
					CharacterData.网络连接.发送封包(new SyncGuildMemberPacket
					{
						字节数据 = this.成员数据()
					});
				}
			}
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00020F44 File Offset: 0x0001F144
		public byte[] 奖励数据(CharacterData 角色)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					if (角色 == this.师父数据)
					{
						binaryWriter.Seek(12, SeekOrigin.Begin);
						using (IEnumerator<CharacterData> enumerator = this.师门成员.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								CharacterData CharacterData = enumerator.Current;
								binaryWriter.Write(CharacterData.角色编号);
								binaryWriter.Write(this.徒弟提供经验(CharacterData));
								binaryWriter.Write(this.徒弟提供声望(CharacterData));
								binaryWriter.Write(this.徒弟提供金币(CharacterData));
							}
							goto IL_A3;
						}
					}
					binaryWriter.Write(this.师父编号);
					binaryWriter.Write(this.徒弟出师经验(角色));
					binaryWriter.Write(this.徒弟出师金币(角色));
					IL_A3:
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x0002103C File Offset: 0x0001F23C
		public byte[] 成员数据()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(this.师父编号);
					binaryWriter.Write(this.师父数据.角色等级);
					binaryWriter.Write((byte)this.师门成员.Count);
					foreach (CharacterData CharacterData in this.师门成员)
					{
						binaryWriter.Write(CharacterData.角色编号);
						binaryWriter.Write(CharacterData.角色等级);
						binaryWriter.Write(CharacterData.角色等级);
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		// Token: 0x040007E1 RID: 2017
		public readonly DataMonitor<CharacterData> 师门师父;

		// Token: 0x040007E2 RID: 2018
		public readonly HashMonitor<CharacterData> 师门成员;

		// Token: 0x040007E3 RID: 2019
		public readonly MonitorDictionary<CharacterData, int> 徒弟经验;

		// Token: 0x040007E4 RID: 2020
		public readonly MonitorDictionary<CharacterData, int> 徒弟金币;

		// Token: 0x040007E5 RID: 2021
		public readonly MonitorDictionary<CharacterData, int> 师父经验;

		// Token: 0x040007E6 RID: 2022
		public readonly MonitorDictionary<CharacterData, int> 师父金币;

		// Token: 0x040007E7 RID: 2023
		public readonly MonitorDictionary<CharacterData, int> 师父声望;

		// Token: 0x040007E8 RID: 2024
		public Dictionary<int, DateTime> 申请列表;

		// Token: 0x040007E9 RID: 2025
		public Dictionary<int, DateTime> 邀请列表;
	}
}
