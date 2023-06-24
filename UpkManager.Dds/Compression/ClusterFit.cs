using System;

using UpkManager.Dds.Constants;


namespace UpkManager.Dds.Compression {

  internal class ClusterFit : ColourFit {

    #region Private Fields

    private float bestError;

    private Vec3 start;
    private Vec3 end;

    private Vec3 metric;

    #endregion Private Fields

    #region Constructor

    public ClusterFit(ColourSet Colours, SquishFlags Flags) : base(Colours, Flags) {
      //
      // initialise the metric
      //
      bool isPerceptual = (flags & SquishFlags.ColourMetricPerceptual) != 0;

      metric = isPerceptual ? new Vec3(0.2126f, 0.7152f, 0.0722f) : new Vec3(1.0f);
      //
      // initialise the best error
      //
      bestError = Single.MaxValue;
      //
      // cache some values
      //
      int count = colours.Count;

      Vec3[] values = colours.Points;

      float[] weights = colours.Weights;
      //
      // get the covariance matrix
      //
      Sym3x3 covariance = Maths.ComputeWeightedCovariance(count, values, weights);
      //
      // compute the principle component
      //
      Vec3 principle = Maths.ComputePrincipleComponent(covariance);
      //
      // get the min and max range as the codebook endpoints
      //
      Vec3 startTemp = new Vec3(0.0f);
      Vec3   endTemp = new Vec3(0.0f);

      if (count > 0) {
        //
        // compute the range
        //
        startTemp = endTemp = values[0];

        float min = Vec3.Dot(values[0], principle);

        float max = min;

        for(int i = 1; i < count; ++i) {
          float val = Vec3.Dot(values[i], principle);

          if (val < min) {
            startTemp = values[i];

            min = val;
          }
          else {
            if (val > max) {
              endTemp = values[i];

              max = val;
            }
          }
        }
      }
      //
      // clamp the output to [0, 1]
      //
      Vec3 one  = new Vec3(1.0f);
      Vec3 zero = new Vec3(0.0f);

      startTemp = Vec3.Min(one, Vec3.Max(zero, startTemp));
      endTemp   = Vec3.Min(one, Vec3.Max(zero, endTemp));
      //
      // clamp to the grid and save
      //
      Vec3 grid    = new Vec3(31.0f, 63.0f, 31.0f);
      Vec3 gridrcp = new Vec3(1.0f / 31.0f, 1.0f / 63.0f, 1.0f / 31.0f);
      Vec3 half    = new Vec3(0.5f);

      start = Vec3.Truncate(grid * startTemp + half) * gridrcp;
      end   = Vec3.Truncate(grid * endTemp   + half) * gridrcp;
    }

    #endregion Constructor

    #region Overrides

    protected override unsafe void Compress3(byte *block) {
      //
      // cache some values
      //
      int count = colours.Count;

      Vec3[] values = colours.Points;
      //
      // create a codebook
      //
      Vec3[] codes = new Vec3[3];

      codes[0] = start;
      codes[1] = end;
      codes[2] = 0.5f * start + 0.5f * end;
      //
      // match each point to the closest code
      //
      byte[] closest = new byte[16];

      float error = 0.0f;

      for(int i = 0; i < count; ++i) {
        //
        // find the closest code
        //
        float dist = Single.MaxValue;

        int idx = 0;

        for(int j = 0; j < 3; ++j) {
          float d = Vec3.LengthSquared(metric * (values[i] - codes[j]));

          if (d < dist) {
            dist = d;

            idx = j;
          }
        }
        //
        // save the index
        //
        closest[i] = (byte)idx;
        //
        // accumulate the error
        //
        error += dist;
      }
      //
      // save this scheme if it wins
      //
      if (error < bestError) {
        //
        // remap the indices
        //
        byte[] indices = new byte[16];

        colours.RemapIndices(closest, indices);
        //
        // save the block
        //
        ColourBlock.WriteColourBlock3(start, end, indices, block);
        //
        // save the error
        //
        bestError = error;
      }
    }

    protected override unsafe void Compress4(byte *block) {
      //
      // cache some values
      //
      int count = colours.Count;

      Vec3[] values = colours.Points;
      //
      // create a codebook
      //
      Vec3[] codes = new Vec3[4];

      codes[0] = start;
      codes[1] = end;
      codes[2] = 2.0f / 3.0f * start + 1.0f / 3.0f * end;
      codes[3] = 1.0f / 3.0f * start + 2.0f / 3.0f * end;
      //
      // match each point to the closest code
      //
      byte[] closest = new byte[16];

      float error = 0.0f;

      for(int i = 0; i < count; ++i) {
        //
        // find the closest code
        //
        float dist = Single.MaxValue;

        int idx = 0;

        for(int j = 0; j < 4; ++j) {
          float d = Vec3.LengthSquared(metric * (values[i] - codes[j]));

          if (d < dist) {
            dist = d;

            idx = j;
          }
        }
        //
        // save the index
        //
        closest[i] = (byte)idx;
        //
        // accumulate the error
        //
        error += dist;
      }
      //
      // save this scheme if it wins
      //
      if (error < bestError) {
        //
        // remap the indices
        //
        byte[] indices = new byte[16];

        colours.RemapIndices(closest, indices);
        //
        // save the block
        //
        ColourBlock.WriteColourBlock4(start, end, indices, block);
        //
        // save the error
        //
        bestError = error;
      }
    }

    #endregion Overrides

  }

}
