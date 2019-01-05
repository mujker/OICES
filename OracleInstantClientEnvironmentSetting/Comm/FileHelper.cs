using System;
using System.IO;
using System.Linq;
using System.Text;
using OracleInstantClientEnvironmentSetting.Entities;

namespace OracleInstantClientEnvironmentSetting.Comm
{
	public class FileHelper
	{
		public static void WriteXml(OracleSettingsEntity obj)
		{
			StringBuilder builder    = new StringBuilder();
			var           properties = obj.GetType().GetProperties();
			foreach (var property in properties)
			{
				builder.AppendLine($"{property.Name}={property.GetValue(obj)}");
			}

			string path = $@"{System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase}{DateTime.Now.ToFileTime()}.xml";
			File.WriteAllText(path, builder.ToString());
		}

		public static OracleSettingsEntity ReadXml(string url)
		{
			var                  text   = File.ReadAllLines(url);
			OracleSettingsEntity result = new OracleSettingsEntity();
			foreach (var row in text)
			{
				var setts = row.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries);
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
	}
}