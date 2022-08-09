using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace AccountServer
{
	public static class Serializer
	{		
		public static string Serialize(object O)
		{
			return JsonConvert.SerializeObject(O, Serializer.GlobalSettings);
		}		
		public static object[] Deserialize(string directoryPath, Type type)
		{
			List<object> list = new List<object>();
			FileInfo[] files = new DirectoryInfo(directoryPath).GetFiles();
			for (int i = 0; i < files.Length; i++)
			{
				object obj = JsonConvert.DeserializeObject(File.ReadAllText(files[i].FullName), type, Serializer.GlobalSettings);
				if (obj != null)
				{
					list.Add(obj);
				}
			}
			return list.ToArray();
		}
		
		private static readonly JsonSerializerSettings GlobalSettings = new JsonSerializerSettings
		{
			DefaultValueHandling = DefaultValueHandling.Ignore,
			NullValueHandling = NullValueHandling.Ignore,
			TypeNameHandling = TypeNameHandling.Auto,
			Formatting = Formatting.Indented
		};
	}
}
