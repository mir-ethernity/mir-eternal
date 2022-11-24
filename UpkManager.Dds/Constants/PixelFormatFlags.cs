using System;


namespace UpkManager.Dds.Constants {

  [Flags]
  internal enum PixelFormatFlags {

    FourCC = 0x00000004,
    RGB    = 0x00000040,
    RGBA   = 0x00000041,
    Gray   = 0x00020000

  }

}
