using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace BlackAccounting
{
	public class Settings
	{
		public IList<Setting> Values { get; private set; }
		private Configuration _config;

		public string DataFilePath => Values.FirstOrDefault(s => s.ID == "DataFilePath")?.Value?.ToString();
		public string BackupFilePath => Values.FirstOrDefault(s => s.ID == "BackupFilePath")?.Value?.ToString();
		public string Password => Values.FirstOrDefault(s => s.ID == "Password")?.Value?.ToString();
		public string Iv => Values.FirstOrDefault(s => s.ID == "IV")?.Value?.ToString();

		public Settings()
		{
			_config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);

			Values = new List<Setting>
			{
				new Setting
				{
					ID = "DataFilePath",
					Description = "Путь к файлу с данными",
					Value = _config.AppSettings.Settings["DataFilePath"].Value
				},
				new Setting
				{
					ID = "BackupFilePath",
					Description = "Путь к запасному файлу с данными",
					Value = _config.AppSettings.Settings["BackupFilePath"].Value
				},
				new Setting
				{
					ID = "Password",
					Description = "Ключ к файлу с данными",
					Value = _config.AppSettings.Settings["Password"].Value
				},
				new Setting
				{
					ID = "IV",
					Description = "Вектор инициализации",
					Value = _config.AppSettings.Settings["IV"].Value
				}
			};
		}

		public void Save()
		{
			_config.AppSettings.Settings["DataFilePath"].Value = DataFilePath;
			_config.AppSettings.Settings["BackupFilePath"].Value = BackupFilePath;
			_config.AppSettings.Settings["Password"].Value = Password;
			_config.AppSettings.Settings["IV"].Value = Iv;

			_config.Save();
		}
	}
}
