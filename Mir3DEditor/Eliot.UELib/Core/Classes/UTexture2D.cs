using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UELib.Engine.UTexture;
using UpkManager.Dds;
using UpkManager.Dds.Constants;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace UELib.Core.Classes
{
    public class UMipMap
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public byte[] TextureData { get; set; }
        public Bitmap ImageBitmap { get; set; }

        public UTexture2D Texture2D { get; set; }
        public int Index { get; set; }

        public UMipMap(UTexture2D texture2d, int index)
        {
            Texture2D = texture2d;
            Index = index;
        }
    }

    [UnrealRegisterClass]
    public class UTexture2D : UCompressionBase
    {
        //public int MipMapsCount { get; private set; }
        public UMipMap[] MipMaps { get; set; }
        public byte[] UnknownEndData { get; set; }

        public FileFormat ImageFormat { get; set; }

        protected override void Deserialize()
        {
            base.Deserialize();

            var mipMapsCount = _Buffer.ReadInt32();

            MipMaps = new UMipMap[mipMapsCount];

            var format = Properties.FirstOrDefault(x => x.Name == "Format");

            ImageFormat = FileFormat.DXT1;

            if (format != null)
            {
                switch (((UValueByteProperty)format.GoodValue).EnumValue)
                {
                    case "PF_DXT1":
                        ImageFormat = FileFormat.DXT1;
                        break;
                    case "PF_DXT3":
                        ImageFormat = FileFormat.DXT3;
                        break;
                    case "PF_DXT5":
                        ImageFormat = FileFormat.DXT5;
                        break;
                    case "PF_A8R8G8B8":
                        ImageFormat = FileFormat.A8R8G8B8;
                        break;
                }
            }

            for (var i = 0; i < mipMapsCount; i++)
            {
                var data = ProcessCompressedBulkData();

                var mipmap = new UMipMap(this, i);
                MipMaps[i] = mipmap;

                mipmap.Width = _Buffer.ReadInt32();
                mipmap.Height = _Buffer.ReadInt32();

                if (mipmap.Width >= 4 && mipmap.Height >= 4)
                    mipmap.TextureData = data.Decompress();

                var config = new DdsSaveConfig(ImageFormat, 0, 0, false, false);
                var ddsHeader = new DdsHeader(config, mipmap.Width, mipmap.Height);

                using (var ms = new MemoryStream())
                using (var bw = new BinaryWriter(ms))
                {
                    ddsHeader.Write(bw);
                    ms.Write(mipmap.TextureData, 0, mipmap.TextureData.Length);
                    ms.Flush();

                    ms.Seek(0, SeekOrigin.Begin);

                    DdsFile ddsFile = new DdsFile();
                    ddsFile.Load(ms);

                    mipmap.ImageBitmap = ConvertBytesToBitmap(ddsFile.largestMipMap, mipmap.Width, mipmap.Height);
                }
            }

            UnknownEndData = _Buffer.ReadBytes((int)_Buffer.Length - (int)_Buffer.Position);
        }

        public override void Serialize(IUnrealStream stream)
        {
            base.Serialize(stream);

            stream.Write(MipMaps.Length);

            for (var i = 0; i < MipMaps.Length; i++)
            {
                var mipmap = MipMaps[i];

                if (mipmap.Width >= 4 && mipmap.Height >= 4)
                {
                    var bitmapConfig = new DdsSaveConfig(FileFormat.A8R8G8B8, 0, 0, false, false) { IncludeHeader = false };
                    var bitmapHeader = new DdsHeader(bitmapConfig, mipmap.Width, mipmap.Height);

                    using (var ms = new MemoryStream())
                    using (var bw = new BinaryWriter(ms))
                    {
                        bitmapHeader.Write(bw);
                        var buffer = ConvertBitmapToByteArray(mipmap.ImageBitmap);
                        ms.Write(buffer, 0, buffer.Length);
                        ms.Flush();

                        ms.Seek(0, SeekOrigin.Begin);

                        DdsFile ddsFile = new DdsFile();
                        ddsFile.Load(ms);

                        using (var oms = new MemoryStream())
                        {
                            var ddsConfig = new DdsSaveConfig(ImageFormat, 0, 0, false, false) { IncludeHeader = false };
                            ddsFile.Save(oms, ddsConfig);
                            mipmap.TextureData = oms.ToArray();
                        }
                    }

                    WriteUncompressedChunk(stream, mipmap.TextureData);
                }

                stream.Write(mipmap.Width);
                stream.Write(mipmap.Height);

            }

            stream.Write(UnknownEndData);
        }

        public static Bitmap ConvertBytesToBitmap(byte[] rgba, int width, int height)
        {
            // Crear un nuevo Bitmap
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            // Bloquear los bits del Bitmap
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly, bitmap.PixelFormat);

            // Copiar los bytes al Bitmap
            Marshal.Copy(rgba, 0, bmpData.Scan0, rgba.Length);

            // Desbloquear los bits del Bitmap
            bitmap.UnlockBits(bmpData);

            return bitmap;
        }

        public static byte[] ConvertBitmapToByteArray(Bitmap bitmap)
        {
            // Lock the bitmap's bits.
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpData =
                bitmap.LockBits(rect, ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bitmap.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            // Unlock the bits.
            bitmap.UnlockBits(bmpData);

            return rgbValues;
        }

        public static Bitmap BitmapFromSource(BitmapSource bitmapsource)
        {
            Bitmap bitmap;
            using (var outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapsource));
                enc.Save(outStream);
                bitmap = new Bitmap(outStream);
            }
            return bitmap;
        }
    }
}
