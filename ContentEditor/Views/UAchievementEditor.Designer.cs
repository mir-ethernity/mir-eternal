namespace ContentEditor.Views
{
    partial class UAchievementEditor
    {
        private Sunny.UI.UIDataGridView DataGridAchievements;

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
            this.DataGridAchievements = new Sunny.UI.UIDataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AchievementName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResetType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AchievementPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridAchievements)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridAchievements
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridAchievements.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridAchievements.BackgroundColor = System.Drawing.Color.White;
            this.DataGridAchievements.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridAchievements.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridAchievements.ColumnHeadersHeight = 32;
            this.DataGridAchievements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridAchievements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.AchievementName,
            this.Desc,
            this.BaseClass,
            this.SubClass,
            this.ResetType,
            this.AchievementPoints});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridAchievements.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridAchievements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridAchievements.EnableHeadersVisualStyles = false;
            this.DataGridAchievements.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataGridAchievements.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DataGridAchievements.Location = new System.Drawing.Point(0, 0);
            this.DataGridAchievements.Margin = new System.Windows.Forms.Padding(5);
            this.DataGridAchievements.Name = "DataGridAchievements";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridAchievements.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridAchievements.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataGridAchievements.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridAchievements.RowTemplate.Height = 25;
            this.DataGridAchievements.SelectedIndex = -1;
            this.DataGridAchievements.Size = new System.Drawing.Size(1276, 893);
            this.DataGridAchievements.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridAchievements.TabIndex = 0;
            this.DataGridAchievements.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.Frozen = true;
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 150;
            // 
            // AchievementName
            // 
            this.AchievementName.DataPropertyName = "Name";
            this.AchievementName.Frozen = true;
            this.AchievementName.HeaderText = "Name";
            this.AchievementName.MinimumWidth = 8;
            this.AchievementName.Name = "AchievementName";
            this.AchievementName.Width = 150;
            // 
            // Desc
            // 
            this.Desc.DataPropertyName = "Desc";
            this.Desc.HeaderText = "Desc";
            this.Desc.MinimumWidth = 8;
            this.Desc.Name = "Desc";
            this.Desc.Width = 150;
            // 
            // BaseClass
            // 
            this.BaseClass.DataPropertyName = "BaseClass";
            this.BaseClass.HeaderText = "Base Class";
            this.BaseClass.MinimumWidth = 8;
            this.BaseClass.Name = "BaseClass";
            this.BaseClass.Width = 150;
            // 
            // SubClass
            // 
            this.SubClass.DataPropertyName = "SubClass";
            this.SubClass.HeaderText = "Sub Class";
            this.SubClass.MinimumWidth = 8;
            this.SubClass.Name = "SubClass";
            this.SubClass.Width = 150;
            // 
            // ResetType
            // 
            this.ResetType.DataPropertyName = "ResetType";
            this.ResetType.HeaderText = "Reset Type";
            this.ResetType.MinimumWidth = 8;
            this.ResetType.Name = "ResetType";
            this.ResetType.Width = 150;
            // 
            // AchievementPoints
            // 
            this.AchievementPoints.DataPropertyName = "AchievementPoints";
            this.AchievementPoints.HeaderText = "Achievement Points";
            this.AchievementPoints.MinimumWidth = 8;
            this.AchievementPoints.Name = "AchievementPoints";
            this.AchievementPoints.Width = 150;
            // 
            // UAchievementEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridAchievements);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UAchievementEditor";
            this.Size = new System.Drawing.Size(1276, 893);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridAchievements)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn AchievementName;
        private DataGridViewTextBoxColumn Desc;
        private DataGridViewTextBoxColumn BaseClass;
        private DataGridViewTextBoxColumn SubClass;
        private DataGridViewTextBoxColumn ResetType;
        private DataGridViewTextBoxColumn AchievementPoints;
    }
}
