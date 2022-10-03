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
    public partial class UMapEditor : UBaseEditor
    {
        public override string AttachedTabName => "TabMaps";

        public IDatabaseManager Database { get; private set; }

        public UMapEditor()
        {
            InitializeComponent();

            DataGridMaps.DataError += DataGridMaps_DataError;
            DataGridMaps.CellDoubleClick += DataGridMaps_CellDoubleClick;
        }

        private void DataGridMaps_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = DataGridMaps.Rows[e.RowIndex];

            if (row.IsNewRow)
                return;

            var map = (MapInfo)row.DataBoundItem;

            FMapEditor.ShowEditor(Database, map.MapId);
        }

        private void DataGridMaps_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {

        }

        public override void ReloadDatabase(IDatabaseManager database)
        {
            Database = database;

            var noReconnectMapColumn = ((DataGridViewComboBoxColumn)DataGridMaps.Columns["NoReconnectMap"]);

            var mapsWithUnselectedOption = database.Map.DataSource.ToList();
            mapsWithUnselectedOption.Add(new MapInfo { MapId = 0, MapName = "None" });

            noReconnectMapColumn.DataSource = mapsWithUnselectedOption;
            noReconnectMapColumn.ValueMember = nameof(MapInfo.MapId);
            noReconnectMapColumn.DisplayMember = nameof(MapInfo.MapName);

            DataGridMaps.DataSource = database.Map.DataSource;
            DataGridMaps.Refresh();
        }
    }
}
