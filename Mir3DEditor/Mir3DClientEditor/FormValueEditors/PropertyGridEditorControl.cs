using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UELib.Core;
using UELib.Core.Classes.Values;

namespace Mir3DClientEditor.FormValueEditors
{
    public partial class PropertyGridEditorControl : UserControl
    {
        public UDefaultProperty? Property { get; private set; } = null;

        public bool HasPendingChangesToSave { get; private set; }

        public UValueProperty[] Values { get; private set; } = Array.Empty<UValueProperty>();

        public PropertyGridEditorControl()
        {
            InitializeComponent();
            Load += GridEditorControl_Load;
        }

        private void GridEditorControl_Load(object? sender, EventArgs e)
        {
            DataGrid.CellClick += DataGrid_CellClick;
            DataGrid.CellValueChanged += DataGrid_CellValueChanged;
        }

        private void DataGrid_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var row = DataGrid.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];
            var value = cell.Value;

            HasPendingChangesToSave = true;

            var propertyValue = Property.GoodValue is UValueStructProperty ? Property.GoodValue : Values[e.RowIndex];

            if (propertyValue is UValueStructProperty propStruct)
            {
                var propName = Property.GoodValue is UValueStructProperty ? row.Cells[0].Value.ToString() : cell.OwningColumn.Name;
                var prop = propStruct.Properties.First(x => x.Name == propName);

                if (prop.GoodValue is UValueStrProperty strValue)
                    strValue.Text = (string)value;
                else if (prop.GoodValue is UValueIntProperty intValue)
                    intValue.Number = (int)value;
                else
                {
                    MessageBox.Show($"Edit for {propertyValue.GetType().Name} is not implemented");
                }
            }
        }

        private void DataGrid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var row = DataGrid.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];

            if (cell.GetType() != typeof(DataGridViewButtonCell))
                return;


            var value = Values[e.RowIndex];

            if (value is UValueStructProperty structValue)
            {
                var property = structValue.Properties[e.ColumnIndex];
                if (FPropertyEditor.Show(property))
                    HasPendingChangesToSave = true;
            }
        }

        public void SetProperty(UDefaultProperty property)
        {
            Property = property;

            if (property.GoodValue is UValueArrayProperty arrayValue)
            {
                LoadGrid(arrayValue);
            }
            else if (property.GoodValue is UValueStructProperty structValue)
            {
                LoadGrid(structValue);
            }
            else if (property.GoodValue is UValueVector2D vector2dValue)
            {
                LoadGrid(vector2dValue);
            }

            DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void LoadGrid(UValueVector2D value)
        {
            DataGrid.Columns.Add("Property", "Property");
            DataGrid.Columns.Add("Value", "Value");

            DataGrid.Rows.Add("X", value.X);
            DataGrid.Rows.Add("Y", value.Y);
        }

        private void LoadGrid(UValueStructProperty value)
        {
            DataGrid.Columns.Add("Property", "Property");
            DataGrid.Columns.Add("Value", "Value");

            foreach (var prop in value.Properties)
            {
                var row = new DataGridViewRow();
                row.CreateCells(DataGrid);

                row.Cells[0].Value = prop.Name;
                row.Cells[1] = CreateCell(prop.TypeName);

                if (row.Cells[1] is DataGridViewButtonCell)
                {
                    row.Cells[1].Value = "View Data";
                }
                else
                {
                    row.Cells[1].Value = prop.GoodValue.ToString();
                }

                DataGrid.Rows.Add(row);
            }
        }

        private void LoadGrid(UValueArrayProperty value)
        {
            if (value.Array.Length == 0)
                return;

            var firstValue = value.Array[0];

            if (firstValue is UValueUnknownProperty)
            {
                var sourceFileFullPath = (value.Property.Owner.Properties.Find(x => x.Name == "SourceFile")?.GoodValue as UValueStrProperty)?.Text ?? "content.raw";
                var sourceFile = Path.GetFileName(sourceFileFullPath);
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = sourceFile;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    File.WriteAllBytes(saveFileDialog.FileName, value.OriginalBuffer.Skip(4).ToArray());
                }
                return;
            }
            else if (firstValue is UValueStructProperty valueStruct)
            {
                Values = value.Array;

                var array = value.Array.Cast<UValueStructProperty>().ToArray();

                foreach (var prop in valueStruct.Properties)
                {
                    var cell = CreateCell(prop.TypeName);
                    var column = new DataGridViewColumn(cell);
                    column.Name = prop.Name;
                    column.HeaderText = prop.Name;
                    DataGrid.Columns.Add(column);
                }

                foreach (var item in array)
                {
                    var row = new DataGridViewRow();
                    row.CreateCells(DataGrid);

                    foreach (var prop in item.Properties)
                    {
                        var column = DataGrid.Columns.Cast<DataGridViewColumn>().Where(x => x.Name == prop.Name).First();

                        var col = row.Cells[column.Index];

                        if (col is DataGridViewButtonCell)
                        {
                            col.Value = "View Data";
                        }
                        else
                        {
                            col.Value = prop.GoodValue.ToString();
                        }
                    }

                    DataGrid.Rows.Add(row);
                }
            }
        }

        private DataGridViewCell CreateCell(string type)
        {
            DataGridViewCell cell;

            switch (type)
            {
                case "StrProperty":
                    cell = new DataGridViewTextBoxCell() { };
                    break;
                case "IntProperty":
                    cell = new DataGridViewTextBoxCell() { };
                    break;
                case "BoolProperty":
                    //cell = new DataGridViewTextBoxCell() { };
                    cell = new DataGridViewCheckBoxCell() { };
                    break;
                case "FloatProperty":
                    cell = new DataGridViewTextBoxCell() { };
                    break;
                case "ArrayProperty":
                case "StructProperty":
                    cell = new DataGridViewButtonCell() { };
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    break;
                default:
                    cell = new DataGridViewTextBoxCell() { };
                    break;
            }

            return cell;
        }
    }
}
