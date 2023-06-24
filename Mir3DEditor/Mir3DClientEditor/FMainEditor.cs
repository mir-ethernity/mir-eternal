using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mir3DClientEditor
{

    public partial class FMainEditor : Form
    {
        public string CurentPath { get; private set; }

        public event EventHandler<SaveFileEventArgs> SaveFile;

        public FMainEditor()
        {
            InitializeComponent();
            FormClosing += FMainEditor_FormClosing;
        }

        private void FMainEditor_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!MainEditor.HasPendingChanges) return;

            var result = MessageBox.Show($"Do you want to save the changes?", "Editor", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SaveFile?.Invoke(this, new SaveFileEventArgs { Buffer = MainEditor.GetBuffer(), Path = CurentPath });
            }
        }

        internal void LoadFile(string path, byte[] data, Func<string, byte[]?>? callbackToLoadDepFile = null)
        {
            CurentPath = path;
            Text = path;
            MainEditor.LoadEditor(path, data, callbackToLoadDepFile);
        }
    }
}
