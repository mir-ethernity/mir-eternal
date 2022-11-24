using System;

using UpkManager.Dds.Compression.LookupTables;
using UpkManager.Dds.Constants;


namespace UpkManager.Dds.Compression {

  internal sealed class SingleColourFit : ColourFit {

    #region Private Fields

    private byte index;

    private int error;
    private int bestError;

    private Vec3 start;
    private Vec3 end;

    private readonly byte[] colour = new byte[3];

    #endregion Private Fields

    #region Constructor

    public SingleColourFit(ColourSet colours, SquishFlags flags) : base(colours, flags) {
      //
      // grab the single colour
      //
      Vec3[] values = colours.Points;

      colour[0] = (byte)ColourBlock.FloatToInt(255.0f * values[0].X, 255);
      colour[1] = (byte)ColourBlock.FloatToInt(255.0f * values[0].Y, 255);
      colour[2] = (byte)ColourBlock.FloatToInt(255.0f * values[0].Z, 255);
      //
      // initialise the best error
      //
      bestError = Int32.MaxValue;
    }

    #endregion Constructor

    #region Overrides

    protected override unsafe void Compress3(byte *block) {
      //
      // build the table of lookups
      //
      SingleColourLookup[][] lookups = {
        SingleColourLookups.Lookup_5_3,
        SingleColourLookups.Lookup_6_3,
        SingleColourLookups.Lookup_5_3
      };
      //
      // find the best end-points and index
      //
      computeEndPoints(lookups);
      //
      // build the block if we win
      //
      if (error < bestError) {
        //
        // remap the indices
        //
        byte[] indices = new byte[16];
        //
        // The c++ passed a pointer to index and that pointer was used as an array.  If the RemapIndices method
        // throws an IndexOutOfRangeException, then it was definitely a bug in the c++.
        //
        colours.RemapIndices(new byte[] { index }, indices);
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
      // build the table of lookups
      //
      SingleColourLookup[][] lookups = {
        SingleColourLookups.Lookup_5_4,
        SingleColourLookups.Lookup_6_4,
        SingleColourLookups.Lookup_5_4
      };
      //
      // find the best end-points and index
      //
      computeEndPoints(lookups);
      //
      // build the block if we win
      //
      if (error < bestError) {
        //
        // remap the indices
        //
        byte[] indices = new byte[16];
        //
        // The c++ passed a pointer to index and that pointer was used as an array.  If the RemapIndices method
        // throws an IndexOutOfRangeException, then it was definitely a bug in the c++.
        //
        colours.RemapIndices(new byte[] { index }, indices);
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

    #region Private Methods

    private void computeEndPoints(SingleColourLookup[][] lookups) {
      //
      // check each index combination (endpoint or intermediate)
      //
      error = Int32.MaxValue;

      for(int i = 0; i < 2; ++i) {
        //
        // check the error for this codebook index
        //
        SourceBlock[] sources = new SourceBlock[3];

        int err = 0;

        for(int channel = 0; channel < 3; ++channel) {
          //
          // grab the lookup table and index for this channel
          //
          SingleColourLookup[] lookup = lookups[channel];

          int target = colour[channel];
          //
          // store a pointer to the source for this channel
          //
          sources[channel] = lookup[target].sources[i];
          //
          // accumulate the error
          //
          int diff = sources[channel].error;

          err += diff * diff;
        }
        //
        // keep it if the error is lower
        //
        if (err < error) {
          start = new Vec3(sources[0].start / 31.0f, sources[1].start / 63.0f, sources[2].start / 31.0f);

          end = new Vec3(sources[0].end / 31.0f, sources[1].end / 63.0f, sources[2].end / 31.0f);

          index = (byte)(2 * i);

          error = err;
        }
      }
    }

    #endregion Private Methods

  }

}
