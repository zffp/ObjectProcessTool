using GeoAPI.Geometries;
using ObjectProcessTool.Model;
using ObjectProcessTool.Workflow;
using SharpMap;
using SharpMap.Layers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Layer
{
    class WorkflowLayer : ILayer
    {

        public double MinVisible { get; set; }
        public double MaxVisible { get; set; }
        public bool Enabled { get; set; }
        public string LayerName { get; set; }
        public string LayerTitle { get; set; }

        public Envelope Envelope => new Envelope(0, 2000, 0, 2000);

        public int SRID { get; set; }

        public int TargetSRID => 0;

        public string Proj4Projection { get; set; }


        WorkflowP workflow = new WorkflowP();

        public WorkflowLayer(string layerName)
        {
            this.LayerName = layerName;
            MaxVisible = double.MaxValue;
            Enabled = true;

            workflow.Tasks.Add(new WFTask());
        }
        public void AddTask(WFTask task)
        {
            workflow.Tasks.Add(task);
        }
        /// <summary>
        /// 移除任务
        /// </summary>
        /// <param name="task"></param>
        public void RemoveTask(WFTask task)
        {
            workflow.Tasks.Remove(task);

            foreach (WFTask fTask in workflow.Tasks)
            {
                fTask.NextTasks.Remove(task);
                fTask.PreTasks.Remove(task);
            }
        }
        public void Render(Graphics g, Map map)
        {

            foreach (WFTask task in workflow.Tasks)
            {
                task.RenderLine(g, map);
            }

            foreach (WFTask task in workflow.Tasks)
            {
                task.RenderTask(g, map);
            }
        }

        public WFTask Query(Point pt, Map map)
        {
            foreach (WFTask task in workflow.Tasks)
            {
                if (task.Contain(pt, map))
                {
                    return task;
                }
            }
            return null;
        }

    }
}
