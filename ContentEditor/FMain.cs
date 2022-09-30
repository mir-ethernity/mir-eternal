using ContentEditor.Repository.JSON;
using ContentEditor.Services;
using ContentEditor.Services.JSON;
using ContentEditor.Views;
using Microsoft.VisualBasic.Devices;
using Sunny.UI;
using System.Reflection;
using System.Threading;

namespace ContentEditor
{
    public partial class FMain : Form
    {
        public IDatabaseManager DatabaseManager { get; private set; }

        private Dictionary<string, UBaseEditor> _editors = new Dictionary<string, UBaseEditor>();
        private UBaseEditor? _activeEditor = null;


        public FMain()
        {
            InitializeComponent();
            PreloadAllEditors();
            NavMenu.AfterSelect += NavMenu_AfterSelect;
        }

        private void PreloadAllEditors()
        {
            var editors = typeof(UBaseEditor).Assembly.GetTypes()
                .Where(x => !x.IsAbstract && x.IsAssignableTo(typeof(UBaseEditor)))
                .ToArray();

            foreach (var editor in editors)
            {
                var instance = (UBaseEditor)Activator.CreateInstance(editor);
                instance.Visible = false;
                _editors.Add(instance.AttachedTabName, instance);
                EditorContainer.Controls.Add(instance);
            }
        }

        private void NavMenu_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (_activeEditor != null)
            {
                _activeEditor.Visible = false;
                _activeEditor = null;
            }

            if (_editors.TryGetValue(e.Node.Name, out var editor))
            {
                _activeEditor = editor;
                _activeEditor.Visible = true;
            }
        }

        private async void loadDatabaseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var openFolderDialog = new FolderBrowserDialog();

            if (openFolderDialog.ShowDialog() != DialogResult.OK)
                return;

            DatabaseManager = new JsonDatabaseManager(openFolderDialog.SelectedPath);

            await DatabaseManager.Map.Initialize();
            
            foreach (var editor in _editors.Values)
                editor.ReloadDatabase(DatabaseManager);
        }

    }
}