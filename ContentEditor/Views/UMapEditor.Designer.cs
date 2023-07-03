namespace ContentEditor.Views
{
    partial class UMapEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridMaps = new Sunny.UI.UIDataGridView();
            this.MapId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MapName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MapFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TerrainFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimitPlayers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimitInstances = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoRecconect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NoReconnectMap = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CopyMap = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMaps)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridMaps
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridMaps.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridMaps.BackgroundColor = System.Drawing.Color.White;
            this.DataGridMaps.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridMaps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridMaps.ColumnHeadersHeight = 32;
            this.DataGridMaps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridMaps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MapId,
            this.MapName,
            this.MapFile,
            this.TerrainFile,
            this.LimitPlayers,
            this.MinLevel,
            this.LimitInstances,
            this.NoRecconect,
            this.NoReconnectMap,
            this.CopyMap});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridMaps.DefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridMaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridMaps.EnableHeadersVisualStyles = false;
            this.DataGridMaps.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataGridMaps.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DataGridMaps.Location = new System.Drawing.Point(0, 0);
            this.DataGridMaps.Name = "DataGridMaps";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridMaps.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataGridMaps.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DataGridMaps.RowTemplate.Height = 25;
            this.DataGridMaps.SelectedIndex = -1;
            this.DataGridMaps.Size = new System.Drawing.Size(760, 545);
            this.DataGridMaps.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridMaps.TabIndex = 0;
            this.DataGridMaps.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // MapId
            // 
            this.MapId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MapId.DataPropertyName = "MapId";
            this.MapId.HeaderText = "Id";
            this.MapId.Name = "MapId";
            this.MapId.ReadOnly = true;
            this.MapId.Width = 49;
            // 
            // MapName
            // 
            this.MapName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MapName.DataPropertyName = "MapName";
            this.MapName.HeaderText = "Name";
            this.MapName.Name = "MapName";
            this.MapName.Width = 80;
            // 
            // MapFile
            // 
            this.MapFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MapFile.DataPropertyName = "MapFile";
            this.MapFile.HeaderText = "Map File";
            this.MapFile.Name = "MapFile";
            // 
            // TerrainFile
            // 
            this.TerrainFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TerrainFile.DataPropertyName = "TerrainFile";
            this.TerrainFile.HeaderText = "Terrain File";
            this.TerrainFile.Name = "TerrainFile";
            this.TerrainFile.Width = 118;
            // 
            // LimitPlayers
            // 
            this.LimitPlayers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LimitPlayers.DataPropertyName = "LimitPlayers";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.LimitPlayers.DefaultCellStyle = dataGridViewCellStyle3;
            this.LimitPlayers.HeaderText = "Limit Players";
            this.LimitPlayers.Name = "LimitPlayers";
            this.LimitPlayers.Width = 129;
            // 
            // MinLevel
            // 
            this.MinLevel.DataPropertyName = "MinLevel";
            dataGridViewCellStyle4.Format = "N0";
            this.MinLevel.DefaultCellStyle = dataGridViewCellStyle4;
            this.MinLevel.HeaderText = "Min Level";
            this.MinLevel.Name = "MinLevel";
            // 
            // LimitInstances
            // 
            this.LimitInstances.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LimitInstances.DataPropertyName = "LimitInstances";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.LimitInstances.DefaultCellStyle = dataGridViewCellStyle5;
            this.LimitInstances.HeaderText = "Limit Instances";
            this.LimitInstances.Name = "LimitInstances";
            this.LimitInstances.Width = 147;
            // 
            // NoRecconect
            // 
            this.NoRecconect.DataPropertyName = "NoReconnect";
            this.NoRecconect.HeaderText = "No Reconnect";
            this.NoRecconect.Name = "NoRecconect";
            this.NoRecconect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NoRecconect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // NoReconnectMap
            // 
            this.NoReconnectMap.DataPropertyName = "NoReconnectMapId";
            this.NoReconnectMap.HeaderText = "No Reconnect Map";
            this.NoReconnectMap.Name = "NoReconnectMap";
            this.NoReconnectMap.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NoReconnectMap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CopyMap
            // 
            this.CopyMap.DataPropertyName = "CopyMap";
            this.CopyMap.HeaderText = "Copy";
            this.CopyMap.Name = "CopyMap";
            // 
            // UMapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridMaps);
            this.Name = "UMapEditor";
            this.Size = new System.Drawing.Size(760, 545);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMaps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIDataGridView DataGridMaps;
        private DataGridViewTextBoxColumn MapId;
        private DataGridViewTextBoxColumn MapName;
        private DataGridViewTextBoxColumn MapFile;
        private DataGridViewTextBoxColumn TerrainFile;
        private DataGridViewTextBoxColumn LimitPlayers;
        private DataGridViewTextBoxColumn MinLevel;
        private DataGridViewTextBoxColumn LimitInstances;
        private DataGridViewCheckBoxColumn NoRecconect;
        private DataGridViewComboBoxColumn NoReconnectMap;
        private DataGridViewCheckBoxColumn CopyMap;
    }
}
