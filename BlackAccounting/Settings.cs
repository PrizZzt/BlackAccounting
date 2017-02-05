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
				}
			};
		}

		public void Save()
		{
			_config.AppSettings.Settings["DataFilePath"].Value = DataFilePath;
			_config.AppSettings.Settings["BackupFilePath"].Value = BackupFilePath;
			
			_config.Save();
		}
	}
}
