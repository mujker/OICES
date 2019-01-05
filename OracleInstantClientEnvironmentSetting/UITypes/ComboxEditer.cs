// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComboxEditer.cs" company="DHC">
//   自定义下拉框
// </copyright>
// <summary>
//   The combox editer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OracleInstantClientEnvironmentSetting.UITypes
{
	using System.ComponentModel;

	/// <summary>
	/// The combox editer.
	/// </summary>
	public class ComboxEditer : StringConverter
	{
		/// <summary>
		/// The get standard values.
		/// </summary>
		/// <param name="context">
		/// The context.
		/// </param>
		/// <returns>
		/// The <see cref="StandardValuesCollection"/>.
		/// </returns>
		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(new string[] { "SIMPLIFIED CHINESE_CHINA.ZHS16GBK", "AMERICAN_AMERICA.ZHS16GBK" });
		}

		/// <summary>
		/// The get standard values exclusive.
		/// </summary>
		/// <param name="context">
		/// The context.
		/// </param>
		/// <returns>
		/// The <see cref="bool"/>.
		/// </returns>
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return true;
		}

		/// <summary>
		/// The get standard values supported.
		/// </summary>
		/// <param name="context">
		/// The context.
		/// </param>
		/// <returns>
		/// The <see cref="bool"/>.
		/// </returns>
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}
	}
}