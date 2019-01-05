using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using OracleInstantClientEnvironmentSetting.Forms;

namespace OracleInstantClientEnvironmentSetting.UITypes
{
    public class PathEditer : UITypeEditor
    {
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

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }
}