using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mir3DClientEditor.FormValueEditors
{
    public class CustomGridControl : DataGridView
    {
        private FSearch _searchDialog;

        public CustomGridControl()
        {
            Disposed += CustomGridControl_Disposed;
        }

        private void CustomGridControl_Disposed(object? sender, EventArgs e)
        {
            _searchDialog?.Dispose();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                OpenSearchToolbox();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.V))
            {
                SmartPaste();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void SmartPaste()
        {
            if (this.ReadOnly) return;
            var text = Clipboard.GetText();
            if (string.IsNullOrEmpty(text)) return;
            var lines = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var currentRow = CurrentRow.Index;
            var currentCell = CurrentCell.ColumnIndex;

            for (var i = 0; i < lines.Length; i++)
            {
                var columns = lines[i].Split('\t');
                for (var c = 0; c < columns.Length; c++)
                {
                    Rows[currentRow + i].Cells[currentCell + c].Value = columns[c];
                }
            }
        }

        private void OpenSearchToolbox()
        {
            if (_searchDialog != null)
            {
                _searchDialog.BringToFront();
                return;
            }

            _searchDialog = new FSearch(this);

            _searchDialog.FormClosed += (s, e) =>
            {
                _searchDialog.Dispose();
                _searchDialog = null;
            };

            _searchDialog.Show();
        }
    }
}
