using System;
using System.Windows.Forms;

namespace OracleInstantClientEnvironmentSetting.Forms
{
	public partial class FormPathEdit : Form
	{
		public string EnvPath { get; set; }

		public FormPathEdit()
		{
			InitializeComponent();
		}

		private void FormPathEdit_Load(object sender, EventArgs e)
		{
			tb_path.Text = string.Empty;
			var pathStrings = EnvPath.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
			tb_path.Lines = pathStrings;
			tb_path.Select(tb_path.Text.Length, 0);
		}

		private void tsmi_save_Click(object sender, EventArgs e)
		{
			foreach (string line in tb_path.Lines)
			{
				if (string.IsNullOrWhiteSpace(line))
				{
					continue;
				}

				EnvPath += $@"{line};";
			}

			DialogResult = DialogResult.OK;
			Close();
		}
	}
}