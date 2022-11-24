using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;

namespace UELib
{

    /// <summary>
    /// An export table entry, representing a @UObject in a package.
    /// </summary>
    public sealed class UExportTableItem : UObjectTableItem, IUnrealSerializableClass
    {
        private const int VArchetype = 220;
        public const int VObjectFlagsToULONG = 195;
        private const int VSerialSizeConditionless = 249;
        // FIXME: Version?
        public const int VNetObjects = 322;

        #region Serialized Members

        /// <summary>
        /// Object index to the Super(parent) object of structs.
        /// -- Not Fixed
        /// </summary>
        public int SuperIndex { get; private set; }

        [Pure]
        public UObjectTableItem SuperTable => Owner.GetIndexTable(SuperIndex);

        [Pure]
        public string SuperName
        {
            get
            {
                var table = SuperTable;
                return table != null ? table.ObjectName : string.Empty;
            }
        }

        /// <summary>
        /// Object index.
        /// -- Not Fixed
        /// </summary>
        public int ArchetypeIndex { get; private set; }

        [Pure]
        public UObjectTableItem ArchetypeTable => Owner.GetIndexTable(ArchetypeIndex);

        [Pure]
        public string ArchetypeName
        {
            get
            {
                var table = ArchetypeTable;
                return table != null ? table.ObjectName : string.Empty;
            }
        }

        public byte[] NetObjectData { get; private set; }
        public Guid PackageGuid { get; private set; }
        public int PackageFlags { get; private set; }

        /// <summary>
        /// Object flags, such as Public, Protected and Private.
        /// 32bit aligned.
        /// </summary>
        public ulong ObjectFlags;

        /// <summary>
        /// Object size in bytes.
        /// </summary>
        public int SerialSize;

        /// <summary>
        /// Object offset in bytes. Starting from the beginning of a file.
        /// </summary>
        public int SerialOffset;

        public uint ExportFlags;
        //public Dictionary<int, int> Components;
        //public List<int> NetObjects;

        #endregion

        // @Warning - Only supports Official builds.
        public void Serialize(IUnrealStream stream)
        {
            stream.Write(ClassTable.Object);
            stream.Write(SuperTable?.Object);
            stream.Write((int)OuterTable?.Object);

            stream.Write(ObjectName);

            if (stream.Version >= VArchetype)
            {
                stream.Write(ArchetypeIndex);
            }


            stream.Write(stream.Version >= VObjectFlagsToULONG
                ? ObjectFlags
                : (uint)ObjectFlags);

            stream.WriteIndex(SerialSize); // Assumes SerialSize has been updated to @Object's buffer size.

            if (SerialSize > 0 || stream.Version >= VSerialSizeConditionless)
            {
                // SerialOffset has to be set and written after this object has been serialized.
                stream.WriteIndex(SerialOffset); // Assumes the same as @SerialSize comment.
            }

            stream.Write(ExportFlags);

            stream.Write(NetObjectData.Length / 4);
            stream.Write(NetObjectData);

            stream.Write(PackageGuid);

            stream.Write(PackageFlags);
        }

        public void Deserialize(IUnrealStream stream)
        {
            ClassIndex = stream.ReadObjectIndex();
            SuperIndex = stream.ReadObjectIndex();
            OuterIndex = stream.ReadInt32(); // ObjectIndex, though always written as 32bits regardless of build.

            ObjectName = stream.ReadNameReference();
            ArchetypeIndex = stream.ReadInt32();

            _ObjectFlagsOffset = stream.Position;

            ObjectFlags = stream.ReadUInt64();

            SerialSize = stream.ReadIndex();
            if (SerialSize > 0) SerialOffset = stream.ReadIndex();

            ExportFlags = stream.ReadUInt32();


            // Array of objects
            int netObjectCount = stream.ReadInt32();
            NetObjectData = new byte[netObjectCount * 4];
            for (var i = 0; i < NetObjectData.Length; i++)
                NetObjectData[i] = stream.ReadByte();

            PackageGuid = stream.ReadGuid();

            PackageFlags = stream.ReadInt32();
        }

        #region Writing Methods

        private long _ObjectFlagsOffset;

        /// <summary>
        /// Updates the ObjectFlags inside the Stream to the current set ObjectFlags of this Table
        /// </summary>
        [Obsolete]
        public void WriteObjectFlags()
        {
            Owner.Stream.Seek(_ObjectFlagsOffset, SeekOrigin.Begin);
            Owner.Stream.Write((uint)ObjectFlags);
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return ObjectName + "(" + Index + 1 + ")";
        }

        #endregion
    }
}