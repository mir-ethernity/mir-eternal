using System;


namespace UpkManager.Dds.Constants {

  [Flags]
  internal enum HeaderFlags {

    None       = 0x00000000,

    Texture    = 0x00001007, // DDSD_CAPS | DDSD_HEIGHT | DDSD_WIDTH | DDSD_PIXELFORMAT
    MipMap     = 0x00020000, // DDSD_MIPMAPCOUNT
    Volume     = 0x00800000, // DDSD_DEPTH
    Pitch      = 0x00000008, // DDSD_PITCH
    LinearSize = 0x00080000  // DDSD_LINEARSIZE

  }

}
