using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameServer.Templates
{
	public sealed class NpcDialogs
	{
		public static Dictionary<int, string> DataSheet;
		public static Dictionary<int, byte[]> DataById;

		public int Id;
		public string Content;

		public static byte[] GetBufferFromDialogId(int npcDialogId)
		{
			byte[] result;
			if (DataById.TryGetValue(npcDialogId, out result))
			{
				return result;
			}
			string str;
			if (DataSheet.TryGetValue(npcDialogId, out str))
			{
				return DataById[npcDialogId] = Encoding.UTF8.GetBytes(str + "\0");
			}
			return new byte[0];
		}

		
		public static byte[] CombineDialog(int npcDialogId, string content)
		{
			byte[] second;
			if (DataById.TryGetValue(npcDialogId, out second))
			{
				return Encoding.UTF8.GetBytes(content).Concat(second).ToArray<byte>();
			}
			string str;
			if (DataSheet.TryGetValue(npcDialogId, out str))
			{
				return Encoding.UTF8.GetBytes(content).Concat(DataById[npcDialogId] = Encoding.UTF8.GetBytes(str + "\0")).ToArray<byte>();
			}
			return new byte[0];
		}

		
		public static void LoadData()
		{
			DataSheet = new Dictionary<int, string>();
			DataById = new Dictionary<int, byte[]>();
			string text = Config.GameDataPath + "\\System\\Npc\\Dialogs\\";

			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(NpcDialogs)))
				{
					DataSheet.Add(((NpcDialogs)obj).Id, ((NpcDialogs)obj).Content);
				}
			}
		}
	}
}
