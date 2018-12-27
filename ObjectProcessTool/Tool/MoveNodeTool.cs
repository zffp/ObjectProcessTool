using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeoAPI.Geometries;
using ObjectProcessTool.Event;
using ObjectProcessTool.Layer;
using ObjectProcessTool.MapControl;
using ObjectProcessTool.Model;
using ObjectProcessTool.UI;
using ObjectProcessTool.Util;
using SharpMap;

namespace ObjectProcessTool.Tool
{
    /// <summary>
    /// 移动节点工具
    /// </summary>
    public class MoveNodeTool : AbstractTool
    {
        public override string Name => "MoveNode";
        public override Cursor Cursor
        {
            get { return Cursors.Cross; }
        }
        Map map;
        ObjectMapBox mapBox;
        public MoveNodeTool()
        {
            map = GlobalContainer.GetInstance<Map>("Map");
            mapBox = GlobalContainer.GetInstance<ObjectMapBox>("MapBox");
        }

        bool dragModelFlag = false;
        Coordinate preCoordinate;
        Point downPoint;
        Entity selectEntity = null;
        public override void MouseDown(Coordinate worldPos, MouseEventArgs imagePos)
        {
            downPoint = imagePos.Location;

            if (selectEntity != null && selectEntity is Node)
            {
                Node node = selectEntity as Node;
                var pt1 = map.ImageToWorld(new PointF(downPoint.X - 5, downPoint.Y - 5));
                var pt2 = map.ImageToWorld(new PointF(downPoint.X + 5, downPoint.Y + 5));
                var envelope = new Envelope(pt1, pt2);

                if (envelope.Contains(node.Lon, node.Lat))
                {
                    dragModelFlag = true;
                }
            }
            else
            {
                EventManage.Instance.FireEvent(EventNameList.START_DRAGMAP, worldPos, imagePos, mapBox);
            }
        }
        public override void MouseMove(Coordinate worldPos, MouseEventArgs imagePos)
        {
            if (dragModelFlag)
            {
                var offsetx = worldPos.X - preCoordinate.X;
                var offsety = worldPos.Y - preCoordinate.Y;
                Node node = selectEntity as Node;

                node.Lat += offsety;
                node.Lon += offsetx;

                mapBox.Invalidate();
            }
            else
            {
                EventManage.Instance.FireEvent(EventNameList.DRAGMAP, worldPos, imagePos, mapBox);
            }
            preCoordinate = worldPos;
        }
        public override void MouseUp(Coordinate worldPos, MouseEventArgs imagePos)
        {
            Point upPoint = imagePos.Location;
            if (dragModelFlag)
            {
                selectEntity.Graph.MoveNode(selectEntity as Node);

                mapBox.Refresh();
            }
            else if (downPoint == upPoint)
            {
                selectEntity = null;
                map.Decorations.Clear();
                selectEntity = QueryNode(upPoint.X, upPoint.Y);

                PropertyUserControl propertyUserControl = GlobalContainer.GetInstance<PropertyUserControl>("PropertyUserControl");
                propertyUserControl.SetFeatureData(selectEntity);

                if (selectEntity != null)
                {
                    map.Decorations.Add(selectEntity);
                }
                mapBox.Refresh();
            }
            dragModelFlag = false;
            EventManage.Instance.FireEvent(EventNameList.END_DARGMAP, worldPos, imagePos, mapBox, true);

        }

        private Entity QueryNode(int x, int y)
        {
            map = GlobalContainer.GetInstance<Map>("Map");
            foreach (SObjectLayer layer in map.Layers.Where(l => l.Enabled && l is SObjectLayer))
            {
                SObjectLayer sObjectLayer = layer as SObjectLayer;
                Entity entity = sObjectLayer.Query(x, y);
                if (entity != null)
                {
                    return entity;
                }
            }
            return null;
        }
    }
}
