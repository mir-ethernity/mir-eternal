namespace ContentEditor.Views
{
    partial class UGuardEditor
    {
        private Sunny.UI.UIDataGridView DataGridGuards;

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
            this.DataGridGuards = new Sunny.UI.UIDataGridView();
            this.GuardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuardName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RangeHate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridGuards)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridGuards
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridGuards.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridGuards.BackgroundColor = System.Drawing.Color.White;
            this.DataGridGuards.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridGuards.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridGuards.ColumnHeadersHeight = 32;
            this.DataGridGuards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridGuards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GuardNumber,
            this.GuardName,
            this.Level,
            this.RangeHate});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridGuards.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridGuards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridGuards.EnableHeadersVisualStyles = false;
            this.DataGridGuards.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataGridGuards.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DataGridGuards.Location = new System.Drawing.Point(0, 0);
            this.DataGridGuards.Margin = new System.Windows.Forms.Padding(5);
            this.DataGridGuards.Name = "DataGridGuards";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridGuards.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridGuards.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataGridGuards.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridGuards.RowTemplate.Height = 25;
            this.DataGridGuards.SelectedIndex = -1;
            this.DataGridGuards.Size = new System.Drawing.Size(1276, 893);
            this.DataGridGuards.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridGuards.TabIndex = 0;
            this.DataGridGuards.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // GuardNumber
            // 
            this.GuardNumber.DataPropertyName = "GuardNumber";
            this.GuardNumber.HeaderText = "Guard Number";
            this.GuardNumber.MinimumWidth = 8;
            this.GuardNumber.Name = "GuardNumber";
            this.GuardNumber.ReadOnly = true;
            this.GuardNumber.Width = 150;
            // 
            // GuardName
            // 
            this.GuardName.DataPropertyName = "Name";
            this.GuardName.HeaderText = "Name";
            this.GuardName.MinimumWidth = 8;
            this.GuardName.Name = "GuardName";
            this.GuardName.Width = 150;
            // 
            // Level
            // 
            this.Level.DataPropertyName = "Level";
            this.Level.HeaderText = "Level";
            this.Level.MinimumWidth = 8;
            this.Level.Name = "Level";
            this.Level.Width = 150;
            // 
            // RangeHate
            // 
            this.RangeHate.DataPropertyName = "RangeHate";
            this.RangeHate.HeaderText = "Range Hate";
            this.RangeHate.MinimumWidth = 8;
            this.RangeHate.Name = "RangeHate";
            this.RangeHate.Width = 150;
            // 
            // UGuardEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridGuards);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UGuardEditor";
            this.Size = new System.Drawing.Size(1276, 893);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridGuards)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewTextBoxColumn GuardNumber;
        private DataGridViewTextBoxColumn GuardName;
        private DataGridViewTextBoxColumn Level;
        private DataGridViewTextBoxColumn RangeHate;
    }
}
