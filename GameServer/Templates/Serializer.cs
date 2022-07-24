using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using Newtonsoft.Json;

namespace GameServer.Templates
{
	
	public static class Serializer
	{
		static Serializer()
		{
			
			Serializer.全局设置 = new JsonSerializerSettings
			{
				DefaultValueHandling = DefaultValueHandling.Ignore,
				NullValueHandling = NullValueHandling.Ignore,
				TypeNameHandling = TypeNameHandling.Auto,
				Formatting = Formatting.Indented
			};
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary["Assembly-CSharp"] = "GameServer";
			Serializer.定向字典 = dictionary;
			foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
			{
				if (type.IsSubclassOf(typeof(SkillTask)))
				{
					Serializer.定向字典[type.Name] = type.FullName;
				}
			}
		}
		
		public static object[] Deserialize(string 文件夹, Type 类型)
		{
			ConcurrentQueue<object> concurrentQueue = new ConcurrentQueue<object>();
			if (Directory.Exists(文件夹))
			{
				FileInfo[] files = new DirectoryInfo(文件夹).GetFiles();
				for (int i = 0; i < files.Length; i++)
				{
					string text = File.ReadAllText(files[i].FullName);
					foreach (KeyValuePair<string, string> keyValuePair in Serializer.定向字典)
					{
						text = text.Replace(keyValuePair.Key, keyValuePair.Value);
					}
					object obj = JsonConvert.DeserializeObject(text, 类型, Serializer.全局设置);
					if (obj != null)
					{
						concurrentQueue.Enqueue(obj);
					}
				}
			}
			return concurrentQueue.ToArray();
		}
		
		public static byte[] Decompress(byte[] data)
		{
			MemoryStream memoryStream = new MemoryStream();
			DeflaterOutputStream deflaterOutputStream = new DeflaterOutputStream(memoryStream);
			deflaterOutputStream.Write(data, 0, data.Length);
			deflaterOutputStream.Close();
			return memoryStream.ToArray();
		}
		public static byte[] 解压字节(byte[] data)
		{
			Stream baseInputStream = new MemoryStream(data);
			MemoryStream memoryStream = new MemoryStream();
			new InflaterInputStream(baseInputStream).CopyTo(memoryStream);
			return memoryStream.ToArray();
		}
		
		public static void 备份文件夹(string 源目录, string 文件名)
		{
			if (!Directory.Exists(源目录))
			{
				return;
			}
			new FastZip().CreateZip(文件名, 源目录, false, "");
		}
		
		private static readonly JsonSerializerSettings 全局设置;
		private static readonly Dictionary<string, string> 定向字典;
	}
}
