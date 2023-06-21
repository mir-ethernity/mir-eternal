using Microsoft.VisualBasic;
using Mir3DClientEditor.FormValueEditors;
using Mir3DClientEditor.Services;
using Mir3DCrypto;
using System.Globalization;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Text;
using UELib;

namespace Mir3DClientEditor
{
    public partial class FMain : Form
    {
        public IGrouping<UELib.Core.UObject, UELib.Core.UObject>[] UnrealClasses { get; private set; }

        public string CurrentPath = string.Empty;

        public FMain()
        {
            InitializeComponent();
        }

        private void Menu_OpenFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "All Mir3D Files|*.pak;*.txt;*.ini;*.int;*.upk;*.umap;*.udk;*.u|Mir3D txt file|*.txt|Mir3D ini file|*.ini|Mir3D int file|*.int|Mir3D UPK file|*.upk|Mir3D UMAP file|*.umap|Mir3D UDK|*.udk|Mir3D U File|*.u|Mir3D Pak File|*.pak";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            CurrentPath = dialog.FileName;

            LoadFile(CurrentPath);

            UpdateUI();
        }

        private void LoadFile(string path)
        {
            var buffer = File.ReadAllBytes(path);
            MainEditor.LoadEditor(path, buffer);
        }

        private void SaveFile(string path)
        {
            if (MainEditor.MPQControl != null)
            {
                MessageBox.Show($"PAK files are saved automatically, not require save.");
                return;
            }

            var buffer = MainEditor.GetBuffer();
            File.WriteAllBytes(path, buffer);
            MessageBox.Show("File Saved!");
        }

        private void UpdateUI()
        {
            LblActiveFile.Text = $"File: {CurrentPath}";
        }

        private void Menu_Save_Click(object sender, EventArgs e)
        {
            SaveFile(CurrentPath);
        }

        private void Menu_File_SaveAs_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.InitialDirectory = Path.GetDirectoryName(CurrentPath);
            dialog.FileName = Path.GetFileName(CurrentPath);
            dialog.DefaultExt = Path.GetExtension(CurrentPath);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveFile(dialog.FileName);
            }
        }

        private void Menu_File_OpenGameFolder_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MainEditor.LoadGameFolder(dialog.SelectedPath);
            }
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            var splash = new FSplash();
            splash.ShowDialog();
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var splash = new FSplash();
            splash.ShowDialog();
        }

        private void SyncClientTextsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FSyncClientTexts();
            form.ShowDialog();
            form.Dispose();
        }

        private void locateUPKNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainEditor == null)
            {
                MessageBox.Show("Please, open game folder to search masivally a name");
                return;
            }

            var control = MainEditor.Controls.OfType<MPQExplorerControl>().FirstOrDefault();
            if (control == null)
            {
                MessageBox.Show("Please, open game folder to search masivally a name");
                return;
            }

            var nameToSearch = Interaction.InputBox("Specify name to search", "Name Search Locator");

            if (string.IsNullOrEmpty(nameToSearch))
                return;

            var found = new List<string>();

            foreach (var archive in control._archives)
            {
                foreach (var file in archive.ListFiles)
                {
                    using var stream = archive.Archive.OpenFile(file.Path);
                    var data = new byte[stream.Length];
                    stream.Read(data, 0, data.Length);
                    data = Crypto.Decrypt(data);

                    switch (Path.GetExtension(file.Path))
                    {
                        case ".upk":
                        case ".u":
                            var package = UnrealLoader.LoadPackage(file.Path, data);
                            var exists = package.Names?.Any(x => x.Name.Contains(nameToSearch, StringComparison.InvariantCultureIgnoreCase)) ?? false;
                            if (exists)
                                found.Add(file.Path);
                            break;
                        case ".txt":
                            var rawContent = data.DecodeString(out Encoding encoding);
                            if (rawContent.Contains(nameToSearch, StringComparison.InvariantCultureIgnoreCase))
                                found.Add(file.Path);
                            break;
                    }

                }
            }

            if (found.Count == 0)
            {
                MessageBox.Show($"Not found input");
            }
            else
            {
                MessageBox.Show($"Found in this files:\n{string.Join('\n', found.Select(x => $" - {x}").ToArray())}");
            }
        }
    }
}