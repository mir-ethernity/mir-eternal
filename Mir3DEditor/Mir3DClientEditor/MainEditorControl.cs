using Mir3DClientEditor.FormValueEditors;
using Mir3DClientEditor.Services;
using Mir3DCrypto;
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
    public partial class MainEditorControl : UserControl
    {
        public bool IsEncrypted { get; private set; } = false;
        public BaseGridEditorControl? EditorControl { get; private set; } = null;
        public MPQExplorerControl? MPQControl { get; private set; } = null;

        public MainEditorControl()
        {
            InitializeComponent();
            Disposed += MainEditorControl_Disposed;
        }

        private void MainEditorControl_Disposed(object? sender, EventArgs e)
        {
            EditorControl?.Dispose();
            MPQControl?.Dispose();
            Controls.Clear();
        }

        public void LoadEditor(string path, byte[] buffer, Func<string, byte[]>? callbackToLoadDepFile = null)
        {
            IsEncrypted = false;
            EditorControl?.Dispose();
            EditorControl = null;
            MPQControl?.Dispose();
            MPQControl = null;

            Controls.Clear();

            switch (Path.GetExtension(path).ToLowerInvariant())
            {
                case ".txt":
                    EditorControl = new CSVGridEditorControl();
                    IsEncrypted = true;
                    buffer = Crypto.Decrypt(buffer);
                    break;
                case ".ini":
                case ".int":
                    EditorControl = new INIGridEditorControl();
                    IsEncrypted = true;
                    buffer = Crypto.Decrypt(buffer);
                    break;
                case ".upk":
                case ".umap":
                case ".udk":
                case ".u":
                    EditorControl = new UnrealEditorControl(callbackToLoadDepFile);
                    IsEncrypted = buffer[0] != 193 || buffer[1] != 131;
                    if (IsEncrypted)
                        buffer = Crypto.Decrypt(buffer);
                    break;
                case ".pak":
                    MPQControl = new MPQExplorerControl();
                    break;
                default:
                    throw new NotImplementedException();
            }

            if (EditorControl != null)
            {
                EditorControl.Dock = DockStyle.Fill;
                EditorControl.SetBuffer(path, buffer);
                Controls.Add(EditorControl);
            }
            else if (MPQControl != null)
            {
                MPQControl.Dock = DockStyle.Fill;
                MPQControl.LoadMPQ(new string[] { path });
                Controls.Add(MPQControl);
            }

        }

        public void LoadGameFolder(string path)
        {
            Controls.Clear();

            var files = Directory.GetFiles(path, "*.pak", SearchOption.AllDirectories);

            MPQControl = new MPQExplorerControl();
            MPQControl.Dock = DockStyle.Fill;

            Controls.Add(MPQControl);
            MPQControl.LoadMPQ(files);
        }

        public byte[] GetBuffer()
        {
            var buffer = EditorControl?.GetBuffer() ?? Array.Empty<byte>();

            return IsEncrypted ? Crypto.Encrypt(buffer) : buffer;
        }

        public bool HasPendingChanges => EditorControl?.HasPendingChangesToSave ?? false;
    }
}
