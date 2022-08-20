using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameServer.Templates
{
	
	public sealed class CharacterProgression
	{
		
		static CharacterProgression()
		{
			
			Dictionary<byte, long> dictionary = new Dictionary<byte, long>();
			dictionary[1] = 100;
			dictionary[2] = 200;
			dictionary[3] = 300;
			dictionary[4] = 400;
			dictionary[5] = 600;
			dictionary[6] = 900;
			dictionary[7] = 1200;
			dictionary[8] = 1700;
			dictionary[9] = 2500;
			dictionary[10] = 6000;
			dictionary[11] = 8000;
			dictionary[12] = 10000;
			dictionary[13] = 15000;
			dictionary[14] = 30000;
			dictionary[15] = 40000;
			dictionary[16] = 50000;
			dictionary[17] = 70000;
			dictionary[18] = 100000;
			dictionary[19] = 120000;
			dictionary[20] = 140000;
			dictionary[21] = 250000;
			dictionary[22] = 300000;
			dictionary[23] = 350000;
			dictionary[24] = 400000;
			dictionary[25] = 500000;
			dictionary[26] = 700000;
			dictionary[27] = 1000000;
			dictionary[28] = 1400000;
			dictionary[29] = 1800000;
			dictionary[30] = 2000000;
			dictionary[31] = 2400000;
			dictionary[32] = 2800000;
			dictionary[33] = 3200000;
			dictionary[34] = 3600000;
			dictionary[35] = 4000000;
			dictionary[36] = 4800000;
			dictionary[37] = 5600000;
			dictionary[38] = 8200000;
			dictionary[39] = 9000000;
			dictionary[40] = 12000000;
			dictionary[41] = 16000000;
			dictionary[42] = 30000000;
			dictionary[43] = 50000000;
			dictionary[44] = 80000000;
			dictionary[45] = 120000000;
			dictionary[46] = 280000000;
			dictionary[47] = 360000000;
			dictionary[48] = 400000000;
			dictionary[49] = 420000000;
			dictionary[50] = 430000000;
			dictionary[51] = 440000000;
			dictionary[52] = 460000000;
			dictionary[53] = 480000000;
			dictionary[54] = 500000000;
			dictionary[55] = 520000000;
			dictionary[56] = 550000000;
			dictionary[57] = 600000000;
			dictionary[58] = 700000000;
			dictionary[59] = 800000000;
			CharacterProgression.MaxExpTable = dictionary;
			CharacterProgression.宠物升级经验 = new ushort[]
			{
				5,
				10,
				15,
				20,
				25,
				30,
				35,
				40,
				45
			};
			CharacterProgression.DataSheet = new Dictionary<int, Dictionary<GameObjectStats, int>>();
			string path = Config.GameDataPath + "\\System\\GrowthAttribute.txt";
			string[] array = Regex.Split(File.ReadAllText(path).Trim(new char[]
			{
				'\r',
				'\n',
				'\r'
			}), "\r\n", RegexOptions.IgnoreCase);
            Dictionary<string, int> dictionary2 = array[0].Split(new char[]
            {
                '\t'
            }).ToDictionary((string K) => K, (string V) => Array.IndexOf<string>((string[])array[0].Split(new char[]
            {
                '\t'
            }), V));
			for (int i = 1; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					'\t'
				});
				if (array2.Length > 1)
				{
					Dictionary<GameObjectStats, int> dictionary3 = new Dictionary<GameObjectStats, int>();
					int num = (int)((GameObjectRace)Enum.Parse(typeof(GameObjectRace), array2[0]));
					int num2 = Convert.ToInt32(array2[1]);
					int key = num * 256 + num2;
					for (int j = 2; j < array[0].Split(new char[]
					{
						'\t'
					}).Length; j++)
					{
						GameObjectStats GameObjectProperties;
						if (Enum.TryParse<GameObjectStats>(array[0].Split(new char[]
						{
							'\t'
						})[j], out GameObjectProperties) && Enum.IsDefined(typeof(GameObjectStats), GameObjectProperties))
						{
							dictionary3[GameObjectProperties] = Convert.ToInt32(array2[dictionary2[GameObjectProperties.ToString()]]);
						}
					}
					CharacterProgression.DataSheet.Add(key, dictionary3);
				}
			}
		}

		
		public static Dictionary<GameObjectStats, int> GetData(GameObjectRace 职业, byte 等级)
		{
			return CharacterProgression.DataSheet[(int)((byte)职业) * 256 + (int)等级];
		}

		
		public CharacterProgression()
		{
			
			
		}

		
		public static Dictionary<int, Dictionary<GameObjectStats, int>> DataSheet;

		
		public static readonly Dictionary<byte, long> MaxExpTable;

		
		public static readonly ushort[] 宠物升级经验;
	}
}
