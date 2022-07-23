using System;
using System.IO;
using System.Reflection;

namespace GameServer.Data
{
	
	public abstract class GameData
	{
		
		// (get) Token: 0x0600055C RID: 1372 RVA: 0x000050EC File Offset: 0x000032EC
		// (set) Token: 0x0600055D RID: 1373 RVA: 0x000050F4 File Offset: 0x000032F4
		public byte[] RawData { get; set; }

		
		// (get) Token: 0x0600055E RID: 1374 RVA: 0x000050FD File Offset: 0x000032FD
		// (set) Token: 0x0600055F RID: 1375 RVA: 0x00005105 File Offset: 0x00003305
		public bool 已经修改 { get; set; }

		
		// (get) Token: 0x06000560 RID: 1376 RVA: 0x0000510E File Offset: 0x0000330E
		// (set) Token: 0x06000561 RID: 1377 RVA: 0x00005116 File Offset: 0x00003316
		public DataTableBase StorageDataTable { get; set; }

		
		protected void 创建字段()
		{
			foreach (FieldInfo fieldInfo in base.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				if (fieldInfo.FieldType.IsGenericType)
				{
					Type genericTypeDefinition = fieldInfo.FieldType.GetGenericTypeDefinition();
					if (!(genericTypeDefinition != typeof(DataMonitor<>)) || !(genericTypeDefinition != typeof(ListMonitor<>)) || !(genericTypeDefinition != typeof(HashMonitor<>)) || !(genericTypeDefinition != typeof(MonitorDictionary<, >)))
					{
						fieldInfo.SetValue(this, Activator.CreateInstance(fieldInfo.FieldType, new object[]
						{
							this
						}));
					}
				}
			}
		}

		
		public override string ToString()
		{
			Type type = this.Data型;
			if (type == null)
			{
				return null;
			}
			return type.Name;
		}

		
		public GameData()
		{
			
			
			this.Data型 = base.GetType();
			this.内存流 = new MemoryStream();
			this.写入流 = new BinaryWriter(this.内存流);
			this.创建字段();
		}

		
		public void 保存数据()
		{
			this.内存流.SetLength(0L);
			foreach (DataField DataField in this.StorageDataTable.CurrentMappingVersion.FieldList)
			{
				DataField.保存字段内容(this.写入流, DataField.字段详情.GetValue(this));
			}
			this.RawData = this.内存流.ToArray();
			this.已经修改 = false;
		}

		
		public void LoadData(DataMapping 历史映射)
		{
			using (MemoryStream memoryStream = new MemoryStream(this.RawData))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					foreach (DataField DataField in 历史映射.FieldList)
					{
						object value = DataField.读取字段内容(binaryReader, this, DataField);
						if (!(DataField.字段详情 == null) && DataField.字段类型 == DataField.字段详情.FieldType)
						{
							DataField.字段详情.SetValue(this, value);
						}
					}
				}
			}
		}

		
		public virtual void 删除数据()
		{
			DataTableBase 数据存表 = this.StorageDataTable;
			if (数据存表 == null)
			{
				return;
			}
			数据存表.删除数据(this);
		}

		
		public virtual void OnLoadCompleted()
		{
		}

		
		public readonly DataMonitor<int> 数据索引;

		
		public readonly Type Data型;

		
		public readonly MemoryStream 内存流;

		
		public readonly BinaryWriter 写入流;
	}
}
