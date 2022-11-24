using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            if (Width < 200) Width = 200;
            if (Height < 200) Height = 200;
        }

        private void UpdateUI()
        {
            LblCurrentImage.Text = string.Format("{0}/{1}", Array.IndexOf(UnrealObject.MipMaps, ActiveMipmap) + 1, UnrealObject.MipMaps.Length);
        }

        public void SetImage(UMipMap mipmap)
        {
            ActiveMipmap = mipmap;
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
    }
}
