using System.Diagnostics.CodeAnalysis;
using UELib.Annotations;
using UELib.Core.Types;

namespace UELib
{
    using Core;
    using System;
    using System.Collections.Generic;
    using UELib.Flags;

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
            stream.Write(UncompressedOffset);
            stream.Write(UncompressedSize);
            stream.Write(CompressedOffset);
            stream.Write(CompressedSize);
        }

        public void Deserialize(IUnrealStream stream)
        {
            UncompressedOffset = stream.ReadInt32();
            UncompressedSize = stream.ReadInt32();

            CompressedOffset = stream.ReadInt32();
            CompressedSize = stream.ReadInt32();

            DeserializeLogger.Log($"Compressed Block -> UncompressedOffset: {UncompressedOffset}, UncompressedSize: {UncompressedSize}, CompressedOffset: {CompressedOffset}, CompressedSize: {CompressedSize}");

            var pos = stream.Position;
            ReadData(stream);
            stream.Seek(pos, System.IO.SeekOrigin.Begin);
        }

        private void ReadData(IUnrealStream stream)
        {
            stream.Seek(CompressedOffset, System.IO.SeekOrigin.Begin);

            var signature = stream.ReadUInt32();

            DeserializeLogger.Log($" Chunk signature: {signature}");

            if (signature != UnrealPackage.Signature)
                throw new ApplicationException();

            var blockSize = stream.ReadInt32();

            var compressedSize = stream.ReadInt32();
            var uncompressedSize = stream.ReadInt32();

            int blockCount = (uncompressedSize + blockSize - 1) / blockSize;

            DeserializeLogger.Log($" CompressedBlockData -> BlockSize {blockSize}, compressedSize: {compressedSize}, uncompressedSize: {uncompressedSize}");


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

                DeserializeLogger.Log($" Block Part -> CompressedSize: {block.CompressedSize}, UncompressedSize: {block.UncompressedSize}, data: {BitConverter.ToString(block.Data)}");
            }
        }
    }
}