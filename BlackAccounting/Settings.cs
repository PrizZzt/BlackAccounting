using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace BlackAccounting
{
	[DataContract]
	public class Settings
	{
		public static Settings Instance { get; private set; }
		
		public static IList<Setting> EditValues { get; private set; }

		[DataMember]
		public string DataFilePath { get; set; }
		[DataMember]
		public string BackupFilePath { get; set; }
		[DataMember]
		public string Password { get; set; }
		[DataMember]
		public string Iv { get; set; }

		public static void Load()
		{
			string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			string filePath = Path.Combine(myDocumentsPath, ".blackAccountingSettings");

			if (File.Exists(filePath))
			{
				using (FileStream fs = new FileStream(filePath, FileMode.Open))
				{
					DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Settings));
					Instance = (Settings)serializer.ReadObject(fs);
				}
			}
			else
			{
				Instance = new Settings
				{
					DataFilePath = Path.Combine(myDocumentsPath, "accounting.dat"),
					BackupFilePath = Path.Combine(myDocumentsPath, "backup.json"),
					Password = "12345678",
					Iv = "87654321"
				};
			}
		}

		public static void Save()
		{
			if (Instance != null)
			{
				EndEdit();
				string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				string filePath = Path.Combine(myDocumentsPath, ".blackAccountingSettings");

				using (FileStream fs = new FileStream(filePath, FileMode.Create))
				{
					DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Settings));
					serializer.WriteObject(fs, Instance);
				}
			}
		}

		public static void PrepareToEdit()
		{
			EditValues = new List<Setting>
			{
				new Setting
				{
					ID = "DataFilePath",
					Description = "Путь к файлу с данными",
					Value = Instance.DataFilePath
				},
				new Setting
				{
					ID = "BackupFilePath",
					Description = "Путь к запасному файлу с данными",
					Value = Instance.BackupFilePath
				},
				new Setting
				{
					ID = "Password",
					Description = "Ключ к файлу с данными",
					Value = Instance.Password
				},
				new Setting
				{
					ID = "IV",
					Description = "Вектор инициализации",
					Value = Instance.Iv
				}
			};
		}

		public static void EndEdit()
		{
			if (EditValues == null) return;
			foreach (Setting s in EditValues)
			{
				switch (s.ID)
				{
					case "DataFilePath": Instance.DataFilePath = (string)s.Value; break;
					case "BackupFilePath": Instance.BackupFilePath = (string)s.Value; break;
					case "Password": Instance.Password = (string)s.Value; break;
					case "IV": Instance.Iv = (string)s.Value; break;
				}
			}
			EditValues = null;
		}
	}
}
