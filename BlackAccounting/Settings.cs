using System.Collections.Generic;
using System.Linq;

namespace BlackAccounting
{
	public class Settings
	{
		public IList<Setting> Values;

		public string DataFilePath => (string)Values.FirstOrDefault(s => s.ID == "DataFilePath").Value;

		public Settings()
		{
			Values = new List<Setting>();
			Values.Add(new Setting { ID = "DataFilePath", Description = "Путь к файлу с данными", Value = Properties.Settings.Default.DataFilePath });
		}

		public void Save()
		{
			Properties.Settings.Default.DataFilePath = DataFilePath;
			Properties.Settings.Default.Save();
		}
	}
}
