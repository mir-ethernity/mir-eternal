using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;

namespace UELib
{
    public sealed class UDependTableItem : UObjectTableItem, IUnrealSerializableClass
    {
        public int ObjectReference;
        public void Deserialize(IUnrealStream stream)
        {
            ObjectReference = stream.ReadInt32();
        }

        public void Serialize(IUnrealStream stream)
        {
            stream.Write(ObjectReference);
        }
    }
}