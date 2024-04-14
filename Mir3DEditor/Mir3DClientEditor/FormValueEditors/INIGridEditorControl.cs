using Mir3DClientEditor.Services;
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
    public partial class INIGridEditorControl : BaseGridEditorControl
    {
        private Encoding _encoding = Encoding.UTF8;

        private bool _hasPendingChangesToSave = false;
        public override bool HasPendingChangesToSave { get => _hasPendingChangesToSave; }

        public INIGridEditorControl()
        {
            InitializeComponent();
            DataGrid.CellValueChanged += DataGrid_CellValueChanged;
        }

        private void DataGrid_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            _hasPendingChangesToSave = true;
        }

        public override void SetBuffer(string name, byte[] buffer)
        {
            _encoding = buffer.GetPosibleEncoding();

            var content = _encoding.GetStringExcludeBOMPreamble(buffer);
            var data = INI.Read(content, _encoding);

            foreach (var field in data)
            {
                var row = new DataGridViewRow();

                row.CreateCells(DataGrid);
                row.Cells[0].Value = field.Category;
                row.Cells[1].Value = field.Key;
                row.Cells[2].Value = field.Value;

                DataGrid.Rows.Add(row);
            }

            DataGrid.Refresh();
        }

        public override byte[] GetBuffer()
        {
            var sections = new Dictionary<string, List<string>>();

            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.IsNewRow) continue;

                var section = (string)row.Cells[0].Value;
                var key = (string)row.Cells[1].Value;
                var value = (string)row.Cells[2].Value;

                if (!sections.ContainsKey(section))
                    sections.Add(section, new List<string>());

                sections[section].Add($"{key}={value}");
            }

            var sb = new StringBuilder();

            foreach (var section in sections)
            {
                sb.AppendLine($"[{section.Key}]");
                foreach (var item in section.Value)
                    sb.AppendLine(item);
            }

            var bom = _encoding.GetPreamble();
            var buffer = _encoding.GetBytes(sb.ToString());
            return bom?.Concat(buffer).ToArray();
        }
    }
}
