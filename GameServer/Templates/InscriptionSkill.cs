using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	public sealed class InscriptionSkill
	{
		public static Dictionary<ushort, InscriptionSkill> DataSheet;
		private static Dictionary<byte, List<InscriptionSkill>> _probabilityTable;

		public string SkillName;
		public GameObjectRace Race;
		public ushort SkillId;
		public byte Id;
		public byte SkillCount;
		public ushort PeriodCount;
		public bool PassiveSkill;
		public byte Quality;
		public int Probability;
		public bool BroadcastNotification;
		public bool RemoveOnDie;
		public string Description;
		public byte[] MinPlayerLevel;
		public ushort[] MinSkillExp;
		public int[] SkillCombatBonus;
		public InscriptionStat[] StatsBonus;
		public List<ushort> ComesWithBuff;
		public List<ushort> PassiveSkills;
		public List<string> MainSkills;
		public List<string> SwitchSkills;

		private Dictionary<GameObjectStats, int>[] _statsBonus;

		public ushort Index
		{
			get
			{
				return (ushort)(SkillId * 10 + (ushort)Id);
			}
		}

		public Dictionary<GameObjectStats, int>[] StatsBonusDictionary
		{
			get
			{
				if (_statsBonus != null)
				{
					return _statsBonus;
				}
				_statsBonus = new Dictionary<GameObjectStats, int>[]
				{
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>()
				};
				if (StatsBonus != null)
				{
					foreach (InscriptionStat 铭文Stat in StatsBonus)
					{
						_statsBonus[0][铭文Stat.Stat] = 铭文Stat.Level0;
						_statsBonus[1][铭文Stat.Stat] = 铭文Stat.Level1;
						_statsBonus[2][铭文Stat.Stat] = 铭文Stat.Level2;
						_statsBonus[3][铭文Stat.Stat] = 铭文Stat.Level3;
					}
				}
				return _statsBonus;
			}
		}

		public static InscriptionSkill RandomWashing(byte cleanUpRace)
		{
			List<InscriptionSkill> list;
			if (_probabilityTable.TryGetValue(cleanUpRace, out list) && list.Count > 0)
				return list[MainProcess.RandomNumber.Next(list.Count)];
			return null;
		}
		
		public static void LoadData()
		{
			DataSheet = new Dictionary<ushort, InscriptionSkill>();
			string text = Config.GameDataPath + "\\System\\Skills\\Inscriptions\\";
			
			if (Directory.Exists(text))
			{
				foreach (var obj in Serializer.Deserialize<InscriptionSkill>(text))
					DataSheet.Add(obj.Index, obj);
			}

            var dictionary = new Dictionary<byte, List<InscriptionSkill>>
            {
                [0] = new List<InscriptionSkill>(),
                [1] = new List<InscriptionSkill>(),
                [2] = new List<InscriptionSkill>(),
                [3] = new List<InscriptionSkill>(),
                [4] = new List<InscriptionSkill>(),
                [5] = new List<InscriptionSkill>()
            };

            _probabilityTable = dictionary;
			foreach (InscriptionSkill skill in DataSheet.Values)
			{
				if (skill.Id != 0)
				{
					for (int j = 0; j < skill.Probability; j++)
					{
						_probabilityTable[(byte)skill.Race].Add(skill);
					}
				}
			}
			foreach (var list in _probabilityTable.Values)
			{
				for (int k = 0; k < list.Count; k++)
				{
					InscriptionSkill value = list[k];
					int index = MainProcess.RandomNumber.Next(list.Count);
					list[k] = list[index];
					list[index] = value;
				}
			}
		}
	}
}
