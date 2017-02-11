using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
	}
}
