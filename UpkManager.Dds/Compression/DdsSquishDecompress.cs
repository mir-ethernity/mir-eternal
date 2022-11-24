using System;
using System.Threading;
using System.Threading.Tasks;

using UpkManager.Dds.Constants;


namespace UpkManager.Dds.Compression {

  internal static partial class DdsSquish {

    #region Public Methods

    public static unsafe byte[] DecompressImage(int width, int height, byte[] blocks, SquishFlags flags, Action<int, int> progressFn) {
      //
      // fix any bad flags
      //
      flags = fixFlags(flags);
      //
      // initialise the block input
      //
      byte[] dest = new byte[width * height * 4];

      int bytesPerBlock = (flags & SquishFlags.Dxt1) != 0 ? 8 : 16;

      int progress = 0;

      progressFn?.Invoke(0, height);
      //
      // loop over blocks
      //
      fixed(byte *pBlocks = blocks) {
        byte *source = pBlocks;

        fixed(byte *pDest = dest) {
          byte *rgba = pDest;

          Parallel.ForEach(SteppedEnumerable.SteppedRange(0, height, 4), y => {
            Parallel.ForEach(SteppedEnumerable.SteppedRange(0, width, 4), x => {
              //
              // decompress the block
              //
              int blockNum = (width + 3) / 4 * (y / 4) + x / 4;

              byte *sourceBlock = source + bytesPerBlock * blockNum;

              byte[] targetRgba = new byte[4 * 16];
              //
              // write the decompressed pixels to the correct image locations
              //
              fixed(byte *pTargetRgba = targetRgba) {
                decompress(pTargetRgba, sourceBlock, flags);

                byte *sourcePixel = pTargetRgba;

                for(int py = 0; py < 4; ++py) {
                  for(int px = 0; px < 4; ++px) {
                    //
                    // get the target location
                    //
                    int sx = x + px;
                    int sy = y + py;

                    if (sx < width && sy < height) {
                      byte *targetPixel = rgba + 4 * (width * sy + sx);
                      //
                      // copy the rgba value
                      //
                      for(int i = 0; i < 4; ++i) *targetPixel++ = *sourcePixel++;
                    }
                    else {
                      //
                      // skip this pixel as it is outside the image
                      //
                      sourcePixel += 4;
                    }
                  }
                }
              }

              Interlocked.Add(ref progress, 4);

              progressFn?.Invoke(progress, height);
            });
          });
        }
      }

      progressFn?.Invoke(height, height);

      return dest;
    }

    #endregion Public Methods

    #region Private Methods

    private static SquishFlags fixFlags(SquishFlags flags) {
      //
      // grab the flag bits
      //
      SquishFlags method = flags & (SquishFlags.Dxt1 | SquishFlags.Dxt3 | SquishFlags.Dxt5);

      SquishFlags fit = flags & (SquishFlags.ColourIterativeClusterFit | SquishFlags.ColourClusterFit | SquishFlags.ColourRangeFit);

      SquishFlags metric = flags & (SquishFlags.ColourMetricPerceptual | SquishFlags.ColourMetricUniform);

      SquishFlags extra = flags & SquishFlags.WeightColourByAlpha;
      //
      // set defaults
      //
      if (method != SquishFlags.Dxt3 && method != SquishFlags.Dxt5) method = SquishFlags.Dxt1;

      if (fit != SquishFlags.ColourRangeFit && fit != SquishFlags.ColourIterativeClusterFit) fit = SquishFlags.ColourClusterFit;

      if (metric != SquishFlags.ColourMetricUniform) metric = SquishFlags.ColourMetricPerceptual;
      //
      // done
      //
      return method | fit | metric | extra;
    }

    private static unsafe void decompress(byte *rgba, byte *block, SquishFlags flags) {
      //
      // get the block locations
      //
      byte *colourBlock = block;
      byte *alphaBock   = block;

      if ((flags & (SquishFlags.Dxt3 | SquishFlags.Dxt5)) != 0 ) colourBlock = block + 8;
      //
      // decompress colour
      //
      decompressColour(rgba, colourBlock, (flags & SquishFlags.Dxt1) != 0 );
      //
      // decompress alpha separately if necessary
      //
      if ((flags & SquishFlags.Dxt3) != 0) decompressAlphaDxt3(rgba, alphaBock);
      else if ((flags & SquishFlags.Dxt5) != 0) decompressAlphaDxt5(rgba, alphaBock);
    }

