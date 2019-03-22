using SharpMap;
using SharpMap.Rendering.Decoration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Workflow
{
    
    /// <summary>
    /// 批处理工作流
    /// </summary>
    public class WorkflowP
    {
        public List<WFTask> Tasks { get; set; }

        public WorkflowP()
        {
            Tasks = new List<WFTask>();
        }

        public void StartRun()
        {

        }
    }
}
