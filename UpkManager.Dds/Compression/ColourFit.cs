using UpkManager.Dds.Constants;


namespace UpkManager.Dds.Compression {

  internal abstract class ColourFit {

    #region Private Fields

    protected ColourSet colours;

    protected SquishFlags flags;

    #endregion Private Fields

    #region Constructor

    protected ColourFit(ColourSet Colours, SquishFlags Flags) {
      colours = Colours;
      flags   = Flags;
    }

    #endregion Constructor

    #region Public Methods

    public unsafe void Compress(byte *block) {
      bool isDxt1 = (flags & SquishFlags.Dxt1) != 0;

      if (isDxt1) {
        Compress3(block);

        if (!colours.IsTransparent) Compress4(block);
      }
      else Compress4(block);
    }

    #endregion Public Methods

    #region Protected Abstract Methods

    protected abstract unsafe void Compress3(byte *block);

    protected abstract unsafe void Compress4(byte *block);

    #endregion Protected Abstract Methods

  }

}
