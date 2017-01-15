using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BlackAccounting
{
	public partial class ChartForm : Form
	{
		private Series _series;
		private AccountingData _data;
		private IList<Tuple<string, Action<Record>>> _chartParameters;

		public ChartForm(AccountingData accountingData)
		{
			InitializeComponent();

			_series = chrtMain.Series.Add("");
			_data = accountingData;
			_chartParameters = new List<Tuple<string, Action<Record>>>();

			_chartParameters.Add(new Tuple<string, Action<Record>>("Потрачено за день в среднем", r => { _series.Points.AddXY(r.Date, r.AvgForDay); }));
			_chartParameters.Add(new Tuple<string, Action<Record>>("Остаток", r => { _series.Points.AddXY(r.Date, r.AfterOperation); }));
			_chartParameters.Add(new Tuple<string, Action<Record>>("Потрачено за день", r => { _series.Points.AddXY(r.Date, r.ThisDayValue); }));

			cmbChartTypeSelect.DataSource = _chartParameters;
			cmbChartTypeSelect.ValueMember = "";
			cmbChartTypeSelect.DisplayMember = "Item1";
		}

		private void cmbChartTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selected = (Tuple<string, Action<Record>>)cmbChartTypeSelect.SelectedValue;

			_series.Points.Clear();
			foreach (Record r in _data.Records)
			{
				selected.Item2(r);
			}
		}
	}
}
