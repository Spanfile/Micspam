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
			this.lblAudioLength = new System.Windows.Forms.Label();
			this.progAudioPos = new System.Windows.Forms.ProgressBar();
			this.lblAudioPosition = new System.Windows.Forms.Label();
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
			this.acceptedExtensionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSettingsChangeDir = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSettingsChangeDirBrowse = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSettingsChangeDirDefault = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSettingsFindFromChildren = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSettingsRefresh = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSettingsRefreshDevices = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSettingsRefreshExtensions = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSettingsRefreshAudios = new System.Windows.Forms.ToolStripMenuItem();
			this.btnRefreshAudioList = new System.Windows.Forms.Button();
			this.trackGlobalVolume = new System.Windows.Forms.TrackBar();
			this.label2 = new System.Windows.Forms.Label();
			this.splitMain = new System.Windows.Forms.SplitContainer();
			this.label4 = new System.Windows.Forms.Label();
			this.textAudioFilter = new System.Windows.Forms.TextBox();
			this.lblAudioSourceDir = new System.Windows.Forms.Label();
			this.lblGlobalVolumeValue = new System.Windows.Forms.Label();
			this.btnStopAllAudios = new System.Windows.Forms.Button();
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
			this.listAudios.Size = new System.Drawing.Size(473, 245);
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
			this.groupAudioSettings.Controls.Add(this.lblAudioLength);
			this.groupAudioSettings.Controls.Add(this.progAudioPos);
			this.groupAudioSettings.Controls.Add(this.lblAudioPosition);
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
			this.groupAudioSettings.Size = new System.Drawing.Size(282, 295);
			this.groupAudioSettings.TabIndex = 1;
			this.groupAudioSettings.TabStop = false;
			this.groupAudioSettings.Text = "Audio settings";
			// 
			// lblAudioLength
			// 
			this.lblAudioLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAudioLength.AutoSize = true;
			this.lblAudioLength.Location = new System.Drawing.Point(241, 275);
			this.lblAudioLength.Name = "lblAudioLength";
			this.lblAudioLength.Size = new System.Drawing.Size(28, 13);
			this.lblAudioLength.TabIndex = 9;
			this.lblAudioLength.Text = "0:00";
			// 
			// progAudioPos
			// 
			this.progAudioPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progAudioPos.Location = new System.Drawing.Point(37, 275);
			this.progAudioPos.Name = "progAudioPos";
			this.progAudioPos.Size = new System.Drawing.Size(198, 14);
			this.progAudioPos.TabIndex = 8;
			// 
			// lblAudioPosition
			// 
			this.lblAudioPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblAudioPosition.AutoSize = true;
			this.lblAudioPosition.Location = new System.Drawing.Point(6, 275);
			this.lblAudioPosition.Name = "lblAudioPosition";
			this.lblAudioPosition.Size = new System.Drawing.Size(28, 13);
			this.lblAudioPosition.TabIndex = 7;
			this.lblAudioPosition.Text = "0:00";
			// 
			// lblAudioVolumeValue
			// 
			this.lblAudioVolumeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAudioVolumeValue.AutoSize = true;
			this.lblAudioVolumeValue.Location = new System.Drawing.Point(215, 227);
			this.lblAudioVolumeValue.Name = "lblAudioVolumeValue";
			this.lblAudioVolumeValue.Size = new System.Drawing.Size(33, 13);
			this.lblAudioVolumeValue.TabIndex = 6;
			this.lblAudioVolumeValue.Text = "100%";
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
			this.label3.Location = new System.Drawing.Point(6, 227);
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
			this.trackAudioVolume.Location = new System.Drawing.Point(6, 246);
			this.trackAudioVolume.Maximum = 100;
			this.trackAudioVolume.Name = "trackAudioVolume";
			this.trackAudioVolume.Size = new System.Drawing.Size(270, 23);
			this.trackAudioVolume.TabIndex = 3;
			this.trackAudioVolume.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackAudioVolume.Value = 100;
			this.trackAudioVolume.ValueChanged += new System.EventHandler(this.trackAudioVolume_ValueChanged);
			// 
			// btnPlayAudio
			// 
			this.btnPlayAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPlayAudio.Location = new System.Drawing.Point(6, 201);
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
			this.listAudioOutputDevices.Size = new System.Drawing.Size(270, 110);
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
			this.menuMain.Size = new System.Drawing.Size(793, 24);
			this.menuMain.TabIndex = 2;
			this.menuMain.Text = "menuStrip1";
			// 
			// menuView
			// 
			this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewOutputDevices,
            this.menuViewAudioDir,
            this.acceptedExtensionsToolStripMenuItem});
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
			// acceptedExtensionsToolStripMenuItem
			// 
			this.acceptedExtensionsToolStripMenuItem.Name = "acceptedExtensionsToolStripMenuItem";
			this.acceptedExtensionsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.acceptedExtensionsToolStripMenuItem.Text = "Accepted extensions";
			this.acceptedExtensionsToolStripMenuItem.Click += new System.EventHandler(this.acceptedExtensionsToolStripMenuItem_Click);
			// 
			// menuSettings
			// 
			this.menuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSettingsChangeDir,
            this.menuSettingsFindFromChildren,
            this.menuSettingsRefresh});
			this.menuSettings.Name = "menuSettings";
			this.menuSettings.Size = new System.Drawing.Size(61, 20);
			this.menuSettings.Text = "Settings";
			// 
			// menuSettingsChangeDir
			// 
			this.menuSettingsChangeDir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSettingsChangeDirBrowse,
            this.menuSettingsChangeDirDefault});
			this.menuSettingsChangeDir.Name = "menuSettingsChangeDir";
			this.menuSettingsChangeDir.Size = new System.Drawing.Size(251, 22);
			this.menuSettingsChangeDir.Text = "Change source directory";
			// 
			// menuSettingsChangeDirBrowse
			// 
			this.menuSettingsChangeDirBrowse.Name = "menuSettingsChangeDirBrowse";
			this.menuSettingsChangeDirBrowse.Size = new System.Drawing.Size(121, 22);
			this.menuSettingsChangeDirBrowse.Text = "Browse...";
			this.menuSettingsChangeDirBrowse.Click += new System.EventHandler(this.menuSettingsChangeDirBrowse_Click);
			// 
			// menuSettingsChangeDirDefault
			// 
			this.menuSettingsChangeDirDefault.Name = "menuSettingsChangeDirDefault";
			this.menuSettingsChangeDirDefault.Size = new System.Drawing.Size(121, 22);
			this.menuSettingsChangeDirDefault.Text = "Default";
			this.menuSettingsChangeDirDefault.Click += new System.EventHandler(this.menuSettingsChangeDirDefault_Click);
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
			// menuSettingsRefresh
			// 
			this.menuSettingsRefresh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSettingsRefreshDevices,
            this.menuSettingsRefreshExtensions,
            this.menuSettingsRefreshAudios});
			this.menuSettingsRefresh.Name = "menuSettingsRefresh";
			this.menuSettingsRefresh.Size = new System.Drawing.Size(251, 22);
			this.menuSettingsRefresh.Text = "Refresh...";
			// 
			// menuSettingsRefreshDevices
			// 
			this.menuSettingsRefreshDevices.Name = "menuSettingsRefreshDevices";
			this.menuSettingsRefreshDevices.Size = new System.Drawing.Size(129, 22);
			this.menuSettingsRefreshDevices.Text = "Devices";
			this.menuSettingsRefreshDevices.Click += new System.EventHandler(this.menuSettingsRefreshDevices_Click);
			// 
			// menuSettingsRefreshExtensions
			// 
			this.menuSettingsRefreshExtensions.Name = "menuSettingsRefreshExtensions";
			this.menuSettingsRefreshExtensions.Size = new System.Drawing.Size(129, 22);
			this.menuSettingsRefreshExtensions.Text = "Extensions";
			this.menuSettingsRefreshExtensions.Click += new System.EventHandler(this.menuSettingsRefreshExtensions_Click);
			// 
			// menuSettingsRefreshAudios
			// 
			this.menuSettingsRefreshAudios.Name = "menuSettingsRefreshAudios";
			this.menuSettingsRefreshAudios.Size = new System.Drawing.Size(129, 22);
			this.menuSettingsRefreshAudios.Text = "Audios";
			this.menuSettingsRefreshAudios.Click += new System.EventHandler(this.menuSettingsRefreshAudios_Click);
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
			this.trackGlobalVolume.Location = new System.Drawing.Point(274, 24);
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
			this.label2.Location = new System.Drawing.Point(271, 5);
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
			this.splitMain.Size = new System.Drawing.Size(768, 327);
			this.splitMain.SplitterDistance = 476;
			this.splitMain.TabIndex = 6;
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
			// textAudioFilter
			// 
			this.textAudioFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textAudioFilter.Location = new System.Drawing.Point(38, 304);
			this.textAudioFilter.Name = "textAudioFilter";
			this.textAudioFilter.Size = new System.Drawing.Size(435, 20);
			this.textAudioFilter.TabIndex = 8;
			this.textAudioFilter.TextChanged += new System.EventHandler(this.textAudioFilter_TextChanged);
			// 
			// lblAudioSourceDir
			// 
			this.lblAudioSourceDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAudioSourceDir.AutoEllipsis = true;
			this.lblAudioSourceDir.Location = new System.Drawing.Point(3, 34);
			this.lblAudioSourceDir.Name = "lblAudioSourceDir";
			this.lblAudioSourceDir.Size = new System.Drawing.Size(265, 13);
			this.lblAudioSourceDir.TabIndex = 7;
			this.lblAudioSourceDir.Text = "Audio source directory";
			// 
			// lblGlobalVolumeValue
			// 
			this.lblGlobalVolumeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblGlobalVolumeValue.AutoSize = true;
			this.lblGlobalVolumeValue.Location = new System.Drawing.Point(438, 5);
			this.lblGlobalVolumeValue.Name = "lblGlobalVolumeValue";
			this.lblGlobalVolumeValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblGlobalVolumeValue.Size = new System.Drawing.Size(33, 13);
			this.lblGlobalVolumeValue.TabIndex = 6;
			this.lblGlobalVolumeValue.Text = "100%";
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(793, 367);
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
		private System.Windows.Forms.ToolStripMenuItem menuSettingsChangeDir;
		private System.Windows.Forms.ToolStripMenuItem menuSettingsFindFromChildren;
		private System.Windows.Forms.TextBox textAudioFilter;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ToolStripMenuItem menuSettingsChangeDirBrowse;
		private System.Windows.Forms.ToolStripMenuItem menuSettingsChangeDirDefault;
		private System.Windows.Forms.ProgressBar progAudioPos;
		private System.Windows.Forms.Label lblAudioPosition;
		private System.Windows.Forms.Label lblAudioLength;
		private System.Windows.Forms.ToolStripMenuItem menuSettingsRefresh;
		private System.Windows.Forms.ToolStripMenuItem menuSettingsRefreshDevices;
		private System.Windows.Forms.ToolStripMenuItem menuSettingsRefreshExtensions;
		private System.Windows.Forms.ToolStripMenuItem menuSettingsRefreshAudios;
		private System.Windows.Forms.ToolStripMenuItem acceptedExtensionsToolStripMenuItem;

	}
}

