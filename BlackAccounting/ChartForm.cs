using BlackAccounting.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BlackAccounting
{
	public partial class ChartForm : Form
	{
		private Series _series;
		private AccountingData _data;
		private IList<Tuple<string, SeriesChartType, Action<Record>>> _chartParameters;

		public ChartForm(AccountingData accountingData)
		{
			InitializeComponent();

			_series = chrtMain.Series.Add("");
			_data = accountingData;
			_chartParameters = new List<Tuple<string, SeriesChartType, Action<Record>>>();

			_chartParameters.Add(new Tuple<string, SeriesChartType, Action<Record>>("Потрачено за день в среднем", SeriesChartType.Line, r => { _series.Points.AddXY(r.Date, r.AvgForDay); }));
			_chartParameters.Add(new Tuple<string, SeriesChartType, Action<Record>>("Остаток", SeriesChartType.Line, r => { _series.Points.AddXY(r.Date, r.AfterOperation); }));
			_chartParameters.Add(new Tuple<string, SeriesChartType, Action<Record>>("Потрачено за день", SeriesChartType.Column, r => { _series.Points.AddXY(r.Date, r.ThisDayValue); }));
			_chartParameters.Add(new Tuple<string, SeriesChartType, Action<Record>>("Потрачено за месяц", SeriesChartType.Column, r => { if (r.ThisMonthValue != null) _series.Points.AddXY(r.Date.ToString("MMMM yy"), r.ThisMonthValue); }));

			cmbChartTypeSelect.DataSource = _chartParameters;
			cmbChartTypeSelect.ValueMember = "";
			cmbChartTypeSelect.DisplayMember = "Item1";
		}

		private void cmbChartTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selected = (Tuple<string, SeriesChartType, Action<Record>>)cmbChartTypeSelect.SelectedValue;

			_series.Points.Clear();
			_series.ChartType = selected.Item2;
			foreach (Record r in _data.Records)
			{
				selected.Item3(r);
			}
		}
	}
}
