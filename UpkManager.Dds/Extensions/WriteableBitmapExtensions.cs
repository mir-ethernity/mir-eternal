using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace UpkManager.Dds.Extensions {

  internal static class WriteableBitmapExtensions {

    public static WriteableBitmap ResizeHighQuality(this BitmapSource source, int width, int height) {
      Rect rect = new Rect(0, 0, width, height);

      DrawingGroup group = new DrawingGroup();

      RenderOptions.SetBitmapScalingMode(group, BitmapScalingMode.HighQuality);

      group.Children.Add(new ImageDrawing(source, rect));

      DrawingVisual visual = new DrawingVisual();

      using(DrawingContext context = visual.RenderOpen()) {
        context.DrawDrawing(group);
      }

      RenderTargetBitmap destination = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);

      destination.Render(visual);

      return BitmapFactory.ConvertToPbgra32Format(destination);
    }

    public static unsafe byte[] ConvertToRgba(this WriteableBitmap source) {
      Func<byte, byte, byte> deMultiply = (color, alpha) => {
        if (alpha == 0) return color;

        return (byte)(255.0 * color / alpha + 0.5);
      };

      using(BitmapContext context = source.GetBitmapContext()) {
        byte[] rgba = new byte[context.Length * 4];

        int *src = context.Pixels;

        fixed(byte *dest = rgba) {
          byte *destPtr = dest;

          for(int i = 0; i < context.Length; ++i) {
            int color = src[i];

            byte b = (byte)((color >>  0) & 0xff);
            byte g = (byte)((color >>  8) & 0xff);
            byte r = (byte)((color >> 16) & 0xff);
            byte a = (byte)((color >> 24) & 0xff);

            *destPtr++ = deMultiply(r, a);
            *destPtr++ = deMultiply(g, a);
            *destPtr++ = deMultiply(b, a);
            *destPtr++ = a;
          }
        }

        return rgba;
      }
    }

  }

}
