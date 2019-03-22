using GeoAPI.Geometries;
using GeoSOT;
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
    class GeoSotLayer : ILayer
    {
        public double MinVisible { get; set; }
        public double MaxVisible { get; set; }
        public bool Enabled { get; set; }
        public string LayerName { get; set; }
        public Envelope Envelope => new Envelope(-180, 180, -90, 90);

        public int SRID { get; set; }

        public int TargetSRID => 0;

        public string Proj4Projection { get; set; }

        public GeoSotLayer()
        {
            this.LayerName = "GeoSotLayer";
            MaxVisible = double.MaxValue;
            Enabled = true;
        }
        static protected Font font = new Font("宋体", 9);
        public void Render(Graphics g, Map map)
        {
            double mapWdith = map.Envelope.Width;

            List<double> sizelist = new List<double>();

            for (var l = 0; l < 32; l++)
            {
                sizelist.Add(CellSize.GetCellSizeInDegree(l));
            }




            double width = CellSize.GetCellSizeInDegree(1);
            int level = 1;
            for (int l = 1; l < 31; l++)
            {
                width = CellSize.GetCellSizeInDegree(l);
                if (width < mapWdith / 3)
                {
                    level = l;
                    break;
                }
            }
            double minx = map.Envelope.MinX < -256 ? -256 : map.Envelope.MinX;
            double miny = map.Envelope.MinY < -256 ? -256 : map.Envelope.MinY;
            double maxx = map.Envelope.MaxX > 256 ? 256 : map.Envelope.MaxX;
            double maxy = map.Envelope.MaxY > 256 ? 256 : map.Envelope.MaxY;


            List<Coordinate> coordinates = new List<Coordinate>();

            for (double j = miny; j < maxy; j += width)
            {
                for (double i = minx; i < maxx; i += width)
                {
                    Tile tile = new Tile(j, i, level);
                    LngLatBbox box1 = tile.GetBbox();

                    RenderTile(tile, map, g);

                }
            }
            PointF pt1 = map.WorldToImage(new Coordinate(-180, -90));
            PointF pt2 = map.WorldToImage(new Coordinate(180, 90));
            g.DrawRectangle(Pens.Blue, pt1.X, pt2.Y, pt2.X - pt1.X, pt1.Y - pt2.Y);



        }
        private void RenderTile(Tile tile, Map map, Graphics g)
        {
            LngLatBbox box1 = tile.GetBbox();

            LngLatSegments lng = new LngLatSegments((box1.West + box1.East) / 2);
            LngLatSegments lat = new LngLatSegments((box1.South + box1.North) / 2);


            double width = CellSize.GetCellSizeInDegree(tile.Level);
            long lngcode = Convert.ToInt64(lng.Code1 / width);
            string lngcode2 =lng.G+  Convert.ToString(lngcode, 2);
             if (lngcode2.Length > tile.Level)
            {
                //lngcode2 = lngcode2.Substring(0, tile.Level );
            }



            long latcode = Convert.ToInt64(lat.Code1 / width);
            string latcode2 = lat.G + Convert.ToString(latcode, 2);
            // if (latcode2.Length > tile.Level)
            {
              //  latcode2 = latcode2.Substring(0, tile.Level );
            }


            //  LngLatSegments lng = new LngLatSegments((box1.West + box1.East) / 2);
            //  LngLatSegments lat = new LngLatSegments((box1.South + box1.North) / 2);

            PointF pt1 = map.WorldToImage(new Coordinate(box1.West, box1.South));
            PointF pt2 = map.WorldToImage(new Coordinate(box1.East, box1.North));
            g.DrawRectangle(Pens.Red, pt1.X, pt2.Y, pt2.X - pt1.X, pt1.Y - pt2.Y);

            PointF pt3 = map.WorldToImage(new Coordinate(lng.Degree, lat.Degree));
            g.FillEllipse(Brushes.YellowGreen, pt3.X - 3, pt3.Y - 3, 6, 6);


            g.DrawString(tile.ToString(), font, Brushes.Red, pt1.X, pt2.Y);

            g.DrawString(string.Format("{0}-{1}-{2}", tile.X, tile.Y, tile.Level), font, Brushes.Red, pt1.X, pt2.Y + 20);

            //g.DrawString(tile.Id.ToString() + "," + lngcode2, font, Brushes.Red, pt1.X, pt2.Y + 40);
            g.DrawString("经度：" + lngcode2 + "," + Convert.ToInt64(lngcode2, 2), font, Brushes.Red, pt1.X, pt2.Y + 40);

            g.DrawString("纬度：" + latcode2 + "," + Convert.ToInt64(latcode2, 2),
               font, Brushes.Red, pt1.X, pt2.Y + 60);

            g.DrawString("编码：" + ((lat.G == 1 ? -latcode : latcode) * 2 + (lng.G == 1 ? -lngcode : lngcode)),
               font, Brushes.Red, pt1.X, pt2.Y + 80);

            g.DrawString(lng.Degree.ToString(),
                font, Brushes.Red, pt1.X, pt2.Y + 100);
            g.DrawString(lat.Degree.ToString(),
               font, Brushes.Red, pt1.X, pt2.Y + 120);




        }
    }
}
