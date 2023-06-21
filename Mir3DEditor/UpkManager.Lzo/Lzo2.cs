using System;
using System.Runtime.InteropServices;


namespace UpkManager.Lzo
{

    internal static class Lzo2
    {

        #region Private Fields

        private const string LzoDll32 = @"lib32\lzo2_32.dll";
        private const string LzoDll64 = @"lib64\lzo2_64.dll";

        #endregion Private Fields

        #region Imports

        #region 32 Bit

        [DllImport(LzoDll32, EntryPoint = "__lzo_init_v2")]
        internal static extern int lzo_init_32(uint v, int s1, int s2, int s3, int s4, int s5, int s6, int s7, int s8, int s9);

        [DllImport(LzoDll32, EntryPoint = "lzo_version_string")]
        internal static extern IntPtr lzo_version_string_32();

        [DllImport(LzoDll32, EntryPoint = "lzo1x_1_compress", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lzo1x_1_compress_32(byte[] src, int src_len, byte[] dst, ref int dst_len, byte[] wrkmem);
        
        [DllImport(LzoDll32, EntryPoint = "lzo1x_999_compress", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lzo1x_999_compress_32(byte[] src, int src_len, byte[] dst, ref int dst_len, byte[] wrkmem);

        [DllImport(LzoDll32, EntryPoint = "lzo1x_decompress_safe", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lzo1x_decompress_32(byte[] src, int src_len, byte[] dst, ref int dst_len, byte[] wrkmem);

        #endregion 32 Bit

        #region 64 Bit

        [DllImport(LzoDll64, EntryPoint = "__lzo_init_v2")]
        internal static extern int lzo_init_64(uint v, int s1, int s2, int s3, int s4, int s5, int s6, int s7, int s8, int s9);

        [DllImport(LzoDll64, EntryPoint = "lzo_version_string")]
        internal static extern IntPtr lzo_version_string_64();

        [DllImport(LzoDll64)]
        internal static extern string lzo_version_date();

        [DllImport(LzoDll64, EntryPoint = "lzo1x_1_compress", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lzo1x_1_compress_64(byte[] src, int src_len, byte[] dst, ref int dst_len, byte[] wrkmem);

        [DllImport(LzoDll64, EntryPoint = "lzo1x_999_compress", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lzo1x_999_compress_64(byte[] src, int src_len, byte[] dst, ref int dst_len, byte[] wrkmem);


        [DllImport(LzoDll64, EntryPoint = "lzo1x_decompress_safe", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lzo1x_decompress_64(byte[] src, int src_len, byte[] dst, ref int dst_len, byte[] wrkmem);

        #endregion 64 Bit

        #endregion Imports

    }

}
