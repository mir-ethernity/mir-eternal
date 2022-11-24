using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace UpkManager.Dds {
  //
  // http://stackoverflow.com/questions/21428272/show-rgba-image-from-memory
  //
  internal sealed class RgbaBitmapSource : BitmapSource {

    #region Private Fields

    private readonly byte[] rgbaBuffer;

    private readonly int pixelWidth;
    private readonly int pixelHeight;

    #endregion Private Fields

    #region Constructor

    internal RgbaBitmapSource(byte[] Rgba, int PixelWidth) {
      rgbaBuffer = Rgba;

      pixelWidth  = PixelWidth;
      pixelHeight = rgbaBuffer.Length / (4 * pixelWidth);
    }

    #endregion Constructor

    #region Overrides

    public override unsafe void CopyPixels(Int32Rect sourceRect, Array pixels, int stride, int offset) {
      Func<byte, byte, byte> preMultiply = (source, alpha) => (byte)(source * (double)alpha / 255.0 + 0.5);

      fixed(byte* source = rgbaBuffer, destination = (byte[])pixels) {
        byte* dstPtr = destination + offset;

        for(int y = sourceRect.Y; y < sourceRect.Y + sourceRect.Height; y++) {
          for(int x = sourceRect.X; x < sourceRect.X + sourceRect.Width; x++) {
            byte *srcPtr = source + stride * y + 4 * x;

            byte a = *(srcPtr + 3);

            *dstPtr++ = preMultiply(*(srcPtr + 2), a); // pre-multiplied B
            *dstPtr++ = preMultiply(*(srcPtr + 1), a); // pre-multiplied G
            *dstPtr++ = preMultiply(*(srcPtr + 0), a); // pre-multiplied R
            *dstPtr++ = a;
          }
        }
      }
    }

    protected override Freezable CreateInstanceCore() {
      return new RgbaBitmapSource(rgbaBuffer, pixelWidth);
    }

    public override BitmapPalette Palette => null;

    public override double DpiX => 96;

    public override double DpiY => 96;

    public override PixelFormat Format => PixelFormats.Pbgra32;

    public override int PixelWidth => pixelWidth;

    public override int PixelHeight => pixelHeight;

    public override double Width => pixelWidth;

    public override double Height => pixelHeight;

    public override bool IsDownloading => false;

    public override event EventHandler<DownloadProgressEventArgs> DownloadProgress {
      add { }
      remove { }
    }

    public override event EventHandler DownloadCompleted {
      add { }
      remove { }
    }

    public override event EventHandler<ExceptionEventArgs> DownloadFailed {
      add { }
      remove { }
    }

    public override event EventHandler<ExceptionEventArgs> DecodeFailed {
      add { }
      remove { }
    }

    #endregion Overrides

  }

}
