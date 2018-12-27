using GeoAPI.Geometries;
using Newtonsoft.Json;
using ObjectProcessTool.Layer;
using SharpMap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Model
{
    public class Node : Entity, IEqualityComparer<Node>
    {
        [JsonProperty("y")]
        public double Lat { get; set; }
        [JsonProperty("x")]
        public double Lon { get; set; }
        [JsonProperty("z")]
        public double Z { get; set; }

        [JsonIgnore]
        public Way Way { get; set; }

        int width = 4;



        public Node(long id) : base(id, "Node")
        {

        }
        public Node(long id, double lat, double lon) : base(id, "Node")
        {
            this.Lat = lat;
            this.Lon = lon;

        }
        static protected Font font = new Font("宋体", 9);

        public override void RenderEntity(Graphics g, Map map)
        {
            var pt1 = map.WorldToImage(new Coordinate(Lon, Lat));
            bool isObject = Convert.ToBoolean(GetTagValue("isObject", false));
            if (isObject)
            {
                g.DrawRectangle(Pens.OrangeRed, pt1.X - width, pt1.Y - width, width * 2, width * 2);
            }
            else
            {
                g.DrawEllipse(Pens.Red, pt1.X - width, pt1.Y - width, width * 2, width * 2);
            }

            //显示注记

            if (SObjectLayer.ShowText)
            {
                //显示注记

                if (SObject != null && !string.IsNullOrEmpty(SObject.name))
                {
                    g.DrawString(SObject.name, font, Brushes.Red, pt1.X, pt1.Y + 1);
                }
            }

        }
        public override void Render(Graphics g, Map map)
        {
            var pt1 = map.WorldToImage(new Coordinate(Lon, Lat));

            g.FillEllipse(Brushes.Red, pt1.X - width, pt1.Y - width, width * 2, width * 2);
        }

        public bool Query(Envelope envelope)
        {
            return envelope.Contains(new Coordinate(Lon, Lat));
        }


        public override void CalculationEnvelope()
        {
            this.Envelope = new Envelope(Lon, Lon, Lat, Lat);
        }

        #region IEqualityComparer
        public bool Equals(Node x, Node y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Node obj)
        {
            return obj.Id.GetHashCode();
        }
        #endregion
    }
}
