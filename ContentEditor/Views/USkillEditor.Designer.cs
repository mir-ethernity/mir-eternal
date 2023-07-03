namespace ContentEditor.Views
{
    partial class USkillEditor
    {
        private Sunny.UI.UIDataGridView DataGridSkills;

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
            this.DataGridSkills = new Sunny.UI.UIDataGridView();
            this.OwnSkillId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SkillName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BindingLevelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalculateTriggerProbability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckBusyGreen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CheckStiff = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSkills)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridSkills
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridSkills.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridSkills.BackgroundColor = System.Drawing.Color.White;
            this.DataGridSkills.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridSkills.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridSkills.ColumnHeadersHeight = 32;
            this.DataGridSkills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridSkills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OwnSkillId,
            this.SkillName,
            this.BindingLevelId,
            this.CalculateTriggerProbability,
            this.CheckBusyGreen,
            this.CheckStiff});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridSkills.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridSkills.EnableHeadersVisualStyles = false;
            this.DataGridSkills.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataGridSkills.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DataGridSkills.Location = new System.Drawing.Point(0, 0);
            this.DataGridSkills.Margin = new System.Windows.Forms.Padding(5);
            this.DataGridSkills.Name = "DataGridSkills";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridSkills.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridSkills.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataGridSkills.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridSkills.RowTemplate.Height = 25;
            this.DataGridSkills.SelectedIndex = -1;
            this.DataGridSkills.Size = new System.Drawing.Size(1276, 893);
            this.DataGridSkills.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridSkills.TabIndex = 0;
            this.DataGridSkills.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // OwnSkillId
            // 
            this.OwnSkillId.DataPropertyName = "OwnSkillId";
            this.OwnSkillId.HeaderText = "Own SkillId";
            this.OwnSkillId.MinimumWidth = 8;
            this.OwnSkillId.Name = "OwnSkillId";
            this.OwnSkillId.ReadOnly = true;
            this.OwnSkillId.Width = 150;
            // 
            // SkillName
            // 
            this.SkillName.DataPropertyName = "SkillName";
            this.SkillName.HeaderText = "Name";
            this.SkillName.MinimumWidth = 8;
            this.SkillName.Name = "SkillName";
            this.SkillName.Width = 150;
            // 
            // BindingLevelId
            // 
            this.BindingLevelId.DataPropertyName = "BindingLevelId";
            this.BindingLevelId.HeaderText = "Binding LevelId";
            this.BindingLevelId.MinimumWidth = 8;
            this.BindingLevelId.Name = "BindingLevelId";
            this.BindingLevelId.Width = 150;
            // 
            // CalculateTriggerProbability
            // 
            this.CalculateTriggerProbability.DataPropertyName = "CalculateTriggerProbability";
            this.CalculateTriggerProbability.HeaderText = "Calculate Trigger Probability";
            this.CalculateTriggerProbability.MinimumWidth = 8;
            this.CalculateTriggerProbability.Name = "CalculateTriggerProbability";
            this.CalculateTriggerProbability.Width = 150;
            // 
            // CheckBusyGreen
            // 
            this.CheckBusyGreen.DataPropertyName = "CheckBusyGreen";
            this.CheckBusyGreen.HeaderText = "Check Busy Green";
            this.CheckBusyGreen.MinimumWidth = 8;
            this.CheckBusyGreen.Name = "CheckBusyGreen";
            this.CheckBusyGreen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CheckBusyGreen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CheckBusyGreen.Width = 150;
            // 
            // CheckStiff
            // 
            this.CheckStiff.DataPropertyName = "CheckStiff";
            this.CheckStiff.HeaderText = "Check Stiff";
            this.CheckStiff.MinimumWidth = 8;
            this.CheckStiff.Name = "CheckStiff";
            this.CheckStiff.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CheckStiff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CheckStiff.Width = 150;
            // 
            // USkillEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridSkills);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "USkillEditor";
            this.Size = new System.Drawing.Size(1276, 893);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSkills)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewTextBoxColumn OwnSkillId;
        private DataGridViewTextBoxColumn SkillName;
        private DataGridViewTextBoxColumn BindingLevelId;
        private DataGridViewTextBoxColumn CalculateTriggerProbability;
        private DataGridViewCheckBoxColumn CheckBusyGreen;
        private DataGridViewCheckBoxColumn CheckStiff;
    }
}
