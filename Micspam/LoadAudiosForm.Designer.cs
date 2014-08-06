namespace Micspam
{
	partial class LoadAudiosForm
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
			this.lblCurrent = new System.Windows.Forms.Label();
			this.progressLoadProg = new System.Windows.Forms.ProgressBar();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblCurrent
			// 
			this.lblCurrent.AutoSize = true;
			this.lblCurrent.Location = new System.Drawing.Point(13, 13);
			this.lblCurrent.Name = "lblCurrent";
			this.lblCurrent.Size = new System.Drawing.Size(41, 13);
			this.lblCurrent.TabIndex = 0;
			this.lblCurrent.Text = "Current";
			// 
			// progressLoadProg
			// 
			this.progressLoadProg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressLoadProg.Location = new System.Drawing.Point(12, 29);
			this.progressLoadProg.Name = "progressLoadProg";
			this.progressLoadProg.Size = new System.Drawing.Size(384, 21);
			this.progressLoadProg.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(321, 56);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// LoadAudiosForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(408, 87);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.progressLoadProg);
			this.Controls.Add(this.lblCurrent);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LoadAudiosForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Loading audios";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoadAudiosForm_FormClosing);
			this.Shown += new System.EventHandler(this.LoadAudiosForm_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblCurrent;
		private System.Windows.Forms.ProgressBar progressLoadProg;
		private System.Windows.Forms.Button btnCancel;
	}
}