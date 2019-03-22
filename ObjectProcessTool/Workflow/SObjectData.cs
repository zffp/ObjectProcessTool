using ObjectProcessTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Workflow
{
    /// <summary>
    /// 对象数据类型
    /// </summary>
    public class SObjectData : TaskData
    {
        public List<SObject> SObjectList { get; set; }

        public SObjectData()
        {
            SObjectList = new List<SObject>();
            DataType = DataType.SObject;
        }
    }
}
