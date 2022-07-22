using System;
using System.Collections.Generic;
using System.IO;
using GameServer.Data;

namespace GameServer.Maps
{
	// Token: 0x020002EB RID: 747
	public sealed class PlayerBoth
	{
		// Token: 0x060009FE RID: 2558 RVA: 0x00007A0E File Offset: 0x00005C0E
		public PlayerBoth()
		{
			
			
			this.摊位状态 = 1;
			this.物品数量 = new Dictionary<ItemData, int>();
			this.物品单价 = new Dictionary<ItemData, int>();
			this.摊位物品 = new Dictionary<byte, ItemData>();
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x00062D80 File Offset: 0x00060F80
		public long 物品总价()
		{
			long num = 0L;
			foreach (ItemData key in this.摊位物品.Values)
			{
				num += (long)this.物品数量[key] * (long)this.物品单价[key];
			}
			return num;
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x00062DFC File Offset: 0x00060FFC
		public byte[] 摊位描述()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write((byte)this.摊位物品.Count);
					foreach (KeyValuePair<byte, ItemData> keyValuePair in this.摊位物品)
					{
						binaryWriter.Write(keyValuePair.Key);
						binaryWriter.Write(this.物品单价[keyValuePair.Value]);
						binaryWriter.Write(0);
						binaryWriter.Write(0);
						binaryWriter.Write(keyValuePair.Value.字节描述(this.物品数量[keyValuePair.Value]));
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		// Token: 0x04000D5C RID: 3420
		public byte 摊位状态;

		// Token: 0x04000D5D RID: 3421
		public string 摊位名字;

		// Token: 0x04000D5E RID: 3422
		public Dictionary<ItemData, int> 物品数量;

		// Token: 0x04000D5F RID: 3423
		public Dictionary<ItemData, int> 物品单价;

		// Token: 0x04000D60 RID: 3424
		public Dictionary<byte, ItemData> 摊位物品;
	}
}
