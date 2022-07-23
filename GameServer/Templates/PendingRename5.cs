using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameServer.Maps;

namespace GameServer.Templates
{
	
	public class 命中详情
	{
		
		public 命中详情(MapObject 目标)
		{
			
			
			this.技能目标 = 目标;
		}

		
		public 命中详情(MapObject 目标, 技能命中反馈 反馈)
		{
			
			
			this.技能目标 = 目标;
			this.技能反馈 = 反馈;
		}

		
		public static byte[] 命中描述(Dictionary<int, 命中详情> 命中列表, int 命中延迟)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write((byte)命中列表.Count);
					foreach (KeyValuePair<int, 命中详情> keyValuePair in 命中列表.ToList<KeyValuePair<int, 命中详情>>())
					{
						binaryWriter.Write(keyValuePair.Value.技能目标.地图编号);
						binaryWriter.Write((ushort)keyValuePair.Value.技能反馈);
						binaryWriter.Write((ushort)命中延迟);
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		
		public int 技能伤害;

		
		public ushort 招架伤害;

		
		public MapObject 技能目标;

		
		public 技能命中反馈 技能反馈;
	}
}
