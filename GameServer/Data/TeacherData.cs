using System;
using System.Collections.Generic;
using System.IO;
using GameServer.Networking;

namespace GameServer.Data
{
	
	public sealed class TeacherData : GameData
	{
		
		public int 师父编号
		{
			get
			{
				return this.师父数据.Id;
			}
		}

		
		public int 徒弟数量
		{
			get
			{
				return this.师门成员.Count;
			}
		}

		
		public CharacterData 师父数据
		{
			get
			{
				return this.师门师父.V;
			}
		}

		
		public TeacherData()
		{
			
			this.申请列表 = new Dictionary<int, DateTime>();
			this.邀请列表 = new Dictionary<int, DateTime>();
			
		}

		
		public TeacherData(CharacterData 师父数据)
		{
			
			this.申请列表 = new Dictionary<int, DateTime>();
			this.邀请列表 = new Dictionary<int, DateTime>();
			
			this.师门师父.V = 师父数据;
			GameDataGateway.TeacherData表.AddData(this, true);
		}

		
		public override string ToString()
		{
			CharacterData 师父数据 = this.师父数据;
			if (师父数据 == null)
			{
				return null;
			}
			return 师父数据.ToString();
		}

		
		public override void Delete()
		{
			this.师父数据.所属师门.V = null;
			foreach (CharacterData CharacterData in this.师门成员)
			{
				CharacterData.所属师门.V = null;
			}
			base.Delete();
		}

		
		public int 徒弟提供经验(CharacterData 角色)
		{
			int result;
			if (!this.师父经验.TryGetValue(角色, out result))
			{
				return 0;
			}
			return result;
		}

		
		public int 徒弟提供金币(CharacterData 角色)
		{
			int result;
			if (!this.师父金币.TryGetValue(角色, out result))
			{
				return 0;
			}
			return result;
		}

		
		public int 徒弟提供声望(CharacterData 角色)
		{
			int result;
			if (!this.师父声望.TryGetValue(角色, out result))
			{
				return 0;
			}
			return result;
		}

		
		public int 徒弟出师经验(CharacterData 角色)
		{
			int result;
			if (!this.徒弟经验.TryGetValue(角色, out result))
			{
				return 0;
			}
			return result;
		}

		
		public int 徒弟出师金币(CharacterData 角色)
		{
			int result;
			if (!this.徒弟金币.TryGetValue(角色, out result))
			{
				return 0;
			}
			return result;
		}

		
		public void 发送封包(GamePacket P)
		{
			foreach (CharacterData CharacterData in this.师门成员)
			{
				SConnection 网络连接 = CharacterData.ActiveConnection;
				if (网络连接 != null)
				{
					网络连接.SendPacket(P);
				}
			}
		}

		
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
					CharacterData.ActiveConnection.SendPacket(new SyncGuildMemberPacket
					{
						字节数据 = this.成员数据()
					});
				}
			}
		}

		
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
					CharacterData.ActiveConnection.SendPacket(new SyncGuildMemberPacket
					{
						字节数据 = this.成员数据()
					});
				}
			}
		}

		
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
								binaryWriter.Write(CharacterData.Id);
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
						binaryWriter.Write(CharacterData.Id);
						binaryWriter.Write(CharacterData.角色等级);
						binaryWriter.Write(CharacterData.角色等级);
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		
		public readonly DataMonitor<CharacterData> 师门师父;

		
		public readonly HashMonitor<CharacterData> 师门成员;

		
		public readonly MonitorDictionary<CharacterData, int> 徒弟经验;

		
		public readonly MonitorDictionary<CharacterData, int> 徒弟金币;

		
		public readonly MonitorDictionary<CharacterData, int> 师父经验;

		
		public readonly MonitorDictionary<CharacterData, int> 师父金币;

		
		public readonly MonitorDictionary<CharacterData, int> 师父声望;

		
		public Dictionary<int, DateTime> 申请列表;

		
		public Dictionary<int, DateTime> 邀请列表;
	}
}
