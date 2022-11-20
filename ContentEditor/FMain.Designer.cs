namespace ContentEditor
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Maps");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Items");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Mounts");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Chests");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Guards");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Monsters");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Skills");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Growth");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Quests");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Achievements");
            this.NavMenu = new Sunny.UI.UINavMenu();
            this.AppLayout = new Sunny.UI.UITableLayoutPanel();
            this.EditorContainer = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AppLayout.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NavMenu
            // 
            this.NavMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NavMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavMenu.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.NavMenu.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NavMenu.FullRowSelect = true;
            this.NavMenu.ItemHeight = 50;
            this.NavMenu.Location = new System.Drawing.Point(3, 3);
            this.NavMenu.Name = "NavMenu";
            treeNode1.Name = "TabMaps";
            treeNode1.Text = "Maps";
            treeNode2.Name = "TabItems";
            treeNode2.Text = "Items";
            treeNode3.Name = "TabMounts";
            treeNode3.Text = "Mounts";
            treeNode4.Name = "TabChests";
            treeNode4.Text = "Chests";
            treeNode5.Name = "TabGuards";
            treeNode5.Text = "Guards";
            treeNode6.Name = "TabMonsters";
            treeNode6.Text = "Monsters";
            treeNode7.Name = "TabSkills";
            treeNode7.Text = "Skills";
            treeNode8.Name = "TabGrowth";
            treeNode8.Text = "Growth";
            treeNode9.Name = "TabQuests";
            treeNode9.Text = "Quests";
            treeNode10.Name = "TabAchievements";
            treeNode10.Text = "Achievements";
            this.NavMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            this.NavMenu.ShowLines = false;
            this.NavMenu.Size = new System.Drawing.Size(160, 648);
            this.NavMenu.TabIndex = 4;
            this.NavMenu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // AppLayout
            // 
            this.AppLayout.ColumnCount = 2;
            this.AppLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.58342F));
            this.AppLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.41658F));
            this.AppLayout.Controls.Add(this.NavMenu, 0, 0);
            this.AppLayout.Controls.Add(this.EditorContainer, 1, 0);
            this.AppLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppLayout.Location = new System.Drawing.Point(0, 24);
            this.AppLayout.Name = "AppLayout";
            this.AppLayout.RowCount = 1;
            this.AppLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AppLayout.Size = new System.Drawing.Size(1001, 654);
            this.AppLayout.TabIndex = 5;
            this.AppLayout.TagString = null;
            // 
            // EditorContainer
            // 
            this.EditorContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditorContainer.Location = new System.Drawing.Point(169, 3);
            this.EditorContainer.Name = "EditorContainer";
            this.EditorContainer.Size = new System.Drawing.Size(829, 648);
            this.EditorContainer.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.LanguageMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1001, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDatabaseToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // loadDatabaseToolStripMenuItem
            // 
            this.loadDatabaseToolStripMenuItem.Name = "loadDatabaseToolStripMenuItem";
            this.loadDatabaseToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.loadDatabaseToolStripMenuItem.Text = "Load Database";
            this.loadDatabaseToolStripMenuItem.Click += new System.EventHandler(this.loadDatabaseToolStripMenuItem_Click_1);
            // 
            // LanguageMenu
            // 
            this.LanguageMenu.Name = "LanguageMenu";
            this.LanguageMenu.Size = new System.Drawing.Size(97, 20);
            this.LanguageMenu.Text = "Language (%s)";
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1001, 678);
            this.Controls.Add(this.AppLayout);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FMain";
            this.Text = "Content Editor";
            this.AppLayout.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UINavMenu NavMenu;
        private Sunny.UI.UITableLayoutPanel AppLayout;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem databaseToolStripMenuItem;
        private ToolStripMenuItem loadDatabaseToolStripMenuItem;
        private Panel EditorContainer;
        private ToolStripMenuItem LanguageMenu;
    }
}