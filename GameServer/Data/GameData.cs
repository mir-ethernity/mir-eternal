using System;
using System.IO;
using System.Reflection;

namespace GameServer.Data
{

    public abstract class GameData
    {

        public byte[] RawData { get; set; }


        public bool 已经修改 { get; set; }


        public DataTableBase StorageDataTable { get; set; }


        protected void 创建字段()
        {
            foreach (FieldInfo fieldInfo in base.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (fieldInfo.FieldType.IsGenericType)
                {
                    Type genericTypeDefinition = fieldInfo.FieldType.GetGenericTypeDefinition();
                    if (
                        genericTypeDefinition == typeof(DataMonitor<>)
                        || genericTypeDefinition == typeof(ListMonitor<>)
                        || genericTypeDefinition == typeof(HashMonitor<>)
                        || genericTypeDefinition == typeof(MonitorDictionary<,>)
                    )
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


        public virtual void Delete()
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


        public readonly DataMonitor<int> Index;


        public readonly Type Data型;


        public readonly MemoryStream 内存流;


        public readonly BinaryWriter 写入流;
    }
}
