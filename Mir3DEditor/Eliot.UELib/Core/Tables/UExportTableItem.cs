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

        public int[] NetObjectData { get; private set; }
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
        private int _serialSize;
        public int SerialSize
        {
            get => _serialSize;
            set { _serialSize = value; }
        }

        /// <summary>
        /// Object offset in bytes. Starting from the beginning of a file.
        /// </summary>
        private int _serialOffset;
        public int SerialOffset
        {
            get => _serialOffset;
            set { _serialOffset = value; }
        }

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

            stream.Write(ArchetypeIndex);

            stream.Write(stream.Version >= VObjectFlagsToULONG
                ? ObjectFlags
                : (uint)ObjectFlags);

            stream.WriteIndex(SerialSize);

            if (SerialSize > 0)
                stream.WriteIndex(SerialOffset);

            stream.Write(ExportFlags);

            stream.Write(NetObjectData.Length);
            for (var i = 0; i < NetObjectData.Length; i++)
                stream.Write(NetObjectData[i]);

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

            ObjectFlags = stream.ReadUInt64();

            SerialSize = stream.ReadIndex();
            if (SerialSize > 0) SerialOffset = stream.ReadIndex();

            ExportFlags = stream.ReadUInt32();


            // Array of objects
            int netObjectCount = stream.ReadInt32();
            NetObjectData = new int[netObjectCount];
            for (var i = 0; i < NetObjectData.Length; i++)
                NetObjectData[i] = stream.ReadInt32();

            PackageGuid = stream.ReadGuid();

            PackageFlags = stream.ReadInt32();

            DeserializeLogger.Log($"[UExportTableItem] ClassIndex: {ClassIndex}, SuperIndex: {SuperIndex}, OuterIndex: {OuterIndex}, ObjectName: {ObjectName}, ArchetypeIndex: {ArchetypeIndex}, ObjectFlags: {ObjectFlags}, SerialSize: {SerialSize}, SerialOffset: {SerialOffset}, ExportFlags: {ExportFlags}, netObjectCount: {netObjectCount}, PackageGuid: {PackageGuid}, PackageFlags: {PackageFlags}");
        }

        #region Methods

        public override string ToString()
        {
            return ObjectName + "(" + Index + 1 + ")";
        }

        #endregion
    }
}