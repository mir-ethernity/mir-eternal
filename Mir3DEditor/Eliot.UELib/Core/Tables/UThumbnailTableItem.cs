using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;

namespace UELib
{
    public sealed class UThumbnailTableItem : UObjectTableItem, IUnrealSerializableClass
    {
        public string OwnerName;
        public string RefName;
        public int RefId;

        public void Deserialize(IUnrealStream stream)
        {
            OwnerName = stream.ReadText();
            RefName = stream.ReadText();
            RefId = stream.ReadInt32();

            DeserializeLogger.Log($"[UThumbnailTableItem] OwnerName: {OwnerName}, RefName: {RefName}, RefId: {RefId}");
        }

        public void Serialize(IUnrealStream stream)
        {
            stream.Write(OwnerName);
            stream.Write(RefName);
            stream.Write(RefId);
        }
    }
}