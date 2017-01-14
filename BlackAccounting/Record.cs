using System;
using System.Runtime.Serialization;

namespace BlackAccounting
{
	[DataContract]
	public class Record
	{
		/// <summary>
		/// ID операции
		/// </summary>
		[DataMember]
		public int ID { get; set; }
		/// <summary>
		/// Тип операции
		/// </summary>
		[DataMember]
		public int TypeID { get; set; }
		/// <summary>
		/// Дата операции
		/// </summary>
		[DataMember]
		public DateTime Date { get; set; }
		/// <summary>
		/// Сумма операции
		/// </summary>
		[DataMember]
		public decimal Value { get; set; }
		/// <summary>
		/// Описание операции
		/// </summary>
		[DataMember]
		public string Description { get; set; }
		/// <summary>
		/// Остаток после операции
		/// </summary>
		[DataMember]
		public decimal AfterOperation { get; set; }

		/// <summary>
		/// Проверка остатка после операции
		/// </summary>
		[IgnoreDataMember]
		public decimal? ValueCheck { get; set; }

		/// <summary>
		/// Истрачено за данный день
		/// </summary>
		[IgnoreDataMember]
		public decimal? ThisDayValue { get; set; }
		/// <summary>
		/// Истрачено за данный месяц
		/// </summary>
		[IgnoreDataMember]
		public decimal? ThisMonthValue { get; set; }
		/// <summary>
		/// Истрачено всего
		/// </summary>
		[IgnoreDataMember]
		public decimal Spent { get; set; }
		/// <summary>
		/// Истрачено за день в среднем
		/// </summary>
		[IgnoreDataMember]
		public decimal AvgForDay { get; set; }
	}
}
