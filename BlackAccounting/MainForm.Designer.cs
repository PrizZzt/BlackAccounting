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
			this.tsbtnUpdate = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnTypeEdit = new System.Windows.Forms.ToolStripButton();
			this.tsbtnSettings = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEnter = new System.Windows.Forms.ToolStripButton();
			this.tsbtnChart = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
			this.tsbtnFromBackup = new System.Windows.Forms.ToolStripButton();
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
            this.tsbtnUpdate,
            this.toolStripSeparator1,
            this.tsbtnTypeEdit,
            this.tsbtnSettings,
            this.toolStripSeparator2,
            this.tsbtnEnter,
            this.tsbtnChart,
            this.toolStripSeparator3,
            this.tsbtnSave,
            this.tsbtnFromBackup});
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
			// tsbtnUpdate
			// 
			this.tsbtnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnUpdate.Image = global::BlackAccounting.Properties.Resources.lightning;
			this.tsbtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnUpdate.Name = "tsbtnUpdate";
			this.tsbtnUpdate.Size = new System.Drawing.Size(23, 22);
			this.tsbtnUpdate.Text = "Обновить вычисляемые поля";
			this.tsbtnUpdate.Click += new System.EventHandler(this.tsbtnUpdate_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbtnTypeEdit
			// 
			this.tsbtnTypeEdit.CheckOnClick = true;
			this.tsbtnTypeEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnTypeEdit.Image = global::BlackAccounting.Properties.Resources.hierarchical_structure;
			this.tsbtnTypeEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnTypeEdit.Name = "tsbtnTypeEdit";
			this.tsbtnTypeEdit.Size = new System.Drawing.Size(23, 22);
			this.tsbtnTypeEdit.Text = "Редактировать типы записей";
			this.tsbtnTypeEdit.CheckedChanged += new System.EventHandler(this.gridSwitchData);
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
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbtnEnter
			// 
			this.tsbtnEnter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnEnter.Image = global::BlackAccounting.Properties.Resources.add_green;
			this.tsbtnEnter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEnter.Name = "tsbtnEnter";
			this.tsbtnEnter.Size = new System.Drawing.Size(23, 22);
			this.tsbtnEnter.Text = "Ввод нескольких записей сразу...";
			this.tsbtnEnter.Click += new System.EventHandler(this.tsbtnEnter_Click);
			// 
			// tsbtnChart
			// 
			this.tsbtnChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnChart.Image = global::BlackAccounting.Properties.Resources.bar_chart;
			this.tsbtnChart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnChart.Name = "tsbtnChart";
			this.tsbtnChart.Size = new System.Drawing.Size(23, 22);
			this.tsbtnChart.Text = "Графики...";
			this.tsbtnChart.Click += new System.EventHandler(this.tsbtnChart_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbtnSave
			// 
			this.tsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnSave.Image = global::BlackAccounting.Properties.Resources.checked_1;
			this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSave.Name = "tsbtnSave";
			this.tsbtnSave.Size = new System.Drawing.Size(23, 22);
			this.tsbtnSave.Text = "Сохранить";
			this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
			// 
			// tsbtnFromBackup
			// 
			this.tsbtnFromBackup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnFromBackup.Image = global::BlackAccounting.Properties.Resources.shuffle;
			this.tsbtnFromBackup.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnFromBackup.Name = "tsbtnFromBackup";
			this.tsbtnFromBackup.Size = new System.Drawing.Size(23, 22);
			this.tsbtnFromBackup.Text = "Взять данные из бэкапа";
			this.tsbtnFromBackup.Click += new System.EventHandler(this.tsbtnFromBackup_Click);
			// 
			// gvMain
			// 
			this.gvMain.AllowUserToAddRows = false;
			this.gvMain.AllowUserToResizeRows = false;
			this.gvMain.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.gvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gvMain.Location = new System.Drawing.Point(0, 25);
			this.gvMain.Name = "gvMain";
			this.gvMain.RowHeadersVisible = false;
			this.gvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.gvMain.Size = new System.Drawing.Size(624, 395);
			this.gvMain.TabIndex = 2;
			this.gvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellClick);
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
		private System.Windows.Forms.ToolStripButton tsbtnTypeEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnSettings;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnChart;
		private System.Windows.Forms.ToolStripButton tsbtnUpdate;
		private System.Windows.Forms.ToolStripButton tsbtnEnter;
		private System.Windows.Forms.ToolStripButton tsbtnFromBackup;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton tsbtnSave;
	}
}

