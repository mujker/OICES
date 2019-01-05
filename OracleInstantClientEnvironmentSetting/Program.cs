// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="DHC">
//   程序入口
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OracleInstantClientEnvironmentSetting
{
	using System;
	using System.Windows.Forms;

	using OracleInstantClientEnvironmentSetting.Forms;

	/// <summary>
	/// The program.
	/// </summary>
	public static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new SettingMainForm());
		}
	}
}