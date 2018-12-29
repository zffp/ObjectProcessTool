using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeoAPI.Geometries;
using ObjectProcessTool.Bil;
using ObjectProcessTool.Layer;
using ObjectProcessTool.MapControl;
using ObjectProcessTool.Model;
using ObjectProcessTool.UI;
using ObjectProcessTool.Util;
using SharpMap;
using SharpMap.Data;
using SharpMap.Layers;

namespace ObjectProcessTool.Tool
{
    /// <summary>
    /// 查询工具
    /// </summary>
    class QueryTool : AbstractTool
    {
        public override string Name => "QueryTool";

        private Point downPoint;

        public override Cursor Cursor => Cursors.Cross;

        public override void MouseDown(Coordinate worldPos, MouseEventArgs imagePos)
        {
            downPoint = imagePos.Location;
        }

        public override void MouseMove(Coordinate worldPos, MouseEventArgs imagePos)
        {
            base.MouseMove(worldPos, imagePos);
        }

        public override void MouseUp(Coordinate worldPos, MouseEventArgs imagePos)
        {
            Map map = GlobalContainer.GetInstance<Map>("Map");
            

            Point upPoint = imagePos.Location;
            if (downPoint == upPoint)
            {
                int x = imagePos.X;
                int y = imagePos.Y;
                var pt1 = map.ImageToWorld(new PointF(x - 5, y - 5));
                var pt2 = map.ImageToWorld(new PointF(x + 5, y + 5));
                var envelope = new Envelope(pt1, pt2);

               
                Entity entity = null;
                //点击查询
                foreach (ICanQueryLayer layer in map.Layers.Where(l => l.Enabled && l is ICanQueryLayer))
                {
                    if (layer is SObjectLayer)
                    {
                        SObjectLayer sObjectLayer = layer as SObjectLayer;
                        entity = sObjectLayer.Query(x, y);
                        if (entity != null)
                        {
                            break;
                        }
                       
                    }
                    else
                    {
                        FeatureDataSet featureDataSet = new FeatureDataSet();
                        layer.ExecuteIntersectionQuery(envelope, featureDataSet);
                        if (featureDataSet.Tables.Count > 0)
                        {
                            if (featureDataSet.Tables[0].Rows.Count > 0)
                            {
                                FeatureDataRow featureDataRow = featureDataSet.Tables[0].Rows[0] as FeatureDataRow;
                                if (featureDataRow != null)
                                {
                                    entity = new Entity(featureDataRow);

                                    break;
                                }
                            }
                        }
                    }
                }

                QueryManager.Instance.SetSelectEntity(entity);
               
            }
        }
    }
}
