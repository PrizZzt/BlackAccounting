﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace BlackAccounting
{
	[DataContract]
	public class AccountingData
	{
		[DataMember]
		public List<RecordType> Types { get; private set; }
		[DataMember]
		public List<Record> Records { get; private set; }

		public AccountingData()
		{
			Types = new List<RecordType>();
			Records = new List<Record>();
		}

		public void UpdateData()
		{
			// Если нет хранилищ данных - создаем
			if (Records == null) Records = new List<Record>();
			if (Types == null) Types = new List<RecordType>();

			// Если нет нулевого типа - создаем
			if (Types.Exists(rt => rt.ID == 0) == false)
				Types.Add(new RecordType { ID = 0, Description = string.Empty });

			// Если данных нет - завершаем выполнение
			if (Records.Count == 0) return;

			// Сортируем все данные и типы
			Types = Types.OrderBy(rt => rt.ID).ToList();
			Records = Records.OrderBy(r => r.ID).ToList();
			
			// Перенумеровываем данные, номерами по порядку и без пропусков
			for (int i = 0; i < Records.Count; i++)
			{
				Records[i].ID = i + 1;
				if (Types.Select(rt => rt.ID).Contains(Records[i].TypeID) == false) Records[i].TypeID = 0;

				// Вычисляем контрольное значение
				Records[i].ValueCheck = i == 0 ? null : (decimal?)(Records[i].AfterOperation - Records[i - 1].AfterOperation - Records[i].Value);
			}

			// Обновляем данные в вычисляемых полях
			foreach (var thisR in Records)
			{
				thisR.ThisDayValue = Records.Where(r => r.Date == thisR.Date && r.Value < 0 && r.ID <= thisR.ID).Sum(r => -r.Value);

				thisR.Spent = Records.Where(r => r.Value < 0 && r.ID <= thisR.ID).Sum(r => -r.Value);

				int daysPassed = Records.Where(r => r.ID <= thisR.ID).Select(r => r.Date).Distinct().Count();
				thisR.AvgForDay = thisR.Spent / (daysPassed == 0 ? 1 : daysPassed);
			}

			// Обнуляем тип записи для всех записей с недействительными типами записей
			foreach (var record in Records.Where(r => Types.Select(rt => rt.ID).Contains(r.TypeID) == false))
			{
				record.TypeID = 0;
			}
		}
	}
}