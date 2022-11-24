using System;
using System.Threading;
using System.Threading.Tasks;

using UpkManager.Dds.Constants;


namespace UpkManager.Dds.Compression {

  internal static partial class DdsSquish {

    #region Public Methods

    public static unsafe byte[] CompressImage(byte[] rgba, int width, int height, SquishFlags flags, Action<int, int> progressFn) {
      //
      // fix any bad flags
      //
      flags = fixFlags(flags);
      //
      // initialise the block output
      //
      int blockCount = (width + 3 ) / 4 * ((height + 3) / 4);

      int blockSize = (flags & SquishFlags.Dxt1) != 0 ? 8 : 16;

      byte[] blocks = new byte[blockCount * blockSize];

      int progress = 0;

      progressFn?.Invoke(0, height);
      //
      // loop over blocks
      //
      fixed(byte *pBlocks = blocks) {
        byte *targetBlock = pBlocks;

        fixed(byte *pRgba = rgba) {
          byte *source = pRgba;

          Parallel.ForEach(SteppedEnumerable.SteppedRange(0, height, 4), y => {
            Parallel.ForEach(SteppedEnumerable.SteppedRange(0, width, 4), x => {
              //
              // build the 4x4 block of pixels
              //
              byte[] sourceRgba = new byte[16 * 4];

              int mask = 0;

              fixed(byte *pSourceRgba = sourceRgba) {
                byte *targetPixel = pSourceRgba;

                for(int py = 0; py < 4; ++py) {
                  for(int px = 0; px < 4; ++px) {
                    //
                    // get the source pixel in the image
                    //
                    int sx = x + px;
                    int sy = y + py;
                    //
                    // enable if we're in the image
                    //
                    if (sx < width && sy < height) {
                      //
                      // copy the rgba value
                      //
                      byte *sourcePixel = source + 4 * (width * sy + sx);

                      for(int i = 0; i < 4; ++i) *targetPixel++ = *sourcePixel++;
                      //
                      // enable this pixel
                      //
                      mask |= 1 << (4 * py + px);
                    }
                    else {
                      //
                      // skip this pixel as its outside the image
                      //
                      targetPixel += 4;
                    }
                  }
                }
                //
                // compress it into the output
                //
                int blockNum = (width + 3) / 4 * (y / 4) + x / 4;

                byte *outputBlock = targetBlock + blockSize * blockNum;

                compressMasked(pSourceRgba, mask, outputBlock, flags);
              }
            });

            Interlocked.Add(ref progress, 4);

            progressFn?.Invoke(progress, height);
          });
        }
      }

      progressFn?.Invoke(height, height);

      return blocks;
    }

    #endregion Public Methods

    #region Private Methods

    private static unsafe void compressMasked(byte *rgba, int mask, byte *block, SquishFlags flags) {
      //
      // get the block locations
      //
      byte *colourBlock = block;
      byte *alphaBlock  = block;

      if ((flags & (SquishFlags.Dxt3 | SquishFlags.Dxt5)) != 0) colourBlock = block + 8;
      //
      // create the minimal point set
      //
      ColourSet colours = new ColourSet(rgba, mask, flags);
      //
      // check the compression type and compress colour
      //
      if (colours.Count == 1) {
        //
        // always do a single colour fit
        //
        SingleColourFit fit = new SingleColourFit(colours, flags);

        fit.Compress(colourBlock);
      }
      else if ((flags & SquishFlags.ColourRangeFit) != 0 || colours.Count == 0) {
        //
        // do a range fit
        //
        RangeFit fit = new RangeFit(colours, flags);

        fit.Compress(colourBlock);
      }
      else {
        //
        // default to a cluster fit (could be iterative or not)
        //
        ClusterFit fit = new ClusterFit(colours, flags);

        fit.Compress(colourBlock);
      }
      //
      // compress alpha separately if necessary
      //
      if ((flags & SquishFlags.Dxt3) != 0) compressAlphaDxt3(rgba, mask, alphaBlock);
      else if ((flags & SquishFlags.Dxt5) != 0) compressAlphaDxt5(rgba, mask, alphaBlock);
    }

    private static unsafe void compressAlphaDxt3(byte *rgba, int mask, byte *block) {
      byte *bytes = block;
      //
      // quantise and pack the alpha values pairwise
      //
      for(int i = 0; i < 8; ++i) {
        //
        // quantise down to 4 bits
        //
        float alpha1 = rgba[8 * i + 3] * (15.0f / 255.0f);
        float alpha2 = rgba[8 * i + 7] * (15.0f / 255.0f);

        int quant1 = ColourBlock.FloatToInt(alpha1, 15);
        int quant2 = ColourBlock.FloatToInt(alpha2, 15);
        //
        // set alpha to zero where masked
        //
        int bit1 = 1 << (2 * i);
        int bit2 = 1 << (2 * i + 1);

        if ((mask & bit1) == 0) quant1 = 0;
        if ((mask & bit2) == 0) quant2 = 0;
        //
        // pack into the byte
        //
        bytes[i] = (byte)(quant1 | (quant2 << 4));
      }
    }

