using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsTransltor
{
    public class TranslationMonitorControl : IDisposable
    {
        public TranslationMonitorControl(Control control, ITranslationService translationService)
        {
            Root = control;
            Translations = translationService;
            Controls = new List<TranslationMonitorControl>();
            Nodes = new List<TranslationMonitorTreeNode>();
            ToolStripItems = new List<TranslationMonitorToolStripItem>();
            DataViewGridColumns = new List<TranslationMonitorDataGridViewColumn>();

            GenerateKeys();
            Translate();

            if (control is TreeView treeControl)
            {
                foreach (TreeNode node in treeControl.Nodes)
                    Nodes.Add(new TranslationMonitorTreeNode(control, node, translationService));
            }
            else if (control is ToolStrip toolStripControl)
            {
                foreach (ToolStripItem item in toolStripControl.Items)
                    ToolStripItems.Add(new TranslationMonitorToolStripItem(control, item, translationService));

            }
            else if (control is DataGridView dataGridViewControl)
            {
                foreach (DataGridViewColumn header in dataGridViewControl.Columns)
                    DataViewGridColumns.Add(new TranslationMonitorDataGridViewColumn(control, header, translationService));

            }

            foreach (Control children in control.Controls)
                Controls.Add(new TranslationMonitorControl(children, translationService));
        }

        public Control Root { get; }
        public List<TranslationMonitorTreeNode> Nodes { get; }
        public List<TranslationMonitorToolStripItem> ToolStripItems { get; }
        public List<TranslationMonitorDataGridViewColumn> DataViewGridColumns { get; }
        public List<TranslationMonitorControl> Controls { get; }
        public ITranslationService Translations { get; }
        public string TranslationTextKey { get; private set; } = string.Empty;

        public void Dispose()
        {
            foreach (var node in Nodes)
                node.Dispose();

            foreach (var item in ToolStripItems)
                item.Dispose();

            foreach (var column in DataViewGridColumns)
                column.Dispose();

            foreach (var control in Controls)
                control.Dispose();

            Nodes.Clear();
            ToolStripItems.Clear();
            DataViewGridColumns.Clear();
            Controls.Clear();
        }

        public void Refresh()
        {
            if (Root.InvokeRequired)
            {
                Root.Invoke(() => Translate());
                return;
            }

            Translate();

            foreach (var node in Nodes)
                node.Refresh();

            foreach (var item in ToolStripItems)
                item.Refresh();

            foreach (var column in DataViewGridColumns)
                column.Refresh();

            foreach (var control in Controls)
                control.Refresh();
        }

        private void GenerateKeys()
        {
            if (string.IsNullOrEmpty(Root.Text))
                return;

            var name = string.Empty;
            var parent = Root;

            do
            {
                if (!string.IsNullOrEmpty(parent.Name))
                    name = $"{parent.Name}." + name;
            } while ((parent = parent.Parent) != null);

            name = name.Replace(' ', '_').ToLowerInvariant();

            TranslationTextKey = $"{name}text";
        }

        private void Translate()
        {
            if (Root.InvokeRequired)
            {
                Root.Invoke(() => Translate());
                return;
            }

            if (!string.IsNullOrEmpty(TranslationTextKey))
                Root.Text = Translations.GetString(TranslationTextKey, null, Root.Text);
        }
    }
}
