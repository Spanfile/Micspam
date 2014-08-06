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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.listAudios = new System.Windows.Forms.ListView();
			this.columnAudioPlaying = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnAudioName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnAudioLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnAudioType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnAudioSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imglistAudios = new System.Windows.Forms.ImageList(this.components);
			this.groupAudioSettings = new System.Windows.Forms.GroupBox();
			this.lblAudioVolumeValue = new System.Windows.Forms.Label();
			this.btnUseDefaultDevice = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.trackAudioVolume = new System.Windows.Forms.TrackBar();
			this.btnPlayAudio = new System.Windows.Forms.Button();
			this.listAudioOutputDevices = new System.Windows.Forms.ListView();
			this.label1 = new System.Windows.Forms.Label();
			this.menuMain = new System.Windows.Forms.MenuStrip();
			this.menuView = new System.Windows.Forms.ToolStripMenuItem();
			this.menuViewOutputDevices = new System.Windows.Forms.ToolStripMenuItem();
			this.menuViewAudioDir = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSettingsChangeSourceDir = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSettingsFindFromChildren = new System.Windows.Forms.ToolStripMenuItem();
			this.btnRefreshAudioList = new System.Windows.Forms.Button();
			this.trackGlobalVolume = new System.Windows.Forms.TrackBar();
			this.label2 = new System.Windows.Forms.Label();
			this.splitMain = new System.Windows.Forms.SplitContainer();
			this.lblAudioSourceDir = new System.Windows.Forms.Label();
			this.lblGlobalVolumeValue = new System.Windows.Forms.Label();
			this.btnStopAllAudios = new System.Windows.Forms.Button();
			this.textAudioFilter = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupAudioSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackAudioVolume)).BeginInit();
			this.menuMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackGlobalVolume)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
			this.splitMain.Panel1.SuspendLayout();
			this.splitMain.Panel2.SuspendLayout();
			this.splitMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// listAudios
			// 
			this.listAudios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listAudios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnAudioPlaying,
            this.columnAudioName,
            this.columnAudioLength,
            this.columnAudioType,
            this.columnAudioSource});
			this.listAudios.FullRowSelect = true;
			this.listAudios.GridLines = true;
			this.listAudios.HideSelection = false;
			this.listAudios.Location = new System.Drawing.Point(0, 53);
			this.listAudios.MultiSelect = false;
			this.listAudios.Name = "listAudios";
			this.listAudios.Size = new System.Drawing.Size(476, 245);
			this.listAudios.SmallImageList = this.imglistAudios;
			this.listAudios.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listAudios.TabIndex = 0;
			this.listAudios.UseCompatibleStateImageBehavior = false;
			this.listAudios.View = System.Windows.Forms.View.Details;
			this.listAudios.SelectedIndexChanged += new System.EventHandler(this.listAudios_SelectedIndexChanged);
			// 
			// columnAudioPlaying
			// 
			this.columnAudioPlaying.Text = "";
			this.columnAudioPlaying.Width = 30;
			// 
			// columnAudioName
			// 
			this.columnAudioName.Text = "Name";
			this.columnAudioName.Width = 154;
			// 
			// columnAudioLength
			// 
			this.columnAudioLength.Text = "Length";
			// 
			// columnAudioType
			// 
			this.columnAudioType.Text = "Type";
			this.columnAudioType.Width = 46;
			// 
			// columnAudioSource
			// 
			this.columnAudioSource.Text = "Source";
			this.columnAudioSource.Width = 181;
			// 
			// imglistAudios
			// 
			this.imglistAudios.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglistAudios.ImageStream")));
			this.imglistAudios.TransparentColor = System.Drawing.Color.Transparent;
			this.imglistAudios.Images.SetKeyName(0, "arrow_right_grey.png");
			// 
			// groupAudioSettings
			// 
			this.groupAudioSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupAudioSettings.Controls.Add(this.lblAudioVolumeValue);
			this.groupAudioSettings.Controls.Add(this.btnUseDefaultDevice);
			this.groupAudioSettings.Controls.Add(this.label3);
			this.groupAudioSettings.Controls.Add(this.trackAudioVolume);
			this.groupAudioSettings.Controls.Add(this.btnPlayAudio);
			this.groupAudioSettings.Controls.Add(this.listAudioOutputDevices);
			this.groupAudioSettings.Controls.Add(this.label1);
			this.groupAudioSettings.Enabled = false;
			this.groupAudioSettings.Location = new System.Drawing.Point(3, 29);
			this.groupAudioSettings.Name = "groupAudioSettings";
			this.groupAudioSettings.Size = new System.Drawing.Size(253, 295);
			this.groupAudioSettings.TabIndex = 1;
			this.groupAudioSettings.TabStop = false;
			this.groupAudioSettings.Text = "Audio settings";
			// 
			// lblAudioVolumeValue
			// 
			this.lblAudioVolumeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAudioVolumeValue.AutoSize = true;
			this.lblAudioVolumeValue.Location = new System.Drawing.Point(186, 247);
			this.lblAudioVolumeValue.Name = "lblAudioVolumeValue";
			this.lblAudioVolumeValue.Size = new System.Drawing.Size(61, 13);
			this.lblAudioVolumeValue.TabIndex = 6;
			this.lblAudioVolumeValue.Text = "(1.00, 1.00)";
			// 
			// btnUseDefaultDevice
			// 
			this.btnUseDefaultDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnUseDefaultDevice.Location = new System.Drawing.Point(6, 154);
			this.btnUseDefaultDevice.Name = "btnUseDefaultDevice";
			this.btnUseDefaultDevice.Size = new System.Drawing.Size(127, 23);
			this.btnUseDefaultDevice.TabIndex = 5;
			this.btnUseDefaultDevice.Text = "Use default device";
			this.btnUseDefaultDevice.UseVisualStyleBackColor = true;
			this.btnUseDefaultDevice.Click += new System.EventHandler(this.btnUseDefaultDevice_Click);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 247);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Volume";
			// 
			// trackAudioVolume
			// 
			this.trackAudioVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trackAudioVolume.AutoSize = false;
			this.trackAudioVolume.Location = new System.Drawing.Point(6, 266);
			this.trackAudioVolume.Maximum = 100;
			this.trackAudioVolume.Name = "trackAudioVolume";
			this.trackAudioVolume.Size = new System.Drawing.Size(241, 23);
			this.trackAudioVolume.TabIndex = 3;
			this.trackAudioVolume.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackAudioVolume.Value = 100;
			this.trackAudioVolume.ValueChanged += new System.EventHandler(this.trackAudioVolume_ValueChanged);
			// 
			// btnPlayAudio
			// 
			this.btnPlayAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPlayAudio.Location = new System.Drawing.Point(6, 221);
			this.btnPlayAudio.Name = "btnPlayAudio";
			this.btnPlayAudio.Size = new System.Drawing.Size(75, 23);
			this.btnPlayAudio.TabIndex = 2;
			this.btnPlayAudio.Text = "Play";
			this.btnPlayAudio.UseVisualStyleBackColor = true;
			this.btnPlayAudio.Click += new System.EventHandler(this.btnPlayAudio_Click);
			// 
			// listAudioOutputDevices
			// 
			this.listAudioOutputDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listAudioOutputDevices.CheckBoxes = true;
			this.listAudioOutputDevices.FullRowSelect = true;
			this.listAudioOutputDevices.Location = new System.Drawing.Point(6, 37);
			this.listAudioOutputDevices.MultiSelect = false;
			this.listAudioOutputDevices.Name = "listAudioOutputDevices";
			this.listAudioOutputDevices.Size = new System.Drawing.Size(241, 110);
			this.listAudioOutputDevices.TabIndex = 1;
			this.listAudioOutputDevices.UseCompatibleStateImageBehavior = false;
			this.listAudioOutputDevices.View = System.Windows.Forms.View.List;
			this.listAudioOutputDevices.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listAudioOutputDevices_ItemChecked);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Output devices";
			// 
			// menuMain
			// 
			this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuView,
            this.menuSettings});
			this.menuMain.Location = new System.Drawing.Point(0, 0);
			this.menuMain.Name = "menuMain";
			this.menuMain.Size = new System.Drawing.Size(767, 24);
			this.menuMain.TabIndex = 2;
			this.menuMain.Text = "menuStrip1";
			// 
			// menuView
			// 
			this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewOutputDevices,
            this.menuViewAudioDir});
			this.menuView.Name = "menuView";
			this.menuView.Size = new System.Drawing.Size(44, 20);
			this.menuView.Text = "View";
			// 
			// menuViewOutputDevices
			// 
			this.menuViewOutputDevices.Name = "menuViewOutputDevices";
			this.menuViewOutputDevices.Size = new System.Drawing.Size(194, 22);
			this.menuViewOutputDevices.Text = "Output devices";
			this.menuViewOutputDevices.Click += new System.EventHandler(this.menuViewOutputDevices_Click);
			// 
			// menuViewAudioDir
			// 
			this.menuViewAudioDir.Name = "menuViewAudioDir";
			this.menuViewAudioDir.Size = new System.Drawing.Size(194, 22);
			this.menuViewAudioDir.Text = "Audio source directory";
			this.menuViewAudioDir.Click += new System.EventHandler(this.menuViewAudioDir_Click);
			// 
			// menuSettings
			// 
			this.menuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSettingsChangeSourceDir,
            this.menuSettingsFindFromChildren});
			this.menuSettings.Name = "menuSettings";
			this.menuSettings.Size = new System.Drawing.Size(61, 20);
			this.menuSettings.Text = "Settings";
			// 
			// menuSettingsChangeSourceDir
			// 
			this.menuSettingsChangeSourceDir.Name = "menuSettingsChangeSourceDir";
			this.menuSettingsChangeSourceDir.Size = new System.Drawing.Size(251, 22);
			this.menuSettingsChangeSourceDir.Text = "Change source directory";
			this.menuSettingsChangeSourceDir.Click += new System.EventHandler(this.menuSettingsChangeSourceDir_Click);
			// 
			// menuSettingsFindFromChildren
			// 
			this.menuSettingsFindFromChildren.Checked = true;
			this.menuSettingsFindFromChildren.CheckOnClick = true;
			this.menuSettingsFindFromChildren.CheckState = System.Windows.Forms.CheckState.Checked;
			this.menuSettingsFindFromChildren.Name = "menuSettingsFindFromChildren";
			this.menuSettingsFindFromChildren.Size = new System.Drawing.Size(251, 22);
			this.menuSettingsFindFromChildren.Text = "Find sounds from source children";
			this.menuSettingsFindFromChildren.Click += new System.EventHandler(this.menuSettingsFindFromChildren_Click);
			// 
			// btnRefreshAudioList
			// 
			this.btnRefreshAudioList.Location = new System.Drawing.Point(0, 0);
			this.btnRefreshAudioList.Name = "btnRefreshAudioList";
			this.btnRefreshAudioList.Size = new System.Drawing.Size(101, 23);
			this.btnRefreshAudioList.TabIndex = 3;
			this.btnRefreshAudioList.Text = "Refresh list";
			this.btnRefreshAudioList.UseVisualStyleBackColor = true;
			this.btnRefreshAudioList.Click += new System.EventHandler(this.btnRefreshAudioList_Click);
			// 
			// trackGlobalVolume
			// 
			this.trackGlobalVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.trackGlobalVolume.AutoSize = false;
			this.trackGlobalVolume.Location = new System.Drawing.Point(277, 24);
			this.trackGlobalVolume.Maximum = 100;
			this.trackGlobalVolume.Name = "trackGlobalVolume";
			this.trackGlobalVolume.Size = new System.Drawing.Size(199, 23);
			this.trackGlobalVolume.TabIndex = 4;
			this.trackGlobalVolume.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackGlobalVolume.Value = 100;
			this.trackGlobalVolume.ValueChanged += new System.EventHandler(this.trackGlobalVolume_ValueChanged);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(274, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Global volume";
			// 
			// splitMain
			// 
			this.splitMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitMain.Location = new System.Drawing.Point(13, 28);
			this.splitMain.Name = "splitMain";
			// 
			// splitMain.Panel1
			// 
			this.splitMain.Panel1.Controls.Add(this.label4);
			this.splitMain.Panel1.Controls.Add(this.textAudioFilter);
			this.splitMain.Panel1.Controls.Add(this.lblAudioSourceDir);
			this.splitMain.Panel1.Controls.Add(this.lblGlobalVolumeValue);
			this.splitMain.Panel1.Controls.Add(this.btnRefreshAudioList);
			this.splitMain.Panel1.Controls.Add(this.trackGlobalVolume);
			this.splitMain.Panel1.Controls.Add(this.listAudios);
			this.splitMain.Panel1.Controls.Add(this.label2);
			// 
			// splitMain.Panel2
			// 
			this.splitMain.Panel2.Controls.Add(this.btnStopAllAudios);
			this.splitMain.Panel2.Controls.Add(this.groupAudioSettings);
			this.splitMain.Size = new System.Drawing.Size(742, 327);
			this.splitMain.SplitterDistance = 479;
			this.splitMain.TabIndex = 6;
			// 
			// lblAudioSourceDir
			// 
			this.lblAudioSourceDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAudioSourceDir.AutoEllipsis = true;
			this.lblAudioSourceDir.Location = new System.Drawing.Point(3, 34);
			this.lblAudioSourceDir.Name = "lblAudioSourceDir";
			this.lblAudioSourceDir.Size = new System.Drawing.Size(268, 13);
			this.lblAudioSourceDir.TabIndex = 7;
			this.lblAudioSourceDir.Text = "Audio source directory";
			// 
			// lblGlobalVolumeValue
			// 
			this.lblGlobalVolumeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblGlobalVolumeValue.AutoSize = true;
			this.lblGlobalVolumeValue.Location = new System.Drawing.Point(441, 5);
			this.lblGlobalVolumeValue.Name = "lblGlobalVolumeValue";
			this.lblGlobalVolumeValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblGlobalVolumeValue.Size = new System.Drawing.Size(34, 13);
			this.lblGlobalVolumeValue.TabIndex = 6;
			this.lblGlobalVolumeValue.Text = "(1.00)";
			// 
			// btnStopAllAudios
			// 
			this.btnStopAllAudios.Location = new System.Drawing.Point(3, 0);
			this.btnStopAllAudios.Name = "btnStopAllAudios";
			this.btnStopAllAudios.Size = new System.Drawing.Size(103, 23);
			this.btnStopAllAudios.TabIndex = 2;
			this.btnStopAllAudios.Text = "Stop all audios";
			this.btnStopAllAudios.UseVisualStyleBackColor = true;
			this.btnStopAllAudios.Click += new System.EventHandler(this.btnStopAllAudios_Click);
			// 
			// textAudioFilter
			// 
			this.textAudioFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textAudioFilter.Location = new System.Drawing.Point(38, 304);
			this.textAudioFilter.Name = "textAudioFilter";
			this.textAudioFilter.Size = new System.Drawing.Size(438, 20);
			this.textAudioFilter.TabIndex = 8;
			this.textAudioFilter.TextChanged += new System.EventHandler(this.textAudioFilter_TextChanged);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 307);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Filter";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(767, 367);
			this.Controls.Add(this.splitMain);
			this.Controls.Add(this.menuMain);
			this.MainMenuStrip = this.menuMain;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Micspam Mk. 2";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.groupAudioSettings.ResumeLayout(false);
			this.groupAudioSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackAudioVolume)).EndInit();
			this.menuMain.ResumeLayout(false);
			this.menuMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackGlobalVolume)).EndInit();
			this.splitMain.Panel1.ResumeLayout(false);
			this.splitMain.Panel1.PerformLayout();
			this.splitMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
			this.splitMain.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listAudios;
		private System.Windows.Forms.GroupBox groupAudioSettings;
		private System.Windows.Forms.ColumnHeader columnAudioPlaying;
		private System.Windows.Forms.ColumnHeader columnAudioName;
		private System.Windows.Forms.ColumnHeader columnAudioType;
		private System.Windows.Forms.ColumnHeader columnAudioSource;
		private System.Windows.Forms.MenuStrip menuMain;
		private System.Windows.Forms.ToolStripMenuItem menuView;
		private System.Windows.Forms.ToolStripMenuItem menuViewOutputDevices;
		private System.Windows.Forms.ToolStripMenuItem menuViewAudioDir;
		private System.Windows.Forms.Button btnRefreshAudioList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView listAudioOutputDevices;
		private System.Windows.Forms.Button btnPlayAudio;
		private System.Windows.Forms.TrackBar trackAudioVolume;
		private System.Windows.Forms.TrackBar trackGlobalVolume;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnUseDefaultDevice;
		private System.Windows.Forms.ColumnHeader columnAudioLength;
		private System.Windows.Forms.SplitContainer splitMain;
		private System.Windows.Forms.Label lblGlobalVolumeValue;
		private System.Windows.Forms.Label lblAudioVolumeValue;
		private System.Windows.Forms.Label lblAudioSourceDir;
		private System.Windows.Forms.ImageList imglistAudios;
		private System.Windows.Forms.Button btnStopAllAudios;
		private System.Windows.Forms.ToolStripMenuItem menuSettings;
		private System.Windows.Forms.ToolStripMenuItem menuSettingsChangeSourceDir;
		private System.Windows.Forms.ToolStripMenuItem menuSettingsFindFromChildren;
		private System.Windows.Forms.TextBox textAudioFilter;
		private System.Windows.Forms.Label label4;

	}
}

