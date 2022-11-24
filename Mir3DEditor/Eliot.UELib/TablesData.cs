using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using UELib.Annotations;
using UELib.Flags;

namespace UELib
{
    using Core;
    using Decoding;

    public sealed partial class UnrealPackage
    {
        public struct TablesData : IUnrealSerializableClass
        {
            public int NamesCount;
            public int NamesOffset { get; internal set; }

            public int ExportsCount { get; internal set; }
            public int ExportsOffset { get; internal set; }

            public int ImportsCount { get; internal set; }
            public int ImportsOffset { get; internal set; }

            private const int VDependsOffset = 415;
            public int DependsOffset { get; internal set; }

            private const int VImportExportGuidsOffset = 623;
            public int ImportExportGuidsOffset;
            public int ImportGuidsCount;
            public int ExportGuidsCount;

            private const int VThumbnailTableOffset = 584;
            public int ThumbnailTableOffset;

            public void Serialize(IUnrealStream stream)
            {
                stream.Write(NamesCount);
                stream.Write(NamesOffset);

                stream.Write(ExportsCount);
                stream.Write(ExportsOffset);

                stream.Write(ImportsCount);
                stream.Write(ImportsOffset);

                if (stream.Version >= 414)
                    stream.Write(DependsOffset);

                if (stream.Version >= VImportExportGuidsOffset)
                {
                    stream.Write(ImportExportGuidsOffset);
                    stream.Write(ImportGuidsCount);
                    stream.Write(ExportGuidsCount);
                }

                if (stream.Version >= VThumbnailTableOffset)
                {
                    stream.Write(ThumbnailTableOffset);
                }
            }

            public void Deserialize(IUnrealStream stream)
            {
#if HAWKEN
                if (stream.Package.Build == GameBuild.BuildName.Hawken &&
                    stream.Package.LicenseeVersion >= 2)
                    stream.Skip(4);
#endif
                NamesCount = stream.ReadInt32();
                NamesOffset = stream.ReadInt32();
                ExportsCount = stream.ReadInt32();
                ExportsOffset = stream.ReadInt32();
#if APB
                if (stream.Package.Build == GameBuild.BuildName.APB &&
                    stream.Package.LicenseeVersion >= 28)
                {
                    if (stream.Package.LicenseeVersion >= 29)
                    {
                        stream.Skip(4);
                    }

                    stream.Skip(20);
                }
#endif
                ImportsCount = stream.ReadInt32();
                ImportsOffset = stream.ReadInt32();

                Console.WriteLine("Names Count:" + NamesCount + " Names Offset:" + NamesOffset
                                  + " Exports Count:" + ExportsCount + " Exports Offset:" + ExportsOffset
                                  + " Imports Count:" + ImportsCount + " Imports Offset:" + ImportsOffset
                );

                DependsOffset = stream.ReadInt32();

                ImportExportGuidsOffset = stream.ReadInt32();
                ImportGuidsCount = stream.ReadInt32();
                ExportGuidsCount = stream.ReadInt32();

                ThumbnailTableOffset = stream.ReadInt32();
            }
        }

    }
}