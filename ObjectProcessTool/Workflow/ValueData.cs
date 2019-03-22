using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Workflow
{
    public class ValueData : TaskData
    {
        public object Value { get; set; }

        public ValueData(object value)
        {
            this.Value = value;

            DataType = DataType.Value;
        }
    }
}
