using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace GameServer.Data
{
	
	public sealed class DataTableCrud<T> : DataTableBase where T : GameData, new()
	{
		
		public DataTableCrud()
		{
			
			
			this.CurrentMappingVersion = new DataMapping(this.DataType = typeof(T));
			this.DataSheet = new Dictionary<int, GameData>();
			this.Keyword = new Dictionary<string, GameData>();
			FastDataReturnAttribute customAttribute = this.DataType.GetCustomAttribute<FastDataReturnAttribute>();
			if (customAttribute != null)
			{
				this.SearchField = this.DataType.GetField(customAttribute.检索字段, BindingFlags.Instance | BindingFlags.Public);
			}
			if (this.DataType == typeof(GuildData))
			{
				this.CurrentIndex = 1610612736;
			}
			if (this.DataType == typeof(TeamData))
			{
				this.CurrentIndex = 1879048192;
			}
		}

		
		public override void AddData(GameData 数据, bool 分配索引 = false)
		{
			if (分配索引)
			{
				DataMonitor<int> 数据索引 = 数据.数据索引;
				int num = this.CurrentIndex + 1;
				this.CurrentIndex = num;
				数据索引.V = num;
			}
			if (数据.数据索引.V == 0)
			{
				MessageBox.Show("Data table add data exception, index is zero.");
			}
			数据.StorageDataTable = this;
			this.DataSheet.Add(数据.数据索引.V, 数据);
			if (this.SearchField != null)
			{
				this.Keyword.Add((this.SearchField.GetValue(数据) as DataMonitor<string>).V, 数据);
			}
			GameDataGateway.已经修改 = true;
		}

		
		public override void 删除数据(GameData 数据)
		{
			this.DataSheet.Remove(数据.数据索引.V);
			if (this.SearchField != null)
			{
				this.Keyword.Remove((this.SearchField.GetValue(数据) as DataMonitor<string>).V);
			}
			GameDataGateway.已经修改 = true;
		}

		
		public override void 保存数据()
		{
			foreach (KeyValuePair<int, GameData> keyValuePair in this.DataSheet)
			{
				if (!this.IsSameVersion || keyValuePair.Value.已经修改)
				{
					keyValuePair.Value.保存数据();
				}
			}
			this.IsSameVersion = true;
		}

		
		public override void 强制保存()
		{
			foreach (KeyValuePair<int, GameData> keyValuePair in this.DataSheet)
			{
				keyValuePair.Value.保存数据();
			}
			this.IsSameVersion = true;
		}

		
		public override void LoadData(byte[] buffer, DataMapping histoMapping)
		{
			this.IsSameVersion = histoMapping.CheckMappingVersion(this.CurrentMappingVersion);
			using (MemoryStream memoryStream = new MemoryStream(buffer))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					this.CurrentIndex = binaryReader.ReadInt32();
					int num = binaryReader.ReadInt32();
					for (int i = 0; i < num; i++)
					{
						T t = Activator.CreateInstance<T>();
						t.StorageDataTable = this;
						T t2 = t;
						t2.RawData = binaryReader.ReadBytes(binaryReader.ReadInt32());
						t2.LoadData(histoMapping);
						this.DataSheet[t2.数据索引.V] = t2;
						if (this.SearchField != null)
						{
							DataMonitor<string> DataMonitor = this.SearchField.GetValue(t2) as DataMonitor<string>;
							if (DataMonitor != null && DataMonitor.V != null)
							{
								this.Keyword[DataMonitor.V] = t2;
							}
						}
					}
					MainForm.AddSystemLog(string.Format("{0} Loaded, Total: {1}", this.DataType.Name, num));
				}
			}
		}

		
		public override byte[] SaveData()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(this.CurrentIndex);
					binaryWriter.Write(this.DataSheet.Count);
					foreach (KeyValuePair<int, GameData> keyValuePair in this.DataSheet)
					{
						if (keyValuePair.Value.RawData == null || keyValuePair.Value.RawData.Length == 0) continue;
						binaryWriter.Write(keyValuePair.Value.RawData.Length);
						binaryWriter.Write(keyValuePair.Value.RawData);
					}
					memoryStream.Seek(4L, SeekOrigin.Begin);
					result = memoryStream.ToArray();
				}
			}
			return result;
		}
	}
}
