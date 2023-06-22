using Mir3DClientEditor.Dialogs;
using NAudio.Vorbis;
using NAudio.Wave;
using Newtonsoft.Json.Converters;
using System.Data;
using UELib;
using UELib.Core;
using UELib.Core.Classes;

namespace Mir3DClientEditor.FormValueEditors
{
    public class PlaySongActive
    {
        public DataGridViewButtonCell Cell { get; set; }
        public USoundNodeWave Object { get; set; }
        public VorbisWaveReader Reader { get; set; }
        public WaveOutEvent WaveOutEvent { get; set; }

        public void Stop()
        {
            Cell.Value = "Play";
            Reader.Dispose();
            WaveOutEvent.Dispose();
        }
    }

    public partial class UnrealEditorControl : BaseGridEditorControl
    {
        private UnrealPackage _unrealPackage;
        private bool _hasPendingChangesToSave = false;
        private readonly Func<string, byte[]>? _callbackToLoadDepFile;
        private PlaySongActive? _songActive = null;

        public IGrouping<UObject, UObject>[] UnrealClasses { get; private set; }
        public override bool HasPendingChangesToSave { get => _hasPendingChangesToSave; }

        public UnrealEditorControl(Func<string, byte[]>? callbackToLoadDepFile = null)
        {
            InitializeComponent();

            _callbackToLoadDepFile = callbackToLoadDepFile;
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
            _songActive?.Stop();
        }

        private void UnrealEditorControl_ControlRemoved(object? sender, ControlEventArgs e)
        {
            _unrealPackage?.Dispose();
            _songActive?.Stop();
        }


        private void DataGrid_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var row = DataGrid.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];

            if (cell is DataGridViewImageCell)
                return;

            var objId = (int)row.Cells[0].Value;

            var obj = _unrealPackage.Objects[objId];
            var prop = obj.Properties.Where(x => x.Name == cell.OwningColumn.Name).FirstOrDefault();

            if (prop == null) return;

            _hasPendingChangesToSave = true;

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
            var objId = (int)row.Cells[0].Value;
            var obj = _unrealPackage.Objects[objId];

