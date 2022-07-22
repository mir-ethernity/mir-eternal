using System;
using System.Drawing;
using System.Text;

namespace Launcher
{
  public static class CapchaClass
  {
    public static string stringBuilded;

    public static Bitmap GenerateVerificationCode()
    {
      Bitmap bitmap = new Bitmap(200, 60);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      graphics.FillRectangle((Brush) new SolidBrush(Color.White), 0, 0, 200, 60);
      Font font = new Font(FontFamily.GenericSerif, 48f, FontStyle.Bold, GraphicsUnit.Pixel);
      Random random = new Random();
      string str = "ABCDEFGHIJKLMNPQRSTUVWXYZ0123456789";
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < 5; ++index)
      {
        string s = str.Substring(random.Next(0, str.Length - 1), 1);
        stringBuilder.Append(s);
        graphics.DrawString(s, font, (Brush) new SolidBrush(Color.Black), (float) (index * 38), (float) random.Next(0, 15));
      }
      CapchaClass.stringBuilded = stringBuilder.ToString();
      Pen pen = new Pen((Brush) new SolidBrush(Color.Black), 2f);
      for (int index = 0; index < 6; ++index)
        graphics.DrawLine(pen, new Point(random.Next(0, 199), random.Next(0, 59)), new Point(random.Next(0, 199), random.Next(0, 59)));
      return bitmap;
    }
  }
}
