using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace UELib.Core.Classes
{

    public abstract class UCompressionBase : UObject
    {
        public const int BLOCK_SIZE = 131072;
        public const int BLOCK_HEADER_SIZE = 24;

        public byte[] Unknown1 { get; private set; }
        public int CompressedChunkOffset { get; private set; }
        public DomainCompressedChunk TemporalChunk { get; private set; }

        public DomainCompressedChunk ProcessCompressedBulkData()
        {
            TemporalChunk = new DomainCompressedChunk();
            TemporalChunk.Deserialize(_Buffer);
            return TemporalChunk;
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

            int blockCount = (chunk.Length + BLOCK_SIZE - 1) / BLOCK_SIZE;

            // Blocks Header
            stream.Write((int)BulkDataCompressionTypes.LZO);
            stream.Write(chunk.Length);
            var pos = stream.Position;
            stream.Write(0);
            stream.Write(stream.RealPosition + 4);

            // Blocks data
            stream.Write(UnrealPackage.Signature);
            stream.Write(BLOCK_SIZE); // block size 
            var pos2 = stream.Position;
            stream.Write(0); // compressed size + block header size (24 bytes for each block)
            stream.Write(chunk.Length);

            var compresedLength = 0;
            using (var tmpMS = new MemoryStream())
            {
                for (var i = 0; i < blockCount; i++)
                {
                    var blockUncompressed = new byte[
                        (i * BLOCK_SIZE + BLOCK_SIZE) > chunk.Length
                        ? chunk.Length - (i * BLOCK_SIZE + BLOCK_SIZE)
                        : BLOCK_SIZE
                    ];

                    Array.Copy(chunk, i * BLOCK_SIZE, blockUncompressed, 0, blockUncompressed.Length);
                    var compressed = deco.CompressSync(blockUncompressed);
                    compresedLength += compressed.Length;

                    stream.Write(compressed.Length); // compressed size chunk
                    stream.Write(blockUncompressed.Length); // uncompressed size chunk

                    tmpMS.Write(compressed, 0, compressed.Length);
                }

                tmpMS.Seek(0, SeekOrigin.Begin);
                tmpMS.CopyTo(stream.UW.BaseStream);
            }

            var curpos = stream.Position;
            stream.Seek(pos, SeekOrigin.Begin);
            stream.Write(compresedLength + (BLOCK_HEADER_SIZE * blockCount));

            stream.Seek(pos2, SeekOrigin.Begin);
            stream.Write(compresedLength);

            stream.Seek(curpos, SeekOrigin.Begin);
        }
    }
}
