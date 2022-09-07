using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UELib.Core.Classes
{
    [Flags]
    public enum BulkDataCompressionTypes : uint
    {

        StoreInSeparatefile = 0x00000001,
        ZLIB = 0x00000002,
        LZO = 0x00000010,
        Unused = 0x00000020,
        SeperateData = 0x00000040,
        LZX = 0x00000080,
        LZO_ENC = 0x00000100
    }

    public class DomainCompressedChunk
    {
        private const BulkDataCompressionTypes NothingToDo = BulkDataCompressionTypes.Unused | BulkDataCompressionTypes.StoreInSeparatefile;

        public uint Flags;
        public int UncompressedSize;
        public int CompressedSize;
        public int CompressedOffset;
        public List<CompressedBlock> Blocks = new List<CompressedBlock>();

        public void Deserialize(IUnrealStream stream)
        {
            var bulkDataFlags = stream.ReadUInt32();
            var uncompressedSize = stream.ReadInt32();
            var compressedSize = stream.ReadInt32();
            var compressedOffset = stream.ReadInt32();

            if (((BulkDataCompressionTypes)bulkDataFlags & NothingToDo) > 0) return;

            DecompressBlocks(stream);
        }

        private void DecompressBlocks(IUnrealStream stream)
        {
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

    public abstract class UCompressionBase : UObject
    {
        public void ProcessCompressedBulkData()
        {
            var domain = new DomainCompressedChunk();
            domain.Deserialize(_Buffer);

        }
    }
}
