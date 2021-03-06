﻿using BlackAccounting.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BlackAccounting
{
	public partial class MainForm : Form
	{
		private Accounting _accounting;

		public MainForm()
		{
			InitializeComponent();
			Icon = Resources.pirate_icon;
			gvMain.AutoGenerateColumns = false;

			Settings.Load();
			_accounting = new Accounting(Settings.Instance);

			gridSwitchData(null, null);
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			gvMain.EndEdit();

			Settings.Save();

			_accounting.ProtectedSave(Settings.Instance.DataFilePath, Settings.Instance.Password, Settings.Instance.Iv);
			if (string.IsNullOrEmpty(Settings.Instance.BackupFilePath) == false)
				_accounting.Save(Settings.Instance.BackupFilePath);
		}

		private void tsbtnAddRecord_Click(object sender, EventArgs e)
		{
			var firstRow = gvMain.FirstDisplayedScrollingRowIndex;
			gvMain.DataSource = null;

			if (tsbtnTypeEdit.Checked)
			{
				_accounting.AddType();
				gvMain.DataSource = _accounting.Data.Types;
			}
			else
			{
				_accounting.AddRecord();
				gvMain.DataSource = _accounting.Data.Records;
			}

			if (firstRow >= 0)
				gvMain.FirstDisplayedScrollingRowIndex = firstRow;

      tsslRowsCount.Text = $"Количество строк : {gvMain.Rows.Count}";
		}

		private void tsbtnDelRecord_Click(object sender, EventArgs e)
		{
			List<int> idToRemove = new List<int>();

			foreach (DataGridViewCell cell in gvMain.SelectedCells)
				idToRemove.Add((int)cell.OwningRow.Cells["IDColumn"].Value);

			var firstRow = gvMain.FirstDisplayedScrollingRowIndex;
			gvMain.DataSource = null;

			if (tsbtnTypeEdit.Checked)
			{
				_accounting.DelType(idToRemove);
				gvMain.DataSource = _accounting.Data.Types;
			}
			else
			{
				_accounting.DelRecord(idToRemove);
				gvMain.DataSource = _accounting.Data.Records;
			}

			if (firstRow >= 0 && gvMain.Rows.Count > 0)
				gvMain.FirstDisplayedScrollingRowIndex = firstRow;

			_accounting.Data.UpdateData();

      tsslRowsCount.Text = $"Количество строк : {gvMain.Rows.Count}";
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
						AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
						DataPropertyName = "Value",
						HeaderText = "Значение",
						Name = "ValueColumn"
					}
				};

				Settings.PrepareToEdit();
				gvMain.DataSource = Settings.EditValues;
			}
			else
			{
				Settings.EndEdit();
				if (tsbtnTypeEdit.Checked)
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
						},
						new DataGridViewButtonColumn
						{
							AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
							DataPropertyName = "Color",
							HeaderText = "Цвет",
							Name = "ColorColumn"
						}
					};

					gvMain.DataSource = _accounting.Data.Types;
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
							DataSource = _accounting.Data.Types,
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

					gvMain.DataSource = _accounting.Data.Records;
				}
			}

			gvMain.Columns.Clear();
			gvMain.Columns.AddRange(columns);

			if (gvMain.Columns["ColorColumn"] != null)
			{
				foreach (DataGridViewRow row in gvMain.Rows)
				{
					row.DefaultCellStyle.BackColor = (Color)row.Cells["ColorColumn"].Value;
				}
			}

			SetButtonsAvailability();

      tsslRowsCount.Text = $"Количество строк : {gvMain.Rows.Count}";
    }

		private void tsbtnChart_Click(object sender, EventArgs e)
		{
			using (ChartForm chartForm = new ChartForm(_accounting.Data))
			{
				chartForm.ShowDialog();
			}
		}

		private void tsbtnUpdate_Click(object sender, EventArgs e)
		{
			var firstRow = gvMain.FirstDisplayedScrollingRowIndex;
			gvMain.DataSource = null;
			_accounting.Data.UpdateData();

			if (tsbtnTypeEdit.Checked)
			{
				gvMain.DataSource = _accounting.Data.Types;
			}
			else
			{
				var TypeColumn = (DataGridViewComboBoxColumn)gvMain.Columns["TypeColumn"];
				TypeColumn.DataSource = _accounting.Data.Types;
				TypeColumn.ValueMember = "ID";
				TypeColumn.DisplayMember = "Description";

				gvMain.DataSource = _accounting.Data.Records;
			}

			if (firstRow > gvMain.Rows.Count)
				gvMain.FirstDisplayedScrollingRowIndex = firstRow;
		}

		private void SetButtonsAvailability()
		{
			tsbtnAdd.Enabled = tsbtnSettings.Checked == false;
			tsbtnEnter.Enabled = tsbtnSettings.Checked == false && tsbtnTypeEdit.Checked == false;
			tsbtnDel.Enabled = tsbtnSettings.Checked == false;
			tsbtnUpdate.Enabled = tsbtnSettings.Checked == false && tsbtnTypeEdit.Checked == false;
			tsbtnTypeEdit.Enabled = tsbtnSettings.Checked == false;
		}

		private void tsbtnEnter_Click(object sender, EventArgs e)
		{
			using (EnterForm enterForm = new EnterForm())
			{
				enterForm.ShowDialog();
			}

			if (EnterForm.Values.Count > 0)
			{
				foreach (Record item in EnterForm.Values)
					_accounting.AddRecord(item);

				tsbtnUpdate_Click(null, null);
      }

      tsslRowsCount.Text = $"Количество строк : {gvMain.Rows.Count}";
    }

		private void tsbtnFromBackup_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы уверены, что хотите восстановить данные из бэкапа", "Внимание", MessageBoxButtons.OKCancel) != DialogResult.OK)
				return;

			_accounting.Load(Settings.Instance.BackupFilePath, true);

			if (_accounting.Backup == null)
			{
				MessageBox.Show("Бэкап еще не существует", "Внимание");
				return;
			}

			if (_accounting.Data.LastSaveTime > _accounting.Backup.LastSaveTime)
			{
				if (MessageBox.Show("Дата последнего сохранения бэкапа меньше текущих данных, все равно заменить данные?", "Внимание", MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					_accounting.Backup = null;
					return;
				}
			}

			_accounting.Data = _accounting.Backup;
			tsbtnUpdate_Click(null, null);

      tsslRowsCount.Text = $"Количество строк : {gvMain.Rows.Count}";
    }

		private void tsbtnSave_Click(object sender, EventArgs e)
		{
			MainForm_FormClosing(null, null);
		}

		private void gvMain_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;

			if (gvMain.Columns["ColorColumn"]!=null && e.ColumnIndex == gvMain.Columns["ColorColumn"].Index)
			{
				using (ColorDialog colorDialog = new ColorDialog())
				{
					if (colorDialog.ShowDialog() == DialogResult.OK)
					{
						gvMain[e.ColumnIndex, e.RowIndex].Value = colorDialog.Color;
						gvMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorDialog.Color;
					}
				}
			}
		}
	}
}
