using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace GameServer.Data
{
	// Token: 0x02000276 RID: 630
	public sealed class DataTableCrud<T> : DataTableBase where T : GameData, new()
	{
		// Token: 0x0600064D RID: 1613 RVA: 0x0002E5BC File Offset: 0x0002C7BC
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

		// Token: 0x0600064E RID: 1614 RVA: 0x0002E674 File Offset: 0x0002C874
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
				MessageBox.Show("数据表添加数据异常, 索引为零.");
			}
			数据.StorageDataTable = this;
			this.DataSheet.Add(数据.数据索引.V, 数据);
			if (this.SearchField != null)
			{
				this.Keyword.Add((this.SearchField.GetValue(数据) as DataMonitor<string>).V, 数据);
			}
			GameDataGateway.已经修改 = true;
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x0002E70C File Offset: 0x0002C90C
		public override void 删除数据(GameData 数据)
		{
			this.DataSheet.Remove(数据.数据索引.V);
			if (this.SearchField != null)
			{
				this.Keyword.Remove((this.SearchField.GetValue(数据) as DataMonitor<string>).V);
			}
			GameDataGateway.已经修改 = true;
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0002E768 File Offset: 0x0002C968
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

		// Token: 0x06000651 RID: 1617 RVA: 0x0002E7E0 File Offset: 0x0002C9E0
		public override void 强制保存()
		{
			foreach (KeyValuePair<int, GameData> keyValuePair in this.DataSheet)
			{
				keyValuePair.Value.保存数据();
			}
			this.IsSameVersion = true;
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0002E840 File Offset: 0x0002CA40
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

		// Token: 0x06000653 RID: 1619 RVA: 0x0002E9A4 File Offset: 0x0002CBA4
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
