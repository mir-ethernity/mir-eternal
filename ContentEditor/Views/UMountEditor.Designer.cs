namespace ContentEditor.Views
{
    partial class UMountEditor
    {
        private Sunny.UI.UIDataGridView DataGridMounts;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridMounts = new Sunny.UI.UIDataGridView();
            this.InUiSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HitUnmountRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpeedModificationRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LevelLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoulAuraID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MountPower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuraID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMounts)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridMounts
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridMounts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridMounts.BackgroundColor = System.Drawing.Color.White;
            this.DataGridMounts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridMounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridMounts.ColumnHeadersHeight = 32;
            this.DataGridMounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridMounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.MountName,
            this.AuraID,
            this.MountPower,
            this.SoulAuraID,
            this.Quality,
            this.LevelLimit,
            this.SpeedModificationRate,
            this.HitUnmountRate,
            this.InUiSpeed});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridMounts.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridMounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridMounts.EnableHeadersVisualStyles = false;
            this.DataGridMounts.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataGridMounts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DataGridMounts.Location = new System.Drawing.Point(0, 0);
            this.DataGridMounts.Margin = new System.Windows.Forms.Padding(5);
            this.DataGridMounts.Name = "DataGridMounts";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridMounts.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridMounts.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataGridMounts.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridMounts.RowTemplate.Height = 25;
            this.DataGridMounts.SelectedIndex = -1;
            this.DataGridMounts.Size = new System.Drawing.Size(1276, 893);
            this.DataGridMounts.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridMounts.TabIndex = 0;
            this.DataGridMounts.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // InUiSpeed
            // 
            this.InUiSpeed.DataPropertyName = "InUiSpeed";
            this.InUiSpeed.HeaderText = "In Ui Speed";
            this.InUiSpeed.MinimumWidth = 8;
            this.InUiSpeed.Name = "InUiSpeed";
            this.InUiSpeed.Width = 150;
            // 
            // HitUnmountRate
            // 
            this.HitUnmountRate.DataPropertyName = "HitUnmountRate";
            this.HitUnmountRate.HeaderText = "Hit Unmount Rate";
            this.HitUnmountRate.MinimumWidth = 8;
            this.HitUnmountRate.Name = "HitUnmountRate";
            this.HitUnmountRate.Width = 150;
            // 
            // SpeedModificationRate
            // 
            this.SpeedModificationRate.DataPropertyName = "SpeedModificationRate";
            this.SpeedModificationRate.HeaderText = "Speed Modification Rate";
            this.SpeedModificationRate.MinimumWidth = 8;
            this.SpeedModificationRate.Name = "SpeedModificationRate";
            this.SpeedModificationRate.Width = 150;
            // 
            // LevelLimit
            // 
            this.LevelLimit.DataPropertyName = "LevelLimit";
            this.LevelLimit.HeaderText = "Limit Level";
            this.LevelLimit.MinimumWidth = 8;
            this.LevelLimit.Name = "LevelLimit";
            this.LevelLimit.Width = 150;
            // 
            // Quality
            // 
            this.Quality.DataPropertyName = "Quality";
            this.Quality.HeaderText = "Quality";
            this.Quality.MinimumWidth = 8;
            this.Quality.Name = "Quality";
            this.Quality.Width = 150;
            // 
            // SoulAuraID
            // 
            this.SoulAuraID.DataPropertyName = "SoulAuraID";
            this.SoulAuraID.HeaderText = "Soul Aura ID";
            this.SoulAuraID.MinimumWidth = 8;
            this.SoulAuraID.Name = "SoulAuraID";
            this.SoulAuraID.Width = 150;
            // 
            // MountPower
            // 
            this.MountPower.DataPropertyName = "MountPower";
            this.MountPower.HeaderText = "Mount Power";
            this.MountPower.MinimumWidth = 8;
            this.MountPower.Name = "MountPower";
            this.MountPower.Width = 150;
            // 
            // AuraID
            // 
            this.AuraID.DataPropertyName = "AuraID";
            this.AuraID.HeaderText = "Aura ID";
            this.AuraID.MinimumWidth = 8;
            this.AuraID.Name = "AuraID";
            this.AuraID.Width = 150;
            // 
            // MountName
            // 
            this.MountName.DataPropertyName = "Name";
            this.MountName.HeaderText = "Name";
            this.MountName.MinimumWidth = 8;
            this.MountName.Name = "MountName";
            this.MountName.Width = 150;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 150;
            // 
            // UMountEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridMounts);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UMountEditor";
            this.Size = new System.Drawing.Size(1276, 893);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMounts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn MountName;
        private DataGridViewTextBoxColumn AuraID;
        private DataGridViewTextBoxColumn MountPower;
        private DataGridViewTextBoxColumn SoulAuraID;
        private DataGridViewTextBoxColumn Quality;
        private DataGridViewTextBoxColumn LevelLimit;
        private DataGridViewTextBoxColumn SpeedModificationRate;
        private DataGridViewTextBoxColumn HitUnmountRate;
        private DataGridViewTextBoxColumn InUiSpeed;
    }
}
