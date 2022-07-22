using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameServer.Maps;

namespace GameServer.Templates
{
	// Token: 0x020002A3 RID: 675
	public class 命中详情
	{
		// Token: 0x060006C3 RID: 1731 RVA: 0x00005FBE File Offset: 0x000041BE
		public 命中详情(MapObject 目标)
		{
			
			
			this.技能目标 = 目标;
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x00005FD2 File Offset: 0x000041D2
		public 命中详情(MapObject 目标, 技能命中反馈 反馈)
		{
			
			
			this.技能目标 = 目标;
			this.技能反馈 = 反馈;
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x00034CA0 File Offset: 0x00032EA0
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

		// Token: 0x04000A8A RID: 2698
		public int 技能伤害;

		// Token: 0x04000A8B RID: 2699
		public ushort 招架伤害;

		// Token: 0x04000A8C RID: 2700
		public MapObject 技能目标;

		// Token: 0x04000A8D RID: 2701
		public 技能命中反馈 技能反馈;
	}
}
