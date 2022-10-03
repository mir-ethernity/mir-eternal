using ContentEditor.Models;
using ContentEditor.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContentEditor.Views
{
    public partial class UItemEditor : UBaseEditor
    {
        public override string AttachedTabName => "TabItems";

        public UItemEditor()
        {
            InitializeComponent();
            DataGridItems.DataError += DataGridItems_DataError;
            DataGridItems.CellDoubleClick += DataGridItems_CellDoubleClick;
        }

        private void DataGridItems_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = DataGridItems.Rows[e.RowIndex];

            if (row.IsNewRow)
                return;

            //var map = (MapInfo)row.DataBoundItem;

            //FMapEditor.ShowEditor(Database, map.MapId);
        }

        private void DataGridItems_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {

        }

        public override void ReloadDatabase(IDatabaseManager database)
        {
            
        }
    }
}
