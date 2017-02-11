namespace BlackAccounting
{
	partial class EnterForm
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
			this.lblExplanation = new System.Windows.Forms.Label();
			this.txtEnter = new System.Windows.Forms.TextBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.lbErrors = new System.Windows.Forms.ListBox();
			this.lblExplanationBold = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblExplanation
			// 
			this.lblExplanation.AutoSize = true;
			this.lblExplanation.Location = new System.Drawing.Point(126, 9);
			this.lblExplanation.Name = "lblExplanation";
			this.lblExplanation.Size = new System.Drawing.Size(353, 13);
			this.lblExplanation.TabIndex = 0;
			this.lblExplanation.Text = "dd.MM.yyyy[ hh:mm:ss] <TAB> 999[.99] <TAB> AAAAAA <TAB> 999[.99]";
			// 
			// txtEnter
			// 
			this.txtEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEnter.Location = new System.Drawing.Point(12, 41);
			this.txtEnter.Multiline = true;
			this.txtEnter.Name = "txtEnter";
			this.txtEnter.Size = new System.Drawing.Size(760, 395);
			this.txtEnter.TabIndex = 1;
			this.txtEnter.TabStop = false;
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(670, 12);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(102, 23);
			this.btnAdd.TabIndex = 2;
			this.btnAdd.TabStop = false;
			this.btnAdd.Text = "Добавить";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// lbErrors
			// 
			this.lbErrors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbErrors.FormattingEnabled = true;
			this.lbErrors.Location = new System.Drawing.Point(12, 442);
			this.lbErrors.Name = "lbErrors";
			this.lbErrors.Size = new System.Drawing.Size(760, 108);
			this.lbErrors.TabIndex = 3;
			this.lbErrors.TabStop = false;
			// 
			// lblExplanationBold
			// 
			this.lblExplanationBold.AutoSize = true;
			this.lblExplanationBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblExplanationBold.Location = new System.Drawing.Point(12, 9);
			this.lblExplanationBold.Name = "lblExplanationBold";
			this.lblExplanationBold.Size = new System.Drawing.Size(108, 13);
			this.lblExplanationBold.TabIndex = 4;
			this.lblExplanationBold.Text = "Формат строки :";
			// 
			// EnterForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.lblExplanationBold);
			this.Controls.Add(this.lbErrors);
			this.Controls.Add(this.txtEnter);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lblExplanation);
			this.Name = "EnterForm";
			this.Text = "EnterForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblExplanation;
		private System.Windows.Forms.TextBox txtEnter;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.ListBox lbErrors;
		private System.Windows.Forms.Label lblExplanationBold;
	}
}