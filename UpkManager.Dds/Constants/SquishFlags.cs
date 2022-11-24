using System;


namespace UpkManager.Dds.Constants {

  [Flags]
  internal enum SquishFlags {

    Unknown = 0,

    Dxt1 = 1 << 0, // Use DXT1 compression.
    Dxt3 = 1 << 1, // Use DXT3 compression.
    Dxt5 = 1 << 2, // Use DXT5 compression.

    ColourClusterFit = 1 << 3, // Use a slow but high quality colour compressor (the default).
    ColourRangeFit   = 1 << 4, // Use a fast but low quality colour compressor.

    ColourMetricPerceptual = 1 << 5, // Use a perceptual metric for colour error (the default).
    ColourMetricUniform    = 1 << 6, // Use a uniform metric for colour error.

    WeightColourByAlpha = 1 << 7, // Weight the colour by alpha during cluster fit (disabled by default).

    ColourIterativeClusterFit = 1 << 8, // Use a very slow but very high quality colour compressor.

  }

}
