using System;
using System.Collections.Generic;
using System.IO;
using GameServer.Networking;

namespace GameServer.Data
{
	
	public sealed class TeamData : GameData
	{
		
		public int 队伍编号
		{
			get
			{
				return this.数据索引.V;
			}
		}

		
		public int 队长编号
		{
			get
			{
				return this.队伍队长.V.数据索引.V;
			}
		}

		
		public int 队员数量
		{
			get
			{
				return this.队伍成员.Count;
			}
		}

		
		public byte 拾取方式
		{
			get
			{
				return this.分配方式.V;
			}
		}

		
		public string 队长名字
		{
			get
			{
				return this.队长数据.CharName.V;
			}
		}

		
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
				SConnection 网络连接 = CharacterData.ActiveConnection;
				if (网络连接 != null)
				{
					网络连接.SendPacket(P);
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
					binaryWriter.Write((byte)队友.CharGender.V);
					binaryWriter.Write((byte)队友.CharRole.V);
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
