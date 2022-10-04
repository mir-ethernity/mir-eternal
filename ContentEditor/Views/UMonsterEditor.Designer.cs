namespace ContentEditor.Views
{
    partial class UMonsterEditor
    {
        private Sunny.UI.UIDataGridView DataGridMonsters;

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
            this.DataGridMonsters = new Sunny.UI.UIDataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonsterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanBeDrivenBySkills = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CanBeControlledBySkills = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MoveInterval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoamInterval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorpsePreservationDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActiveAttackTarget = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RangeHate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NormalAttackSkills = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMonsters)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridMonsters
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridMonsters.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridMonsters.BackgroundColor = System.Drawing.Color.White;
            this.DataGridMonsters.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridMonsters.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridMonsters.ColumnHeadersHeight = 32;
            this.DataGridMonsters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridMonsters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.MonsterName,
            this.Level,
            this.Category,
            this.CanBeDrivenBySkills,
            this.CanBeControlledBySkills,
            this.MoveInterval,
            this.RoamInterval,
            this.CorpsePreservationDuration,
            this.ActiveAttackTarget,
            this.RangeHate,
            this.HateTime,
            this.NormalAttackSkills});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridMonsters.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridMonsters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridMonsters.EnableHeadersVisualStyles = false;
            this.DataGridMonsters.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataGridMonsters.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DataGridMonsters.Location = new System.Drawing.Point(0, 0);
            this.DataGridMonsters.Margin = new System.Windows.Forms.Padding(5);
            this.DataGridMonsters.Name = "DataGridMonsters";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridMonsters.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridMonsters.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataGridMonsters.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridMonsters.RowTemplate.Height = 25;
            this.DataGridMonsters.SelectedIndex = -1;
            this.DataGridMonsters.Size = new System.Drawing.Size(1276, 893);
            this.DataGridMonsters.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridMonsters.TabIndex = 0;
            this.DataGridMonsters.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            // MonsterName
            // 
            this.MonsterName.DataPropertyName = "MonsterName";
            this.MonsterName.HeaderText = "Name";
            this.MonsterName.MinimumWidth = 8;
            this.MonsterName.Name = "MonsterName";
            this.MonsterName.Width = 150;
            // 
            // Level
            // 
            this.Level.DataPropertyName = "Level";
            this.Level.HeaderText = "Level";
            this.Level.MinimumWidth = 8;
            this.Level.Name = "Level";
            this.Level.Width = 150;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "Category";
            this.Category.MinimumWidth = 8;
            this.Category.Name = "Category";
            this.Category.Width = 150;
            // 
            // CanBeDrivenBySkills
            // 
            this.CanBeDrivenBySkills.DataPropertyName = "CanBeDrivenBySkills";
            this.CanBeDrivenBySkills.HeaderText = "Can Be Driven By Skills";
            this.CanBeDrivenBySkills.MinimumWidth = 8;
            this.CanBeDrivenBySkills.Name = "CanBeDrivenBySkills";
            this.CanBeDrivenBySkills.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CanBeDrivenBySkills.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CanBeDrivenBySkills.Width = 150;
            // 
            // CanBeControlledBySkills
            // 
            this.CanBeControlledBySkills.DataPropertyName = "CanBeControlledBySkills";
            this.CanBeControlledBySkills.HeaderText = "Can Be Controlled By Skills";
            this.CanBeControlledBySkills.MinimumWidth = 8;
            this.CanBeControlledBySkills.Name = "CanBeControlledBySkills";
            this.CanBeControlledBySkills.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CanBeControlledBySkills.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CanBeControlledBySkills.Width = 150;
            // 
            // MoveInterval
            // 
            this.MoveInterval.DataPropertyName = "MoveInterval";
            this.MoveInterval.HeaderText = "Move Interval";
            this.MoveInterval.MinimumWidth = 8;
            this.MoveInterval.Name = "MoveInterval";
            this.MoveInterval.Width = 150;
            // 
            // RoamInterval
            // 
            this.RoamInterval.DataPropertyName = "RoamInterval";
            this.RoamInterval.HeaderText = "Roam Interval";
            this.RoamInterval.MinimumWidth = 8;
            this.RoamInterval.Name = "RoamInterval";
            this.RoamInterval.Width = 150;
            // 
            // CorpsePreservationDuration
            // 
            this.CorpsePreservationDuration.DataPropertyName = "CorpsePreservationDuration";
            this.CorpsePreservationDuration.HeaderText = "Corpse Preservation Duration";
            this.CorpsePreservationDuration.MinimumWidth = 8;
            this.CorpsePreservationDuration.Name = "CorpsePreservationDuration";
            this.CorpsePreservationDuration.Width = 150;
            // 
            // ActiveAttackTarget
            // 
            this.ActiveAttackTarget.DataPropertyName = "ActiveAttackTarget";
            this.ActiveAttackTarget.HeaderText = "Active Attack Target";
            this.ActiveAttackTarget.MinimumWidth = 8;
            this.ActiveAttackTarget.Name = "ActiveAttackTarget";
            this.ActiveAttackTarget.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ActiveAttackTarget.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ActiveAttackTarget.Width = 150;
            // 
            // RangeHate
            // 
            this.RangeHate.DataPropertyName = "RangeHate";
            this.RangeHate.HeaderText = "Range Hate";
            this.RangeHate.MinimumWidth = 8;
            this.RangeHate.Name = "RangeHate";
            this.RangeHate.Width = 150;
            // 
            // HateTime
            // 
            this.HateTime.DataPropertyName = "HateTime";
            this.HateTime.HeaderText = "Hate Time";
            this.HateTime.MinimumWidth = 8;
            this.HateTime.Name = "HateTime";
            this.HateTime.Width = 150;
            // 
            // NormalAttackSkills
            // 
            this.NormalAttackSkills.DataPropertyName = "NormalAttackSkills";
            this.NormalAttackSkills.HeaderText = "Normal Attack Skills";
            this.NormalAttackSkills.MinimumWidth = 8;
            this.NormalAttackSkills.Name = "NormalAttackSkills";
            this.NormalAttackSkills.Width = 150;
            // 
            // UMonsterEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridMonsters);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UMonsterEditor";
            this.Size = new System.Drawing.Size(1276, 893);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMonsters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn MonsterName;
        private DataGridViewTextBoxColumn Level;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewCheckBoxColumn CanBeDrivenBySkills;
        private DataGridViewCheckBoxColumn CanBeControlledBySkills;
        private DataGridViewTextBoxColumn MoveInterval;
        private DataGridViewTextBoxColumn RoamInterval;
        private DataGridViewTextBoxColumn CorpsePreservationDuration;
        private DataGridViewCheckBoxColumn ActiveAttackTarget;
        private DataGridViewTextBoxColumn RangeHate;
        private DataGridViewTextBoxColumn HateTime;
        private DataGridViewTextBoxColumn NormalAttackSkills;
    }
}
