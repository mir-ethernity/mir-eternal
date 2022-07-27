using System;
using System.Collections.Generic;
using System.IO;
using GameServer.Networking;

namespace GameServer.Data
{
	
	public sealed class TeamData : GameData
	{
		
		// (get) Token: 0x0600062C RID: 1580 RVA: 0x000054C0 File Offset: 0x000036C0
		public int 队伍编号
		{
			get
			{
				return this.数据索引.V;
			}
		}

		
		// (get) Token: 0x0600062D RID: 1581 RVA: 0x00005A9D File Offset: 0x00003C9D
		public int 队长编号
		{
			get
			{
				return this.队伍队长.V.数据索引.V;
			}
		}

		
		// (get) Token: 0x0600062E RID: 1582 RVA: 0x00005AB4 File Offset: 0x00003CB4
		public int 队员数量
		{
			get
			{
				return this.队伍成员.Count;
			}
		}

		
		// (get) Token: 0x0600062F RID: 1583 RVA: 0x00005AC1 File Offset: 0x00003CC1
		public byte 拾取方式
		{
			get
			{
				return this.分配方式.V;
			}
		}

		
		// (get) Token: 0x06000630 RID: 1584 RVA: 0x00005ACE File Offset: 0x00003CCE
		public string 队长名字
		{
			get
			{
				return this.队长数据.CharName.V;
			}
		}

		
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

		
		public override string ToString()
		{
			CharacterData 队长数据 = this.队长数据;
			if (队长数据 == null)
			{
				return null;
			}
			DataMonitor<string> CharName = 队长数据.CharName;
			if (CharName == null)
			{
				return null;
			}
			return CharName.V;
		}

		
		public TeamData()
		{
			
			this.申请列表 = new Dictionary<CharacterData, DateTime>();
			this.邀请列表 = new Dictionary<CharacterData, DateTime>();
			
		}

		
		public TeamData(CharacterData 创建角色, byte 分配方式)
		{
			
			this.申请列表 = new Dictionary<CharacterData, DateTime>();
			this.邀请列表 = new Dictionary<CharacterData, DateTime>();
			
			this.分配方式.V = 分配方式;
			this.队伍队长.V = 创建角色;
			this.队伍成员.Add(创建角色);
			GameDataGateway.TeamData表.AddData(this, true);
		}

		
		public override void Delete()
		{
			foreach (CharacterData CharacterData in this.队伍成员)
			{
				CharacterData.当前队伍 = null;
			}
			base.Delete();
		}

		
		public void 发送封包(GamePacket P)
		{
			foreach (CharacterData CharacterData in this.队伍成员)
			{
				客户网络 网络连接 = CharacterData.ActiveConnection;
				if (网络连接 != null)
				{
					网络连接.发送封包(P);
				}
			}
		}

		
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
					binaryWriter.Write((队友.ActiveConnection != null) ? (byte)0 : (byte)3);
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		
		public readonly DataMonitor<byte> 分配方式;

		
		public readonly DataMonitor<CharacterData> 队伍队长;

		
		public readonly HashMonitor<CharacterData> 队伍成员;

		
		public Dictionary<CharacterData, DateTime> 申请列表;

		
		public Dictionary<CharacterData, DateTime> 邀请列表;
	}
}
