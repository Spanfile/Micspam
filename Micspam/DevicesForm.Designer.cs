namespace Micspam
{
	partial class DevicesForm
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
			this.splitMain = new System.Windows.Forms.SplitContainer();
			this.listDevices = new System.Windows.Forms.ListView();
			this.groupDeviceSettings = new System.Windows.Forms.GroupBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.checkDeviceEnabled = new System.Windows.Forms.CheckBox();
			this.columnDeviceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnDeviceEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lblDefaultDevice = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
			this.splitMain.Panel1.SuspendLayout();
			this.splitMain.Panel2.SuspendLayout();
			this.splitMain.SuspendLayout();
			this.groupDeviceSettings.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitMain
			// 
			this.splitMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitMain.Location = new System.Drawing.Point(12, 12);
			this.splitMain.Name = "splitMain";
			// 
			// splitMain.Panel1
			// 
			this.splitMain.Panel1.Controls.Add(this.listDevices);
			// 
			// splitMain.Panel2
			// 
			this.splitMain.Panel2.Controls.Add(this.groupDeviceSettings);
			this.splitMain.Size = new System.Drawing.Size(401, 197);
			this.splitMain.SplitterDistance = 221;
			this.splitMain.TabIndex = 0;
			// 
			// listDevices
			// 
			this.listDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDeviceName,
            this.columnDeviceEnabled});
			this.listDevices.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listDevices.FullRowSelect = true;
			this.listDevices.GridLines = true;
			this.listDevices.HideSelection = false;
			this.listDevices.Location = new System.Drawing.Point(0, 0);
			this.listDevices.Name = "listDevices";
			this.listDevices.Size = new System.Drawing.Size(221, 197);
			this.listDevices.TabIndex = 0;
			this.listDevices.UseCompatibleStateImageBehavior = false;
			this.listDevices.View = System.Windows.Forms.View.Details;
			this.listDevices.SelectedIndexChanged += new System.EventHandler(this.listDevices_SelectedIndexChanged);
			// 
			// groupDeviceSettings
			// 
			this.groupDeviceSettings.Controls.Add(this.lblDefaultDevice);
			this.groupDeviceSettings.Controls.Add(this.checkDeviceEnabled);
			this.groupDeviceSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupDeviceSettings.Enabled = false;
			this.groupDeviceSettings.Location = new System.Drawing.Point(0, 0);
			this.groupDeviceSettings.Name = "groupDeviceSettings";
			this.groupDeviceSettings.Size = new System.Drawing.Size(176, 197);
			this.groupDeviceSettings.TabIndex = 0;
			this.groupDeviceSettings.TabStop = false;
			this.groupDeviceSettings.Text = "Device settings";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(338, 215);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(257, 215);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// checkDeviceEnabled
			// 
			this.checkDeviceEnabled.AutoSize = true;
			this.checkDeviceEnabled.Location = new System.Drawing.Point(7, 20);
			this.checkDeviceEnabled.Name = "checkDeviceEnabled";
			this.checkDeviceEnabled.Size = new System.Drawing.Size(65, 17);
			this.checkDeviceEnabled.TabIndex = 0;
			this.checkDeviceEnabled.Text = "Enabled";
			this.checkDeviceEnabled.UseVisualStyleBackColor = true;
			this.checkDeviceEnabled.CheckedChanged += new System.EventHandler(this.checkDeviceEnabled_CheckedChanged);
			// 
			// columnDeviceName
			// 
			this.columnDeviceName.Text = "Name";
			this.columnDeviceName.Width = 155;
			// 
			// columnDeviceEnabled
			// 
			this.columnDeviceEnabled.Text = "Enabled";
			// 
			// lblDefaultDevice
			// 
			this.lblDefaultDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDefaultDevice.Location = new System.Drawing.Point(7, 44);
			this.lblDefaultDevice.Name = "lblDefaultDevice";
			this.lblDefaultDevice.Size = new System.Drawing.Size(163, 30);
			this.lblDefaultDevice.TabIndex = 1;
			this.lblDefaultDevice.Text = "This is the default device. It cannot be disabled.\r\n";
			this.lblDefaultDevice.Visible = false;
			// 
			// DevicesForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(425, 250);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.splitMain);
			this.Name = "DevicesForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Devices";
			this.splitMain.Panel1.ResumeLayout(false);
			this.splitMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
			this.splitMain.ResumeLayout(false);
			this.groupDeviceSettings.ResumeLayout(false);
			this.groupDeviceSettings.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitMain;
		private System.Windows.Forms.ListView listDevices;
		private System.Windows.Forms.GroupBox groupDeviceSettings;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.CheckBox checkDeviceEnabled;
		private System.Windows.Forms.ColumnHeader columnDeviceName;
		private System.Windows.Forms.ColumnHeader columnDeviceEnabled;
		private System.Windows.Forms.Label lblDefaultDevice;
	}
}