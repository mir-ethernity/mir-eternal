namespace Mir3DClientEditor.FormValueEditors
{
    partial class UnrealEditorControl
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
            this.DataGrid = new Mir3DClientEditor.FormValueEditors.CustomGridControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ListClasses = new System.Windows.Forms.ListBox();
            this.FilterGroup = new System.Windows.Forms.GroupBox();
            this.TextFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.FilterGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGrid
            // 
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGrid.Location = new System.Drawing.Point(0, 0);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.RowTemplate.Height = 25;
            this.DataGrid.Size = new System.Drawing.Size(596, 485);
            this.DataGrid.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ListClasses);
            this.splitContainer1.Panel1.Controls.Add(this.FilterGroup);
            this.splitContainer1.Panel1MinSize = 150;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DataGrid);
            this.splitContainer1.Size = new System.Drawing.Size(900, 485);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 1;
            // 
            // ListClasses
            // 
            this.ListClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListClasses.FormattingEnabled = true;
            this.ListClasses.ItemHeight = 15;
            this.ListClasses.Location = new System.Drawing.Point(0, 48);
            this.ListClasses.Name = "ListClasses";
            this.ListClasses.Size = new System.Drawing.Size(300, 437);
            this.ListClasses.TabIndex = 0;
            // 
            // FilterGroup
            // 
            this.FilterGroup.Controls.Add(this.TextFilter);
            this.FilterGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterGroup.Location = new System.Drawing.Point(0, 0);
            this.FilterGroup.Name = "FilterGroup";
            this.FilterGroup.Size = new System.Drawing.Size(300, 48);
            this.FilterGroup.TabIndex = 1;
            this.FilterGroup.TabStop = false;
            this.FilterGroup.Text = "Filter";
            // 
            // TextFilter
            // 
            this.TextFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextFilter.Location = new System.Drawing.Point(3, 19);
            this.TextFilter.Name = "TextFilter";
            this.TextFilter.Size = new System.Drawing.Size(294, 23);
            this.TextFilter.TabIndex = 0;
            this.TextFilter.TextChanged += new System.EventHandler(this.TextFilter_TextChanged);
            // 
            // UnrealEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UnrealEditorControl";
            this.Size = new System.Drawing.Size(900, 485);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.FilterGroup.ResumeLayout(false);
            this.FilterGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomGridControl DataGrid;
        private SplitContainer splitContainer1;
        private ListBox ListClasses;
        private GroupBox FilterGroup;
        private TextBox TextFilter;
    }
}
