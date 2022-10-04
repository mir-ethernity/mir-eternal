namespace ContentEditor.Views
{
    partial class UQuestEditor
    {
        private Sunny.UI.UIDataGridView DataGridQuests;

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
            this.DataGridQuests = new Sunny.UI.UIDataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chapter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelationLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartNPCMap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartNPCID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinishNPCID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AutoStartNextID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxCompleteCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResetTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanAbandon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CanShare = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CanPublish = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CanTeleport = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TeleportCostId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeleportCostValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridQuests)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridQuests
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridQuests.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridQuests.BackgroundColor = System.Drawing.Color.White;
            this.DataGridQuests.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridQuests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridQuests.ColumnHeadersHeight = 32;
            this.DataGridQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridQuests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Chapter,
            this.Stage,
            this.QuestName,
            this.Level,
            this.Type,
            this.Reset,
            this.RelationLimit,
            this.StartNPCMap,
            this.StartNPCID,
            this.FinishNPCID,
            this.AutoStartNextID,
            this.MaxCompleteCount,
            this.ResetTime,
            this.CanAbandon,
            this.CanShare,
            this.CanPublish,
            this.CanTeleport,
            this.TeleportCostId,
            this.TeleportCostValue});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridQuests.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridQuests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridQuests.EnableHeadersVisualStyles = false;
            this.DataGridQuests.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataGridQuests.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DataGridQuests.Location = new System.Drawing.Point(0, 0);
            this.DataGridQuests.Margin = new System.Windows.Forms.Padding(5);
            this.DataGridQuests.Name = "DataGridQuests";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridQuests.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridQuests.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataGridQuests.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridQuests.RowTemplate.Height = 25;
            this.DataGridQuests.SelectedIndex = -1;
            this.DataGridQuests.Size = new System.Drawing.Size(1276, 893);
            this.DataGridQuests.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridQuests.TabIndex = 0;
            this.DataGridQuests.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            // Chapter
            // 
            this.Chapter.DataPropertyName = "Chapter";
            this.Chapter.HeaderText = "Chapter";
            this.Chapter.MinimumWidth = 8;
            this.Chapter.Name = "Chapter";
            this.Chapter.Width = 150;
            // 
            // Stage
            // 
            this.Stage.DataPropertyName = "Stage";
            this.Stage.HeaderText = "Stage";
            this.Stage.MinimumWidth = 8;
            this.Stage.Name = "Stage";
            this.Stage.Width = 150;
            // 
            // QuestName
            // 
            this.QuestName.DataPropertyName = "Name";
            this.QuestName.HeaderText = "Name";
            this.QuestName.MinimumWidth = 8;
            this.QuestName.Name = "QuestName";
            this.QuestName.Width = 150;
            // 
            // Level
            // 
            this.Level.DataPropertyName = "Level";
            this.Level.HeaderText = "Level";
            this.Level.MinimumWidth = 8;
            this.Level.Name = "Level";
            this.Level.Width = 150;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 8;
            this.Type.Name = "Type";
            this.Type.Width = 150;
            // 
            // Reset
            // 
            this.Reset.DataPropertyName = "Reset";
            this.Reset.HeaderText = "Reset";
            this.Reset.MinimumWidth = 8;
            this.Reset.Name = "Reset";
            this.Reset.Width = 150;
            // 
            // RelationLimit
            // 
            this.RelationLimit.DataPropertyName = "RelationLimit";
            this.RelationLimit.HeaderText = "Relation Limit";
            this.RelationLimit.MinimumWidth = 8;
            this.RelationLimit.Name = "RelationLimit";
            this.RelationLimit.Width = 150;
            // 
            // StartNPCMap
            // 
            this.StartNPCMap.DataPropertyName = "StartNPCMap";
            this.StartNPCMap.HeaderText = "Start NPC Map";
            this.StartNPCMap.MinimumWidth = 8;
            this.StartNPCMap.Name = "StartNPCMap";
            this.StartNPCMap.Width = 150;
            // 
            // StartNPCID
            // 
            this.StartNPCID.DataPropertyName = "StartNPCID";
            this.StartNPCID.HeaderText = "Start NPCID";
            this.StartNPCID.MinimumWidth = 8;
            this.StartNPCID.Name = "StartNPCID";
            this.StartNPCID.Width = 150;
            // 
            // FinishNPCID
            // 
            this.FinishNPCID.DataPropertyName = "FinishNPCID";
            this.FinishNPCID.HeaderText = "Finish NPCID";
            this.FinishNPCID.MinimumWidth = 8;
            this.FinishNPCID.Name = "FinishNPCID";
            this.FinishNPCID.Width = 150;
            // 
            // AutoStartNextID
            // 
            this.AutoStartNextID.DataPropertyName = "AutoStartNextID";
            this.AutoStartNextID.HeaderText = "Auto Start NextID";
            this.AutoStartNextID.MinimumWidth = 8;
            this.AutoStartNextID.Name = "AutoStartNextID";
            this.AutoStartNextID.Width = 150;
            // 
            // MaxCompleteCount
            // 
            this.MaxCompleteCount.DataPropertyName = "MaxCompleteCount";
            this.MaxCompleteCount.HeaderText = "Max Complete Count";
            this.MaxCompleteCount.MinimumWidth = 8;
            this.MaxCompleteCount.Name = "MaxCompleteCount";
            this.MaxCompleteCount.Width = 150;
            // 
            // ResetTime
            // 
            this.ResetTime.DataPropertyName = "ResetTime";
            this.ResetTime.HeaderText = "Reset Time";
            this.ResetTime.MinimumWidth = 8;
            this.ResetTime.Name = "ResetTime";
            this.ResetTime.Width = 150;
            // 
            // CanAbandon
            // 
            this.CanAbandon.DataPropertyName = "CanAbandon";
            this.CanAbandon.HeaderText = "Can Abandon";
            this.CanAbandon.MinimumWidth = 8;
            this.CanAbandon.Name = "CanAbandon";
            this.CanAbandon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CanAbandon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CanAbandon.Width = 150;
            // 
            // CanShare
            // 
            this.CanShare.DataPropertyName = "CanShare";
            this.CanShare.HeaderText = "Can Share";
            this.CanShare.MinimumWidth = 8;
            this.CanShare.Name = "CanShare";
            this.CanShare.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CanShare.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CanShare.Width = 150;
            // 
            // CanPublish
            // 
            this.CanPublish.DataPropertyName = "Can Publish";
            this.CanPublish.HeaderText = "CanPublish";
            this.CanPublish.MinimumWidth = 8;
            this.CanPublish.Name = "CanPublish";
            this.CanPublish.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CanPublish.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CanPublish.Width = 150;
            // 
            // CanTeleport
            // 
            this.CanTeleport.DataPropertyName = "CanTeleport";
            this.CanTeleport.HeaderText = "Can Teleport";
            this.CanTeleport.MinimumWidth = 8;
            this.CanTeleport.Name = "CanTeleport";
            this.CanTeleport.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CanTeleport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CanTeleport.Width = 150;
            // 
            // TeleportCostId
            // 
            this.TeleportCostId.DataPropertyName = "TeleportCostId";
            this.TeleportCostId.HeaderText = "Teleport Cost Id";
            this.TeleportCostId.MinimumWidth = 8;
            this.TeleportCostId.Name = "TeleportCostId";
            this.TeleportCostId.Width = 150;
            // 
            // TeleportCostValue
            // 
            this.TeleportCostValue.DataPropertyName = "TeleportCostValue";
            this.TeleportCostValue.HeaderText = "Teleport Cost Value";
            this.TeleportCostValue.MinimumWidth = 8;
            this.TeleportCostValue.Name = "TeleportCostValue";
            this.TeleportCostValue.Width = 150;
            // 
            // UQuestEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridQuests);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UQuestEditor";
            this.Size = new System.Drawing.Size(1276, 893);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridQuests)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Chapter;
        private DataGridViewTextBoxColumn Stage;
        private DataGridViewTextBoxColumn QuestName;
        private DataGridViewTextBoxColumn Level;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Reset;
        private DataGridViewTextBoxColumn RelationLimit;
        private DataGridViewTextBoxColumn StartNPCMap;
        private DataGridViewTextBoxColumn StartNPCID;
        private DataGridViewTextBoxColumn FinishNPCID;
        private DataGridViewTextBoxColumn AutoStartNextID;
        private DataGridViewTextBoxColumn MaxCompleteCount;
        private DataGridViewTextBoxColumn ResetTime;
        private DataGridViewCheckBoxColumn CanAbandon;
        private DataGridViewCheckBoxColumn CanShare;
        private DataGridViewCheckBoxColumn CanPublish;
        private DataGridViewCheckBoxColumn CanTeleport;
        private DataGridViewTextBoxColumn TeleportCostId;
        private DataGridViewTextBoxColumn TeleportCostValue;
    }
}