    private static unsafe void decompressColour(byte *rgba, byte *block, bool isDxt1) {
      //
      // get the block bytes
      //
      byte *bytes = block;
      //
      // unpack the endpoints
      //
      byte[] codes = new byte[16];

      int a;
      int b;

      fixed(byte *pCodes = codes) {
        a = unpack565(bytes, pCodes);
        b = unpack565(bytes + 2, pCodes + 4);
      }
      //
      // generate the midpoints
      //
      for(int i = 0; i < 3; ++i) {
        int c = codes[i];
        int d = codes[4 + i];

        if (isDxt1 && a <= b) {
          codes[ 8 + i] = (byte)((c + d) / 2);
          codes[12 + i] = 0;
        }
        else {
          codes[ 8 + i] = (byte)((2 * c + d ) / 3);
          codes[12 + i] = (byte)((c + 2 * d ) / 3);
        }
      }
      //
      // fill in alpha for the intermediate values
      //
      codes[ 8 + 3] = 255;
      codes[12 + 3] = (byte)(isDxt1 && a <= b ? 0 : 255);
      //
      // unpack the indices
      //
      byte[] indices = new byte[16];

      fixed(byte *pIndices = indices) {
        for(int i = 0; i < 4; ++i) {
          byte* ind = pIndices + 4 * i;

          byte packed = bytes[4 + i];

          ind[0] = (byte)((packed >> 0) & 0x3);
          ind[1] = (byte)((packed >> 2) & 0x3);
          ind[2] = (byte)((packed >> 4) & 0x3);
          ind[3] = (byte)((packed >> 6) & 0x3);
        }
      }
      //
      // store out the colours
      //
      for(int i = 0; i < 16; ++i ) {
        byte offset = (byte)(4 * indices[i]);

        for(int j = 0; j < 4; ++j) rgba[4 * i + j] = codes[offset + j];
      }
    }

    private static unsafe int unpack565(byte *packed, byte *colour) {
      //
      // build the packed value
      //
      int value = packed[0] | (packed[1] << 8);
      //
      // get the components in the stored range
      //
      byte red   = (byte)((value >> 11) & 0x1f);
      byte green = (byte)((value >>  5) & 0x3f);
      byte blue  = (byte)((value >>  0) & 0x1f);
      //
      // scale up to 8 bits
      //
      colour[0] = (byte)((red   << 3) | (red   >> 2));
      colour[1] = (byte)((green << 2) | (green >> 4));
      colour[2] = (byte)((blue  << 3) | (blue  >> 2));
      colour[3] = 255;
      //
      // return the value
      //
      return value;
    }

    private static unsafe void decompressAlphaDxt3(byte *rgba, byte *block) {
      byte *bytes = block;
      //
      // unpack the alpha values pairwise
      //
      for(int i = 0; i < 8; ++i) {
        //
        // quantise down to 4 bits
        //
        byte quant = bytes[i];
        //
        // unpack the values
        //
        byte lo = (byte)(quant & 0x0f);
        byte hi = (byte)(quant & 0xf0);
        //
        // convert back up to bytes
        //
        rgba[8 * i + 3] = (byte)(lo | (lo << 4));
        rgba[8 * i + 7] = (byte)(hi | (hi >> 4));
      }
    }

    private static unsafe void decompressAlphaDxt5(byte *rgba, byte *block) {
      //
      // get the two alpha values
      //
      byte *bytes = block;

      int alpha0 = bytes[0];
      int alpha1 = bytes[1];
      //
      // compare the values to build the codebook
      //
      byte[] codes = new byte[8];

      codes[0] = (byte)alpha0;
      codes[1] = (byte)alpha1;

      if (alpha0 <= alpha1) {
        //
        // use 5-alpha codebook
        //
        for(int i = 1; i < 5; ++i) codes[1 + i] = (byte)(((5 - i) * alpha0 + i * alpha1) / 5);

        codes[6] =   0;
        codes[7] = 255;
      }
      else {
        //
        // use 7-alpha codebook
        //
        for(int i = 1; i < 7; ++i) codes[1 + i] = (byte)(((7 - i) * alpha0 + i * alpha1) / 7);
      }
      //
      // decode the indices
      //
      byte[] indices = new byte[16];

      byte *src = bytes + 2;

      fixed(byte *pIndices = indices) {
        byte *dest = pIndices;

        for(int i = 0; i < 2; ++i) {
          //
          // grab 3 bytes
          //
          int value = 0;

          for(int j = 0; j < 3; ++j) {
            int @byte = *src++;

            value |= @byte << 8 * j;
          }
          //
          // unpack 8 3-bit values from it
          //
          for(int j = 0; j < 8; ++j) {
            int index = (value >> 3 * j) & 0x7;

            *dest++ = (byte)index;
          }
        }
      }
      //
      // write out the indexed codebook values
      //
      for(int i = 0; i < 16; ++i) rgba[4 * i + 3] = codes[indices[i]];
    }

    #endregion Private Methods

  }

}
