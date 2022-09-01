namespace ClientPacketSnifferApp
{
    partial class FDeviceSelector
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DevicesList = new System.Windows.Forms.CheckedListBox();
            this.ButtonSelectDevice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DevicesList
            // 
            this.DevicesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DevicesList.FormattingEnabled = true;
            this.DevicesList.Location = new System.Drawing.Point(0, 0);
            this.DevicesList.Name = "DevicesList";
            this.DevicesList.Size = new System.Drawing.Size(664, 347);
            this.DevicesList.TabIndex = 0;
            // 
            // ButtonSelectDevice
            // 
            this.ButtonSelectDevice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonSelectDevice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonSelectDevice.Location = new System.Drawing.Point(0, 347);
            this.ButtonSelectDevice.Name = "ButtonSelectDevice";
            this.ButtonSelectDevice.Size = new System.Drawing.Size(664, 40);
            this.ButtonSelectDevice.TabIndex = 1;
            this.ButtonSelectDevice.Text = "Select device";
            this.ButtonSelectDevice.UseVisualStyleBackColor = true;
            this.ButtonSelectDevice.Click += new System.EventHandler(this.ButtonSelectDevice_Click);
            // 
            // FDeviceSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 387);
            this.Controls.Add(this.DevicesList);
            this.Controls.Add(this.ButtonSelectDevice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FDeviceSelector";
            this.Text = "Devices";
            this.Load += new System.EventHandler(this.FDeviceSelector_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CheckedListBox DevicesList;
        private Button ButtonSelectDevice;
    }
}