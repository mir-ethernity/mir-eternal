using ContentEditor.Models;
using ContentEditor.Services;
using GameServer;
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
    public partial class UAchievementEditor : UBaseEditor
    {
        public override string AttachedTabName => "TabAchievements";

        public IDatabaseManager Database { get; private set; }

        public UAchievementEditor()
        {
            InitializeComponent();
            DataGridAchievements.AutoGenerateColumns = false;
            DataGridAchievements.DataError += DataGridAchievements_DataError;
            DataGridAchievements.CellDoubleClick += DataGridAchievements_CellDoubleClick;
        }

        private void DataGridAchievements_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = DataGridAchievements.Rows[e.RowIndex];

            if (row.IsNewRow)
                return;

            var map = (GameItem)row.DataBoundItem;
        }

        private void DataGridAchievements_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {

        }

        public override void ReloadDatabase(IDatabaseManager database)
        {
            Database = database;

            DataGridAchievements.DataSource = database.Item.DataSource;
            DataGridAchievements.Refresh();
        }

        private void ConfigureDropDownForEnum<TEnum>(DataGridViewComboBoxColumn dropdown) where TEnum : struct
        {
            var options = GetOptionsFromEnum<TEnum>();

            dropdown.DataSource = options;
            dropdown.ValueMember = "Key";
            dropdown.DisplayMember = "Value";
        }

        private List<KeyValuePair<string, string>> GetOptionsFromEnum<TEnum>() where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("TEnum must be an enumerated type");

            var options = new List<KeyValuePair<string, string>>();

            var values = Enum.GetValues(typeof(TEnum));

            foreach (var value in values)
            {
                options.Add(new KeyValuePair<string, string>(value.ToString() ?? "-1", Enum.GetName(typeof(TEnum), value) ?? "Unknown"));
            }

            return options;
        }
    }
}
