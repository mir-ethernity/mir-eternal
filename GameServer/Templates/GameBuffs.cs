using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	public sealed class GameBuffs
	{
		public static Dictionary<ushort, GameBuffs> DataSheet;

		public string Name;
		public ushort Id;
		public ushort GroupId;
		public BuffActionType ActionType;
		public BuffOverlayType OverlayType;
		public BuffEffectType Effect;
		public bool SyncClient;
		public bool RemoveOnExpire;
		public bool OnChangeMapRemove;
		public bool OnChangeWeaponRemove;
		public bool OnPlayerDiesRemove;
		public bool OnPlayerDisconnectRemove;
		public ushort BindingSkillLevel;
		public bool RemoveAddCooling;
		public ushort SkillCooldown;
		public byte BuffInitialLayer;
		public byte MaxBuffCount;
		public bool AllowsSynthesis;
		public byte BuffSynthesisLayer;
		public ushort BuffSynthesisId;
		public int ProcessInterval;
		public int ProcessDelay;
		public int Duration;
		public bool ExtendedDuration;
		public ushort FollowedById;
		public ushort AssociatedId;
		public ushort[] RequireBuff;
		public bool SkillLevelDelay;
		public int ExtendedTimePerLevel;
		public bool PlayerStatDelay;
		public GameObjectStats BoundPlayerStat;
		public float StatDelayFactor;
		public bool HasSpecificInscriptionDelay;
		public int SpecificInscriptionSkills;
		public int InscriptionExtendedTime;
		public GameObjectState PlayerState;
		public InscriptionStat[] StatsIncOrDec;
		public SkillDamageType DamageType;
		public int[] DamageBase;
		public float[] DamageFactor;
		public int StrengthenInscriptionId;
		public int StrengthenInscriptionBase;
		public float StrengthenInscriptionFactor;
		public bool EffectRemoved;
		public ushort EffectiveFollowedById;
		public bool FollowUpSkillSource;
		public BuffDetherminationMethod HowJudgeEffect;
		public bool LimitedDamage;
		public int LimitedDamageValue;
		public BuffJudgmentType EffectJudgeType;
		public HashSet<ushort> SpecificSkillId;
		public int[] DamageIncOrDecBase;
		public float[] DamageIncOrDecFactor;
		public string TriggerTrapSkills;
		public ObjectSize NumberTrapsTriggered;
		public byte[] PhysicalRecoveryBase;
		public int TemptationIncreaseDuration;
		public float TemptationIncreaseRate;
		public byte TemptationIncreaseLevel;

		private Dictionary<GameObjectStats, int>[] _baseStatsIncOrDec;

		public static void LoadData()
		{
			DataSheet = new Dictionary<ushort, GameBuffs>();
			string text = Config.GameDataPath + "\\System\\Skills\\Buffs\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(GameBuffs)))
				{
					DataSheet.Add(((GameBuffs)obj).Id, (GameBuffs)obj);
				}
			}
		}
		
		public Dictionary<GameObjectStats, int>[] 基础StatsIncOrDec
		{
			get
			{
				if (_baseStatsIncOrDec != null)
				{
					return _baseStatsIncOrDec;
				}
				_baseStatsIncOrDec = new Dictionary<GameObjectStats, int>[]
				{
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>()
				};
				if (StatsIncOrDec != null)
				{
					foreach (InscriptionStat stat in StatsIncOrDec)
					{
						_baseStatsIncOrDec[0][stat.Stat] = stat.Level0;
						_baseStatsIncOrDec[1][stat.Stat] = stat.Level1;
						_baseStatsIncOrDec[2][stat.Stat] = stat.Level2;
						_baseStatsIncOrDec[3][stat.Stat] = stat.Level3;
					}
				}
				return _baseStatsIncOrDec;
			}
		}

		
	}
}
