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
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.lblFrom = new System.Windows.Forms.Label();
			this.lblTo = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this.chrtMain)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// chrtMain
			// 
			this.chrtMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			chartArea1.Name = "ChartArea1";
			this.chrtMain.ChartAreas.Add(chartArea1);
			this.chrtMain.Location = new System.Drawing.Point(12, 75);
			this.chrtMain.Name = "chrtMain";
			this.chrtMain.Size = new System.Drawing.Size(760, 475);
			this.chrtMain.TabIndex = 4;
			// 
			// cmbChartTypeSelect
			// 
			this.cmbChartTypeSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbChartTypeSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbChartTypeSelect.FormattingEnabled = true;
			this.cmbChartTypeSelect.Location = new System.Drawing.Point(12, 12);
			this.cmbChartTypeSelect.Name = "cmbChartTypeSelect";
			this.cmbChartTypeSelect.Size = new System.Drawing.Size(760, 21);
			this.cmbChartTypeSelect.TabIndex = 1;
			this.cmbChartTypeSelect.SelectedIndexChanged += new System.EventHandler(this.rebuildChart);
			// 
			// dtpFrom
			// 
			this.dtpFrom.Checked = false;
			this.dtpFrom.Location = new System.Drawing.Point(177, 3);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.ShowCheckBox = true;
			this.dtpFrom.Size = new System.Drawing.Size(200, 20);
			this.dtpFrom.TabIndex = 2;
			this.dtpFrom.ValueChanged += new System.EventHandler(this.rebuildChart);
			// 
			// dtpTo
			// 
			this.dtpTo.Checked = false;
			this.dtpTo.Location = new System.Drawing.Point(557, 3);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.ShowCheckBox = true;
			this.dtpTo.Size = new System.Drawing.Size(200, 20);
			this.dtpTo.TabIndex = 3;
			this.dtpTo.ValueChanged += new System.EventHandler(this.rebuildChart);
			// 
			// lblFrom
			// 
			this.lblFrom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblFrom.Location = new System.Drawing.Point(3, 0);
			this.lblFrom.Name = "lblFrom";
			this.lblFrom.Size = new System.Drawing.Size(168, 30);
			this.lblFrom.TabIndex = 5;
			this.lblFrom.Text = "От";
			this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblTo
			// 
			this.lblTo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTo.Location = new System.Drawing.Point(383, 0);
			this.lblTo.Name = "lblTo";
			this.lblTo.Size = new System.Drawing.Size(168, 30);
			this.lblTo.TabIndex = 6;
			this.lblTo.Text = "До";
			this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.dtpFrom, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblFrom, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblTo, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.dtpTo, 3, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 39);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 30);
			this.tableLayoutPanel1.TabIndex = 7;
			// 
			// ChartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.cmbChartTypeSelect);
			this.Controls.Add(this.chrtMain);
			this.Name = "ChartForm";
			this.Text = "Графики";
			((System.ComponentModel.ISupportInitialize)(this.chrtMain)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chrtMain;
		private System.Windows.Forms.ComboBox cmbChartTypeSelect;
		private System.Windows.Forms.DateTimePicker dtpFrom;
		private System.Windows.Forms.DateTimePicker dtpTo;
		private System.Windows.Forms.Label lblFrom;
		private System.Windows.Forms.Label lblTo;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}