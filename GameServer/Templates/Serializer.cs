using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using Newtonsoft.Json;

namespace GameServer.Templates
{

    public static class Serializer
    {
        static Serializer()
        {
            JsonOptions = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };

            var dictionary = new Dictionary<string, string>
            {
                ["Assembly-CSharp"] = "GameServer"
            };

            TypesOfSkill = dictionary;
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsSubclassOf(typeof(SkillTask)))
                {
                    TypesOfSkill[type.Name] = type.FullName;
                }
            }
        }

        public static object[] Deserialize(string folder, Type type)
        {
            ConcurrentQueue<object> concurrentQueue = new ConcurrentQueue<object>();
            if (Directory.Exists(folder))
            {
                FileInfo[] files = new DirectoryInfo(folder).GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    string text = File.ReadAllText(files[i].FullName);
                    foreach (KeyValuePair<string, string> keyValuePair in TypesOfSkill)
                    {
                        text = text.Replace(keyValuePair.Key, keyValuePair.Value);
                    }
                    object obj = JsonConvert.DeserializeObject(text, type, JsonOptions);
                    if (obj != null)
                    {
                        concurrentQueue.Enqueue(obj);
                    }
                }
            }
            return concurrentQueue.ToArray();
        }

        public static TItem[] Deserialize<TItem>(string folder) where TItem : class, new()
        {
            var output = new ConcurrentBag<TItem>();

            if (Directory.Exists(folder))
            {
                FileInfo[] files = new DirectoryInfo(folder).GetFiles();

                Parallel.ForEach(files, file =>
                {
                    string text = File.ReadAllText(file.FullName);
                    foreach (KeyValuePair<string, string> keyValuePair in TypesOfSkill)
                    {
                        text = text.Replace(keyValuePair.Key, keyValuePair.Value);
                    }
                    var obj = JsonConvert.DeserializeObject<TItem>(text, JsonOptions);

                    if (obj != null)
                    {
                        output.Add(obj);
                    }
                });

            }
            return output.ToArray();
        }

        public static byte[] Decompress(byte[] data)
        {
            MemoryStream memoryStream = new MemoryStream();
            DeflaterOutputStream deflaterOutputStream = new DeflaterOutputStream(memoryStream);
            deflaterOutputStream.Write(data, 0, data.Length);
            deflaterOutputStream.Close();
            return memoryStream.ToArray();
        }

        public static byte[] Compress(byte[] data)
        {
            Stream baseInputStream = new MemoryStream(data);
            MemoryStream memoryStream = new MemoryStream();
            new InflaterInputStream(baseInputStream).CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        public static void SaveBackup(string sourceDir, string zipPath)
        {
            if (!Directory.Exists(sourceDir))
                return;
            new FastZip().CreateZip(zipPath, sourceDir, false, "");
        }

        private static readonly JsonSerializerSettings JsonOptions;
        private static readonly Dictionary<string, string> TypesOfSkill;
    }
}
