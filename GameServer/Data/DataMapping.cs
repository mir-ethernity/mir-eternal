using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace GameServer.Data
{
	// Token: 0x02000265 RID: 613
	public sealed class DataMapping
	{
		// Token: 0x06000556 RID: 1366 RVA: 0x000050D1 File Offset: 0x000032D1
		public override string ToString()
		{
			Type type = this.DataType;
			if (type == null)
			{
				return null;
			}
			return type.Name;
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000557 RID: 1367 RVA: 0x000050E4 File Offset: 0x000032E4
		public List<DataField> FieldList { get; }

		// Token: 0x06000558 RID: 1368 RVA: 0x00024C08 File Offset: 0x00022E08
		public DataMapping(BinaryReader 读取流)
		{
			
			this.FieldList = new List<DataField>();
			
			string name = 读取流.ReadString();
			this.DataType = (Assembly.GetEntryAssembly().GetType(name) ?? Assembly.GetCallingAssembly().GetType(name));
			int num = 读取流.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				this.FieldList.Add(new DataField(读取流, this.DataType));
			}
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00024C7C File Offset: 0x00022E7C
		public DataMapping(Type Data型)
		{
			
			this.FieldList = new List<DataField>();
			
			this.DataType = Data型;
			foreach (FieldInfo fieldInfo in this.DataType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				if (fieldInfo.FieldType.IsGenericType)
				{
					Type genericTypeDefinition = fieldInfo.FieldType.GetGenericTypeDefinition();
					if (!(genericTypeDefinition != typeof(DataMonitor<>)) || !(genericTypeDefinition != typeof(ListMonitor<>)) || !(genericTypeDefinition != typeof(HashMonitor<>)) || !(genericTypeDefinition != typeof(MonitorDictionary<, >)))
					{
						this.FieldList.Add(new DataField(fieldInfo));
					}
				}
			}
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x00024D38 File Offset: 0x00022F38
		public void 保存映射描述(BinaryWriter writer)
		{
			writer.Write(this.DataType.FullName);
			writer.Write(this.FieldList.Count);
			foreach (DataField DataField in this.FieldList)
			{
				DataField.SaveFieldAttribute(writer);
			}
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x00024DAC File Offset: 0x00022FAC
		public bool CheckMappingVersion(DataMapping 对比映射)
		{
			if (this.FieldList.Count != 对比映射.FieldList.Count)
			{
				return false;
			}
			for (int i = 0; i < this.FieldList.Count; i++)
			{
				if (!this.FieldList[i].检查字段版本(对比映射.FieldList[i]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0400081E RID: 2078
		public Type DataType;
	}
}
