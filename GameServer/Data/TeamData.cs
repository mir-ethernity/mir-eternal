using System;
using System.Collections.Generic;
using System.IO;
using GameServer.Networking;

namespace GameServer.Data
{
	// Token: 0x02000273 RID: 627
	public sealed class TeamData : GameData
	{
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600062C RID: 1580 RVA: 0x000054C0 File Offset: 0x000036C0
		public int 队伍编号
		{
			get
			{
				return this.数据索引.V;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600062D RID: 1581 RVA: 0x00005A9D File Offset: 0x00003C9D
		public int 队长编号
		{
			get
			{
				return this.队伍队长.V.数据索引.V;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600062E RID: 1582 RVA: 0x00005AB4 File Offset: 0x00003CB4
		public int 队员数量
		{
			get
			{
				return this.队伍成员.Count;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600062F RID: 1583 RVA: 0x00005AC1 File Offset: 0x00003CC1
		public byte 拾取方式
		{
			get
			{
				return this.分配方式.V;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000630 RID: 1584 RVA: 0x00005ACE File Offset: 0x00003CCE
		public string 队长名字
		{
			get
			{
				return this.队长数据.角色名字.V;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000631 RID: 1585 RVA: 0x00005AE0 File Offset: 0x00003CE0
		// (set) Token: 0x06000632 RID: 1586 RVA: 0x00005AED File Offset: 0x00003CED
		public CharacterData 队长数据
		{
			get
			{
				return this.队伍队长.V;
			}
			set
			{
				if (this.队伍队长.V.数据索引.V != value.数据索引.V)
				{
					this.队伍队长.V = value;
				}
			}
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x00005B1D File Offset: 0x00003D1D
		public override string ToString()
		{
			CharacterData 队长数据 = this.队长数据;
			if (队长数据 == null)
			{
				return null;
			}
			DataMonitor<string> 角色名字 = 队长数据.角色名字;
			if (角色名字 == null)
			{
				return null;
			}
			return 角色名字.V;
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x00005B3B File Offset: 0x00003D3B
		public TeamData()
		{
			
			this.申请列表 = new Dictionary<CharacterData, DateTime>();
			this.邀请列表 = new Dictionary<CharacterData, DateTime>();
			
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0002DF74 File Offset: 0x0002C174
		public TeamData(CharacterData 创建角色, byte 分配方式)
		{
			
			this.申请列表 = new Dictionary<CharacterData, DateTime>();
			this.邀请列表 = new Dictionary<CharacterData, DateTime>();
			
			this.分配方式.V = 分配方式;
			this.队伍队长.V = 创建角色;
			this.队伍成员.Add(创建角色);
			GameDataGateway.TeamData表.AddData(this, true);
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0002DFD4 File Offset: 0x0002C1D4
		public override void 删除数据()
		{
			foreach (CharacterData CharacterData in this.队伍成员)
			{
				CharacterData.当前队伍 = null;
			}
			base.删除数据();
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x0002E028 File Offset: 0x0002C228
		public void 发送封包(GamePacket P)
		{
			foreach (CharacterData CharacterData in this.队伍成员)
			{
				客户网络 网络连接 = CharacterData.网络连接;
				if (网络连接 != null)
				{
					网络连接.发送封包(P);
				}
			}
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x0002E080 File Offset: 0x0002C280
		public byte[] 队伍描述()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(this.数据索引.V);
					binaryWriter.Write(this.队长数据.名字描述());
					binaryWriter.Seek(36, SeekOrigin.Begin);
					binaryWriter.Write(this.拾取方式);
					binaryWriter.Write(this.队长编号);
					binaryWriter.Write(11);
					binaryWriter.Write((ushort)this.队伍成员.Count);
					binaryWriter.Write(0);
					foreach (CharacterData 队友 in this.队伍成员)
					{
						binaryWriter.Write(this.队友描述(队友));
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x0002E180 File Offset: 0x0002C380
		public byte[] 队友描述(CharacterData 队友)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(new byte[39]))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(队友.数据索引.V);
					binaryWriter.Write(队友.名字描述());
					binaryWriter.Seek(36, SeekOrigin.Begin);
					binaryWriter.Write((byte)队友.角色性别.V);
					binaryWriter.Write((byte)队友.角色职业.V);
					binaryWriter.Write((队友.网络连接 != null) ? 0 : 3);
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		// Token: 0x040008E1 RID: 2273
		public readonly DataMonitor<byte> 分配方式;

		// Token: 0x040008E2 RID: 2274
		public readonly DataMonitor<CharacterData> 队伍队长;

		// Token: 0x040008E3 RID: 2275
		public readonly HashMonitor<CharacterData> 队伍成员;

		// Token: 0x040008E4 RID: 2276
		public Dictionary<CharacterData, DateTime> 申请列表;

		// Token: 0x040008E5 RID: 2277
		public Dictionary<CharacterData, DateTime> 邀请列表;
	}
}
