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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnFindDevices = new System.Windows.Forms.Button();
			this.btnSelectDevice = new System.Windows.Forms.Button();
			this.listInputDevices = new System.Windows.Forms.ListView();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnRemove = new System.Windows.Forms.Button();
			this.listSounds = new System.Windows.Forms.ListView();
			this.columnSoundName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSoundLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSoundPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnPlay = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.btnFindDevices);
			this.groupBox1.Controls.Add(this.btnSelectDevice);
			this.groupBox1.Controls.Add(this.listInputDevices);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 237);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input devices";
			// 
			// btnFindDevices
			// 
			this.btnFindDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnFindDevices.Location = new System.Drawing.Point(6, 208);
			this.btnFindDevices.Name = "btnFindDevices";
			this.btnFindDevices.Size = new System.Drawing.Size(107, 23);
			this.btnFindDevices.TabIndex = 2;
			this.btnFindDevices.Text = "Find devices";
			this.btnFindDevices.UseVisualStyleBackColor = true;
			// 
			// btnSelectDevice
			// 
			this.btnSelectDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectDevice.Location = new System.Drawing.Point(119, 208);
			this.btnSelectDevice.Name = "btnSelectDevice";
			this.btnSelectDevice.Size = new System.Drawing.Size(75, 23);
			this.btnSelectDevice.TabIndex = 1;
			this.btnSelectDevice.Text = "Select";
			this.btnSelectDevice.UseVisualStyleBackColor = true;
			// 
			// listInputDevices
			// 
			this.listInputDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listInputDevices.Location = new System.Drawing.Point(6, 20);
			this.listInputDevices.MultiSelect = false;
			this.listInputDevices.Name = "listInputDevices";
			this.listInputDevices.Size = new System.Drawing.Size(188, 182);
			this.listInputDevices.TabIndex = 0;
			this.listInputDevices.UseCompatibleStateImageBehavior = false;
			this.listInputDevices.View = System.Windows.Forms.View.List;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnRemove);
			this.groupBox2.Controls.Add(this.listSounds);
			this.groupBox2.Controls.Add(this.btnPlay);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Location = new System.Drawing.Point(220, 13);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(394, 237);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Sounds";
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(89, 20);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(75, 23);
			this.btnRemove.TabIndex = 3;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = true;
			// 
			// listSounds
			// 
			this.listSounds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listSounds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSoundName,
            this.columnSoundLength,
            this.columnSoundPath});
			this.listSounds.FullRowSelect = true;
			this.listSounds.GridLines = true;
			this.listSounds.Location = new System.Drawing.Point(7, 50);
			this.listSounds.MultiSelect = false;
			this.listSounds.Name = "listSounds";
			this.listSounds.Size = new System.Drawing.Size(381, 181);
			this.listSounds.TabIndex = 2;
			this.listSounds.UseCompatibleStateImageBehavior = false;
			this.listSounds.View = System.Windows.Forms.View.Details;
			// 
			// columnSoundName
			// 
			this.columnSoundName.Text = "Name";
			this.columnSoundName.Width = 99;
			// 
			// columnSoundLength
			// 
			this.columnSoundLength.Text = "Length";
			// 
			// columnSoundPath
			// 
			this.columnSoundPath.Text = "Path";
			this.columnSoundPath.Width = 212;
			// 
			// btnPlay
			// 
			this.btnPlay.Location = new System.Drawing.Point(313, 20);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(75, 23);
			this.btnPlay.TabIndex = 1;
			this.btnPlay.Text = "Play";
			this.btnPlay.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(7, 20);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Add";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(626, 262);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainForm";
			this.Text = "Micspam";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListView listInputDevices;
		private System.Windows.Forms.Button btnSelectDevice;
		private System.Windows.Forms.Button btnFindDevices;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnPlay;
		private System.Windows.Forms.ListView listSounds;
		private System.Windows.Forms.ColumnHeader columnSoundName;
		private System.Windows.Forms.ColumnHeader columnSoundLength;
		private System.Windows.Forms.ColumnHeader columnSoundPath;
		private System.Windows.Forms.Button btnRemove;
	}
}

