using ObjectProcessTool.ProcessTool;
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
    /// 任务
    /// </summary>
    public class WFTask : IMapDecoration
    {
        public long Id { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 输入数据
        /// </summary>
        public Dictionary<string, TaskData> InputData { get; set; }
        /// <summary>
        /// 输出数据
        /// </summary>
        public TaskData OutputData { get; set; }

        /// <summary>
        /// 处理工具
        /// </summary>
        public IProcessTool ProcessTools { get; set; }

        /// <summary>
        /// 下一步任务
        /// </summary>
        public List<WFTask> NextTasks { get; set; }
        /// <summary>
        /// 上一步任务
        /// </summary>
        public List<WFTask> PreTasks { get; set; }


        public int X { get; set; }

        public int Y { get; set; }

        public WFTask()
        {
            this.InputData = new Dictionary<string, TaskData>();

            NextTasks = new List<WFTask>();
            PreTasks = new List<WFTask>();

            X = 1000;
            Y = 1000;
        }
        public WFTask(TaskData inputData) : this()
        {
            if (inputData.DataType == DataType.Shp)
            {
                ShpData shpData = inputData as ShpData;
                Name = Path.GetFileName(shpData.ShpFileName);
                this.InputData.Add("fileName", inputData);
            }
        }

        public void AddNextTask(WFTask task)
        {
            if (!NextTasks.Contains(task))
            {
                NextTasks.Add(task);
            }
        }
        public void AddPreTask(WFTask task)
        {
            if (!PreTasks.Contains(task))
            {
                PreTasks.Add(task);
            }
        }

        #region render
        static protected Font font = new Font("宋体", 9);
        static Pen pen = null;
        public void RenderTask(Graphics g, Map map)
        {
            PointF pt = map.WorldToImage(new GeoAPI.Geometries.Coordinate(X, Y));
            Rectangle rectangle = new Rectangle((int)pt.X - 80, (int)pt.Y - 30, 160, 60);
            g.FillRectangle(Brushes.Yellow, rectangle);
            g.DrawRectangle(Pens.Red, rectangle);

            SizeF sizeF = g.MeasureString(Name, font);
            g.DrawString(Name, font, Brushes.Red, pt.X - sizeF.Width / 2, pt.Y - sizeF.Height / 2);


        }

        public void RenderLine(Graphics g, Map map)
        {
            //绘制连接线
            if (pen == null)
            {
                pen = new Pen(Color.Red, 3);
                // pen.StartCap = LineCap.Round;
                // pen.EndCap = LineCap.ArrowAnchor;

                // Set the DashCap to round.
                pen.DashCap = DashCap.Triangle;

                // Create a custom dash pattern.
                pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
            }

            PointF pt = map.WorldToImage(new GeoAPI.Geometries.Coordinate(X, Y));
            foreach (WFTask task in NextTasks)
            {
                PointF pt1 = map.WorldToImage(new GeoAPI.Geometries.Coordinate(task.X, task.Y));

                g.DrawLine(pen, pt, pt1);
            }
        }

        public bool Contain(Point imagePt, Map map)
        {
            PointF pt = map.WorldToImage(new GeoAPI.Geometries.Coordinate(X, Y));
            Rectangle rectangle = new Rectangle((int)pt.X - 80, (int)pt.Y - 30, 160, 60);

            return rectangle.Contains(imagePt);
        }

        public void Render(Graphics g, Map map)
        {
            PointF pt = map.WorldToImage(new GeoAPI.Geometries.Coordinate(X, Y));
            Rectangle rectangle = new Rectangle((int)pt.X - 80, (int)pt.Y - 30, 160, 60);
            g.FillRectangle(Brushes.GreenYellow, rectangle);
            g.DrawRectangle(Pens.Honeydew, rectangle);


            SizeF sizeF = g.MeasureString(Name, font);
            g.DrawString(Name, font, Brushes.Red, pt.X - sizeF.Width / 2, pt.Y - sizeF.Height / 2);
        }

        #endregion
    }
}
