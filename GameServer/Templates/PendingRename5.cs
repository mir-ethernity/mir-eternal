using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameServer.Maps;

namespace GameServer.Templates
{
	
	public class HitDetail
	{
		public int Damage;
		public ushort MissDamage;
		public MapObject Object;
		public SkillHitFeedback Feedback;

		public HitDetail(MapObject obj, SkillHitFeedback feedback = default)
		{
			Object = obj;
			Feedback = feedback;
		}
		
		public static byte[] GetHitDescription(Dictionary<int, HitDetail> hitList, int hitDelay)
		{
            using var memoryStream = new MemoryStream();
            using var binaryWriter = new BinaryWriter(memoryStream);
            
			binaryWriter.Write((byte)hitList.Count);
            foreach (var item in hitList.ToList())
            {
                binaryWriter.Write(item.Value.Object.MapId);
                binaryWriter.Write((ushort)item.Value.Feedback);
                binaryWriter.Write((ushort)hitDelay);
            }
            return memoryStream.ToArray();
        }
	}
}
