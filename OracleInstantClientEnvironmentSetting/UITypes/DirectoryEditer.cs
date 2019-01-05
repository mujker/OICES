// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DirectoryEditer.cs" company="DHC">
//   WillJiang
// </copyright>
// <summary>
//   The directory editer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OracleInstantClientEnvironmentSetting.UITypes
{
	using System;
	using System.ComponentModel;
	using System.Drawing.Design;
	using System.IO;
	using System.Windows.Forms;

	/// <summary>
	/// The directory editer.
	/// </summary>
	public class DirectoryEditer : UITypeEditor
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
			FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
			if (folderBrowser.ShowDialog() == DialogResult.OK)
			{
				var exists = Directory.Exists(folderBrowser.SelectedPath);
				if (exists)
				{
					value = folderBrowser.SelectedPath;
				}
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