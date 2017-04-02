using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace BlackAccounting
{
	public partial class EnterForm : Form
	{
		public static IList<Record> Values = new List<Record>();

		public EnterForm()
		{
			InitializeComponent();

			Values.Clear();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			string[] lines = txtEnter.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

			Values.Clear();
			lbErrors.Items.Clear();
			foreach (var item in lines.Select((x, i) => new { Value = x, Index = i }))
			{
				try
				{
					Values.Add(TextParser.Parse(item.Value));
				}
				catch (FormatException ex)
				{
					lbErrors.Items.Add($"Строка {item.Index}\t\t{ex.Message}");
				}
			}

			if (lbErrors.Items.Count == 0)
				DialogResult = DialogResult.OK;
		}

		private void btnAddFromFile_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Multiselect = false;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
					using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
					{
						while (sr.EndOfStream == false)
						{
							string line = sr.ReadLine();

							if (string.IsNullOrWhiteSpace(line)) continue;

							string[] lineSplit;
							string value, description, afterOperation;
							DateTime date;

							switch (line[20])
							{
								case 'P':
									lineSplit = line.Split(new[] { "|Pokupka na summu ", " RUR Karta: ", " Akod: ", ". Dostupno po karte ", " RUR. SDM-BANK +7(495)7059090." }, StringSplitOptions.RemoveEmptyEntries);
									if (lineSplit.Length != 5)
									{
										txtEnter.Text += line + Environment.NewLine;
										continue;
									}
									value = lineSplit[1].Replace(" ", "");
									description = lineSplit[3];
									date = DateTime.Parse(lineSplit[0], CultureInfo.InvariantCulture);
									afterOperation = lineSplit[4].Replace(" ", "");
									line = $"{date}\t-{value}\t{description}\t{afterOperation}";
									txtEnter.Text += line + Environment.NewLine;
									break;
								case 'N':
									lineSplit = line.Split(new[] { "|Na Vash schet ", " postupilo ", " RUB.  Dostupno po karte ", " RUR. SDM-BANK +7495 7059090" }, StringSplitOptions.RemoveEmptyEntries);
									if (lineSplit.Length != 4)
									{
										txtEnter.Text += line + Environment.NewLine;
										continue;
									}
									value = lineSplit[2].Replace(",", "");
									description = lineSplit[1];
									date = DateTime.Parse(lineSplit[0], CultureInfo.InvariantCulture);
									afterOperation = lineSplit[3].Replace(" ", "");
									line = $"{date}\t{value}\t{description}\t{afterOperation}";
									txtEnter.Text += line + Environment.NewLine;
									break;
								case 'V':
									lineSplit = line.Split(new[] { "|Vydano ", " RUR Karta: ", " Akod: ", ". Dostupno po karte ", " RUR. SDM-BANK +7(495)7059090." }, StringSplitOptions.RemoveEmptyEntries);
									if (lineSplit.Length != 5)
									{
										txtEnter.Text += line + Environment.NewLine;
										continue;
									}
									value = lineSplit[1].Replace(" ", "");
									description = lineSplit[3];
									date = DateTime.Parse(lineSplit[0], CultureInfo.InvariantCulture);
									afterOperation = lineSplit[4].Replace(" ", "");
									line = $"{date}\t-{value}\t{description}\t{afterOperation}";
									txtEnter.Text += line + Environment.NewLine;
									break;
								default: continue;
							}
						}
					}
				}
			}
		}
	}
}
