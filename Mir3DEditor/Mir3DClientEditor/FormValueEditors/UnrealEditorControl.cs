using System.Data;
using UELib;
using UELib.Core;

namespace Mir3DClientEditor.FormValueEditors
{
    public partial class UnrealEditorControl : BaseGridEditorControl
    {
        private UnrealPackage _unrealPackage;
        private bool _hasPendingChangesToSave = false;

        public IGrouping<UObject, UObject>[] UnrealClasses { get; private set; }
        public override bool HasPendingChangesToSave { get => _hasPendingChangesToSave; }

        public UnrealEditorControl()
        {
            InitializeComponent();

            DataGrid.AllowUserToAddRows = false;
            DataGrid.AllowUserToDeleteRows = false;
            DataGrid.CellClick += DataGrid_CellClick;
            DataGrid.CellValueChanged += DataGrid_CellValueChanged;
            ListClasses.SelectedIndexChanged += ListClasses_SelectedIndexChanged;

            ControlRemoved += UnrealEditorControl_ControlRemoved;
            Disposed += UnrealEditorControl_Disposed;
        }

        private void UnrealEditorControl_Disposed(object? sender, EventArgs e)
        {
            _unrealPackage.Dispose();
        }

        private void UnrealEditorControl_ControlRemoved(object? sender, ControlEventArgs e)
        {
            _unrealPackage?.Dispose();
        }


        private void DataGrid_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            _hasPendingChangesToSave = true;

            var row = DataGrid.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];

            var objId = (int)row.Cells[0].Value;

            var obj = _unrealPackage.Objects[objId];
            var prop = obj.Properties.Where(x => x.Name == cell.OwningColumn.Name).First();

            var value = cell.Value;

            if (prop.GoodValue is UValueStrProperty strValue)
                strValue.Text = (string)value;
            else if (prop.GoodValue is UValueIntProperty intValue)
                intValue.Number = (int)value;
            else
            {
                MessageBox.Show($"Edit for {prop.GoodValue.GetType().Name} is not implemented");
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

            var objId = (int)row.Cells[0].Value;

            var obj = _unrealPackage.Objects[objId];
            var prop = obj.Properties.Where(x => x.Name == cell.OwningColumn.Name).First();

            if (FPropertyEditor.Show(prop))
                _hasPendingChangesToSave = true;
        }

        private void ListClasses_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var className = ListClasses.SelectedItem as string;

            var objectsWithProps = _unrealPackage.Exports
               .Select(x => x.Object)
               .Where(x => x.Properties != null && x.Properties.Count > 0 && (x.Class?.Name == className))
               .ToArray();

            LoadObjects(objectsWithProps);
        }

        private void LoadObjects(UObject[] objectsWithProps)
        {
            DataGrid.Rows.Clear();
            DataGrid.Columns.Clear();

            DataGrid.Columns.Add("ObjectId", "Object Id");

            // Create all columns
            foreach (var obj in objectsWithProps)
            {
                foreach (var prop in obj.Properties)
                {
                    var col = DataGrid.Columns.Cast<DataGridViewColumn>().Where(x => x.Name == prop.Name).FirstOrDefault();
                    if (col == null)
                    {
                        DataGridViewCell cell;

                        switch (prop.TypeName)
                        {
                            case "StrProperty":
                                cell = new DataGridViewTextBoxCell() { };
                                break;
                            case "IntProperty":
                                cell = new DataGridViewTextBoxCell() { };
                                break;
                            case "BoolProperty":
                                cell = new DataGridViewTextBoxCell() { };
                                // cell = new DataGridViewCheckBoxCell() { ValueType = typeof(bool) };
                                break;
                            case "FloatProperty":
                                cell = new DataGridViewTextBoxCell() { };
                                break;
                            case "ArrayProperty":
                                cell = new DataGridViewButtonCell() { };
                                cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                break;
                            default:
                                cell = new DataGridViewTextBoxCell() { };
                                break;
                        }

                        var column = new DataGridViewColumn(cell);
                        column.Name = prop.Name;
                        column.HeaderText = prop.Name;
                        DataGrid.Columns.Add(column);
                    }
                }
            }

            foreach (var obj in objectsWithProps)
            {
                var row = new DataGridViewRow();
                row.CreateCells(DataGrid);

                // Initialize with default values
                foreach (DataGridViewCell cell in row.Cells)
                    cell.Value = cell.ValueType.IsValueType ? Activator.CreateInstance(cell.ValueType) : null;

                row.Cells[0].Value = _unrealPackage.Objects.IndexOf(obj);

                foreach (var prop in obj.Properties)
                {
                    var col = DataGrid.Columns.Cast<DataGridViewColumn>().Where(x => x.Name == prop.Name).First();

                    if (col.CellType == typeof(DataGridViewButtonCell))
                    {
                        row.Cells[col.Index].Value = "View Data";
                    }
                    else
                    {
                        row.Cells[col.Index].Value = prop.GoodValue?.ToString() ?? "0x" + BitConverter.ToString(prop.ValueData).Replace("-", "");
                    }
                }

                DataGrid.Rows.Add(row);
            }

            DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        public override void SetBuffer(string name, byte[] buffer)
        {
            for (var i = 0; i < buffer.Length - 4; i++)
            {
                var value = BitConverter.ToInt32(buffer, i);
                if (value == 153)
                {
                    var offset = i;
                }
            }


            _unrealPackage = UnrealLoader.LoadPackage(name, buffer);
            _unrealPackage.InitializePackage();

            if (_unrealPackage.Exports == null)
            {
                MessageBox.Show($"Not found objects");
                return;
            }

            UnrealClasses = _unrealPackage.Exports
                .Select(x => x.Object)
                .GroupBy(x => x.Class)
                .ToArray();

            FilterClasses();
        }

        public override byte[] GetBuffer()
        {
            using (var stream = new UPackageStream(Name))
            {
                stream.PostInit(_unrealPackage, onlyWrite: true);
                _unrealPackage.Serialize(stream);
                stream.Flush();
                return stream.ToArray();
            }
        }

        private void TextFilter_TextChanged(object sender, EventArgs e)
        {
            FilterClasses(TextFilter.Text);
        }

        private void FilterClasses(string filter = "")
        {
            ListClasses.Items.Clear();

            foreach (var unrealClass in UnrealClasses)
                if (string.IsNullOrEmpty(filter) || (unrealClass.Key?.Name?.ToLower().Contains(filter.ToLower()) ?? false))
                    ListClasses.Items.Add(unrealClass.Key?.Name ?? "Undefined Class");

            if (ListClasses.Items.Count > 0)
                ListClasses.SelectedIndex = 0;
        }
    }
}
