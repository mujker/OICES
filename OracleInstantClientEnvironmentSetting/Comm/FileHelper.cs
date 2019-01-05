// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileHelper.cs" company="DHC">
//   Will jiang
// </copyright>
// <summary>
//   The file helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OracleInstantClientEnvironmentSetting.Comm
{
	using System;
	using System.IO;
	using System.Text;

	using OracleInstantClientEnvironmentSetting.Entities;

	/// <summary>
	/// The file helper.
	/// </summary>
	public class FileHelper
	{
		/// <summary>
		/// The read xml.
		/// </summary>
		/// <param name="url">
		/// The url.
		/// </param>
		/// <returns>
		/// The <see cref="OracleSettingsEntity"/>.
		/// </returns>
		public static OracleSettingsEntity ReadXml(string url)
		{
			var                  text   = File.ReadAllLines(url);
			OracleSettingsEntity result = new OracleSettingsEntity();
			foreach (var row in text)
			{
				var setts = row.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
				if (setts.Length == 2)
				{
					var propertyInfo = result.GetType().GetProperty(setts[0]);
					if (propertyInfo != null)
					{
						propertyInfo.SetValue(result, setts[1]);
					}
				}
			}

			return result;
		}

		/// <summary>
		/// The write xml.
		/// </summary>
		/// <param name="obj">
		/// The obj.
		/// </param>
		public static void WriteXml(OracleSettingsEntity obj)
		{
			StringBuilder builder    = new StringBuilder();
			var           properties = obj.GetType().GetProperties();
			foreach (var property in properties)
			{
				builder.AppendLine($"{property.Name}={property.GetValue(obj)}");
			}

			var folderPath = $@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}backup\";
			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}

			string path = $@"{folderPath}{DateTime.Now.ToFileTime()}.xml";
			File.WriteAllText(path, builder.ToString());
		}
	}
}