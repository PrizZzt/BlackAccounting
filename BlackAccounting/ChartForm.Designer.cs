namespace BlackAccounting
{
	partial class ChartForm
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			this.chrtMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.cmbChartTypeSelect = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.chrtMain)).BeginInit();
			this.SuspendLayout();
			// 
			// chrtMain
			// 
			this.chrtMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			chartArea1.Name = "ChartArea1";
			this.chrtMain.ChartAreas.Add(chartArea1);
			this.chrtMain.Location = new System.Drawing.Point(12, 12);
			this.chrtMain.Name = "chrtMain";
			this.chrtMain.Size = new System.Drawing.Size(625, 416);
			this.chrtMain.TabIndex = 0;
			// 
			// cmbChartTypeSelect
			// 
			this.cmbChartTypeSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbChartTypeSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbChartTypeSelect.FormattingEnabled = true;
			this.cmbChartTypeSelect.Location = new System.Drawing.Point(644, 13);
			this.cmbChartTypeSelect.Name = "cmbChartTypeSelect";
			this.cmbChartTypeSelect.Size = new System.Drawing.Size(146, 21);
			this.cmbChartTypeSelect.TabIndex = 2;
			this.cmbChartTypeSelect.SelectedIndexChanged += new System.EventHandler(this.cmbChartTypeSelect_SelectedIndexChanged);
			// 
			// ChartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(802, 440);
			this.Controls.Add(this.cmbChartTypeSelect);
			this.Controls.Add(this.chrtMain);
			this.Name = "ChartForm";
			this.Text = "ChartForm";
			((System.ComponentModel.ISupportInitialize)(this.chrtMain)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chrtMain;
		private System.Windows.Forms.ComboBox cmbChartTypeSelect;
	}
}