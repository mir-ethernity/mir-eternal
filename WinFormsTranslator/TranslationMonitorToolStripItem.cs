using System.Windows.Forms;

namespace WinFormsTransltor
{
    public class TranslationMonitorToolStripItem : IDisposable
    {
        public TranslationMonitorToolStripItem(Control container, ToolStripItem item, ITranslationService translations)
        {
            Container = container;
            Item = item;
            Translations = translations;
            Children = new List<TranslationMonitorToolStripItem>();

            if (item is ToolStripDropDownItem dropDown)
                foreach (ToolStripItem nested in dropDown.DropDown.Items)
                    Children.Add(new TranslationMonitorToolStripItem(Container, nested, translations));

            GenerateKeys();
            Translate();
        }

        public Control Container { get; }
        public ToolStripItem Item { get; }

        public List<TranslationMonitorToolStripItem> Children { get; }

        public ITranslationService Translations { get; }
        public string TranslationTextKey { get; private set; } = string.Empty;

        public void Dispose()
        {
            foreach (var children in Children)
                children.Dispose();

            Children.Clear();
        }

        public void Refresh()
        {
            if (Container.InvokeRequired)
            {
                Container.Invoke(() => Translate());
                return;
            }

            Translate();

            foreach (var nested in Children)
                nested.Refresh();
        }

        private void GenerateKeys()
        {
            if (string.IsNullOrEmpty(Item.Text))
                return;

            var name = string.Empty;
            var parent = Container;

            do
            {
                name = $"{parent.Name}." + name;
            } while ((parent = parent.Parent) != null);

            name = name.Replace(' ', '_').ToLowerInvariant();

            TranslationTextKey = $"{name}{Item.Name.Replace(' ', '_').ToLowerInvariant()}.text";
        }

        private void Translate()
        {
            if (Container.InvokeRequired)
            {
                Container.Invoke(() => Translate());
                return;
            }

            if (!string.IsNullOrEmpty(TranslationTextKey))
                Item.Text = Translations.GetString(TranslationTextKey, null, Item.Text);
        }
    }
}
