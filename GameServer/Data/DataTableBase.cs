using System;
using System.Collections.Generic;
using System.Reflection;

namespace GameServer.Data
{
	// Token: 0x02000275 RID: 629
	public abstract class DataTableBase
	{
		// Token: 0x06000643 RID: 1603 RVA: 0x00005BDB File Offset: 0x00003DDB
		public override string ToString()
		{
			Type type = this.DataType;
			if (type == null)
			{
				return null;
			}
			return type.Name;
		}

		// Token: 0x170000B3 RID: 179
		internal GameData this[int 索引]
		{
			get
			{
				GameData result;
				if (!this.DataSheet.TryGetValue(索引, out result))
				{
					return null;
				}
				return result;
			}
		}

		// Token: 0x170000B4 RID: 180
		internal GameData this[string 名称]
		{
			get
			{
				GameData result;
				if (!this.Keyword.TryGetValue(名称, out result))
				{
					return null;
				}
				return result;
			}
		}

		// Token: 0x06000646 RID: 1606
		public abstract void LoadData(byte[] 原始数据, DataMapping DataMapping);

		// Token: 0x06000647 RID: 1607
		public abstract void 保存数据();

		// Token: 0x06000648 RID: 1608
		public abstract void 强制保存();

		// Token: 0x06000649 RID: 1609
		public abstract void 删除数据(GameData 数据);

		// Token: 0x0600064A RID: 1610
		public abstract void AddData(GameData 数据, bool 分配索引 = false);

		// Token: 0x0600064B RID: 1611
		public abstract byte[] SaveData();

		// Token: 0x0600064C RID: 1612 RVA: 0x000027D8 File Offset: 0x000009D8
		protected DataTableBase()
		{
			
			
		}

		// Token: 0x040008EE RID: 2286
		public int CurrentIndex;

		// Token: 0x040008EF RID: 2287
		public bool IsSameVersion;

		// Token: 0x040008F0 RID: 2288
		public Type DataType;

		// Token: 0x040008F1 RID: 2289
		public FieldInfo SearchField;

		// Token: 0x040008F2 RID: 2290
		public DataMapping CurrentMappingVersion;

		// Token: 0x040008F3 RID: 2291
		public Dictionary<int, GameData> DataSheet;

		// Token: 0x040008F4 RID: 2292
		public Dictionary<string, GameData> Keyword;
	}
}
