﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Provider;
using Android.Content;
using Android.Database;
using System.IO;
using System.Text;
using Plugin.Settings;
using System;
using Android.Text.Format;
using System.Globalization;
using Android.Icu.Text;

namespace BlackAccountingMobileAssistant
{
	[Activity(Label = "BlackAccounting Mobile Assistant", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			Button btnLoad = FindViewById<Button>(Resource.Id.loadButton);
			EditText etBankName = FindViewById<EditText>(Resource.Id.bankNameEditText);
			EditText etTargetFolder = FindViewById<EditText>(Resource.Id.targetFolderEditText);
			EditText etFileName = FindViewById<EditText>(Resource.Id.fileNameEditText);

			etBankName.Text = CrossSettings.Current.GetValueOrDefault("BankName", "SDM-BANK");
			etTargetFolder.Text = CrossSettings.Current.GetValueOrDefault("TargetFolder", Android.OS.Environment.ExternalStorageDirectory.Path);
			etFileName.Text = CrossSettings.Current.GetValueOrDefault("FileName", "blackAccounting.txt");

			btnLoad.Click += (s, e) =>
			{
				LoadSms(etBankName.Text, Path.Combine(etTargetFolder.Text, etFileName.Text));
			};
		}

		protected override void OnDestroy()
		{
			EditText etBankName = FindViewById<EditText>(Resource.Id.bankNameEditText);
			EditText etTargetFolder = FindViewById<EditText>(Resource.Id.targetFolderEditText);
			EditText etFileName = FindViewById<EditText>(Resource.Id.fileNameEditText);

			CrossSettings.Current.AddOrUpdateValue("BankName", etBankName.Text);
			CrossSettings.Current.AddOrUpdateValue("TargetFolder", etTargetFolder.Text);
			CrossSettings.Current.AddOrUpdateValue("FileName", etFileName.Text);

			base.OnDestroy();
		}

		public void LoadSms(string bankName, string filePath)
		{
			int totalSMSLoaded = 0;

			using (FileStream fs = new FileStream(filePath, FileMode.Create))
			using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
			using (ICursor c = ContentResolver.Query(Telephony.Sms.Inbox.ContentUri, null, null, null, Telephony.Sms.Inbox.DefaultSortOrder))
			{
				while (c.MoveToNext())
				{
					long ms = c.GetLong(c.GetColumnIndexOrThrow("date"));
					DateTime smsDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(ms).ToLocalTime();

					if (c.GetString(c.GetColumnIndexOrThrow("address")) == bankName)
					{
						sw.WriteLine($"{smsDate.ToString(CultureInfo.InvariantCulture)}|{c.GetString(c.GetColumnIndexOrThrow("body"))}");
						totalSMSLoaded++;
					}
				}
			}

			new AlertDialog.Builder(this).
				SetMessage(totalSMSLoaded > 0 ? $"{totalSMSLoaded} сообщений выгружено" : "Сообщений нет").
				SetNeutralButton("Ок", (s, e) => { }).
				SetCancelable(false).
				Show();
		}
	}
}
