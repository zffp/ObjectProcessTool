using ObjectProcessTool.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectProcessTool.Command
{
    /// <summary>
    /// 添加属性
    /// </summary>
    class AddAttrCommand : ICommand
    {
        public string Name => "AddAttr";

        public void Execute(object sender, EventArgs e)
        {
            AddAttrForm addAttrForm = new AddAttrForm();
            if (addAttrForm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
