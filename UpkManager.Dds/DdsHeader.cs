using System.Diagnostics.CodeAnalysis;
using System.IO;

using UpkManager.Dds.Constants;


namespace UpkManager.Dds {

  [SuppressMessage("ReSharper", "MemberCanBeInternal")]
  [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
  public sealed class DdsHeader {

    #region Constructor

    internal DdsHeader() { }

    public DdsHeader(DdsSaveConfig config, int width, int height) {
      PixelFormat = new DdsPixelFormat(config.FileFormat);

      bool isCompressed = config.FileFormat == FileFormat.DXT1
                       || config.FileFormat == FileFormat.DXT3
                       || config.FileFormat == FileFormat.DXT5;
      //
      // Compute mip map count..
      //
      int mipCount = config.GenerateMipMaps ? CountMipMaps(width, height) : 1;

      Size = 18 * 4 + PixelFormat.Size + 5 * 4;

      Width  = (uint)width;
      Height = (uint)height;

      MipMapCount = mipCount == 1 ? 0 : (uint)mipCount;

      HeaderFlags = (uint)(Constants.HeaderFlags.Texture | (isCompressed ? Constants.HeaderFlags.LinearSize : Constants.HeaderFlags.Pitch)
                                                         | (mipCount > 1 ? Constants.HeaderFlags.MipMap     : Constants.HeaderFlags.None));

      SurfaceFlags = (uint)(Constants.SurfaceFlags.Texture | (mipCount > 1 ? Constants.SurfaceFlags.MipMap : Constants.SurfaceFlags.None));

      if (isCompressed) {
        //
        // Compresssed textures have the linear flag set.  So pitchOrLinearSize
        // needs to contain the entire size of the DXT block.
        //
        int blockCount = (width + 3) / 4 * ((height + 3) / 4);

        int blockSize = config.FileFormat == FileFormat.Unknown ? 8 : 16;

        PitchOrLinearSize = (uint)(blockCount * blockSize);
      }
      else {
        //
        // Non-compressed textures have the pitch flag set. So pitchOrLinearSize
        // needs to contain the row pitch of the main image.
        //
        int pixelWidth = 0;

        switch(config.FileFormat) {
          case FileFormat.A8R8G8B8:
          case FileFormat.X8R8G8B8:
          case FileFormat.A8B8G8R8:
          case FileFormat.X8B8G8R8: {
            pixelWidth = 4;

            break;
          }
          case FileFormat.R8G8B8: {
            pixelWidth = 3;

            break;
          }
          case FileFormat.A1R5G5B5:
          case FileFormat.A4R4G4B4:
          case FileFormat.R5G6B5: {
            pixelWidth = 2;

            break;
          }
          case FileFormat.G8: {
            pixelWidth = 1;

            break;
          }
        }

        PitchOrLinearSize = (uint)(width * pixelWidth);
      }
    }

    #endregion Constructor

    #region Public Properties

    public uint	Size { get; private set; }

    public uint	HeaderFlags { get; private set; }

    public uint	Height { get; private set; }

    public uint	Width { get; private set; }

    public uint	PitchOrLinearSize { get; private set; }

    public uint	Depth { get; private set; }

    public uint	MipMapCount { get; private set; }

    public uint	Reserved1_0 { get; private set; }

    public uint	Reserved1_1 { get; private set; }

    public uint	Reserved1_2 { get; private set; }

    public uint	Reserved1_3 { get; private set; }

    public uint	Reserved1_4 { get; private set; }

    public uint	Reserved1_5 { get; private set; }

    public uint	Reserved1_6 { get; private set; }

    public uint	Reserved1_7 { get; private set; }

    public uint	Reserved1_8 { get; private set; }

    public uint	Reserved1_9 { get; private set; }

    public uint	Reserved1_10 { get; private set; }

    public uint	SurfaceFlags { get; private set; }

    public uint	CubemapFlags { get; private set; }

    public uint	Reserved2_0 { get; private set; }

    public uint	Reserved2_1 { get; private set; }

    public uint	Reserved2_2 { get; private set; }

    public DdsPixelFormat	PixelFormat { get; private set; }

    #endregion Public Properties

    #region Public Methods

    internal static int CountMipMaps(int width, int height) {
      int mipCount = 1;

      while(width > 1 || height > 1) {
        mipCount++;

        if (width  > 1) width  /= 2;
        if (height > 1) height /= 2;
      }

      return mipCount;
    }

    public void Read(BinaryReader reader) {
      Size              = reader.ReadUInt32();
      HeaderFlags       = reader.ReadUInt32();
      Height            = reader.ReadUInt32();
      Width             = reader.ReadUInt32();
      PitchOrLinearSize = reader.ReadUInt32();
      Depth             = reader.ReadUInt32();
      MipMapCount       = reader.ReadUInt32();
      Reserved1_0       = reader.ReadUInt32();
      Reserved1_1       = reader.ReadUInt32();
      Reserved1_2       = reader.ReadUInt32();
      Reserved1_3       = reader.ReadUInt32();
      Reserved1_4       = reader.ReadUInt32();
      Reserved1_5       = reader.ReadUInt32();
      Reserved1_6       = reader.ReadUInt32();
      Reserved1_7       = reader.ReadUInt32();
      Reserved1_8       = reader.ReadUInt32();
      Reserved1_9       = reader.ReadUInt32();
      Reserved1_10      = reader.ReadUInt32();

      PixelFormat = new DdsPixelFormat();

      PixelFormat.Read(reader);

      SurfaceFlags = reader.ReadUInt32();
      CubemapFlags = reader.ReadUInt32();
      Reserved2_0  = reader.ReadUInt32();
      Reserved2_1  = reader.ReadUInt32();
      Reserved2_2  = reader.ReadUInt32();
    }

    public void Write(BinaryWriter writer) {
      writer.Write(HeaderValues.DdsSignature); // "DDS "

      writer.Write(Size);
      writer.Write(HeaderFlags);
      writer.Write(Height);
      writer.Write(Width);
      writer.Write(PitchOrLinearSize);
      writer.Write(Depth);
      writer.Write(MipMapCount);
      writer.Write(Reserved1_0);
      writer.Write(Reserved1_1);
      writer.Write(Reserved1_2);
      writer.Write(Reserved1_3);
      writer.Write(Reserved1_4);
      writer.Write(Reserved1_5);
      writer.Write(Reserved1_6);
      writer.Write(Reserved1_7);
      writer.Write(Reserved1_8);
      writer.Write(Reserved1_9);
      writer.Write(Reserved1_10);

      PixelFormat.Write(writer);

      writer.Write(SurfaceFlags);
      writer.Write(CubemapFlags);
      writer.Write(Reserved2_0);
      writer.Write(Reserved2_1);
      writer.Write(Reserved2_2);

      writer.Flush();
    }

    #endregion Public Methods

  }

}
