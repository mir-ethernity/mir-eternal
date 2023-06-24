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
            DataGrid = new CustomGridControl();
            splitContainer1 = new SplitContainer();
            ListClasses = new ListBox();
            FilterGroup = new GroupBox();
            TextFilter = new TextBox();
            statusStrip1 = new StatusStrip();
            LabelInfo = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            FilterGroup.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DataGrid
            // 
            DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGrid.Dock = DockStyle.Fill;
            DataGrid.Location = new Point(0, 0);
            DataGrid.Name = "DataGrid";
            DataGrid.RowTemplate.Height = 25;
            DataGrid.Size = new Size(596, 463);
            DataGrid.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(ListClasses);
            splitContainer1.Panel1.Controls.Add(FilterGroup);
            splitContainer1.Panel1MinSize = 150;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(DataGrid);
            splitContainer1.Panel2.Controls.Add(statusStrip1);
            splitContainer1.Size = new Size(900, 485);
            splitContainer1.SplitterDistance = 300;
            splitContainer1.TabIndex = 1;
            // 
            // ListClasses
            // 
            ListClasses.Dock = DockStyle.Fill;
            ListClasses.FormattingEnabled = true;
            ListClasses.ItemHeight = 15;
            ListClasses.Location = new Point(0, 48);
            ListClasses.Name = "ListClasses";
            ListClasses.Size = new Size(300, 437);
            ListClasses.TabIndex = 0;
            // 
            // FilterGroup
            // 
            FilterGroup.Controls.Add(TextFilter);
            FilterGroup.Dock = DockStyle.Top;
            FilterGroup.Location = new Point(0, 0);
            FilterGroup.Name = "FilterGroup";
            FilterGroup.Size = new Size(300, 48);
            FilterGroup.TabIndex = 1;
            FilterGroup.TabStop = false;
            FilterGroup.Text = "Filter";
            // 
            // TextFilter
            // 
            TextFilter.Dock = DockStyle.Fill;
            TextFilter.Location = new Point(3, 19);
            TextFilter.Name = "TextFilter";
            TextFilter.Size = new Size(294, 23);
            TextFilter.TabIndex = 0;
            TextFilter.TextChanged += TextFilter_TextChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { LabelInfo });
            statusStrip1.Location = new Point(0, 463);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(596, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // LabelInfo
            // 
            LabelInfo.Name = "LabelInfo";
            LabelInfo.Size = new Size(28, 17);
            LabelInfo.Text = "Info";
            // 
            // UnrealEditorControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "UnrealEditorControl";
            Size = new Size(900, 485);
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            FilterGroup.ResumeLayout(false);
            FilterGroup.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CustomGridControl DataGrid;
        private SplitContainer splitContainer1;
        private ListBox ListClasses;
        private GroupBox FilterGroup;
        private TextBox TextFilter;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel LabelInfo;
    }
}
