// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingMainForm.cs" company="DHC">
//   Oracle精简客户端设置工具-主窗体
// </copyright>
// <summary>
//   Defines the SettingMainForm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OracleInstantClientEnvironmentSetting.Forms
{
	using System;
	using System.IO;
	using System.Windows.Forms;

	using OracleInstantClientEnvironmentSetting.Comm;
	using OracleInstantClientEnvironmentSetting.Entities;

	/// <summary>
	/// The setting main form.
	/// </summary>
	public partial class SettingMainForm : Form
	{
		/// <summary>
		/// Oracle环境变量对象
		/// </summary>
		private OracleSettingsEntity orclSet = new OracleSettingsEntity();

		/// <summary>
		/// Initializes a new instance of the <see cref="SettingMainForm"/> class.
		/// </summary>
		public SettingMainForm()
		{
			this.InitializeComponent();
			this.TsmiRestClick(null, null);
		}

		/// <summary>
		/// 读取系统环境变量
		/// </summary>
		private void ReadOrclSettings()
		{
			this.orclSet.ORACLE_HOME = Environment.GetEnvironmentVariable("ORACLE_HOME", EnvironmentVariableTarget.Machine);
			this.orclSet.NLS_LANG    = Environment.GetEnvironmentVariable("NLS_LANG",    EnvironmentVariableTarget.Machine);
			this.orclSet.TNS_ADMIN   = Environment.GetEnvironmentVariable("TNS_ADMIN",   EnvironmentVariableTarget.Machine);
			this.orclSet.Path        = Environment.GetEnvironmentVariable("Path",        EnvironmentVariableTarget.Machine);
			this.SetPropertyGridSelObj();
			FileHelper.WriteXml(this.orclSet);
		}

		/// <summary>
		/// The set property grid sel obj.
		/// </summary>
		private void SetPropertyGridSelObj()
		{
			this.propertyGrid1.SelectedObject = this.orclSet;
		}

		/// <summary>
		/// The tsmi resetfromfile click.
		/// </summary>
		/// <param name="sender">
		/// The sender.
		/// </param>
		/// <param name="e">
		/// The e.
		/// </param>
		private void TsmiResetfromfileClick(object sender, EventArgs e)
		{
			try
			{
				FileDialog dialog = new OpenFileDialog();
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					if (File.Exists(dialog.FileName))
					{
						this.orclSet = FileHelper.ReadXml(dialog.FileName);
						this.SetPropertyGridSelObj();
						this.UpdateStatus("文件数据已恢复……");
					}
				}
			}
			catch (Exception exception)
			{
				this.UpdateStatus(exception.Message);
			}
		}

		/// <summary>
		/// The tsmi rest click.
		/// </summary>
		/// <param name="sender">
		/// The sender.
		/// </param>
		/// <param name="e">
		/// The e.
		/// </param>
		private void TsmiRestClick(object sender, EventArgs e)
		{
			try
			{
				this.ReadOrclSettings();
				this.UpdateStatus("环境变量读取成功！");
			}
			catch (Exception exception)
			{
				this.UpdateStatus(exception.Message);
			}
		}

		/// <summary>
		/// The tsmi save click.
		/// </summary>
		/// <param name="sender">
		/// The sender.
		/// </param>
		/// <param name="e">
		/// The e.
		/// </param>
		private void TsmiSaveClick(object sender, EventArgs e)
		{
			try
			{
				this.WriteOrclSettings();
				this.UpdateStatus("环境变量修改完成！");
			}
			catch (Exception exception)
			{
				this.UpdateStatus(exception.Message);
			}
		}

		/// <summary>
		/// 更新状态栏
		/// </summary>
		/// <param name="msg">
		/// The msg.
		/// </param>
		private void UpdateStatus(string msg)
		{
			this.toolstrip_status.Text = msg;
		}

		/// <summary>
		/// 写入环境变量
		/// </summary>
		private void WriteOrclSettings()
		{
			Environment.SetEnvironmentVariable("ORACLE_HOME", this.orclSet.ORACLE_HOME, EnvironmentVariableTarget.Machine);
			Environment.SetEnvironmentVariable("NLS_LANG",    this.orclSet.NLS_LANG,    EnvironmentVariableTarget.Machine);
			Environment.SetEnvironmentVariable("TNS_ADMIN",   this.orclSet.TNS_ADMIN,   EnvironmentVariableTarget.Machine);
			Environment.SetEnvironmentVariable("Path",        this.orclSet.Path,        EnvironmentVariableTarget.Machine);
		}
	}
}