using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UELib;
using UELib.Core;

namespace Mir3DClientEditor.Services
{
    public class UPKNPCTemplate : UObject
    {
        public int SomeInteger { get; private set; }

        protected override void Deserialize()
        {
            base.Deserialize();
        }
    }

    public class UPKGlobalMapInfo : UStruct
    {
        protected override void Deserialize()
        {
            base.Deserialize();
        }
    }

    public class UPKNameTable
    {
        public string Name { get; set; }
        public ulong Flags { get; set; }

        public override string ToString()
        {
            return $"{Name} (F:{Flags})";
        }
    }

    public class UPXNameIndex
    {
        public int TableIdx { get; set; }
        public int Numeric { get; set; }
    }

    public class UPXImportObject
    {
        public UPXNameIndex PackageIdx { get; set; }
        public UPXNameIndex TypeIdx { get; set; }
        public int OwnerRef { get; set; }
        public UPXNameIndex NameIdx { get; set; }
    }

    public class UPKExportTable
    {
        public int TypeRef { get; set; }
        public int ParentClassRef { get; set; }
        public int OwnerRef { get; set; }
        public UPXNameIndex NameIdx { get; set; }
        public int ArchetypeRef { get; set; }
        public int ObjectFlagsH { get; set; }
        public int ObjectFlagsL { get; set; }
        public int SerialSize { get; set; }
        public int SerialOffset { get; set; }
        public int ExportFlags { get; set; }
        public int NetObjectCount { get; set; }
        public Guid GUID { get; set; }
        public int Uknown1 { get; set; }
        public byte[] Uknown2 { get; set; } // NetObjectCount * 4
    }

    public class UPKGeneration
    {
        public int ExportTableCount { get; set; }
        public int NameTableCount { get; set; }
        public int NetObjectCount { get; set; }
    }

    public class UPK
    {
        private byte[] _data;

        public string Group { get; private set; }
        public uint Flags { get; private set; }
        public ushort Version { get; private set; }
        public ushort License { get; private set; }

        private UPK(byte[] buffer)
        {
            _data = buffer;

            //var reader = ByteArrayReader.CreateNew(buffer, 0);
            //var header = new UpkManager.Domain.Models.UpkFile.DomainHeader(reader);

            //Task.Run(async () =>
            //{
            //    await header.ReadHeaderAsync((a) => { });

            //    foreach (var export in header.ExportTable)
            //    {
            //        if (export.DomainObject == null)
            //            await export.ParseDomainObject(header, false, false);

            //        if (!export.DomainObject.IsExportable) continue;


            //    }
            //});

            ReadHeader();
        }



        private void ReadHeader()
        {
            using var ms = new MemoryStream(_data);
            using var br = new BinaryReader(ms);

            var signature = br.ReadUInt32();

            if (signature != 0x9e2a83c1)
            {
                MessageBox.Show("Unknown UPK file");
                return;
            }

            Version = br.ReadUInt16();
            License = br.ReadUInt16();

            var headerSize = br.ReadUInt32();

            Group = ReadString(br);
            Flags = br.ReadUInt32();

            var nameTableCount = br.ReadInt32();
            var nameTableOffset = br.ReadInt32();

            var exportTableCount = br.ReadInt32();
            var exportTableOffset = br.ReadInt32();

            var importTableCount = br.ReadInt32();
            var importTableOffset = br.ReadInt32();

            var dependsTableOffset = br.ReadInt32();
            var serializedOffset = br.ReadInt32();
            var u1 = br.ReadInt32();
            var u2 = br.ReadInt32();
            var u3 = br.ReadInt32();
            var guid = br.ReadBytes(16);

            var generationTableCount = br.ReadInt32();
            var generationTables = new UPKGeneration[generationTableCount];

            for (var i = 0; i < generationTableCount; i++)
            {
                generationTables[i] = new UPKGeneration()
                {
                    ExportTableCount = br.ReadInt32(),
                    NameTableCount = br.ReadInt32(),
                    NetObjectCount = br.ReadInt32(),
                };
            }

            var engineVersion = br.ReadUInt32();
            var cookerVersion = br.ReadUInt32();
            var compressionFlags = br.ReadUInt32();
            var compressionTableCount = br.ReadInt32();


            var nameTables = new UPKNameTable[nameTableCount];
            ms.Seek(nameTableOffset, SeekOrigin.Begin);
            for (var i = 0; i < nameTableCount; i++)
            {
                nameTables[i] = new UPKNameTable
                {
                    Name = ReadString(br),
                    Flags = br.ReadUInt64()
                };
            }

            ms.Seek(exportTableOffset, SeekOrigin.Begin);
            for (var i = 0; i < exportTableCount; i++)
            {
                
            }

        }


        private string ReadString(BinaryReader reader)
        {
            var strSize = reader.ReadInt32();

            if (strSize == 0)
                return string.Empty;

            if (strSize < 0)
            {
                int size = -strSize * 2;
                byte[] str = reader.ReadBytes(size);
                return Encoding.Unicode.GetString(str);
            }
            else
            {
                byte[] str = reader.ReadBytes(strSize - 1);
                var w = reader.Read(); // NULL Terminator
                return Encoding.ASCII.GetString(str);
            }
        }


        public static UPK Read(byte[] buffer)
        {
            return new UPK(buffer);
        }


    }
}
