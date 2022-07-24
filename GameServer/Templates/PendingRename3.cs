using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	
	public sealed class 技能陷阱
	{
		
		public static void LoadData()
		{
			技能陷阱.DataSheet = new Dictionary<string, 技能陷阱>();
			string text = CustomClass.GameDataPath + "\\System\\Skills\\Trap\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(技能陷阱)))
				{
					技能陷阱.DataSheet.Add(((技能陷阱)obj).陷阱名字, (技能陷阱)obj);
				}
			}
		}

		
		public 技能陷阱()
		{
			
			
		}

		
		public static Dictionary<string, 技能陷阱> DataSheet;

		
		public string 陷阱名字;

		
		public ushort 陷阱编号;

		
		public ushort GroupId;

		
		public MonsterSize 陷阱体型;

		
		public ushort 绑定等级;

		
		public bool 陷阱允许叠加;

		
		public int 陷阱持续时间;

		
		public bool ExtendedDuration;

		
		public bool SkillLevelDelay;

		
		public int ExtendedTimePerLevel;

		
		public bool PlayerStatDelay;

		
		public GameObjectStats BoundPlayerStat;

		
		public float StatDelayFactor;

		
		public bool HasSpecificInscriptionDelay;

		
		public 铭文技能 绑定铭文技能;

		
		public int SpecificInscriptionSkills;

		
		public int InscriptionExtendedTime;

		
		public bool 陷阱能否移动;

		
		public ushort 陷阱移动速度;

		
		public byte 限制移动次数;

		
		public bool 当前方向移动;

		
		public bool 主动追击敌人;

		
		public byte 陷阱追击范围;

		
		public string 被动触发技能;

		
		public bool 禁止重复触发;

		
		public 指定目标类型 被动指定类型;

		
		public GameObjectType 被动限定类型;

		
		public 游戏对象关系 被动限定关系;

		
		public string 主动触发技能;

		
		public ushort 主动触发间隔;

		
		public ushort 主动触发延迟;
	}
}
