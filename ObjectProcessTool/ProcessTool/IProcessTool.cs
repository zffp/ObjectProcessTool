using ObjectProcessTool.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.ProcessTool
{
    /// <summary>
    /// 处理工具
    /// </summary>
    public interface IProcessTool
    {
        /// <summary>
        /// 处理工具名称
        /// </summary>
        string ProcessToolName { get; }

        /// <summary>
        /// 输出参数类型
        /// </summary>
        DataType OutDataType { get; }

        /// <summary>
        /// 工具参数定义
        /// </summary>
        List<ToolParameter> Parameters { get; }


        TaskData Execute(Dictionary<string, TaskData> InputData);
    }
}
