using System;
using System.ComponentModel.Composition;
using System.Runtime.InteropServices;
using System.Threading.Tasks;


namespace UpkManager.Lzo
{

    [Export(typeof(ILzoCompression))]
    public sealed class LzoCompression : ILzoCompression
    {

        #region Private Fields

        private const long WorkMemorySize_1x_1 = 16384L * 4;

        private static readonly bool is64Bit;

        #endregion Private Fields

        #region Constructor

        static LzoCompression()
        {
            is64Bit = IntPtr.Size == 8;
        }

        public LzoCompression()
        {
            int init = is64Bit ? Lzo2.lzo_init_64(1, -1, -1, -1, -1, -1, -1, -1, -1, -1) : Lzo2.lzo_init_32(1, -1, -1, -1, -1, -1, -1, -1, -1, -1);

            if (init != 0) throw new Exception("Initialization of lzo2.dll failed.");
        }

        #endregion Constructor

        #region ILzoCompression Implementation

        public string Version
        {
            get
            {
                IntPtr strPtr = is64Bit ? Lzo2.lzo_version_string_64() : Lzo2.lzo_version_string_32();

                string version = Marshal.PtrToStringAnsi(strPtr);

                return version;
            }
        }

        public string VersionDate => Lzo2.lzo_version_date();

        public async Task<byte[]> Compress(byte[] Source)
        {
            byte[] compressed = new byte[Source.Length + Source.Length / 64 + 16 + 3 + 4];

            int compressedSize = 0;

            await Task.Run(() =>
            {
                byte[] workMemory = new byte[WorkMemorySize_1x_1];

                if (is64Bit) Lzo2.lzo1x_1_compress_64(Source, Source.Length, compressed, ref compressedSize, workMemory);
                else Lzo2.lzo1x_1_compress_32(Source, Source.Length, compressed, ref compressedSize, workMemory);
            });

            byte[] sizedToFit = new byte[compressedSize];

            await Task.Run(() => Array.ConstrainedCopy(compressed, 0, sizedToFit, 0, compressedSize));

            return sizedToFit;
        }

        public byte[] CompressSync(byte[] Source)
        {
            byte[] compressed = new byte[Source.Length + 50000];

            int compressedSize = 0;

            byte[] workMemory = new byte[WorkMemorySize_1x_1];

            if (is64Bit) Lzo2.lzo1x_1_compress_64(Source, Source.Length, compressed, ref compressedSize, workMemory);
            else Lzo2.lzo1x_1_compress_32(Source, Source.Length, compressed, ref compressedSize, workMemory);

            byte[] sizedToFit = new byte[compressedSize];

            Array.ConstrainedCopy(compressed, 0, sizedToFit, 0, compressedSize);

            return sizedToFit;
        }

        public async Task Decompress(byte[] Source, byte[] Destination)
        {
            await Task.Run(() =>
            {
                int destinationSize = Destination.Length;

                if (is64Bit) Lzo2.lzo1x_decompress_64(Source, Source.Length, Destination, ref destinationSize, null);
                else Lzo2.lzo1x_decompress_32(Source, Source.Length, Destination, ref destinationSize, null);
            });
        }

        public void DecompressSync(byte[] Source, byte[] Destination)
        {
            int destinationSize = Destination.Length;
            if (is64Bit) Lzo2.lzo1x_decompress_64(Source, Source.Length, Destination, ref destinationSize, null);
            else Lzo2.lzo1x_decompress_32(Source, Source.Length, Destination, ref destinationSize, null);
        }

        #endregion ILzoCompression Implementation

    }

}
