using System;
using System.Globalization;

namespace BlackAccounting
{
	static class TextParser
	{
		public static Record Parse(string line)
		{
			string[] splitLine = line.Split('\t');

			if (splitLine.Length != 4)
				throw new FormatException("Неправильный формат строки");

			Record result = new Record();
			result.TypeID = 0;

			DateTime resultDate;
			if (DateTime.TryParse(splitLine[0], out resultDate))
				result.Date = resultDate;
			else
				throw new FormatException("Дата операции не распознана");

			decimal resultValue;
			if (decimal.TryParse(splitLine[1], NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out resultValue))
				result.Value = resultValue;
			else
				throw new FormatException("Значение операции не распознано");

			result.Description = splitLine[2];

			decimal resultAfterOperation;
			if (decimal.TryParse(splitLine[3], NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out resultAfterOperation))
				result.AfterOperation = resultAfterOperation;
			else
				throw new FormatException("Остаток после операции не распознан");

			return result;
		}
	}
}
