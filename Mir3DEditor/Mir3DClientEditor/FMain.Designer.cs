namespace Mir3DClientEditor
{
    partial class FMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_File_OpenGameFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_File_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decryptFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncClientTextsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LblActiveFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MainEditor = new Mir3DClientEditor.MainEditorControl();
            this.locateUPKNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.donateToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(1272, 24);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_File_OpenGameFolder,
            this.Menu_OpenFile,
            this.Menu_Save,
            this.Menu_File_SaveAs});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // Menu_File_OpenGameFolder
            // 
            this.Menu_File_OpenGameFolder.Name = "Menu_File_OpenGameFolder";
            this.Menu_File_OpenGameFolder.Size = new System.Drawing.Size(173, 22);
            this.Menu_File_OpenGameFolder.Text = "Open Game Folder";
            this.Menu_File_OpenGameFolder.Click += new System.EventHandler(this.Menu_File_OpenGameFolder_Click);
            // 
            // Menu_OpenFile
            // 
            this.Menu_OpenFile.Name = "Menu_OpenFile";
            this.Menu_OpenFile.Size = new System.Drawing.Size(173, 22);
            this.Menu_OpenFile.Text = "Open";
            this.Menu_OpenFile.Click += new System.EventHandler(this.Menu_OpenFile_Click);
            // 
            // Menu_Save
            // 
            this.Menu_Save.Name = "Menu_Save";
            this.Menu_Save.Size = new System.Drawing.Size(173, 22);
            this.Menu_Save.Text = "Save";
            this.Menu_Save.Click += new System.EventHandler(this.Menu_Save_Click);
            // 
            // Menu_File_SaveAs
            // 
            this.Menu_File_SaveAs.Name = "Menu_File_SaveAs";
            this.Menu_File_SaveAs.Size = new System.Drawing.Size(173, 22);
            this.Menu_File_SaveAs.Text = "Save As";
            this.Menu_File_SaveAs.Click += new System.EventHandler(this.Menu_File_SaveAs_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decryptFolderToolStripMenuItem,
            this.syncClientTextsToolStripMenuItem,
            this.locateUPKNameToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // decryptFolderToolStripMenuItem
            // 
            this.decryptFolderToolStripMenuItem.Name = "decryptFolderToolStripMenuItem";
            this.decryptFolderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.decryptFolderToolStripMenuItem.Text = "Decrypt Folder";
            // 
            // syncClientTextsToolStripMenuItem
            // 
            this.syncClientTextsToolStripMenuItem.Name = "syncClientTextsToolStripMenuItem";
            this.syncClientTextsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.syncClientTextsToolStripMenuItem.Text = "Sync Client Texts";
            this.syncClientTextsToolStripMenuItem.Click += new System.EventHandler(this.SyncClientTextsToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // LblActiveFile
            // 
            this.LblActiveFile.Name = "LblActiveFile";
            this.LblActiveFile.Size = new System.Drawing.Size(51, 17);
            this.LblActiveFile.Text = "File: N/a";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblActiveFile});
            this.statusStrip1.Location = new System.Drawing.Point(0, 649);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1272, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainEditor
            // 
            this.MainEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainEditor.Location = new System.Drawing.Point(0, 24);
            this.MainEditor.Name = "MainEditor";
            this.MainEditor.Size = new System.Drawing.Size(1272, 625);
            this.MainEditor.TabIndex = 2;
            // 
            // locateUPKNameToolStripMenuItem
            // 
            this.locateUPKNameToolStripMenuItem.Name = "locateUPKNameToolStripMenuItem";
            this.locateUPKNameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.locateUPKNameToolStripMenuItem.Text = "Locate UPK Name";
            this.locateUPKNameToolStripMenuItem.Click += new System.EventHandler(this.locateUPKNameToolStripMenuItem_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 671);
            this.Controls.Add(this.MainEditor);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "FMain";
            this.Text = "Mir3D Client Editor";
            this.Load += new System.EventHandler(this.FMain_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip Menu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem Menu_OpenFile;
        private ToolStripMenuItem Menu_Save;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem decryptFolderToolStripMenuItem;
        private ToolStripStatusLabel LblActiveFile;
        private StatusStrip statusStrip1;
        private ToolStripMenuItem Menu_File_SaveAs;
        private ToolStripMenuItem Menu_File_OpenGameFolder;
        private MainEditorControl MainEditor;
        private ToolStripMenuItem donateToolStripMenuItem;
        private ToolStripMenuItem syncClientTextsToolStripMenuItem;
        private ToolStripMenuItem locateUPKNameToolStripMenuItem;
    }
}