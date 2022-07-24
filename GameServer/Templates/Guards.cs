using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	public sealed class Guards
	{
		public static Dictionary<ushort, Guards> DataSheet;

		public string Name;
		public ushort GuardNumber;
		public byte Level;
		public bool Nothingness;
		public bool CanBeInjured;
		public int CorpsePreservation;
		public int RevivalInterval;
		public bool ActiveAttack;
		public byte RangeHate;
		public string BasicAttackSkills;
		public int StoreId;
		public string InterfaceCode;

		public static void LoadData()
		{
			DataSheet = new Dictionary<ushort, Guards>();
			string text = CustomClass.GameDataPath + "\\System\\Npc\\Guards\\";

			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(Guards)))
				{
					DataSheet.Add(((Guards)obj).GuardNumber, (Guards)obj);
				}
			}
		}
	}
}
