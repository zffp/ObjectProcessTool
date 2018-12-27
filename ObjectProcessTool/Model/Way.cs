using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoAPI.Geometries;
using NetTopologySuite.Algorithm;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using ObjectProcessTool.Layer;
using SharpMap;

namespace ObjectProcessTool.Model
{
    public class Way : Entity
    {

        [JsonProperty("nodes")]
        public List<Node> Nodes { get; set; }
        public Way(long id) : base(id, "Way")
        {
            Nodes = new List<Node>();
            this.type = "Way";
        }
        private static Brush outpolygonBrush = new SolidBrush(Color.FromArgb(100, 50, 205, 50));

        static protected Pen linePen = new Pen(Color.BurlyWood, 2);

        static protected Pen SelectlinePen = new Pen(Color.Red, 3);

        static protected Font font = new Font("宋体", 9);

        public override void RenderEntity(Graphics g, Map map)
        {
            List<PointF> ptList = new List<PointF>();
            foreach (var coord in Nodes)
            {
                var pt = map.WorldToImage(new Coordinate(coord.Lon, coord.Lat));
                ptList.Add(pt);
            }

            bool isArea = Convert.ToBoolean(GetTagValue("area", false));

            if (isArea)
            {
                //绘制面
                g.FillPolygon(outpolygonBrush, ptList.ToArray());
                g.DrawLines(linePen, ptList.ToArray());
                if (SObjectLayer.ShowText)
                {
                    //显示注记

                    if (SObject != null && !string.IsNullOrEmpty(SObject.name))
                    {
                        IPoint point = Geometry.Centroid;
                        var pt = map.WorldToImage(new Coordinate(point.X, point.Y));


                        //  float x = ptList.Average(r => r.X);
                        // float y = ptList.Average(r => r.Y);

                        SizeF sizeF = g.MeasureString(SObject.name, font);

                        g.DrawString(SObject.name, font, Brushes.Red, pt.X - sizeF.Width / 2, pt.Y - sizeF.Height / 2);
                    }
                }

            }
            else
            {
                //绘制线
                g.DrawLines(linePen, ptList.ToArray());
            }
        }
        public override void Render(Graphics g, Map map)
        {
            List<PointF> ptList = new List<PointF>();
            foreach (var coord in Nodes)
            {
                var pt = map.WorldToImage(new Coordinate(coord.Lon, coord.Lat));
                ptList.Add(pt);
            }

            //绘制线
            g.DrawLines(SelectlinePen, ptList.ToArray());
        }

        public bool Query(Coordinate coordinate, RectangleLineIntersector rectintersector)
        {
            bool isArea = Convert.ToBoolean(GetTagValue("area", false));

            if (isArea)
            {
                //查询
                if (Geometry.Contains(new NetTopologySuite.Geometries.Point(coordinate)))
                {
                    return true;
                }
            }
            else
            {
                //查询线
                for (int i = 0; i < Nodes.Count - 1; i++)
                {
                    Node node1 = Nodes[i];
                    Node node2 = Nodes[i + 1];

                    bool result = rectintersector.Intersects(new Coordinate(node1.Lon, node1.Lat), new Coordinate(node2.Lon, node2.Lat));
                    if (result)
                    {
                        return true;
                    }
                }

            }
            return false;
        }
        static GeometryFactory geometryFactory = new GeometryFactory();
        public override void CalculationEnvelope()
        {
            bool isArea = Convert.ToBoolean(GetTagValue("area", false));

            Coordinate[] coordinates = this.Nodes.Select(r => new Coordinate(r.Lon, r.Lat)).ToArray();
            if (isArea)
            {
                this.Geometry = geometryFactory.CreatePolygon(coordinates) as Geometry;
            }
            else
            {
                this.Geometry = geometryFactory.CreateLineString(coordinates) as Geometry;
            }


            double xmin = 0, xmax = 0, ymin = 0, ymax = 0;
            for (int i = 0; i < this.Nodes.Count; i++)
            {
                Node node = this.Nodes[i];
                if (i == 0)
                {
                    xmin = node.Lon;
                    xmax = node.Lon;
                    ymin = node.Lat;
                    ymax = node.Lat;
                }
                else
                {
                    xmin = Math.Min(xmin, node.Lon);
                    xmax = Math.Max(xmax, node.Lon);
                    ymin = Math.Min(ymin, node.Lat);
                    ymax = Math.Max(ymax, node.Lat);
                }
            }

            this.Envelope = new Envelope(xmin, xmax, ymin, ymax);
        }
    }
}
