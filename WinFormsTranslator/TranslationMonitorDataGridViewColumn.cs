using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTransltor
{
    public class TranslationMonitorDataGridViewColumn : IDisposable
    {
        public TranslationMonitorDataGridViewColumn(Control container, DataGridViewColumn column, ITranslationService translations)
        {
            Container = container;
            Column = column;
            Translations = translations;

            GenerateKeys();
            Translate();
        }

        public Control Container { get; }
        public DataGridViewColumn Column { get; }

        public ITranslationService Translations { get; }
        public string TranslationHeaderTextKey { get; private set; } = string.Empty;

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
            if (string.IsNullOrEmpty(Column.Name))
                return;

            var name = string.Empty;
            var parent = Container;

            do
            {
                name = $"{parent.Name}." + name;
            } while ((parent = parent.Parent) != null);

            name = name.Replace(' ', '_').ToLowerInvariant();

            TranslationHeaderTextKey = $"{name}{Column.Name.Replace(' ', '_').ToLowerInvariant()}.header_text";
        }

        private void Translate()
        {
            if (Container.InvokeRequired)
            {
                Container.Invoke(() => Translate());
                return;
            }

            if (!string.IsNullOrEmpty(TranslationHeaderTextKey))
                Column.HeaderText = Translations.GetString(TranslationHeaderTextKey, null, Column.HeaderText);
        }
    }
}
