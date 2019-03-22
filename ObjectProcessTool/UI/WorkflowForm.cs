using GeoAPI.Geometries;
using ObjectProcessTool.Event;
using ObjectProcessTool.Layer;
using ObjectProcessTool.Model;
using ObjectProcessTool.Workflow;
using SharpMap;
using SharpMap.Layers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ObjectProcessTool.UI
{
    public partial class WorkflowForm : DockContent
    {
        public WorkflowForm()
        {
            InitializeComponent();
        }
        Map map;
        WorkflowLayer workflowLayer;

        WFTask selectTask;
        private void Workflow_Load(object sender, EventArgs e)
        {
            workflowLayer = new WorkflowLayer("workflowLayer");
            map = objectMapBox1.Map;
            map.Layers.Add(workflowLayer);

            map.ZoomToExtents();

            objectMapBox1.Refresh();

            //objectMapBox1.ActiveTool = MapControl.ObjectMapBox.Tools.Pan;

            objectMapBox1.Cursor = Cursors.Cross;

            objectMapBox1.MouseDown += ObjectMapBox1_MouseDown;
            objectMapBox1.MouseMove += ObjectMapBox1_MouseMove;
            objectMapBox1.MouseUp += ObjectMapBox1_MouseUp;

            initEvent();
        }
        private void initEvent()
        {
            EventManage.Instance.RegisterEvent(this, EventNameList.ADDTASK,
              new Action<ILayer>((layer) =>
              {
                  if (layer == null)
                  {
                      return;
                  }
                  workflowLayer.AddTask(new WFTask() { Name = layer.LayerName, Id = DateTime.Now.Ticks });

                  objectMapBox1.Refresh();
              }));
        }
        private Point _dragStartPoint;
        private Point _dragEndPoint;
        private Coordinate _dragStartCoord;
        private bool _dragTaskflag = false;

        private LineDecoration lineDecoration = null;
        private void ObjectMapBox1_MouseDown(Coordinate worldPos, MouseEventArgs imagePos)
        {
            _dragStartPoint = imagePos.Location;
            _dragEndPoint = imagePos.Location;
            _dragStartCoord = map.Center;
            if (selectTask != null && selectTask.Contain(imagePos.Location, map))
            {

                _dragTaskflag = true;
                _dragStartCoord = worldPos;
                if (imagePos.Button == MouseButtons.Right)
                {
                    lineDecoration = new LineDecoration() { Pt1 = imagePos.Location };
                    map.Decorations.Add(lineDecoration);
                }

            }
        }
        private void ObjectMapBox1_MouseMove(Coordinate worldPos, MouseEventArgs imagePos)
        {
            _dragEndPoint = imagePos.Location;


            if (_dragTaskflag)
            {
                if (imagePos.Button == MouseButtons.Right)
                {
                    //绘制连接关系
                    lineDecoration.Pt2 = imagePos.Location;
                    objectMapBox1.Invalidate();
                }
                else
                {
                    var offsetx = worldPos.X - _dragStartCoord.X;
                    var offsety = worldPos.Y - _dragStartCoord.Y;

                    selectTask.Y += (int)offsety;
                    selectTask.X += (int)offsetx;

                    objectMapBox1.Invalidate();

                    _dragStartCoord = worldPos;
                }

            }
            else if (_dragStartCoord != null)
            {
                map.Center =
                    new Coordinate(_dragStartCoord.X - map.PixelSize * (_dragEndPoint.X - _dragStartPoint.X),
                                 _dragStartCoord.Y - map.PixelSize * (_dragStartPoint.Y - _dragEndPoint.Y));

                objectMapBox1.Invalidate();
            }
        }
        private void ObjectMapBox1_MouseUp(Coordinate worldPos, MouseEventArgs imagePos)
        {
            if (_dragStartPoint == imagePos.Location)
            {
                //点击
                map.Decorations.Clear();
                selectTask = null;
                selectTask = workflowLayer.Query(imagePos.Location, map);
                if (selectTask != null)
                {
                    map.Decorations.Add(selectTask);
                }
                propertyGrid1.SelectedObject = selectTask;
            }
            if (lineDecoration != null)
            {
                //查询是否选中对象
                WFTask fTask = workflowLayer.Query(imagePos.Location, map);
                if (fTask != selectTask)
                {
                    selectTask.AddNextTask(fTask);
                    fTask.AddPreTask(selectTask);
                }
                map.Decorations.Remove(lineDecoration);
                lineDecoration = null;
            }
            _dragStartCoord = null;
            _dragTaskflag = false;
            objectMapBox1.Refresh();
        }

        private void 添加处理节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Coordinate point = map.ImageToWorld(_dragStartPoint);

            workflowLayer.AddTask(new WFTask()
            {
                Name = "",
                Id = DateTime.Now.Ticks,
                X = (int)point.X,
                Y = (int)point.Y
            });

            objectMapBox1.Refresh();

        }

        private void 删除节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (selectTask != null && selectTask.Contain(_dragStartPoint, map))
            {
                workflowLayer.RemoveTask(selectTask);
                map.Decorations.Remove(selectTask);
                selectTask = null;
                objectMapBox1.Refresh();
            }
        }

        private void 添加SHP文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "shpfile(*.shp)|*.shp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                Coordinate point = map.ImageToWorld(_dragStartPoint);
                workflowLayer.AddTask(new WFTask(new ShpData(fileName))
                {
                    Id = DateTime.Now.Ticks,
                    X = (int)point.X,
                    Y = (int)point.Y
                });
            }
        }
    }
}
