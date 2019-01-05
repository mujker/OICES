// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormPathEdit.cs" company="DHC">
//   修改 环境变量 Path 窗体
// </copyright>
// <summary>
//   The form path edit.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OracleInstantClientEnvironmentSetting.Forms
{
	using System;
	using System.IO;
	using System.Text;
	using System.Windows.Forms;

	/// <summary>
	///     The form path edit.
	/// </summary>
	public partial class FormPathEdit : Form
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="FormPathEdit" /> class.
		/// </summary>
		public FormPathEdit()
		{
			this.InitializeComponent();
		}

		/// <summary>
		///     Gets or sets the env path.
		/// </summary>
		public string EnvPath { get; set; }

		/// <summary>
		/// The form path edit_ load.
		/// </summary>
		/// <param name="sender">
		/// The sender.
		/// </param>
		/// <param name="e">
		/// The e.
		/// </param>
		private void FormPathEditLoad(object sender, EventArgs e)
		{
			this.tb_path.Text = string.Empty;
			var pathStrings = this.EnvPath.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
			this.tb_path.Lines = pathStrings;
			this.tb_path.Select(this.tb_path.Text.Length, 0);
		}

		/// <summary>
		/// The tsmi_save_ click.
		/// </summary>
		/// <param name="sender">
		/// The sender.
		/// </param>
		/// <param name="e">
		/// The e.
		/// </param>
		private void TsmiSaveClick(object sender, EventArgs e)
		{
			StringBuilder envPahtBuilder = new StringBuilder();
			foreach (string line in this.tb_path.Lines)
			{
				if (string.IsNullOrWhiteSpace(line))
				{
					continue;
				}

				Retry:
				if (Directory.Exists(line))
				{
					envPahtBuilder.Append($@"{line};");
					continue;
				}
				else
				{
					var result = MessageBox.Show(
						$@"※无效路径※{Environment.NewLine}{line}",
						@"路径异常提示",
						MessageBoxButtons.AbortRetryIgnore,
						MessageBoxIcon.Warning,
						MessageBoxDefaultButton.Button1);
					switch (result)
					{
						case DialogResult.Abort:
							return;
						case DialogResult.Ignore:
							continue;
						case DialogResult.Retry:
							goto Retry;
					}
				}
			}

			this.EnvPath = envPahtBuilder.ToString();

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}