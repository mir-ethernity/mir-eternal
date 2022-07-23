using System;
using System.Collections.Generic;
using System.Reflection;

namespace GameServer.Data
{
	
	public abstract class DataTableBase
	{
		
		public override string ToString()
		{
			Type type = this.DataType;
			if (type == null)
			{
				return null;
			}
			return type.Name;
		}

		
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

		
		public abstract void LoadData(byte[] 原始数据, DataMapping DataMapping);

		
		public abstract void 保存数据();

		
		public abstract void 强制保存();

		
		public abstract void 删除数据(GameData 数据);

		
		public abstract void AddData(GameData 数据, bool 分配索引 = false);

		
		public abstract byte[] SaveData();

		
		protected DataTableBase()
		{
			
			
		}

		
		public int CurrentIndex;

		
		public bool IsSameVersion;

		
		public Type DataType;

		
		public FieldInfo SearchField;

		
		public DataMapping CurrentMappingVersion;

		
		public Dictionary<int, GameData> DataSheet;

		
		public Dictionary<string, GameData> Keyword;
	}
}
