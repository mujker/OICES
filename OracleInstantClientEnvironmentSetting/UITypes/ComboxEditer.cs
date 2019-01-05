using System.ComponentModel;

namespace OracleInstantClientEnvironmentSetting.UITypes
{
    public class ComboxEditer : StringConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[] { "SIMPLIFIED CHINESE_CHINA.ZHS16GBK", "AMERICAN_AMERICA.ZHS16GBK" });
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}