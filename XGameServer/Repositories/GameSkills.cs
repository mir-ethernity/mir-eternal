using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	public sealed class GameSkills
	{
		public static Dictionary<string, GameSkills> DataSheet;

		public string SkillName;
		public GameObjectRace Race;
		public GameSkillType SkillType;
		public ushort OwnSkillId;
		public byte Id;
		public byte GroupId;
		public ushort BindingLevelId;
		public bool NeedMoveForward;
		public byte MaxDistance;
		public bool CalculateLuckyProbability;
		public float CalculateTriggerProbability;
		public GameObjectStats StatBoostProbability;
		public float StatBoostFactor;
		public bool CheckBusyGreen;
		public bool CheckStiff;
		public bool CheckOccupationalWeapons;
		public bool CheckPassiveTags;
		public bool CheckSkillMarks;
		public bool CheckSkillCount;
		public ushort SkillTagId;
		public int[] NeedConsumeMagic;
		public HashSet<int> NeedConsumeItems;
		public int NeedConsumeItemsQuantity;
		public int GearDeductionPoints;
		public ushort ValidateLearnedSkills;
		public byte VerficationSkillInscription;
		public ushort VerifyPlayerBuff;
		public int PlayerBuffLayer;
		public SpecifyTargetType VerifyTargetType;
		public ushort VerifyTargetBuff;
		public int TargetBuffLayers;
		public SortedDictionary<int, SkillTask> Nodes;

		public GameSkills()
		{
			PlayerBuffLayer = 1;
			TargetBuffLayers = 1;
			Nodes = new SortedDictionary<int, SkillTask>();
		}

		public static void LoadData()
		{
			DataSheet = new Dictionary<string, GameSkills>();
			var text = Path.Combine(Config.GameDataPath, "System", "Skills", "Skills");
			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(GameSkills)))
				{
					DataSheet.Add(((GameSkills)obj).SkillName, (GameSkills)obj);
				}
			}
		}
	}
}
