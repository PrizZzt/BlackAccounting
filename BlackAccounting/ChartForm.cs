using BlackAccounting.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BlackAccounting
{
	public partial class ChartForm : Form
	{
		private Series _series;
		private AccountingData _data;
		private IList<ChartParameters> _chartParameters;

		public ChartForm(AccountingData accountingData)
		{
			InitializeComponent();

			_series = chrtMain.Series.Add("");
			_data = accountingData;
			_chartParameters = new List<ChartParameters>();

			_chartParameters.Add(new ChartParameters(
				"Потрачено за день в среднем",
				SeriesChartType.Line,
				r => { _series.Points.AddXY(r.Date, r.AvgForDay); }
				));
			_chartParameters.Add(new ChartParameters(
				"Остаток",
				SeriesChartType.Line,
				r => { _series.Points.AddXY(r.Date, r.AfterOperation); }
				));
			_chartParameters.Add(new ChartParameters(
				"Потрачено за день",
				SeriesChartType.Column,
				r => { _series.Points.AddXY(r.Date, r.ThisDayValue); }
				));
			_chartParameters.Add(new ChartParameters(
				"Потрачено за месяц",
				SeriesChartType.Column,
				r => { if (r.ThisMonthValue != null) _series.Points.AddXY(r.Date.ToString("MMMM yy"), r.ThisMonthValue); }
				));
			_chartParameters.Add(new ChartParameters(
				"Структура расходов",
				(data, series) =>
				{
					_series.ChartType = SeriesChartType.Pie;
					foreach (var r in data.GroupBy(r => r.TypeID).Select(gr => new { Key = _data.Types[gr.Key].Description, Value = gr.Where(r => r.Value < 0).Sum(r => -r.Value) }).OrderBy(r=>r.Value))
					{
						if (r.Value > 0)
							series.Points.AddXY(r.Key, r.Value);
					}
				}
				));

			cmbChartTypeSelect.DataSource = _chartParameters;
			cmbChartTypeSelect.ValueMember = "";
			cmbChartTypeSelect.DisplayMember = "Description";
		}

		private void cmbChartTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selected = (ChartParameters)cmbChartTypeSelect.SelectedValue;

			_series.Points.Clear();
			if (selected.FullFillAction != null)
				selected.FullFillAction(_data.Records, _series);
			else
			{
				if (selected.FillAction != null)
				{
					_series.ChartType = selected.ChartType;
					foreach (Record r in _data.Records)
					{
						selected.FillAction(r);
					}
				}
			}
		}
	}
}