    private static unsafe void compressAlphaDxt5(byte *rgba, int mask, byte *block) {
      //
      // get the range for 5-alpha and 7-alpha interpolation
      //
      int min5 = 255;
      int max5 = 0;

      int min7 = 255;
      int max7 = 0;

      for(int i = 0; i < 16; ++i) {
        //
        // check this pixel is valid
        //
        int bit = 1 << i;

        if ((mask & bit) == 0) continue;
        //
        // incorporate into the min/max
        //
        int value = rgba[4 * i + 3];

        if (value < min7) min7 = value;
        if (value > max7) max7 = value;

        if (value !=   0 && value < min5) min5 = value;
        if (value != 255 && value > max5) max5 = value;
      }
      //
      // handle the case that no valid range was found
      //
      if (min5 > max5) min5 = max5;
      if (min7 > max7) min7 = max7;
      //
      // fix the range to be the minimum in each case
      //
      fixRange(ref min5, ref max5, 5);
      fixRange(ref min7, ref max7, 7);
      //
      // set up the 5-alpha code book
      //
      byte[] codes5 = new byte[8];

      codes5[0] = (byte)min5;
      codes5[1] = (byte)max5;

      for(int i = 1; i < 5; ++i) codes5[1 + i] = (byte)(((5 - i) * min5 + i * max5) / 5);

      codes5[6] = 0;
      codes5[7] = 255;
      //
      // set up the 7-alpha code book
      //
      byte[] codes7 = new byte[8];

      codes7[0] = (byte)min7;
      codes7[1] = (byte)max7;

      for(int i = 1; i < 7; ++i) codes7[1 + i] = (byte)(((7 - i) * min7 + i * max7) / 7);
      //
      // fit the data to both code books
      //
      byte[] indices5 = new byte[16];
      byte[] indices7 = new byte[16];

      int err5 = fitCodes(rgba, mask, codes5, indices5);
      int err7 = fitCodes(rgba, mask, codes7, indices7);
      //
      // save the block with least error
      //
      if (err5 <= err7) writeAlphaBlock5(min5, max5, indices5, block);
      else writeAlphaBlock7(min7, max7, indices7, block);
    }

    private static void fixRange(ref int min, ref int max, int steps) {
      if (max - min < steps) max = Math.Min(min + steps, 255);

      if (max - min < steps) min = Math.Max(0, max - steps);
    }

    private static unsafe int fitCodes(byte *rgba, int mask, byte[] codes, byte[] indices) {
      //
      // fit each alpha value to the codebook
      //
      int err = 0;

      for(int i = 0; i < 16; ++i) {
        //
        // check this pixel is valid
        //
        int bit = 1 << i;

        if ((mask & bit) == 0) {
          //
          // use the first code
          //
          indices[i] = 0;

          continue;
        }
        //
        // find the least error and corresponding index
        //
        int value = rgba[4 * i + 3];

        int least = Int32.MaxValue;

        int index = 0;

        for(int j = 0; j < 8; ++j) {
          //
          // get the squared error from this code
          //
          int dist = value - codes[j];

          dist *= dist;
          //
          // compare with the best so far
          //
          if (dist < least) {
            least = dist;

            index = j;
          }
        }
        //
        // save this index and accumulate the error
        //
        indices[i] = (byte)index;

        err += least;
      }
      //
      // return the total error
      //
      return err;
    }

    private static unsafe void writeAlphaBlock5(int alpha0, int alpha1, byte[] indices, byte *block) {
      //
      // check the relative values of the endpoints
      //
      if (alpha0 > alpha1) {
        //
        // swap the indices
        //
        byte[] swapped = new byte[16];

        for(int i = 0; i < 16; ++i) {
          byte index = indices[i];

          switch(index) {
            case 0:
              swapped[i] = 1;

              break;
            case 1:
              swapped[i] = 0;

              break;
            default:
              if (index <= 5) swapped[i] = (byte)(7 - index);
              else swapped[i] = index;

              break;
          }
        }

        writeAlphaBlock(alpha1, alpha0, swapped, block);
      }
      else writeAlphaBlock(alpha0, alpha1, indices, block);
    }

    private static unsafe void writeAlphaBlock7(int alpha0, int alpha1, byte[] indices, byte *block) {
      //
      // check the relative values of the endpoints
      //
      if (alpha0 < alpha1) {
        //
        // swap the indices
        //
        byte[] swapped = new byte[16];

        for(int i = 0; i < 16; ++i) {
          byte index = indices[i];

          switch(index) {
            case 0:
              swapped[i] = 1;

              break;
            case 1:
              swapped[i] = 0;

              break;
            default:
              swapped[i] = (byte)(9 - index);

              break;
          }
        }

        writeAlphaBlock(alpha1, alpha0, swapped, block);
      }
      else writeAlphaBlock(alpha0, alpha1, indices, block);
    }

    private static unsafe void writeAlphaBlock(int alpha0, int alpha1, byte[] indices, byte *block) {
      byte *bytes = block;
      //
      // write the first two bytes
      //
      bytes[0] = (byte)alpha0;
      bytes[1] = (byte)alpha1;
      //
      // pack the indices with 3 bits each
      //
      byte *dest = bytes + 2;

      fixed(byte *pIndices = indices) {
        byte *src = pIndices;

        for(int i = 0; i < 2; ++i) {
          //
          // pack 8 3-bit values
          //
          int value = 0;

          for(int j = 0; j < 8; ++j) {
            int index = *src++;

            value |= index << 3 * j;
          }
          //
          // store in 3 bytes
          for(int j = 0; j < 3; ++j) {
            int @byte = (value >> 8 * j) & 0xff;

            *dest++ = (byte)@byte;
          }
        }
      }
    }

    #endregion Private Methods

  }

}
