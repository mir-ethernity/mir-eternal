namespace ContentEditor.Views
{
    partial class UItemEditor
    {
        private Sunny.UI.UIDataGridView DataGridItems;

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
            this.DataGridItems = new Sunny.UI.UIDataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StoreType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PersistType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.NeedLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NeedRace = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CanSold = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxDura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanDrop = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridItems)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridItems
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridItems.BackgroundColor = System.Drawing.Color.White;
            this.DataGridItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridItems.ColumnHeadersHeight = 32;
            this.DataGridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ItemName,
            this.Type,
            this.StoreType,
            this.PersistType,
            this.NeedLevel,
            this.NeedRace,
            this.CanSold,
            this.SalePrice,
            this.MaxDura,
            this.Weight,
            this.CanDrop});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridItems.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridItems.EnableHeadersVisualStyles = false;
            this.DataGridItems.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataGridItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DataGridItems.Location = new System.Drawing.Point(0, 0);
            this.DataGridItems.Name = "DataGridItems";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataGridItems.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridItems.RowTemplate.Height = 25;
            this.DataGridItems.SelectedIndex = -1;
            this.DataGridItems.Size = new System.Drawing.Size(812, 558);
            this.DataGridItems.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridItems.TabIndex = 0;
            this.DataGridItems.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "Name";
            this.ItemName.HeaderText = "Name";
            this.ItemName.Name = "ItemName";
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // StoreType
            // 
            this.StoreType.DataPropertyName = "StoreType";
            this.StoreType.HeaderText = "Store Type";
            this.StoreType.Name = "StoreType";
            // 
            // PersistType
            // 
            this.PersistType.DataPropertyName = "PersisType";
            this.PersistType.HeaderText = "Persist Type";
            this.PersistType.Name = "PersistType";
            // 
            // NeedLevel
            // 
            this.NeedLevel.DataPropertyName = "NeedLevel";
            this.NeedLevel.HeaderText = "Need Level";
            this.NeedLevel.Name = "NeedLevel";
            // 
            // NeedRace
            // 
            this.NeedRace.DataPropertyName = "NeedRace";
            this.NeedRace.HeaderText = "NeedRace";
            this.NeedRace.Name = "NeedRace";
            // 
            // CanSold
            // 
            this.CanSold.DataPropertyName = "CanSold";
            this.CanSold.HeaderText = "Can Sold";
            this.CanSold.Name = "CanSold";
            // 
            // SalePrice
            // 
            this.SalePrice.DataPropertyName = "SalePrice";
            this.SalePrice.HeaderText = "Sale Price";
            this.SalePrice.Name = "SalePrice";
            // 
            // MaxDura
            // 
            this.MaxDura.DataPropertyName = "MaxDura";
            this.MaxDura.HeaderText = "Max Dura";
            this.MaxDura.Name = "MaxDura";
            // 
            // Weight
            // 
            this.Weight.DataPropertyName = "Weight";
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            // 
            // CanDrop
            // 
            this.CanDrop.DataPropertyName = "CanDrop";
            this.CanDrop.HeaderText = "Can Drop";
            this.CanDrop.Name = "CanDrop";
            // 
            // UItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridItems);
            this.Name = "UItemEditor";
            this.Size = new System.Drawing.Size(812, 558);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn ItemName;
        private DataGridViewComboBoxColumn Type;
        private DataGridViewComboBoxColumn StoreType;
        private DataGridViewComboBoxColumn PersistType;
        private DataGridViewTextBoxColumn NeedLevel;
        private DataGridViewComboBoxColumn NeedRace;
        private DataGridViewCheckBoxColumn CanSold;
        private DataGridViewTextBoxColumn SalePrice;
        private DataGridViewTextBoxColumn MaxDura;
        private DataGridViewTextBoxColumn Weight;
        private DataGridViewCheckBoxColumn CanDrop;
    }
}
