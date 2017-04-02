using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;

namespace BlackAccounting
{
	public class Accounting
	{
		public AccountingData Data;
		public AccountingData Backup;
		private DESCryptoServiceProvider _csp;
		private Settings _settings;

		public Accounting(Settings settings)
		{
			Data = new AccountingData();
			_csp = new DESCryptoServiceProvider();
			_settings = settings;

			if (string.IsNullOrEmpty(_settings.DataFilePath) == false)
			{
				ProtectedLoad(_settings.DataFilePath, _settings.Password, _settings.Iv, false);
			}
		}

		public void Load(string fileName, bool isBackup)
		{
			if (string.IsNullOrEmpty(fileName))
				throw new FileNotFoundException();

			if (File.Exists(fileName))
			{
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AccountingData));
				using (FileStream fs = new FileStream(fileName, FileMode.Open))
				{
					if (isBackup)
						Backup = (AccountingData)serializer.ReadObject(fs);
					else
						Data = (AccountingData)serializer.ReadObject(fs);
				}
			}
			Data.UpdateData();
		}

		public void ProtectedLoad(string fileName, string key, string iv, bool isBackup)
		{
			if (string.IsNullOrEmpty(fileName))
				throw new FileNotFoundException();
			if (_csp.ValidKeySize(key.Length * 8) == false)
				throw new CryptographicException("Неподходящий размер ключа");
			if (_csp.ValidKeySize(key.Length * 8) == false)
				throw new CryptographicException("Неподходящий размер вектора инициализации");

			if (File.Exists(fileName))
			{
				byte[] bKey = Encoding.ASCII.GetBytes(key);
				byte[] bIV = Encoding.ASCII.GetBytes(iv);

				DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AccountingData));
				using (FileStream fs = new FileStream(fileName, FileMode.Open))
				using (CryptoStream cs = new CryptoStream(fs, _csp.CreateDecryptor(bKey, bIV), CryptoStreamMode.Read))
				using (GZipStream zs = new GZipStream(cs, CompressionMode.Decompress))
				{
					if (isBackup)
						Backup = (AccountingData)serializer.ReadObject(zs);
					else
						Data = (AccountingData)serializer.ReadObject(zs);
				}
			}
			Data.UpdateData();
		}

		public void Save(string fileName)
		{
			if (string.IsNullOrEmpty(fileName) || Data.Records.Count == 0)
				return;

			if (File.Exists(fileName))
			{
				string oldDataFile = Path.ChangeExtension(fileName, "bak");
				File.Delete(oldDataFile);
				File.Move(fileName, oldDataFile);
			}

			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AccountingData));
			using (FileStream fs = new FileStream(fileName, FileMode.Create))
			{
				Data.SetLastSaveTime();
				serializer.WriteObject(fs, Data);
			}
		}

		public void ProtectedSave(string fileName, string key, string iv)
		{
			if (string.IsNullOrEmpty(fileName) || Data.Records.Count == 0)
				return;

			if (_csp.ValidKeySize(key.Length * 8) == false)
				throw new CryptographicException("Неподходящий размер ключа");
			if (_csp.ValidKeySize(key.Length * 8) == false)
				throw new CryptographicException("Неподходящий размер вектора инициализации");

			byte[] bKey = Encoding.ASCII.GetBytes(key);
			byte[] bIV = Encoding.ASCII.GetBytes(iv);

			if (File.Exists(fileName))
			{
				string oldDataFile = Path.ChangeExtension(fileName, "bak");
				File.Delete(oldDataFile);
				File.Move(fileName, oldDataFile);
			}

			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AccountingData));
			using (FileStream fs = new FileStream(fileName, FileMode.Create))
			using (CryptoStream cs = new CryptoStream(fs, _csp.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write))
			using (GZipStream zs = new GZipStream(cs, CompressionMode.Compress))
			{
				Data.SetLastSaveTime();
				serializer.WriteObject(zs, Data);
			}
		}

		public void AddRecord()
		{
			Data.Records.Add(new Record { ID = Data.Records.Count>0?Data.Records.Select(r => r.ID).Max() + 1 : 0, Date = DateTime.Now.Date, Value = 0, AfterOperation = 0, Description = string.Empty, TypeID = 0 });
			Data.UpdateData();
		}

		public void AddRecord(Record item)
		{
			if (Data.Records.Count(r => r.Date == item.Date) == 0)
			{
				item.ID = Data.Records.Count > 0 ? Data.Records.Select(r => r.ID).Max() + 1 : 0;

				Data.Records.Add(item);
				Data.UpdateData();
			}
		}

		public void AddType()
		{
			Data.Types.Add(new RecordType { ID = Data.Types.Count > 0 ? Data.Types.Select(r => r.ID).Max() + 1 : 0, Description = string.Empty });
			Data.UpdateData();
		}

		public void DelRecord(IList<int> idToRemove)
		{
			Data.Records.RemoveAll(rt => idToRemove.Contains(rt.ID));
			Data.UpdateData();
		}

		public void DelType(IList<int> idToRemove)
		{
			Data.Types.RemoveAll(rt => idToRemove.Contains(rt.ID));
			Data.UpdateData();
		}
	}
}
