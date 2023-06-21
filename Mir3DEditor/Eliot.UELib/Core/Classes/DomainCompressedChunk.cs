using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace UELib.Core.Classes
{
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
            Flags = stream.ReadUInt32();
            UncompressedSize = stream.ReadInt32();
            CompressedSize = stream.ReadInt32();
            CompressedOffset = stream.ReadInt32();

            if (((BulkDataCompressionTypes)Flags & NothingToDo) > 0) return;

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

        public byte[] Decompress()
        {
            var deco = new UpkManager.Lzo.LzoCompression();

            byte[] chunkData = new byte[Blocks.Sum(block => block.UncompressedSize)];
            int uncompressedOffset = 0;

            foreach (var block in Blocks)
            {
                var uncompressedData = new byte[block.UncompressedSize];
                deco.DecompressSync(block.Data, uncompressedData);

                Array.ConstrainedCopy(uncompressedData, 0, chunkData, uncompressedOffset, block.UncompressedSize);
                uncompressedOffset += block.UncompressedSize;
            }

            return chunkData;
        }
    }
}
