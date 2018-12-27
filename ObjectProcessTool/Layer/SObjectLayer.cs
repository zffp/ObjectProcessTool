using GeoAPI.Geometries;
using NetTopologySuite.Algorithm;
using ObjectProcessTool.Model;
using ObjectProcessTool.Util;
using SharpMap;
using SharpMap.Data;
using SharpMap.Layers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Layer
{
    public class SObjectLayer : ILayer, ICanQueryLayer
    {
        public static bool ShowText = false;


        public double MinVisible { get; set; }
        public double MaxVisible { get; set; }
        public bool Enabled { get; set; }
        public string LayerName { get; set; }
        public string LayerTitle { get; set; }

        public Envelope Envelope => new Envelope(120.427961, 120.4287250, 31.325214, 31.325773);

        public int SRID { get; set; }

        public int TargetSRID => 0;

        public string Proj4Projection { get; set; }
        public bool IsQueryEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public List<SObject> SObjects { get; set; }
        public Graph Graph { get; set; }
        public SObjectLayer(string layerName)
        {
            this.LayerName = layerName;
            MaxVisible = double.MaxValue;
            Enabled = true;

            SObjects = new List<SObject>();

            Graph = new Graph();
        }
        public void Render(Graphics g, Map map)
        {
            var envelope = map.Envelope;

            foreach (Entity entity in Graph.EntityMap.Where(r => r.Value is Way).Select(r => r.Value))
            {
                if (envelope.Intersects(entity.Envelope))
                {
                    entity.RenderEntity(g, map);
                }
            }
            foreach (Entity entity in Graph.EntityMap.Where(r => r.Value is Relation).Select(r => r.Value))
            {
                if (envelope.Intersects(entity.Envelope))
                {
                    entity.RenderEntity(g, map);
                }
            }
            foreach (Entity entity in Graph.EntityMap.Where(r => r.Value is Node).Select(r => r.Value))
            {
                if (entity.Envelope == null)
                {
                    entity.CalculationEnvelope();
                }
                if (envelope.Intersects(entity.Envelope))
                {
                    entity.RenderEntity(g, map);
                }
            }
        }

        public Entity Query(int x, int y)
        {
            Map map = GlobalContainer.GetInstance<Map>("Map");

            var pt1 = map.ImageToWorld(new PointF(x - 5, y - 5));
            var pt2 = map.ImageToWorld(new PointF(x + 5, y + 5));
            var envelope = new Envelope(pt1, pt2);

            RectangleLineIntersector rectintersector = new RectangleLineIntersector(envelope);


            var point = map.ImageToWorld(new PointF(x, y));
            foreach (KeyValuePair<long, Entity> keyValue in Graph.EntityMap)
            {
                Entity entity = keyValue.Value;

                if (entity is Way)
                {
                    Way way = entity as Way;

                    if (way.Query(point, rectintersector))
                    {
                        return way;
                    }
                }
                else if (entity is Node)
                {
                    Node node = entity as Node;
                    if (node.Query(envelope))
                    {
                        return node;
                    }
                }
            }
            return null;
        }

        public void RestEnvelope()
        {
            Envelope envelope = null;
            foreach (KeyValuePair<long, Entity> keyValue in Graph.EntityMap)
            {
                if (envelope == null)
                {
                    envelope = keyValue.Value.Geometry.EnvelopeInternal;
                }
                else
                {
                    envelope = envelope.ExpandedBy(keyValue.Value.Geometry.EnvelopeInternal);
                }
            }
        }

        public void ExecuteIntersectionQuery(Envelope box, FeatureDataSet ds)
        {

        }

        public void ExecuteIntersectionQuery(IGeometry geometry, FeatureDataSet ds)
        {

        }
    }
}
