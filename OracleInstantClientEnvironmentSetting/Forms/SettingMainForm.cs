using System;
using System.IO;
using System.Windows.Forms;
using OracleInstantClientEnvironmentSetting.Comm;
using OracleInstantClientEnvironmentSetting.Entities;

namespace OracleInstantClientEnvironmentSetting.Forms
{
	public partial class SettingMainForm : Form
	{
		OracleSettingsEntity orclSet = new OracleSettingsEntity();

		public SettingMainForm()
		{
			InitializeComponent();
			tsmi_rest_Click(null, null);
		}

		private void ReadOrclSettings()
		{
			orclSet.ORACLE_HOME = Environment.GetEnvironmentVariable("ORACLE_HOME", EnvironmentVariableTarget.Machine);
			orclSet.NLS_LANG    = Environment.GetEnvironmentVariable("NLS_LANG",    EnvironmentVariableTarget.Machine);
			orclSet.TNS_ADMIN   = Environment.GetEnvironmentVariable("TNS_ADMIN",   EnvironmentVariableTarget.Machine);
			orclSet.Path        = Environment.GetEnvironmentVariable("Path",        EnvironmentVariableTarget.Machine);
			SetPropertyGridSelObj();
			FileHelper.WriteXml(orclSet);
		}

		private void SetPropertyGridSelObj()
		{
			propertyGrid1.SelectedObject = orclSet;
		}

		private void WriteOrclSettings()
		{
			Environment.SetEnvironmentVariable("ORACLE_HOME", orclSet.ORACLE_HOME, EnvironmentVariableTarget.Machine);
			Environment.SetEnvironmentVariable("NLS_LANG",    orclSet.NLS_LANG,    EnvironmentVariableTarget.Machine);
			Environment.SetEnvironmentVariable("TNS_ADMIN",   orclSet.TNS_ADMIN,   EnvironmentVariableTarget.Machine);
			Environment.SetEnvironmentVariable("Path",        orclSet.Path,        EnvironmentVariableTarget.Machine);
		}

		/// <summary>
		/// 保存设置
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tsmi_save_Click(object sender, EventArgs e)
		{
			try
			{
				WriteOrclSettings();
				UpdateStatus("环境变量修改完成！");
			}
			catch (Exception exception)
			{
				UpdateStatus(exception.Message);
			}
		}

		/// <summary>
		/// 重新读取系统配置
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tsmi_rest_Click(object sender, EventArgs e)
		{
			try
			{
				ReadOrclSettings();
				UpdateStatus("环境变量读取成功！");
			}
			catch (Exception exception)
			{
				UpdateStatus(exception.Message);
			}
		}

		private void tsmi_resetfromfile_Click(object sender, EventArgs e)
		{
			try
			{
				FileDialog dialog = new OpenFileDialog();
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					if (File.Exists(dialog.FileName))
					{
						orclSet = FileHelper.ReadXml(dialog.FileName);
						SetPropertyGridSelObj();
						UpdateStatus("文件数据已恢复……");
					}
				}
			}
			catch (Exception exception)
			{
				UpdateStatus(exception.Message);
			}
		}

		private void UpdateStatus(string msg)
		{
			toolstrip_status.Text = msg;
		}
	}
}