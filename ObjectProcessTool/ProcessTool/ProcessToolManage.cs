using ObjectProcessTool.Util;
using ObjectProcessTool.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.ProcessTool
{

    public class TestProcessTool : IProcessTool
    {
        public string ProcessToolName => "TestProcessTool";

        public List<ToolParameter> Parameters
        {
            get
            {
                List<ToolParameter> result = new List<ToolParameter>();
                result.Add(new ToolParameter("shpfile", DataType.Shp));
                return result;
            }
        }

        public DataType OutDataType => DataType.SObject;

        public TaskData Execute(Dictionary<string, TaskData> InputData)
        {
            return new SObjectData() { DataType = DataType.SObject };
        }
    }

    class ProcessToolManage : Singleton<ProcessToolManage>
    {
        public List<IProcessTool> ProcessToolList { get; set; }

        public ProcessToolManage()
        {
            ProcessToolList = new List<IProcessTool>();
            ProcessToolList.Add(new TestProcessTool());
        }
    }
}
