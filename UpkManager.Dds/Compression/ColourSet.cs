using System;

using UpkManager.Dds.Constants;


namespace UpkManager.Dds.Compression {

  internal sealed class ColourSet {

    #region Private Fields

    private readonly int[] remap = new int[16];

    #endregion Private Fields

    #region Constructor

    public unsafe ColourSet(byte *rgba, int mask, SquishFlags flags) {
      Count = 0;

      IsTransparent = false;
      //
      // check the compression mode for dxt1
      //
      bool isDxt1        = (flags & SquishFlags.Dxt1) != 0;
      bool weightByAlpha = (flags & SquishFlags.WeightColourByAlpha) != 0;
      //
      // create the minimal set
      //
      for (int i = 0; i < 16; ++i) {
        //
        // check this pixel is enabled
        //
        int bit = 1 << i;

        if ((mask & bit) == 0) {
          remap[i] = -1;

          continue;
        }
        //
        // check for transparent pixels when using dxt1
        //
        if (isDxt1 && rgba[4 * i + 3] < 128) {
          remap[i] = -1;

          IsTransparent = true;

          continue;
        }
        //
        // loop over previous points for a match
        //
        for(int j = 0; ; ++j) {
          //
          // allocate a new point
          //
          if (j == i) {
            //
            // normalise coordinates to [0,1]
            //
            float x = rgba[4 * i + 0] / 255.0f;
            float y = rgba[4 * i + 1] / 255.0f;
            float z = rgba[4 * i + 2] / 255.0f;
            //
            // ensure there is always non-zero weight even for zero alpha
            //
            float w = (rgba[4 * i + 3] + 1) / 256.0f;
            //
            // add the point
            //
            Points[Count]  = new Vec3(x, y, z);

            Weights[Count] = weightByAlpha ? w : 1.0f;

            remap[i] = Count;
            //
            // advance
            //
            ++Count;

            break;
          }
          //
          // check for a match
          //
          int oldbit = 1 << j;

          bool match = ((mask & oldbit) != 0) && (rgba[4 * i + 0] == rgba[4 * j])
                                              && (rgba[4 * i + 1] == rgba[4 * j + 1])
                                              && (rgba[4 * i + 2] == rgba[4 * j + 2])
                                              && (rgba[4 * j + 3] >= 128 || !isDxt1);

          if (match) {
            //
            // get the index of the match
            //
            int index = remap[j];
            //
            // ensure there is always non-zero weight even for zero alpha
            //
            float w = (rgba[4 * i + 3] + 1) / 256.0f;
            //
            // map to this point and increase the weight
            //
            Weights[index] += weightByAlpha ? w : 1.0f;

            remap[i] = index;

            break;
          }
        }
      }
      //
      // square root the weights
      //
      for (int i = 0; i < Count; ++i) Weights[i] = (float)Math.Sqrt(Weights[i]);
    }

    #endregion Constructor

    #region Properties

    public bool IsTransparent { get; }

    public float[] Weights { get; } = new float[16];

    public int Count { get; }

    public Vec3[] Points { get; } = new Vec3[16];

    #endregion Properties

    #region Public Methods

    public void RemapIndices(byte[] source, byte[] target) {
      for(int i = 0; i < 16; ++i) {
        int j = remap[i];

        if (j == -1) target[i] = 3;
        else target[i] = source[j];
      }
    }

    #endregion Public Methods

  }

}
