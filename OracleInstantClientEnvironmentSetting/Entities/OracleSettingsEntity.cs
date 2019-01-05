// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OracleSettingsEntity.cs" company="DHC">
//   Oracle 环境变量实体类
// </copyright>
// <summary>
//   The oracle settings entity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable All
namespace OracleInstantClientEnvironmentSetting.Entities
{
	using System.ComponentModel;

	using OracleInstantClientEnvironmentSetting.UITypes;

	/// <summary>
	/// The oracle settings entity.
	/// </summary>
	public class OracleSettingsEntity
	{
		/// <summary>
		/// Gets or sets the nl s_ lang.
		/// </summary>
		[Category("全局设置"), Description("指定语言和字符集")]
		[TypeConverter(typeof(ComboxEditer))]
		public string NLS_LANG { get; set; }

		/// <summary>
		/// Gets or sets the oracl e_ home.
		/// </summary>
		[Category("全局设置"), Description("Oracle精简客户端目录")]
		[Editor(typeof(DirectoryEditer), typeof(System.Drawing.Design.UITypeEditor))]
		public string ORACLE_HOME { get; set; }

		/// <summary>
		/// Gets or sets the path.
		/// </summary>
		[Category("全局设置"), Description("配置开发或运行调用Oracle的程序时使用(仅使用pl/sql连接管理数据库，该变量也可不配置)")]
		[Editor(typeof(PathEditer), typeof(System.Drawing.Design.UITypeEditor))]
		public string Path { get; set; }

		/// <summary>
		/// Gets or sets the tn s_ admin.
		/// </summary>
		[Category("全局设置"), Description("指定路径为tnsnames.ora文件的位置")]
		[Editor(typeof(DirectoryEditer), typeof(System.Drawing.Design.UITypeEditor))]
		public string TNS_ADMIN { get; set; }
	}
}