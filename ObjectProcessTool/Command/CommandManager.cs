using ObjectProcessTool.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectProcessTool.Command
{
    class CommandManager : Singleton<CommandManager>
    {
        public List<ICommand> Commands { get; }

        public CommandManager()
        {
            Commands = new List<ICommand>();
        }

        public void RelationCommand(ToolStripItem toolStripItem, ICommand command)
        {
            Commands.Add(command);

            toolStripItem.Click += command.Execute;
        }
    }
}
