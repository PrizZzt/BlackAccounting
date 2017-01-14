using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BlackAccounting
{
	public partial class MainForm : Form
	{
		private Accounting accounting;
		private Settings settings;

		public MainForm()
		{
			InitializeComponent();
			gvMain.AutoGenerateColumns = false;

			settings = new Settings();
			accounting = new Accounting(settings.DataFilePath);

			gridSwitchData(null, null);
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			gvMain.EndEdit();
			accounting.Save();
			settings.Save();
		}

		private void tsbtnAddRecord_Click(object sender, EventArgs e)
		{
			gvMain.DataSource = null;
			
			if (tsbtnChangeEdit.Checked)
			{
				accounting.AddType();
				gvMain.DataSource = accounting.Data.Types;
			}
			else
			{
				accounting.AddRecord();
				gvMain.DataSource = accounting.Data.Records;
			}
		}

		private void tsbtnDelRecord_Click(object sender, EventArgs e)
		{
			List<int> idToRemove = new List<int>();

			foreach (DataGridViewCell cell in gvMain.SelectedCells)
				idToRemove.Add((int)cell.OwningRow.Cells["IDColumn"].Value);

			gvMain.DataSource = null;

			if (tsbtnChangeEdit.Checked)
			{
				accounting.DelType(idToRemove);
				gvMain.DataSource = accounting.Data.Types;
			}
			else
			{
				accounting.DelRecord(idToRemove);
				gvMain.DataSource = accounting.Data.Records;
			}

			accounting.Data.UpdateData();
		}

		private void gridSwitchData(object sender, EventArgs e)
		{
			DataGridViewColumn[] columns = new DataGridViewColumn[0];

			if (tsbtnSettings.Checked)
			{
				columns = new DataGridViewColumn[]
					{
						new DataGridViewTextBoxColumn
						{
							AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
							DataPropertyName = "Description",
							HeaderText = "Параметр",
							Name = "DescriptionColumn",
							ReadOnly = true
						},
						new DataGridViewTextBoxColumn
						{
							AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
							DataPropertyName = "Value",
							HeaderText = "Значение",
							Name = "ValueColumn"
						}
					};

				gvMain.DataSource = settings.Values;
			}
			else
			{
				if (tsbtnChangeEdit.Checked)
				{
					columns = new DataGridViewColumn[]
					{
						new DataGridViewTextBoxColumn
						{
							AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
							DataPropertyName = "ID",
							HeaderText = "#",
							Name = "IDColumn",
							ReadOnly = true
						},
						new DataGridViewTextBoxColumn
						{
							AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
							DataPropertyName = "Description",
							HeaderText = "Описание",
							Name = "DescriptionColumn"
						}
					};

					gvMain.DataSource = accounting.Data.Types;
				}
				else
				{
					columns = new DataGridViewColumn[]
					{
						new DataGridViewTextBoxColumn
						{
							AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
							DataPropertyName = "ID",
							HeaderText = "#",
							Name = "IDColumn",
							ReadOnly = true
						},
						new DataGridViewTextBoxColumn
						{
							AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
							DataPropertyName = "Date",
							HeaderText = "Дата",
							Name = "DateColumn"
						},
						new DataGridViewTextBoxColumn
						{
							AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
							DataPropertyName = "Value",
							HeaderText = "Значение",
							Name = "ValueColumn"
						},
						new DataGridViewComboBoxColumn
						{
							AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
							DataPropertyName = "TypeID",
							HeaderText = "Тип",
							Name = "TypeColumn",
							DataSource = accounting.Data.Types,
							ValueMember = "ID",
							DisplayMember = "Description"
						},
						new DataGridViewTextBoxColumn
						{
							AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
							DataPropertyName = "Description",
							HeaderText = "Описание",
							Name = "DescriptionColumn"
						},
						new DataGridViewTextBoxColumn
						{
							AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
							DataPropertyName = "AfterOperation",
							HeaderText = "Остаток",
							Name = "AfterOperationColumn"
						},
						new DataGridViewTextBoxColumn
						{
							AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
							DataPropertyName = "ValueCheck",
							HeaderText = "Проверка",
							Name = "ValueCheckColumn",
							ReadOnly = true
						},
						new DataGridViewTextBoxColumn
						{
							AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
							DataPropertyName = "ThisDayValue",
							HeaderText = "Потрачено за день",
							Name = "ThisDayValueColumn",
							ReadOnly = true
						},
						new DataGridViewTextBoxColumn
						{
							AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
							DataPropertyName = "ThisMonthValue",
							HeaderText = "Потрачено за месяц",
							Name = "ThisMonthValueColumn",
							ReadOnly = true
						},
						new DataGridViewTextBoxColumn
						{
							AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
							DataPropertyName = "Spent",
							HeaderText = "Потрачено всего",
							Name = "SpentColumn",
							ReadOnly = true
						},
						new DataGridViewTextBoxColumn
						{
							AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
							DataPropertyName = "AvgForDay",
							HeaderText = "Потрачено за день в среднем",
							Name = "AvgForDayColumn",
							DefaultCellStyle=new DataGridViewCellStyle() { Format = "0.00"},
							ReadOnly = true
						}
					};

					gvMain.DataSource = accounting.Data.Records;
				}
			}

			gvMain.Columns.Clear();
			gvMain.Columns.AddRange(columns);
		}
	}
}
