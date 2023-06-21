using System;
using System.Linq;

namespace UELib
{
    public struct UTextureInfo : IUnrealSerializableClass
    {
        public int U1;
        public int U2;
        public int U3;
        public uint U4;
        public uint U5;
        public int[] Data;

        private const int VNetObjectsCount = 322;

        public void Serialize(IUnrealStream stream)
        {
            stream.Write(U1);
            stream.Write(U2);
            stream.Write(U3);
            stream.Write(U4);
            stream.Write(U5);
            stream.Write((int)Data.Length);
            for (var i = 0; i < Data.Length; i++)
                stream.Write(Data[i]);
        }

        public void Deserialize(IUnrealStream stream)
        {
            U1 = stream.ReadInt32();
            U2 = stream.ReadInt32();
            U3 = stream.ReadInt32();
            U4 = stream.ReadUInt32();
            U5 = stream.ReadUInt32();

            int count2 = stream.ReadInt32();
            Data = new int[count2];
            for (var i = 0; i < count2; i++)
                Data[i] = stream.ReadInt32();

            DeserializeLogger.Log($"[TextureInfo] U1: {U1}, U2: {U2}, U3: {U3}, U4: {U4}, U5: {U5}, Pixel Len: {count2}, RGBA: {string.Join(",", Data.Select(x => BitConverter.ToString(BitConverter.GetBytes(x))).ToArray())}");
        }
    }
}