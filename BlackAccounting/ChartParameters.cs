using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace BlackAccounting
{
	/// <summary>
	/// Параметры для построения графика
	/// </summary>
	class ChartParameters
	{
		/// <summary>
		/// Описание графика
		/// </summary>
		public string Description { get; private set; }
		/// <summary>
		/// 
		/// </summary>
		public SeriesChartType ChartType { get; private set; }
		/// <summary>
		/// Действие для добавления записи на график
		/// </summary>
		public Action<Record> FillAction { get; private set; }
		/// <summary>
		/// Действие для полного управления процессом построения графика
		/// </summary>
		public Action<IEnumerable<Record>, Series> FullFillAction { get; private set; }

		public ChartParameters(string description, SeriesChartType chartType, Action<Record> fillAction)
		{
			Description = description;
			ChartType = chartType;
			FillAction = fillAction;
			FullFillAction = null;
		}
		public ChartParameters(string description, Action<IEnumerable<Record>, Series> fullFillAction)
		{
			Description = description;
			ChartType = SeriesChartType.FastPoint;
			FillAction = null;
			FullFillAction = fullFillAction;
		}
	}
}
