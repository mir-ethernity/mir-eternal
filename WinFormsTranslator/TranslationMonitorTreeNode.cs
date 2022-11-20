using System.Windows.Forms;

namespace WinFormsTransltor
{
    public class TranslationMonitorTreeNode : IDisposable
    {
        public TranslationMonitorTreeNode(Control container, TreeNode node, ITranslationService translations)
        {
            Container = container;
            Node = node;
            Translations = translations;

            GenerateKeys();
            Translate();
        }

        public Control Container { get; }
        public TreeNode Node { get; }
        public ITranslationService Translations { get; }
        public string TranslationTextKey { get; private set; }

        public void Dispose()
        {

        }

        public void Refresh()
        {
            if (Container.InvokeRequired)
            {
                Container.Invoke(() => Translate());
                return;
            }

            Translate();
        }

        private void GenerateKeys()
        {
            if (string.IsNullOrEmpty(Node.Text))
                return;

            var name = string.Empty;
            var parent = Container;

            do
            {
                name = $"{parent.Name}." + name;
            } while ((parent = parent.Parent) != null);

            name = name.Replace(' ', '_').ToLowerInvariant();

            TranslationTextKey = $"{name}{Node.Name.Replace(' ', '_').ToLowerInvariant()}.text";
        }

        private void Translate()
        {
            if (Container.InvokeRequired)
            {
                Container.Invoke(() => Translate());
                return;
            }

            if (!string.IsNullOrEmpty(TranslationTextKey))
                Node.Text = Translations.GetString(TranslationTextKey, null, Node.Text);
        }
    }
}
