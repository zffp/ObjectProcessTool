using ObjectProcessTool.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Command
{
    /// <summary>
    /// 显示隐藏注记
    /// </summary>
    class ShowHideSobjectTextCommand : ICommand
    {
        public string Name => "ShowHideSobjectText";

        public void Execute(object sender, EventArgs e)
        {
            SObjectLayer.ShowText = !SObjectLayer.ShowText;
        }
    }
}
