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
	// Token: 0x0200028D RID: 653
	public static class 序列化类
	{
		// Token: 0x0600069A RID: 1690 RVA: 0x000311D8 File Offset: 0x0002F3D8
		static 序列化类()
		{
			
			序列化类.全局设置 = new JsonSerializerSettings
			{
				DefaultValueHandling = DefaultValueHandling.Ignore,
				NullValueHandling = NullValueHandling.Ignore,
				TypeNameHandling = TypeNameHandling.Auto,
				Formatting = Formatting.Indented
			};
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary["Assembly-CSharp"] = "GameServer";
			序列化类.定向字典 = dictionary;
			foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
			{
				if (type.IsSubclassOf(typeof(技能任务)))
				{
					序列化类.定向字典[type.Name] = type.FullName;
				}
			}
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x00031270 File Offset: 0x0002F470
		public static object[] 反序列化(string 文件夹, Type 类型)
		{
			ConcurrentQueue<object> concurrentQueue = new ConcurrentQueue<object>();
			if (Directory.Exists(文件夹))
			{
				FileInfo[] files = new DirectoryInfo(文件夹).GetFiles();
				for (int i = 0; i < files.Length; i++)
				{
					string text = File.ReadAllText(files[i].FullName);
					foreach (KeyValuePair<string, string> keyValuePair in 序列化类.定向字典)
					{
						text = text.Replace(keyValuePair.Key, keyValuePair.Value);
					}
					object obj = JsonConvert.DeserializeObject(text, 类型, 序列化类.全局设置);
					if (obj != null)
					{
						concurrentQueue.Enqueue(obj);
					}
				}
			}
			return concurrentQueue.ToArray();
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x00005EC2 File Offset: 0x000040C2
		public static byte[] 压缩字节(byte[] data)
		{
			MemoryStream memoryStream = new MemoryStream();
			DeflaterOutputStream deflaterOutputStream = new DeflaterOutputStream(memoryStream);
			deflaterOutputStream.Write(data, 0, data.Length);
			deflaterOutputStream.Close();
			return memoryStream.ToArray();
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x00031334 File Offset: 0x0002F534
		public static byte[] 解压字节(byte[] data)
		{
			Stream baseInputStream = new MemoryStream(data);
			MemoryStream memoryStream = new MemoryStream();
			new InflaterInputStream(baseInputStream).CopyTo(memoryStream);
			return memoryStream.ToArray();
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x00005EE4 File Offset: 0x000040E4
		public static void 备份文件夹(string 源目录, string 文件名)
		{
			if (!Directory.Exists(源目录))
			{
				return;
			}
			new FastZip().CreateZip(文件名, 源目录, false, "");
		}

		// Token: 0x040009B4 RID: 2484
		private static readonly JsonSerializerSettings 全局设置;

		// Token: 0x040009B5 RID: 2485
		private static readonly Dictionary<string, string> 定向字典;
	}
}
