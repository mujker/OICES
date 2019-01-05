// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PathEditer.cs" company="">
//   自定义Path
// </copyright>
// <summary>
//   The path editer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OracleInstantClientEnvironmentSetting.UITypes
{
	using System;
	using System.ComponentModel;
	using System.Drawing.Design;
	using System.Windows.Forms;

	using OracleInstantClientEnvironmentSetting.Forms;

	/// <summary>
	/// The path editer.
	/// </summary>
	public class PathEditer : UITypeEditor
	{
		/// <summary>
		/// The edit value.
		/// </summary>
		/// <param name="context">
		/// The context.
		/// </param>
		/// <param name="provider">
		/// The provider.
		/// </param>
		/// <param name="value">
		/// The value.
		/// </param>
		/// <returns>
		/// The <see cref="object"/>.
		/// </returns>
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			FormPathEdit pathEdit = new FormPathEdit();
			pathEdit.EnvPath = value?.ToString();
			if (pathEdit.ShowDialog() == DialogResult.OK)
			{
				value = pathEdit.EnvPath;
			}

			return base.EditValue(context, provider, value);
		}

		/// <summary>
		/// The get edit style.
		/// </summary>
		/// <param name="context">
		/// The context.
		/// </param>
		/// <returns>
		/// The <see cref="UITypeEditorEditStyle"/>.
		/// </returns>
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}
	}
}