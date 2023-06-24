using System.Linq;


namespace UpkManager.Dds.Compression {

  internal class Sym3x3 {

    #region Private Fields

    private readonly float[] x;

    #endregion Private Fields

    #region Constructors

    public Sym3x3() {
      x = new float[6];
    }

    public Sym3x3(float S) {
      x = Enumerable.Repeat(S, 6).ToArray();
    }

    #endregion Constructors

    #region Properties

    public float this[int index] {
      get { return x[index]; }
      set { x[index] = value; }
    }

    #endregion Properties

  }

}
