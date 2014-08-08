namespace Micspam
{
	partial class AcceptedExtensionsForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.listExtensions = new System.Windows.Forms.ListView();
			this.columnExtName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnExt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(206, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "The app accepts the following extensions.\r\nLoaded from \"extensions.txt\"";
			// 
			// listExtensions
			// 
			this.listExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listExtensions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnExtName,
            this.columnExt});
			this.listExtensions.FullRowSelect = true;
			this.listExtensions.GridLines = true;
			this.listExtensions.HideSelection = false;
			this.listExtensions.Location = new System.Drawing.Point(13, 39);
			this.listExtensions.MultiSelect = false;
			this.listExtensions.Name = "listExtensions";
			this.listExtensions.Size = new System.Drawing.Size(252, 211);
			this.listExtensions.TabIndex = 1;
			this.listExtensions.UseCompatibleStateImageBehavior = false;
			this.listExtensions.View = System.Windows.Forms.View.Details;
			// 
			// columnExtName
			// 
			this.columnExtName.Text = "Name";
			// 
			// columnExt
			// 
			this.columnExt.Text = "Extension";
			// 
			// AcceptedExtensionsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(277, 262);
			this.Controls.Add(this.listExtensions);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AcceptedExtensionsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Accepted extensions";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView listExtensions;
		private System.Windows.Forms.ColumnHeader columnExtName;
		private System.Windows.Forms.ColumnHeader columnExt;
	}
}