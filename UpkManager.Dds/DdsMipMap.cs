using System.Diagnostics.CodeAnalysis;


namespace UpkManager.Dds {

  [SuppressMessage("ReSharper", "MemberCanBeInternal")]
  [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
  [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
  public sealed class DdsMipMap {

    internal DdsMipMap(int width, int height, byte[] mipMap = null) {
      Width  = width;
      Height = height;

      MipMap = mipMap;
    }

    public int Width { get; set; }

    public int Height { get; set; }

    public byte[] MipMap { get; set; }

  }

}
