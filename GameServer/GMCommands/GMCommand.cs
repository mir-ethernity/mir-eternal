using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GameServer
{

    public abstract class GMCommand
    {

        static GMCommand()
        {
            命令字典 = new Dictionary<string, Type>();
            命令格式 = new Dictionary<string, string>();
            字段列表 = new Dictionary<string, FieldInfo[]>();
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
                            字段集合.Add(fieldInfo, customAttribute.Position);
                        }
                    }
                    命令字典[type.Name] = type;
                    字段列表[type.Name] = (from x in 字段集合.Keys
                                       orderby 字段集合[x]
                                       select x).ToArray<FieldInfo>();
                    命令格式[type.Name] = "@" + type.Name;
                    foreach (FieldInfo fieldInfo2 in 字段列表[type.Name])
                    {
                        var fieldCommand = fieldInfo2.GetCustomAttribute<FieldAttribute>();
                        Dictionary<string, string> dictionary = 命令格式;
                        string name = type.Name;
                        dictionary[name] = dictionary[name] + " " + ((fieldCommand?.IsOptional ?? false) ? $"[{fieldInfo2.Name}]" : fieldInfo2.Name);
                    }
                }
            }

            ParseValue = new Dictionary<Type, Func<string, object>>
            {
                [typeof(string)] = (string s) => s,
                [typeof(int)] = (string s) => Convert.ToInt32(s),
                [typeof(uint)] = (string s) => Convert.ToUInt32(s),
                [typeof(byte)] = (string s) => Convert.ToByte(s),
                [typeof(bool)] = (string s) => Convert.ToBoolean(s),
                [typeof(float)] = (string s) => Convert.ToSingle(s),
                [typeof(decimal)] = (string s) => Convert.ToDecimal(s),
                [typeof(short)] = (string s) => Convert.ToInt16(s),
                [typeof(ushort)] = (string s) => Convert.ToUInt16(s),
            };
        }


        public static bool 解析命令(string 文本, out GMCommand cmd)
        {
            string[] array = 文本.Trim('@').Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (!命令字典.TryGetValue(array[0], out Type type) || !字段列表.TryGetValue(array[0], out FieldInfo[] fields))
            {
                MainForm.AddCommandLog("<= @" + array[0] + " is not a valid GM command, use @View");
                cmd = null;
                return false;
            }

            int expectedLength = fields.Length;

            for (var i = fields.Length - 1; i >= 0; i--)
            {
                var field = fields[i];
                var attr = field.GetCustomAttribute<FieldAttribute>();
                if (attr == null || !attr.IsOptional) break;
                expectedLength--;
            }

            if (array.Length <= expectedLength)
            {
                MainForm.AddCommandLog("<= Parameter length error, please see format: " + 命令格式[array[0]]);
                cmd = null;
                return false;
            }

            cmd = Activator.CreateInstance(type) as GMCommand;

            for (int i = 0; i < fields.Length; i++)
            {
                if (array.Length <= i + 1) continue;

                try
                {
                    var fieldType = fields[i].FieldType;

                    if (fieldType.IsGenericType && fieldType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        fieldType = fieldType.GetGenericArguments()[0];

                    fields[i].SetValue(cmd, ParseValue[fieldType](array[i + 1]));
                }
                catch
                {
                    MainForm.AddCommandLog($"<= Parameter conversion error. The string cannot be converted to '{array[i + 1]}' Convert to parameters '{fields[i].Name}' Data type required");
                    cmd = null;
                    return false;
                }
            }
            return true;
        }


        public abstract void Execute();


        public abstract ExecutionWay ExecutionWay { get; }


        protected GMCommand()
        {


        }


        private static readonly Dictionary<string, Type> 命令字典;


        private static readonly Dictionary<string, FieldInfo[]> 字段列表;


        public static readonly Dictionary<Type, Func<string, object>> ParseValue;


        public static readonly Dictionary<string, string> 命令格式;
    }
}
