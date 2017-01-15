using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace BlackAccounting
{
	public class Accounting
	{
		public AccountingData Data;

		public string FileName { get; private set; }

		public Accounting(string fileName = null)
		{
			Data = new AccountingData();

			if (string.IsNullOrEmpty(fileName) == false)
			{
				SetDataFile(fileName);
				Load();
			}
		}

		public void SetDataFile(string fileName)
		{
			FileName = fileName;
		}

		public void Load()
		{
			if (string.IsNullOrEmpty(FileName))
				throw new FileNotFoundException();

			if (File.Exists(FileName))
			{
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AccountingData));
				using (FileStream fs = new FileStream(FileName, FileMode.Open))
				{
					Data = (AccountingData)serializer.ReadObject(fs);
				}
			}
			Data.UpdateData();
		}

		public void Save()
		{
			if (string.IsNullOrEmpty(FileName) && Data.Records.Count == 0)
				return;

			string oldDataFile = Path.ChangeExtension(FileName, "bak");
			File.Delete(oldDataFile);
			File.Copy(FileName, oldDataFile);

			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AccountingData));
			using (FileStream fs = new FileStream(FileName, FileMode.Create))
			{
				serializer.WriteObject(fs, Data);
			}
		}

		public void AddRecord()
		{
			Data.Records.Add(new Record { ID = Data.Records.Select(r => r.ID)?.Max() + 1 ?? 0, Date = DateTime.Now.Date, Value = 0, AfterOperation = 0, Description = string.Empty, TypeID = 0 });
			Data.UpdateData();
		}

		public void AddType()
		{
			Data.Types.Add(new RecordType { ID = Data.Types.Select(rt => rt.ID)?.Max() + 1 ?? 0, Description = string.Empty });
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
