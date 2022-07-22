using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GameServer
{
	// Token: 0x02000005 RID: 5
	public abstract class GMCommand
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00007A64 File Offset: 0x00005C64
		static GMCommand()
		{
			
			GMCommand.命令字典 = new Dictionary<string, Type>();
			GMCommand.命令格式 = new Dictionary<string, string>();
			GMCommand.字段列表 = new Dictionary<string, FieldInfo[]>();
			Type[] types = Assembly.GetExecutingAssembly().GetTypes();
			for (int i = 0; i < types.Length; i++)
			{
				Type type = types[i];
				if (type.IsSubclassOf(typeof(GMCommand)))
				{
					Dictionary<FieldInfo, int> 字段集合 = new Dictionary<FieldInfo, int>();
					foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public))
					{
						FieldAttribute customAttribute = fieldInfo.GetCustomAttribute<FieldAttribute>();
						if (customAttribute != null)
						{
							字段集合.Add(fieldInfo, customAttribute.排序);
						}
					}
					GMCommand.命令字典[type.Name] = type;
					GMCommand.字段列表[type.Name] = (from x in 字段集合.Keys
					orderby 字段集合[x]
					select x).ToArray<FieldInfo>();
					GMCommand.命令格式[type.Name] = "@" + type.Name;
					foreach (FieldInfo fieldInfo2 in GMCommand.字段列表[type.Name])
					{
						Dictionary<string, string> dictionary = GMCommand.命令格式;
						string name = type.Name;
						dictionary[name] = dictionary[name] + " " + fieldInfo2.Name;
					}
				}
			}
			Dictionary<Type, Func<string, object>> dictionary2 = new Dictionary<Type, Func<string, object>>();
			Type typeFromHandle = typeof(string);
			dictionary2[typeFromHandle] = ((string s) => s);
			Type typeFromHandle2 = typeof(int);
			dictionary2[typeFromHandle2] = ((string s) => Convert.ToInt32(s));
			Type typeFromHandle3 = typeof(uint);
			dictionary2[typeFromHandle3] = ((string s) => Convert.ToUInt32(s));
			Type typeFromHandle4 = typeof(byte);
			dictionary2[typeFromHandle4] = ((string s) => Convert.ToByte(s));
			Type typeFromHandle5 = typeof(bool);
			dictionary2[typeFromHandle5] = ((string s) => Convert.ToBoolean(s));
			Type typeFromHandle6 = typeof(float);
			dictionary2[typeFromHandle6] = ((string s) => Convert.ToSingle(s));
			Type typeFromHandle7 = typeof(decimal);
			dictionary2[typeFromHandle7] = ((string s) => Convert.ToDecimal(s));
			GMCommand.字段写入方法表 = dictionary2;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00007CF4 File Offset: 0x00005EF4
		public static bool 解析命令(string 文本, out GMCommand 命令)
		{
			string[] array = 文本.Trim(new char[]
			{
				'@'
			}).Split(new char[]
			{
				' '
			}, StringSplitOptions.RemoveEmptyEntries);
			Type type;
			FieldInfo[] array2;
			if (!GMCommand.命令字典.TryGetValue(array[0], out type) || !GMCommand.字段列表.TryGetValue(array[0], out array2))
			{
				MainForm.添加命令日志("<= @命令解析错误, '" + array[0] + "' 不是支持的GMCommand");
				命令 = null;
				return false;
			}
			if (array.Length <= GMCommand.字段列表[array[0]].Length)
			{
				MainForm.添加命令日志("<= @参数长度错误, 请参照格式: " + GMCommand.命令格式[array[0]]);
				命令 = null;
				return false;
			}
			GMCommand command = Activator.CreateInstance(type) as GMCommand;
			for (int i = 0; i < array2.Length; i++)
			{
				try
				{
					array2[i].SetValue(command, GMCommand.字段写入方法表[array2[i].FieldType](array[i + 1]));
				}
				catch
				{
					MainForm.添加命令日志(string.Concat(new string[]
					{
						"<= @参数转换错误. 不能将字符串 '",
						array[i + 1],
						"' 转换为参数 '",
						array2[i].Name,
						"' 所需要的Data型"
					}));
					命令 = null;
					return false;
				}
			}
			命令 = command;
			return true;
		}

		// Token: 0x06000004 RID: 4
		public abstract void 执行命令();

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5
		public abstract ExecutionWay ExecutionWay { get; }

		// Token: 0x06000006 RID: 6 RVA: 0x000027D8 File Offset: 0x000009D8
		protected GMCommand()
		{
			
			
		}

		// Token: 0x04000007 RID: 7
		private static readonly Dictionary<string, Type> 命令字典;

		// Token: 0x04000008 RID: 8
		private static readonly Dictionary<string, FieldInfo[]> 字段列表;

		// Token: 0x04000009 RID: 9
		private static readonly Dictionary<Type, Func<string, object>> 字段写入方法表;

		// Token: 0x0400000A RID: 10
		public static readonly Dictionary<string, string> 命令格式;
	}
}
