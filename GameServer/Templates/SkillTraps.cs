using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	public sealed class SkillTraps
	{
		public static Dictionary<string, SkillTraps> DataSheet;

		public string Name;
		public ushort Id;
		public ushort GroupId;
		public ObjectSize Size;
		public ushort BindingLevel;
		public bool AllowStacking;
		public int Duration;
		public bool ExtendedDuration;
		public bool SkillLevelDelay;
		public int ExtendedTimePerLevel;
		public bool PlayerStatDelay;
		public GameObjectStats BoundPlayerStat;
		public float StatDelayFactor;
		public bool HasSpecificInscriptionDelay;
		public InscriptionSkill BindInscriptionSkill;
		public int SpecificInscriptionSkills;
		public int InscriptionExtendedTime;
		public bool CanMove;
		public ushort MoveSpeed;
		public byte LimitMoveSteps;
		public bool MoveInCurrentDirection;
		public bool ActivelyPursueEnemy;
		public byte PursuitRange;
		public string PassiveTriggerSkill;
		public bool RetriggeringIsProhibited;
		public SpecifyTargetType PassiveTargetType;
		public GameObjectType PassiveObjectType;
		public GameObjectRelationship PassiveType;
		public string ActivelyTriggerSkills;
		public ushort ActivelyTriggerInterval;
		public ushort ActivelyTriggerDelay;

		public static void LoadData()
		{
			DataSheet = new Dictionary<string, SkillTraps>();
			string text = Config.GameDataPath + "\\System\\Skills\\Trap\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(SkillTraps)))
				{
					DataSheet.Add(((SkillTraps)obj).Name, (SkillTraps)obj);
				}
			}
		}
	}
}
