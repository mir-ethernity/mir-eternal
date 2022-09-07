using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mir3DClientEditor
{
    public partial class FSearch : Form
    {
        public DataGridView Grid { get; }

        public FSearch(DataGridView grid)
        {
            Grid = grid;
            InitializeComponent();
            FormClosed += FSearch_FormClosed;
        }

        private void FSearch_FormClosed(object? sender, FormClosedEventArgs e)
        {
            foreach (DataGridViewRow row in Grid.Rows)
                row.Visible = true;

        }

        private void FSearch_Load(object sender, EventArgs e)
        {
            SearchText.TextChanged += SearchText_TextChanged;
        }

        private void SearchText_TextChanged(object? sender, EventArgs e)
        {
            var search = SearchText.Text.ToLower();

            foreach (DataGridViewRow row in Grid.Rows)
            {
                if (row.IsNewRow) continue;
                var match = false;
                foreach (DataGridViewCell col in row.Cells)
                {
                    if (col.Value != null)
                    {
                        var str = col.Value.ToString();
                        if (str?.ToLower().Contains(search) ?? false)
                        {
                            match = true;
                            break;
                        }
                    }
                }
                row.Visible = match;
            }
        }
    }
}
