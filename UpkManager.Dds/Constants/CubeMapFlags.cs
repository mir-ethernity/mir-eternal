using System;


namespace UpkManager.Dds.Constants {

  [Flags]
  internal enum CubeMapFlags {

    PositiveX = 0x00000600, // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_POSITIVEX
    NegativeX = 0x00000a00, // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_NEGATIVEX
    PositiveY = 0x00001200, // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_POSITIVEY
    NegativeY = 0x00002200, // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_NEGATIVEY
    PositiveZ = 0x00004200, // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_POSITIVEZ
    NegativeZ = 0x00008200, // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_NEGATIVEZ

    AllFaces = PositiveX | NegativeX | PositiveY | NegativeY | PositiveZ | NegativeZ

  }

}
