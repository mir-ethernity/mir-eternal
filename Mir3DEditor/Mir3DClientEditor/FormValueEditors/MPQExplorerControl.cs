using Mir3DCrypto;
using StormLibSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mir3DClientEditor.FormValueEditors
{
    public partial class MPQExplorerControl : UserControl
    {

        public List<MpqArchiveManager> _archives = new List<MpqArchiveManager>();

        public MPQExplorerControl()
        {
            InitializeComponent();
            TreeFolders.AfterSelect += TreeFolders_AfterSelect;
            DataGrid.ReadOnly = true;
            DataGrid.CellDoubleClick += DataGrid_CellDoubleClick;
            DataGrid.CellMouseClick += DataGrid_CellMouseClick;
            DataGrid.AllowDrop = true;
            DataGrid.DragDrop += DataGrid_DragDrop;
            DataGrid.DragOver += DataGrid_DragOver;
            Disposed += MPQExplorerControl_Disposed;
        }

        private void DataGrid_DragOver(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void DataGrid_DragDrop(object? sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(DataFormats.FileDrop) ?? false)
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePath in files)
                {
                    var path = (GetSelectedDirectory() + '\\' + Path.GetFileName(filePath)).TrimStart('\\');
                    var manager = _archives.Where(x => x.ListFiles.Any(x => x.Path == path)).FirstOrDefault();
                    var buffer = System.IO.File.ReadAllBytes(filePath);
                    buffer = Crypto.Encrypt(buffer);

                    if (manager == null)
                    {
                        // Is a new file
                        var smallArchive = _archives.OrderBy(x => x.ListFiles.Sum(x => x.FileSize)).First();
                        var listFiles = new List<MpqArchiveManagerFile>(smallArchive.ListFiles.Length + 1);
                        listFiles.AddRange(smallArchive.ListFiles);
                        listFiles.Add(new MpqArchiveManagerFile
                        {
                            FileSize = (uint)buffer.Length,
                            FileTime = DateTime.Now,
                            Flags = 0,
                            Manager = smallArchive,
                            Path = path
                        });
                        smallArchive.ListFiles = listFiles.ToArray();
                        smallArchive.Archive.FileCreateFile(path, 0, buffer);
                    }
                    else
                    {
                        if (MessageBox.Show("File already exists. Are you sure do you want replace it?", "Replace file", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var file = manager.ListFiles.First(x => x.Path == path);
                            manager.Archive.FileCreateFile(path, file.Flags, buffer);
                        }
                    }
                }

                TreeFolders_AfterSelect(null, default(TreeViewEventArgs));
            }
        }

        private void DataGrid_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                ContextMenuStrip m = new ContextMenuStrip();
                var exportAs = new ToolStripMenuItem("Export As");
                exportAs.Click += ExportAs_Click;
                m.Items.Add(exportAs);
                var point = PointToClient(Cursor.Position);
                Point locationOnForm = DataGrid.FindForm().PointToClient(DataGrid.Parent.PointToScreen(DataGrid.Location));
                point = new Point(point.X - locationOnForm.X, point.Y - locationOnForm.Y);
                m.Show(DataGrid, point);
            }
        }

        private void ExportAs_Click(object? sender, EventArgs e)
        {
            var row = DataGrid.SelectedRows[0];
            var cell = row.Cells[0];

            var path = (GetSelectedDirectory() + '\\' + (string)cell.Value).TrimStart('\\');
            var manager = _archives.Where(x => x.ListFiles.Any(x => x.Path == path)).FirstOrDefault();
            if (manager == null) return;

            var saveDialog = new SaveFileDialog();
            saveDialog.FileName = Path.GetFileName(path);

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;

            using var fileStream = manager.Archive.OpenFile(path);

            var flags = fileStream.GetFlags();
            var data = new byte[fileStream.Length];
            fileStream.Read(data, 0, data.Length);

            data = Crypto.Decrypt(data);

            System.IO.File.WriteAllBytes(saveDialog.FileName, data);
        }

        private void MPQExplorerControl_Disposed(object? sender, EventArgs e)
        {
            foreach (var archive in _archives)
                archive.Archive.Dispose();
        }

        private void DataGrid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var row = DataGrid.Rows[e.RowIndex];
            var cell = row.Cells[0];

            var path = (GetSelectedDirectory() + '\\' + (string)cell.Value).TrimStart('\\');
            var manager = _archives.Where(x => x.ListFiles.Any(x => x.Path == path)).FirstOrDefault();
            if (manager == null) return;

            using var fileStream = manager.Archive.OpenFile(path);

            var flags = fileStream.GetFlags();
            var data = new byte[fileStream.Length];
            fileStream.Read(data, 0, data.Length);

            var form = new FMainEditor();
            form.SaveFile += (s, e) =>
            {
                manager.Archive.FileCreateFile(path, flags, e.Buffer);
            };
            form.LoadFile(path, data, LoadDependantFile);
            form.ShowDialog();
            form.Dispose();
        }

        private byte[]? LoadDependantFile(string file)
        {
            var fileManager = _archives.SelectMany(x => x.ListFiles)
                .Where(x => Path.GetFileNameWithoutExtension(x.Path) == file)
                .FirstOrDefault();

            if (fileManager == null)
                return null;

            using var fileStream = fileManager.Manager.Archive.OpenFile(fileManager.Path);

            var data = new byte[fileStream.Length];
            fileStream.Read(data, 0, data.Length);

            data = Crypto.Decrypt(data);

            return data;
        }

        private string GetSelectedDirectory()
        {
            var pathParts = new List<string>();
            var node = TreeFolders.SelectedNode;
            do
            {
                pathParts.Insert(0, node.Name);
            } while ((node = node.Parent) != null);

            var path = string.Join('\\', pathParts.ToArray()).TrimStart('\\');

            return path;
        }

        private void TreeFolders_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            DataGrid.Rows.Clear();

            var path = GetSelectedDirectory();

            var files = _archives.SelectMany(x => x.ListFiles.Where(x => Path.GetDirectoryName(x.Path) == path).ToArray()).ToArray();

            foreach (var file in files)
            {
                var row = DataGrid.Rows[DataGrid.Rows.Add()];
                row.Cells[0].Value = Path.GetFileName(file.Path);
                row.Cells[1].Value = file.FileSize;
                row.Cells[2].Value = Path.GetExtension(file.Path);
                row.Cells[3].Value = file.FileTime == null ? "N/a" : file.FileTime.ToString();
                row.Cells[4].Value = file.Flags;
                row.Cells[5].Value = file.Manager.FilePath;
            }
        }

        public void LoadMPQ(IEnumerable<string> mpqs)
        {
            foreach (var mpq in mpqs)
            {
                try
                {
                    _archives.Add(new MpqArchiveManager
                    {
                        FilePath = mpq,
                        Archive = new MpqArchive(mpq, FileAccess.ReadWrite)
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error ocurred opening '{mpq}':\n{ex.Message}");
                }
            }

            LoadTree();
        }

        private void LoadTree()
        {
            textBox1.Text = string.Empty;

            foreach (var manager in _archives)
            {
                using (var stream = manager.Archive.OpenFile("(listfile)"))
                {
                    var buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, (int)stream.Length);
                    var content = Encoding.UTF8.GetString(buffer);
                    var files = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    var listfiles = new List<MpqArchiveManagerFile>(files.Length);
                    foreach (var file in files)
                    {
                        listfiles.Add(new MpqArchiveManagerFile
                        {
                            Manager = manager,
                            Path = file,
                            FileSize = manager.Archive.GetFileSize(file),
                            Flags = manager.Archive.GetFileFlags(file),
                            FileTime = manager.Archive.GetFileTime(file)
                        });
                    }

                    manager.ListFiles = listfiles.ToArray();
                }
            }

            FilterNodes(string.Empty);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterNodes(textBox1.Text);
        }

        private void FilterNodes(string text)
        {
            DataGrid.Rows.Clear();
            TreeFolders.Nodes.Clear();
            var rootNode = TreeFolders.Nodes.Add("Root");

            foreach (var manager in _archives)
            {
                foreach (var file in manager.ListFiles)
                {
                    if (!string.IsNullOrEmpty(text) && !file.Path.ToLower().Contains(text.ToLower()))
                        continue;

                    var parts = Path.GetDirectoryName(file.Path).Split('\\');

                    if (parts.Length == 0 || (parts.Length == 1 && parts[0] == string.Empty))
                        continue;

                    var nodes = rootNode.Nodes;
                    foreach (var part in parts)
                    {
                        if (!nodes.ContainsKey(part))
                        {
                            var node = nodes.Add(part, part);
                            nodes = node.Nodes;
                        }
                        else
                        {
                            nodes = nodes[part].Nodes;
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(text) && text.Length > 3)
            {
                TreeFolders.ExpandAll();
            }
            else
            {
                TreeFolders.SelectedNode = rootNode;
                rootNode.Expand();
            }
        }


    }
}
