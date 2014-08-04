namespace Micspam
{
	partial class MainForm
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
			this.groupDevices = new System.Windows.Forms.GroupBox();
			this.btnFindDevices = new System.Windows.Forms.Button();
			this.btnSelectDevice = new System.Windows.Forms.Button();
			this.listInputDevices = new System.Windows.Forms.ListView();
			this.groupSounds = new System.Windows.Forms.GroupBox();
			this.trackVolume = new System.Windows.Forms.TrackBar();
			this.listSounds = new System.Windows.Forms.ListView();
			this.columnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSoundName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSoundLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSoundPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnPlay = new System.Windows.Forms.Button();
			this.btnFindWavSources = new System.Windows.Forms.Button();
			this.lblSelectedDevice = new System.Windows.Forms.Label();
			this.groupDevices.SuspendLayout();
			this.groupSounds.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackVolume)).BeginInit();
			this.SuspendLayout();
			// 
			// groupDevices
			// 
			this.groupDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupDevices.Controls.Add(this.lblSelectedDevice);
			this.groupDevices.Controls.Add(this.btnFindDevices);
			this.groupDevices.Controls.Add(this.btnSelectDevice);
			this.groupDevices.Controls.Add(this.listInputDevices);
			this.groupDevices.Location = new System.Drawing.Point(13, 13);
			this.groupDevices.Name = "groupDevices";
			this.groupDevices.Size = new System.Drawing.Size(209, 237);
			this.groupDevices.TabIndex = 0;
			this.groupDevices.TabStop = false;
			this.groupDevices.Text = "Output devices";
			// 
			// btnFindDevices
			// 
			this.btnFindDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnFindDevices.Location = new System.Drawing.Point(6, 208);
			this.btnFindDevices.Name = "btnFindDevices";
			this.btnFindDevices.Size = new System.Drawing.Size(116, 23);
			this.btnFindDevices.TabIndex = 2;
			this.btnFindDevices.Text = "Find devices";
			this.btnFindDevices.UseVisualStyleBackColor = true;
			this.btnFindDevices.Click += new System.EventHandler(this.btnFindDevices_Click);
			// 
			// btnSelectDevice
			// 
			this.btnSelectDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectDevice.Location = new System.Drawing.Point(128, 208);
			this.btnSelectDevice.Name = "btnSelectDevice";
			this.btnSelectDevice.Size = new System.Drawing.Size(75, 23);
			this.btnSelectDevice.TabIndex = 1;
			this.btnSelectDevice.Text = "Select";
			this.btnSelectDevice.UseVisualStyleBackColor = true;
			this.btnSelectDevice.Click += new System.EventHandler(this.btnSelectDevice_Click);
			// 
			// listInputDevices
			// 
			this.listInputDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listInputDevices.HideSelection = false;
			this.listInputDevices.Location = new System.Drawing.Point(6, 32);
			this.listInputDevices.MultiSelect = false;
			this.listInputDevices.Name = "listInputDevices";
			this.listInputDevices.Size = new System.Drawing.Size(197, 170);
			this.listInputDevices.TabIndex = 0;
			this.listInputDevices.UseCompatibleStateImageBehavior = false;
			this.listInputDevices.View = System.Windows.Forms.View.List;
			// 
			// groupSounds
			// 
			this.groupSounds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupSounds.Controls.Add(this.trackVolume);
			this.groupSounds.Controls.Add(this.listSounds);
			this.groupSounds.Controls.Add(this.btnPlay);
			this.groupSounds.Controls.Add(this.btnFindWavSources);
			this.groupSounds.Enabled = false;
			this.groupSounds.Location = new System.Drawing.Point(228, 13);
			this.groupSounds.Name = "groupSounds";
			this.groupSounds.Size = new System.Drawing.Size(452, 237);
			this.groupSounds.TabIndex = 1;
			this.groupSounds.TabStop = false;
			this.groupSounds.Text = "Sounds";
			// 
			// trackVolume
			// 
			this.trackVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trackVolume.AutoSize = false;
			this.trackVolume.Location = new System.Drawing.Point(267, 19);
			this.trackVolume.Maximum = 100;
			this.trackVolume.Name = "trackVolume";
			this.trackVolume.Size = new System.Drawing.Size(179, 23);
			this.trackVolume.TabIndex = 4;
			this.trackVolume.TickFrequency = 10;
			this.trackVolume.Value = 100;
			this.trackVolume.Scroll += new System.EventHandler(this.trackVolume_Scroll);
			// 
			// listSounds
			// 
			this.listSounds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listSounds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnID,
            this.columnSoundName,
            this.columnSoundLength,
            this.columnSoundPath});
			this.listSounds.FullRowSelect = true;
			this.listSounds.GridLines = true;
			this.listSounds.HideSelection = false;
			this.listSounds.Location = new System.Drawing.Point(6, 48);
			this.listSounds.MultiSelect = false;
			this.listSounds.Name = "listSounds";
			this.listSounds.Size = new System.Drawing.Size(440, 183);
			this.listSounds.TabIndex = 2;
			this.listSounds.UseCompatibleStateImageBehavior = false;
			this.listSounds.View = System.Windows.Forms.View.Details;
			this.listSounds.SelectedIndexChanged += new System.EventHandler(this.listSounds_SelectedIndexChanged);
			// 
			// columnID
			// 
			this.columnID.Text = "ID";
			this.columnID.Width = 24;
			// 
			// columnSoundName
			// 
			this.columnSoundName.Text = "Name";
			this.columnSoundName.Width = 117;
			// 
			// columnSoundLength
			// 
			this.columnSoundLength.Text = "Length";
			// 
			// columnSoundPath
			// 
			this.columnSoundPath.Text = "Path";
			this.columnSoundPath.Width = 227;
			// 
			// btnPlay
			// 
			this.btnPlay.Enabled = false;
			this.btnPlay.Location = new System.Drawing.Point(186, 19);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(75, 23);
			this.btnPlay.TabIndex = 1;
			this.btnPlay.Text = "Play";
			this.btnPlay.UseVisualStyleBackColor = true;
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// btnFindWavSources
			// 
			this.btnFindWavSources.Location = new System.Drawing.Point(6, 19);
			this.btnFindWavSources.Name = "btnFindWavSources";
			this.btnFindWavSources.Size = new System.Drawing.Size(75, 23);
			this.btnFindWavSources.TabIndex = 0;
			this.btnFindWavSources.Text = "Find";
			this.btnFindWavSources.UseVisualStyleBackColor = true;
			this.btnFindWavSources.Click += new System.EventHandler(this.btnFindWavSources_Click);
			// 
			// lblSelectedDevice
			// 
			this.lblSelectedDevice.AutoSize = true;
			this.lblSelectedDevice.Location = new System.Drawing.Point(6, 16);
			this.lblSelectedDevice.Name = "lblSelectedDevice";
			this.lblSelectedDevice.Size = new System.Drawing.Size(52, 13);
			this.lblSelectedDevice.TabIndex = 3;
			this.lblSelectedDevice.Text = "Selected:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(692, 262);
			this.Controls.Add(this.groupSounds);
			this.Controls.Add(this.groupDevices);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Micspam";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.groupDevices.ResumeLayout(false);
			this.groupDevices.PerformLayout();
			this.groupSounds.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackVolume)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupDevices;
		private System.Windows.Forms.ListView listInputDevices;
		private System.Windows.Forms.Button btnSelectDevice;
		private System.Windows.Forms.Button btnFindDevices;
		private System.Windows.Forms.GroupBox groupSounds;
		private System.Windows.Forms.Button btnFindWavSources;
		private System.Windows.Forms.Button btnPlay;
		private System.Windows.Forms.ListView listSounds;
		private System.Windows.Forms.ColumnHeader columnSoundName;
		private System.Windows.Forms.ColumnHeader columnSoundLength;
		private System.Windows.Forms.ColumnHeader columnSoundPath;
		private System.Windows.Forms.TrackBar trackVolume;
		private System.Windows.Forms.ColumnHeader columnID;
		private System.Windows.Forms.Label lblSelectedDevice;
	}
}

