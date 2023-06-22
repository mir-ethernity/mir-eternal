using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UELib;
using UELib.Core.Classes;

namespace Mir3DClientEditor.Dialogs
{
    public partial class FImageViewerDialog : Form
    {
        public FImageViewerDialog(UTexture2D obj)
        {
            InitializeComponent();
            UnrealObject = obj;
            SetImage(obj.MipMaps[0]);
            UpdateViewport();
            UpdateUI();
        }

        public UTexture2D UnrealObject { get; private set; }
        public UMipMap ActiveMipmap { get; private set; }

        private void UpdateViewport()
        {
            Width = ActiveImage.Width + 20;
            Height = ActiveImage.Height + 95;

            if (Width < 400) Width = 400;
            if (Height < 400) Height = 400;
        }

        private void UpdateUI()
        {
            LblCurrentImage.Text = string.Format("{0}/{1}", Array.IndexOf(UnrealObject.MipMaps, ActiveMipmap) + 1, UnrealObject.MipMaps.Length);
        }

        public void SetImage(UMipMap mipmap)
        {
            ActiveMipmap = mipmap;
            MainLayout.Panel1.BackColor = Color.Black;
            ActiveImage.Image = mipmap.ImageBitmap;
            ActiveImage.Width = mipmap.Width;
            ActiveImage.Height = mipmap.Height;
        }

        public static void Show(UTexture2D obj)
        {
            var dialog = new FImageViewerDialog(obj);

            dialog.ShowDialog();
        }

        private void BtnPrevMipmap_Click(object sender, EventArgs e)
        {
            var currentIndex = Array.IndexOf(UnrealObject.MipMaps, ActiveMipmap);
            if (currentIndex <= 0) return;
            SetImage(UnrealObject.MipMaps[currentIndex - 1]);
            UpdateUI();
        }

        private void BtnNextMipmap_Click(object sender, EventArgs e)
        {
            var currentIndex = Array.IndexOf(UnrealObject.MipMaps, ActiveMipmap);
            if (currentIndex + 1 >= UnrealObject.MipMaps.Length) return;
            SetImage(UnrealObject.MipMaps[currentIndex + 1]);
            UpdateUI();
        }

        private void ReplaceImageButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Images PNG (*.png)|*.png";
            dialog.CheckFileExists = true;
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;

            var bufferFile = File.ReadAllBytes(dialog.FileName);
            using (var ms = new MemoryStream(bufferFile))
            {
                var bitmap = new Bitmap(ms);
                ActiveMipmap.ImageBitmap = bitmap;
                ActiveMipmap.Width = bitmap.Width;
                ActiveMipmap.Height = bitmap.Height;

                ActiveMipmap.Texture2D.Properties.Set("SizeX", bitmap.Width);
                ActiveMipmap.Texture2D.Properties.Set("SizeY", bitmap.Height);
                ActiveMipmap.Texture2D.Properties.Set("OriginalSizeX", bitmap.Width);
                ActiveMipmap.Texture2D.Properties.Set("OriginalSizeY", bitmap.Height);

                SetImage(ActiveMipmap);
            }
            UpdateUI();

            MessageBox.Show("Image replaced OK");
        }

        private void ButtonExportImage_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Images PNG (*.png)|*.png";
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;

            // Obtener los datos del bitmap
            byte[] buffer = UTexture2D.ConvertBitmapToByteArray(ActiveMipmap.ImageBitmap);

            using (var ms = new MemoryStream())
            {
                int width = ActiveMipmap.ImageBitmap.Width;
                int height = ActiveMipmap.ImageBitmap.Height;

                // Crear un nuevo Bitmap con los datos
                using (var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb))
                {
                    BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bmp.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    System.Runtime.InteropServices.Marshal.Copy(buffer, 0, ptr, buffer.Length);
                    bmp.UnlockBits(bmpData);

                    // Guardar el bitmap como PNG en el MemoryStream
                    bmp.Save(ms, ImageFormat.Png);
                }

                // Guardar los datos del PNG en un archivo
                var pngData = ms.ToArray();
                File.WriteAllBytes(dialog.FileName, pngData);
                MessageBox.Show("Image exported OK");
            }
        }
    }
}
