using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	public sealed class Monsters
	{
		public static Dictionary<string, Monsters> DataSheet;

		public string MonsterName;
		public ushort Id;
		public byte Level;
		public ObjectSize Size;
		public MonsterRaceType Race;
		public MonsterLevelType Category;
		public bool ForbbidenMove;
		public bool OutWarAutomaticPetrochemical;
		public ushort PetrochemicalStatusId;
		public bool VisibleStealthTargets;
		public bool CanBeDrivenBySkills;
		public bool CanBeControlledBySkills;
		public bool CanBeSeducedBySkills;
		public float BaseTemptationProbability;
		public ushort MoveInterval;
		public ushort RoamInterval;
		public ushort CorpsePreservationDuration;
		public bool ActiveAttackTarget;
		public byte RangeHate;
		public ushort HateTime;
		public string NormalAttackSkills;
		public string ProbabilityTriggerSkills;
		public string EnterCombatSkills;
		public string ExitCombatSkills;
		public string MoveReleaseSkill;
		public string BirthReleaseSkill;
		public string DeathReleaseSkill;
		public BasicStats[] Stats;
		public GrowthStat[] Grows;
		public InheritStat[] InheritsStats;
		public ushort ProvideExperience;
		public List<MonsterDrop> Drops;
		public Dictionary<GameItems, long> DropStats = new Dictionary<GameItems, long>();

		private Dictionary<GameObjectStats, int> _basicStats;
		private Dictionary<GameObjectStats, int>[] _growStats;

		public static void LoadData()
		{
			DataSheet = new Dictionary<string, Monsters>();
			string text = Config.GameDataPath + "\\System\\Npc\\Monsters\\";
			if (Directory.Exists(text))
			{
				object[] array = Serializer.Deserialize(text, typeof(Monsters));
				for (int i = 0; i < array.Length; i++)
				{
					Monsters monster = array[i] as Monsters;
					if (monster != null)
					{
						DataSheet.Add(monster.MonsterName, monster);
					}
				}
			}
		}
		
		public Dictionary<GameObjectStats, int> BasicStats
		{
			get
			{
				if (_basicStats != null)
				{
					return _basicStats;
				}
				_basicStats = new Dictionary<GameObjectStats, int>();
				if (Stats != null)
				{
					foreach (BasicStats start in Stats)
					{
						_basicStats[start.Stat] = start.Value;
					}
				}
				return _basicStats;
			}
		}
		
		public Dictionary<GameObjectStats, int>[] GrowStats
		{
			get
			{
				if (_growStats != null)
				{
					return _growStats;
				}
				_growStats = new Dictionary<GameObjectStats, int>[]
				{
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>()
				};
				if (Grows != null)
				{
					foreach (GrowthStat stat in Grows)
					{
						_growStats[0][stat.Stat] = stat.Level0;
						_growStats[1][stat.Stat] = stat.Level1;
						_growStats[2][stat.Stat] = stat.Level2;
						_growStats[3][stat.Stat] = stat.Level3;
						_growStats[4][stat.Stat] = stat.Level4;
						_growStats[5][stat.Stat] = stat.Level5;
						_growStats[6][stat.Stat] = stat.Level6;
						_growStats[7][stat.Stat] = stat.Level7;
					}
				}
				return _growStats;
			}
		}
	}
}
