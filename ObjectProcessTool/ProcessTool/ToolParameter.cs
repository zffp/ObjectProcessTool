using ObjectProcessTool.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.ProcessTool
{
    /// <summary>
    /// 工具的参数定义
    /// </summary>
    public class ToolParameter
    {
        public string Name { get; set; }
        public DataType DataType { get; set; }

        public ToolParameter(string name,DataType dataType)
        {
            this.Name = name;
            this.DataType = dataType;
        }
    }
}
