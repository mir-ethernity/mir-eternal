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

namespace UELib.Core.Classes
{
    public class UMipMap
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public byte[] TextureData { get; set; }
        public Bitmap ImageBitmap { get; set; }
    }

    [UnrealRegisterClass]
    public class UTexture2D : UCompressionBase
    {
        //public int MipMapsCount { get; private set; }
        public UMipMap[] MipMaps { get; set; }

        protected override void Deserialize()
        {
            base.Deserialize();

            var mipMapsCount = _Buffer.ReadInt32();

            MipMaps = new UMipMap[mipMapsCount];

            var format = Properties.FirstOrDefault(x => x.Name == "Format");

            FileFormat imageFormat = FileFormat.DXT1;

            if (format != null)
            {
                switch (((UValueByteProperty)format.GoodValue).EnumValue)
                {
                    case "PF_DXT1":
                        imageFormat = FileFormat.DXT1;
                        break;
                    case "PF_DXT3":
                        imageFormat = FileFormat.DXT3;
                        break;
                    case "PF_DXT5":
                        imageFormat = FileFormat.DXT5;
                        break;
                    case "PF_A8R8G8B8":
                        imageFormat = FileFormat.A8R8G8B8;
                        break;
                }
            }

            for (var i = 0; i < mipMapsCount; i++)
            {
                var data = ProcessCompressedBulkData();

                var mipmap = new UMipMap();
                MipMaps[i] = mipmap;

                mipmap.Width = _Buffer.ReadInt32();
                mipmap.Height = _Buffer.ReadInt32();

                if (mipmap.Width >= 4 && mipmap.Height >= 4)
                    mipmap.TextureData = data.Decompress();

                var config = new DdsSaveConfig(imageFormat, 0, 0, false, false);
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

                    mipmap.ImageBitmap = BitmapFromSource(ddsFile.BitmapSource);
                }
            }
        }

        public override void Serialize(IUnrealStream stream)
        {
            base.Serialize(stream);

            stream.Write(MipMaps.Length);

            for (var i = 0; i < MipMaps.Length; i++)
            {
                if (MipMaps[i].Width >= 4 && MipMaps[i].Height >= 4)
                    WriteUncompressedChunk(stream, MipMaps[i].TextureData);

                stream.Write(MipMaps[i].Width);
                stream.Write(MipMaps[i].Height);

                //DdsFile ddsFile = new DdsFile();
                //ddsFile.MipMaps[i].MipMap
            }
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
