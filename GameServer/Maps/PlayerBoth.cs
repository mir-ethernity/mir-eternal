using System;
using System.Collections.Generic;
using System.IO;
using GameServer.Data;

namespace GameServer.Maps
{

    public sealed class PlayerBoth
    {

        public PlayerBoth()
        {


            this.摊位状态 = 1;
            this.物品数量 = new Dictionary<ItemData, int>();
            this.物品单价 = new Dictionary<ItemData, int>();
            this.摊位物品 = new Dictionary<byte, ItemData>();
        }


        public long 物品总价()
        {
            long num = 0L;
            foreach (ItemData key in this.摊位物品.Values)
            {
                num += (long)this.物品数量[key] * (long)this.物品单价[key];
            }
            return num;
        }


        public byte[] 摊位描述()
        {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
            binaryWriter.Write((byte)this.摊位物品.Count);
            foreach (KeyValuePair<byte, ItemData> keyValuePair in this.摊位物品)
            {
                binaryWriter.Write(keyValuePair.Key);
                binaryWriter.Write(this.物品单价[keyValuePair.Value]);
                binaryWriter.Write(0);
                binaryWriter.Write(0);
                binaryWriter.Write(keyValuePair.Value.字节描述(this.物品数量[keyValuePair.Value]));
            }
            return memoryStream.ToArray();
        }


        public byte 摊位状态;


        public string 摊位名字;


        public Dictionary<ItemData, int> 物品数量;


        public Dictionary<ItemData, int> 物品单价;


        public Dictionary<byte, ItemData> 摊位物品;
    }
}
