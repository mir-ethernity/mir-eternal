using ContentEditor.Repository.JSON;
using ContentEditor.Services;
using ContentEditor.Services.JSON;
using ContentEditor.Views;
using Microsoft.VisualBasic.Devices;
using Sunny.UI;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using WinFormsTranslator;
using WinFormsTransltor;

namespace ContentEditor
{
    public partial class FMain : Form
    {
        public IDatabaseManager? DatabaseManager { get; private set; } = null;

        private Dictionary<string, UBaseEditor> _editors = new Dictionary<string, UBaseEditor>();
        private UBaseEditor? _activeEditor = null;


        public FMain()
        {
            InitializeComponent();
            LoadLanguageSelector();
            PreloadAllEditors();
            NavMenu.AfterSelect += NavMenu_AfterSelect;
            LanguageMenu.DropDown.ItemClicked += LanguageMenu_ItemClicked;
            Load += FMain_Load;
        }

        private void FMain_Load(object? sender, EventArgs e)
        {
            LanguageMenu.Text = TranslatorContext.GetString("fmain.menustrip1.languagemenu.text", new string[] { TranslatorContext.Translations?.CurrentCulture.Name ?? "en-US" }, $"Language (%s)");
        }

        private void LanguageMenu_ItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            var code = (string)e.ClickedItem.Tag;
            TranslatorContext.Translations?.ChangeLanguage(code);
            LanguageMenu.Text = TranslatorContext.GetString("fmain.menustrip1.languagemenu.text", new string[] { code }, $"Language (%s)");
        }

        private void LoadLanguageSelector()
        {
            if (TranslatorContext.Translations == null) return;

            foreach (var language in TranslatorContext.Translations.GetLanguages())
            {
                LanguageMenu.DropDown.Items.Add(new ToolStripMenuItem { Name = $"MenuLanguage{language.Code}", Tag = language.Code, Text = $"({language.Code}) {language.Name}" });
            }
        }

        private void PreloadAllEditors()
        {
            var editors = typeof(UBaseEditor).Assembly.GetTypes()
                .Where(x => !x.IsAbstract && x.IsAssignableTo(typeof(UBaseEditor)))
                .ToArray();

            foreach (var editor in editors)
            {
                var instance = Activator.CreateInstance(editor) as UBaseEditor;
                if (instance == null) continue;
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
            using var openFolderDialog = new FolderBrowserDialog();

            if (openFolderDialog.ShowDialog() != DialogResult.OK)
                return;

            DatabaseManager = new JsonDatabaseManager(openFolderDialog.SelectedPath);

            await DatabaseManager.Map.Initialize();

            foreach (var editor in _editors.Values)
                editor.ReloadDatabase(DatabaseManager);
        }

    }
}