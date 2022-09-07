using System.Diagnostics.CodeAnalysis;
using UELib.Annotations;
using UELib.Core.Types;

namespace UELib
{
    using Core;
    using System;
    using System.Collections.Generic;

    public class CompressedBlock
    {
        public int CompressedSize;
        public int UncompressedSize;

        public byte[] Data { get; internal set; }
    }

    [PublicAPI]
    public class CompressedChunk : IUnrealSerializableClass
    {
        public int UncompressedOffset;
        public int UncompressedSize;
        public int CompressedOffset;
        public int CompressedSize;

        public List<CompressedBlock> Blocks = new List<CompressedBlock>();

        public void Serialize(IUnrealStream stream)
        {
#if ROCKETLEAGUE

            if (stream.Package.Build == UnrealPackage.GameBuild.BuildName.RocketLeague
                && stream.Package.LicenseeVersion >= 22)
            {
                stream.Write((long)UncompressedOffset);
                stream.Write((long)CompressedOffset);
                goto streamStandardSize;
            }
#endif
            stream.Write(UncompressedOffset);
            stream.Write(UncompressedSize);
        streamStandardSize:
            stream.Write(CompressedOffset);
            stream.Write(CompressedSize);
        }

        public void Deserialize(IUnrealStream stream)
        {
            //#if ROCKETLEAGUE
            //            if (stream.Package.Build == UnrealPackage.GameBuild.BuildName.RocketLeague
            //                && stream.Package.LicenseeVersion >= 22)
            //            {
            //                UncompressedOffset = (int)stream.ReadInt64();
            //                CompressedOffset = (int)stream.ReadInt64();
            //                goto streamStandardSize;
            //            }
            //#endif
            UncompressedOffset = stream.ReadInt32();
            UncompressedSize = stream.ReadInt32();

            CompressedOffset = stream.ReadInt32();
            CompressedSize = stream.ReadInt32();

            //    UncompressedOffset = stream.ReadInt32();
            //    CompressedOffset = stream.ReadInt32();
            //streamStandardSize:
            //    UncompressedSize = stream.ReadInt32();
            //    CompressedSize = stream.ReadInt32();

            var pos = stream.Position;
            ReadData(stream);
            stream.Seek(pos, System.IO.SeekOrigin.Begin);
        }

        private void ReadData(IUnrealStream stream)
        {
            stream.Seek(CompressedOffset, System.IO.SeekOrigin.Begin);

            var signature = stream.ReadUInt32();

            if (signature != UnrealPackage.Signature)
                throw new ApplicationException();

            var blockSize = stream.ReadInt32();

            var compressedSize = stream.ReadInt32();
            var uncompressedSize = stream.ReadInt32();

            int blockCount = (uncompressedSize + blockSize - 1) / blockSize;


            for (int i = 0; i < blockCount; ++i)
            {
                var block = new CompressedBlock()
                {
                    CompressedSize = stream.ReadInt32(),
                    UncompressedSize = stream.ReadInt32()
                };
                Blocks.Add(block);
            }

            foreach (var block in Blocks)
            {
                var data = new byte[block.CompressedSize];
                stream.Read(data, 0, data.Length);
                block.Data = data;
            }
        }
    }

    // TODO: Complete implementation
    // ReSharper disable once UnusedType.Global
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public struct CompressedChunkHeader : IUnrealSerializableClass
    {
        public uint Tag;
        public int ChunkSize;
        public CompressedChunkBlock Summary;
        public UArray<CompressedChunkBlock> Chunks;

        public void Serialize(IUnrealStream stream)
        {
            stream.Write(Tag);
            stream.Write(ChunkSize);
            Summary.Serialize(stream);
            stream.Write(Chunks);
        }

        public void Deserialize(IUnrealStream stream)
        {
            Tag = stream.ReadUInt32();
            ChunkSize = stream.ReadInt32();
            if ((uint)ChunkSize == UnrealPackage.Signature)
            {
                ChunkSize = 0x20000;
            }
            Summary = new CompressedChunkBlock();
            Summary.Deserialize(stream);

            int chunksCount = (Summary.UncompressedSize + ChunkSize - 1) / ChunkSize;
            stream.ReadArray(out Chunks, chunksCount);
        }
    }

    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public struct CompressedChunkBlock : IUnrealSerializableClass
    {
        public int CompressedSize;
        public int UncompressedSize;

        public void Serialize(IUnrealStream stream)
        {
            stream.Write(CompressedSize);
            stream.Write(UncompressedSize);
        }

        public void Deserialize(IUnrealStream stream)
        {
            CompressedSize = stream.ReadInt32();
            UncompressedSize = stream.ReadInt32();
        }
    }
}