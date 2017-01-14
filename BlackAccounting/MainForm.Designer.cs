namespace BlackAccounting
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.ssMain = new System.Windows.Forms.StatusStrip();
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
			this.tsbtnDel = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnChangeEdit = new System.Windows.Forms.ToolStripButton();
			this.tsbtnSettings = new System.Windows.Forms.ToolStripButton();
			this.gvMain = new System.Windows.Forms.DataGridView();
			this.tsMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
			this.SuspendLayout();
			// 
			// ssMain
			// 
			this.ssMain.Location = new System.Drawing.Point(0, 420);
			this.ssMain.Name = "ssMain";
			this.ssMain.Size = new System.Drawing.Size(624, 22);
			this.ssMain.TabIndex = 0;
			this.ssMain.Text = "statusStrip1";
			// 
			// tsMain
			// 
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAdd,
            this.tsbtnDel,
            this.toolStripSeparator1,
            this.tsbtnChangeEdit,
            this.tsbtnSettings});
			this.tsMain.Location = new System.Drawing.Point(0, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(624, 25);
			this.tsMain.TabIndex = 1;
			this.tsMain.Text = "toolStrip1";
			// 
			// tsbtnAdd
			// 
			this.tsbtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnAdd.Image = global::BlackAccounting.Properties.Resources.add;
			this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAdd.Name = "tsbtnAdd";
			this.tsbtnAdd.Size = new System.Drawing.Size(23, 22);
			this.tsbtnAdd.Text = "Добавить запись";
			this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAddRecord_Click);
			// 
			// tsbtnDel
			// 
			this.tsbtnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnDel.Image = global::BlackAccounting.Properties.Resources.cancel;
			this.tsbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDel.Name = "tsbtnDel";
			this.tsbtnDel.Size = new System.Drawing.Size(23, 22);
			this.tsbtnDel.Text = "Удалить запись";
			this.tsbtnDel.Click += new System.EventHandler(this.tsbtnDelRecord_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbtnChangeEdit
			// 
			this.tsbtnChangeEdit.CheckOnClick = true;
			this.tsbtnChangeEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnChangeEdit.Image = global::BlackAccounting.Properties.Resources.hierarchical_structure;
			this.tsbtnChangeEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnChangeEdit.Name = "tsbtnChangeEdit";
			this.tsbtnChangeEdit.Size = new System.Drawing.Size(23, 22);
			this.tsbtnChangeEdit.Text = "Редактировать типы записей";
			this.tsbtnChangeEdit.CheckedChanged += new System.EventHandler(this.gridSwitchData);
			// 
			// tsbtnSettings
			// 
			this.tsbtnSettings.CheckOnClick = true;
			this.tsbtnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnSettings.Image = global::BlackAccounting.Properties.Resources.cogwheel;
			this.tsbtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSettings.Name = "tsbtnSettings";
			this.tsbtnSettings.Size = new System.Drawing.Size(23, 22);
			this.tsbtnSettings.Text = "Редактировать настройки";
			this.tsbtnSettings.CheckedChanged += new System.EventHandler(this.gridSwitchData);
			// 
			// gvMain
			// 
			this.gvMain.AllowUserToAddRows = false;
			this.gvMain.AllowUserToResizeRows = false;
			this.gvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gvMain.Location = new System.Drawing.Point(0, 25);
			this.gvMain.Name = "gvMain";
			this.gvMain.RowHeadersVisible = false;
			this.gvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.gvMain.Size = new System.Drawing.Size(624, 395);
			this.gvMain.TabIndex = 2;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 442);
			this.Controls.Add(this.gvMain);
			this.Controls.Add(this.tsMain);
			this.Controls.Add(this.ssMain);
			this.Name = "MainForm";
			this.Text = "Черная бухгалтерия";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip ssMain;
		private System.Windows.Forms.ToolStrip tsMain;
		private System.Windows.Forms.DataGridView gvMain;
		private System.Windows.Forms.ToolStripButton tsbtnAdd;
		private System.Windows.Forms.ToolStripButton tsbtnDel;
		private System.Windows.Forms.ToolStripButton tsbtnChangeEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnSettings;
	}
}

