using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Command
{
    interface ICommand
    {
        string Name { get; }
        void Execute(object sender, EventArgs e);
    }
}
