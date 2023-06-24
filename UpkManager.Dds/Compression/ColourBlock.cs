

namespace UpkManager.Dds.Compression {

  internal static class ColourBlock {

    #region Public Methods

    public static unsafe void WriteColourBlock3(Vec3 start, Vec3 end, byte[] indices, byte *block) {
      //
      // get the packed values
      //
      int a = floatTo565(start);
      int b = floatTo565(end);
      //
      // remap the indices
      //
      byte[] remapped = new byte[16];

      if (a <= b) {
        //
        // use the indices directly
        //
        for(int i = 0; i < 16; ++i) remapped[i] = indices[i];
      }
      else {
        //
        // swap a and b
        //
        int t = a;

        a = b;

        b = t;

        for(int i = 0; i < 16; ++i) {
          switch(indices[i]) {
            case 0:
              remapped[i] = 1;
              break;
            case 1:
              remapped[i] = 0;
              break;
            default:
              remapped[i] = indices[i];
              break;
          }
        }
      }
      //
      // write the block
      //
      writeColourBlock(a, b, remapped, block);
    }

    public static unsafe void WriteColourBlock4(Vec3 start, Vec3 end, byte[] indices, byte *block) {
      //
      // get the packed values
      //
      int a = floatTo565(start);
      int b = floatTo565(end);
      //
      // remap the indices
      //
      byte[] remapped = new byte[16];

      if (a < b) {
        //
        // swap a and b
        //
        int t = a;

        a = b;

        b = t;

        for(int i = 0; i < 16; ++i) remapped[i] = (byte)((indices[i] ^ 0x1) & 0x3);
      }
      else if (a == b) {
        //
        // use index 0
        for(int i = 0; i < 16; ++i) remapped[i] = 0;
      }
      else {
        //
        // use the indices directly
        //
        for(int i = 0; i < 16; ++i) remapped[i] = indices[i];
      }
      //
      // write the block
      //
      writeColourBlock(a, b, remapped, block);
    }

    public static int FloatToInt(float a, int limit) {
      //
      // use ANSI round-to-zero behaviour to get round-to-nearest
      //
      int i = (int)(a + 0.5f);
      //
      // clamp to the limit
      //
      if (i < 0) i = 0;
      else {
        if (i > limit) i = limit;
      }
      //
      // done
      //
      return i;
    }

    #endregion Public Methods

    #region Private Methods

    private static unsafe void writeColourBlock(int a, int b, byte[] indices, byte *block) {
      //
      // get the block as bytes
      //
      byte *bytes = block;
      //
      // write the endpoints
      //
      bytes[0] = (byte)(a & 0xff);
      bytes[1] = (byte)(a >> 8);
      bytes[2] = (byte)(b & 0xff);
      bytes[3] = (byte)(b >> 8);
      //
      // write the indices
      //
      fixed(byte *pIndicies = indices) {
        for(int i = 0; i < 4; ++i) {
          byte *ind = pIndicies + 4 * i;

          bytes[4 + i] = (byte)(ind[0] | (ind[1] << 2) | (ind[2] << 4) | (ind[3] << 6));
        }
      }
    }

    private static int floatTo565(Vec3 colour) {
      //
      // get the components in the correct range
      //
      int r = FloatToInt(31.0f * colour.X, 31);
      int g = FloatToInt(63.0f * colour.Y, 63);
      int b = FloatToInt(31.0f * colour.Z, 31);
      //
      // pack into a single value
      //
      return (r << 11) | (g << 5) | b;
    }

    #endregion Private Methods

  }

}