            if (cell is DataGridViewImageCell)
            {
                FImageViewerDialog.Show((UTexture2D)obj);
                if (((UTexture2D)obj).MipMaps.Length > 0)
                    cell.Value = ((UTexture2D)obj).MipMaps[0].ImageBitmap;

            }
            else if (cell is DataGridViewButtonCell)
            {
                if (cell.OwningColumn.Name == "Play")
                {
                    if (cell.Value == "Pause")
                    {
                        _songActive?.Stop();
                        return;
                    }

                    _songActive?.Stop();
                    cell.Value = "Pause";
                    var objWave = (USoundNodeWave)obj;
                    var t = new VorbisWaveReader(new MemoryStream(objWave.BufferSound), true);
                    var songevent = new WaveOutEvent();
                    _songActive = new PlaySongActive() { Cell = (DataGridViewButtonCell)cell, Object = objWave, Reader = t, WaveOutEvent = songevent };

                    songevent.Init(t);
                    songevent.Play();
                    songevent.PlaybackStopped += (s, e) =>
                    {
                        cell.Value = "Play";
                    };
                    return;
                }

                var prop = obj.Properties.Where(x => x.Name == cell.OwningColumn.Name).First();

                if (FPropertyEditor.Show(prop))
                    _hasPendingChangesToSave = true;
            }
        }

        private void ListClasses_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var className = ListClasses.SelectedItem as string;

            var objectsWithProps = _unrealPackage.Exports
               .Select(x => x.Object)
               .Where(x => x.Class?.Name == className)
               .ToArray();

            LoadObjects(objectsWithProps);

        }

        private void LoadObjects(UObject[] objects)
        {
            DataGrid.Rows.Clear();
            DataGrid.Columns.Clear();

            if (!objects.Any()) return;

            var isEnum = objects[0] is UEnum;
            var isTexture2D = objects[0] is UTexture2D;
            var isUnknownObject = objects[0] is UnknownObject;
            var isSound = objects[0] is USoundNodeWave;

            if (isEnum)
            {
                DataGrid.Columns.Add("Enum", "Enum");
                DataGrid.Columns.Add("Id", "Id");
                DataGrid.Columns.Add("Label", "Label");
            }
            else
            {
                DataGrid.Columns.Add("ObjectId", "Object Id");
                DataGrid.Columns.Add("Name", "Name");

                if (isSound)
                {
                    var cell = new DataGridViewButtonCell() { };
                    var column = new DataGridViewColumn(cell)
                    {
                        Name = "Play",
                        HeaderText = "Play",
                        Width = 80,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    };
                    DataGrid.Columns.Add(column);
                }

                if (isTexture2D)
                {
                    var cell = new DataGridViewImageCell() { ImageLayout = DataGridViewImageCellLayout.Stretch };
                    var column = new DataGridViewColumn(cell)
                    {
                        Name = "Preview",
                        HeaderText = "Preview",
                        Width = 80,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None

                    };
                    DataGrid.Columns.Add(column);
                }

                // Create all columns
                foreach (var obj in objects)
                {
                    if (obj.Properties != null && obj.Properties.Count > 0)
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
                }

                if (isUnknownObject)
                {
                    var item = new ToolStripButton("Export data");
                    item.Click += (s, e) =>
                    {
                        if (DataGrid.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("Please, select a row for export data");
                            return;
                        }

                        var selected = DataGrid.SelectedRows[0];
                        var obj = objects[selected.Index];

                        if (obj is not UnknownObject)
                        {
                            MessageBox.Show("Please, select an unknown row");
                            return;
                        }

                        var saveFileDialog = new SaveFileDialog();
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllBytes(saveFileDialog.FileName, (((UnknownObject)obj).Data).Skip(32).ToArray());
                            MessageBox.Show("Saved OK");
                        }
                    };
                    DataGrid.ContextMenuStrip = new ContextMenuStrip() { Width = 200 };
                    DataGrid.ContextMenuStrip.Items.Add(item);

                    //var cell = new DataGridViewButtonCell() { };
                    //cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    var column = new DataGridViewColumn(new DataGridViewTextBoxCell());
                    column.Name = "UnknownData";
                    column.HeaderText = "Unknown";
                    DataGrid.Columns.Add(column);
                }
            }

            if (isEnum)
            {
                foreach (var obj in objects.OfType<UEnum>().ToArray())
                {
                    for (var i = 0; i < obj.Names.Count; i++)
                    {
                        var row = new DataGridViewRow();
                        row.CreateCells(DataGrid);
                        row.Cells[0].Value = obj.Name;
                        row.Cells[1].Value = i;
                        row.Cells[2].Value = obj.Names[i];
                        DataGrid.Rows.Add(row);
                    }
                }
            }
            else
            {
                foreach (var obj in objects)
                {
                    var row = new DataGridViewRow();
                    row.CreateCells(DataGrid);

                    if (obj.DeserializationState == UObject.ObjectState.Errorlized)
                        row.DefaultCellStyle.BackColor = Color.Red;

                    // Initialize with default values
                    foreach (DataGridViewCell cell in row.Cells)
                        cell.Value = cell.ValueType.IsValueType ? Activator.CreateInstance(cell.ValueType) : null;

                    row.Cells[0].Value = _unrealPackage.Objects.IndexOf(obj);
                    row.Cells[1].Value = obj.Name;

                    foreach (var prop in obj.Properties)
                    {
                        var col = DataGrid.Columns.Cast<DataGridViewColumn>().Where(x => x.Name == prop.Name).First();

                        if (col.CellType == typeof(DataGridViewButtonCell))
                        {
                            row.Cells[col.Index].Value = "View Data";
                        }
                        else
                        {
                            if (prop.GoodValue != null)
                                row.Cells[col.Index].Value = prop.GoodValue?.ToString();
                            else if (prop.ValueData != null && prop.ValueData.Length > 1000)
                            {
                                var tmp = new byte[1000];
                                Array.Copy(prop.ValueData, tmp, 1000);
                                row.Cells[col.Index].Value = "0x" + BitConverter.ToString(tmp).Replace("-", "") + "...";
                            }
                            else if (prop.ValueData != null)
                            {
                                row.Cells[col.Index].Value = "0x" + BitConverter.ToString(prop.ValueData).Replace("-", "");
                            }
                        }
                    }

                    if (isSound)
                    {
                        var u2d = (USoundNodeWave)obj;
                        var cell = (DataGridViewButtonCell)row.Cells[2];
                        cell.Value = "Play";
                    }

                    if (isTexture2D)
                    {
                        var u2d = (UTexture2D)obj;
                        var imageCell = (DataGridViewImageCell)row.Cells[2];
                        imageCell.Style.BackColor = Color.Black;
                        var bitmap = u2d.MipMaps[0].ImageBitmap;
                        imageCell.Value = bitmap;
                        row.Height = 80;
                    }

                    if (isUnknownObject)
                    {
                        var dataToShow = ((UnknownObject)obj).Data ?? Array.Empty<byte>();
                        if (dataToShow.Length > 100)
                        {
                            var tmp = new byte[100];
                            Array.Copy(dataToShow, tmp, 100);
                            dataToShow = tmp;
                        }
                        var cell = DataGrid.Columns.Cast<DataGridViewColumn>().Where(x => x.Name == "UnknownData").First();
                        row.Cells[cell.Index].Value = ((UnknownObject)obj).Data != null
                            ? $"Len: {((UnknownObject)obj).Data.Length}, Data: " + BitConverter.ToString(dataToShow).Replace("-", "").ToLowerInvariant() + (dataToShow.Length != ((UnknownObject)obj).Data.Length ? "..." : "")
                            : "";
                    }

                    DataGrid.Rows.Add(row);
                }
            }

            DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        public override void SetBuffer(string name, byte[] buffer)
        {
            _unrealPackage = UnrealLoader.LoadPackage(name, buffer);
            _unrealPackage.RegisterCallbackToLoadImportFile(_callbackToLoadDepFile);
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
