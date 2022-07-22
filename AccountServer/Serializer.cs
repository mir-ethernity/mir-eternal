using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace AccountServer
{
	// Token: 0x02000005 RID: 5
	public static class Serializer
	{
		// Token: 0x0600001E RID: 30 RVA: 0x00003880 File Offset: 0x00001A80
		public static string Serialize(object O)
		{
			return JsonConvert.SerializeObject(O, Serializer.GlobalSettings);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003890 File Offset: 0x00001A90
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

		// Token: 0x04000024 RID: 36
		private static readonly JsonSerializerSettings GlobalSettings = new JsonSerializerSettings
		{
			DefaultValueHandling = DefaultValueHandling.Ignore,
			NullValueHandling = NullValueHandling.Ignore,
			TypeNameHandling = TypeNameHandling.Auto,
			Formatting = Formatting.Indented
		};
	}
}
