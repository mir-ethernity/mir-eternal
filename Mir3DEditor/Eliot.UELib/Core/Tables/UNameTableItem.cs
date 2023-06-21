using System.Diagnostics;
using System.Runtime.CompilerServices;
using UELib.Decoding;

namespace UELib
{
    /// <summary>
    /// A names table entry, representing all unique names within a package.
    /// </summary>
    public sealed class UNameTableItem : UTableItem, IUnrealSerializableClass
    {
        #region Serialized Members

        /// <summary>
        /// Object Name
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        /// Object Flags, such as LoadForEdit, LoadForServer, LoadForClient
        /// </summary>
        /// <value>
        /// 32bit in UE2
        /// 64bit in UE3
        /// </value>
        public ulong Flags;

        #endregion

        public void Deserialize(IUnrealStream stream)
        {
            Name = stream.ReadText();
            Flags = stream.Version >= UExportTableItem.VObjectFlagsToULONG
                ? stream.ReadUInt64()
                : stream.ReadUInt32();
            DeserializeLogger.Log($"[UNameTableItem] Name: {Name}, Flags: {Flags}");
        }

        public void Serialize(IUnrealStream stream)
        {
            stream.Write(Name);
            if (stream.Version < UExportTableItem.VObjectFlagsToULONG)
                // Writing UINT
                stream.Write((uint)Flags);
            else
                // Writing ULONG
                stream.Write(Flags);
        }

        public override string ToString()
        {
            return Name;
        }

        public static implicit operator string(UNameTableItem a)
        {
            return a.Name;
        }

        public static implicit operator int(UNameTableItem a)
        {
            return a.Index;
        }
    }
}