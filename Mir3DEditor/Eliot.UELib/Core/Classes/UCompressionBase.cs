using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

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

    public abstract class UCompressionBase : UObject
    {
        public byte[] Unknown1 { get; private set; }
        public int CompressedChunkOffset { get; private set; }

        public DomainCompressedChunk ProcessCompressedBulkData()
        {
            var chunk = new DomainCompressedChunk();
            chunk.Deserialize(_Buffer);
            return chunk;
        }

        protected override void Deserialize()
        {
            base.Deserialize();

            Unknown1 = _Buffer.ReadBytes(sizeof(uint) * 3);
            CompressedChunkOffset = _Buffer.ReadInt32();
        }

        public override void Serialize(IUnrealStream stream)
        {
            base.Serialize(stream);

            stream.Write(Unknown1);
            stream.Write(stream.RealPosition + 4);
        }

        public void WriteUncompressedChunk(IUnrealStream stream, byte[] chunk)
        {
            var deco = new UpkManager.Lzo.LzoCompression();
            
            var compressed = deco.CompressSync(chunk);

            stream.Write((int)BulkDataCompressionTypes.LZO);
            stream.Write(chunk.Length);
            stream.Write(compressed.Length + 24); // 24 corresponds to the sum of all block headers, in this case, only writes one block
            stream.Write(stream.RealPosition + 4);

            // TODO: Atm only writes one block
            stream.Write(UnrealPackage.Signature);
            stream.Write(chunk.Length); // block size
            stream.Write(compressed.Length); // compressed size
            stream.Write(chunk.Length); // uncompressed size

            stream.Write(compressed.Length); // compressed size chunk
            stream.Write(chunk.Length); // uncompressed size chunk

            stream.Write(compressed); // compressed data
        }
    }
}
