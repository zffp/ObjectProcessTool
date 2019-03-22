using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Workflow
{
    /// <summary>
    /// shp数据类型
    /// </summary>
    public class ShpData : TaskData
    {
        public string ShpFileName { get; set; }

        public ShpData(string fileName)
        {
            this.ShpFileName = fileName;
            DataType = DataType.Shp;
        }
    }
}
