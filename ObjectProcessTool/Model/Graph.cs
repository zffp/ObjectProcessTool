using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using ObjectProcessTool.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Model
{
    public class Graph
    {

        public Dictionary<long, Entity> EntityMap { get; set; }

        public Dictionary<long, List<long>> ParentWays { get; set; }
        public Dictionary<long, List<long>> ParentRels { get; set; }
        public Dictionary<long, List<long>> ChildNodes { get; set; }

        public Graph()
        {
            EntityMap = new Dictionary<long, Entity>();
            ParentWays = new Dictionary<long, List<long>>();
            ParentRels = new Dictionary<long, List<long>>();
            ChildNodes = new Dictionary<long, List<long>>();
        }

        public Entity GetEntity(long id)
        {
            if (EntityMap.ContainsKey(id))
            {
                return EntityMap[id];
            }
            return null;
        }

        public void AddEntity(Entity entity)
        {
            entity.Graph = this;

            this.EntityMap.Add(entity.Id, entity);

            //构建层次结构
            if (entity is Way)
            {
                Way way = entity as Way;

                way.Nodes.ForEach(node => AddParentWay(node.Id, way.Id));
            }
            else if (entity is Relation)
            {
                Relation relation = entity as Relation;
                relation.Members.ForEach(member => AddParentRels(member.RefId, relation.Id));
            }
        }
        public Entity AddPoint(Point point, Dictionary<string, object> tags)
        {


            Node node = new Node(IDGenerator.CrateId(), point.Y, point.X);
            node.Geometry = point;
            node.Tags.Add("isObject", true);
            this.AddEntity(node);
            return node;
        }
        public Entity AddLineString(LineString lineString, Dictionary<string, object> tags)
        {
            Way way = new Way(IDGenerator.CrateId());
            way.Geometry = lineString;
            way.Tags = tags;
            way.Tags.Add("isObject", true);
            foreach (Coordinate coordinate in lineString.Coordinates)
            {
                Node node = new Node(IDGenerator.CrateId(), coordinate.Y, coordinate.X);
                node.Geometry = new Point(coordinate);
                node.Tags.Add("isObject", false);
                node.Way = way;
                way.Nodes.Add(node);
                this.AddEntity(node);
            }

            this.AddEntity(way);
            return way;
        }

        public Entity AddPolygon(Polygon polygon, Dictionary<string, object> tags)
        {
            if (polygon.NumGeometries == 1)
            {
                IGeometry geometry = polygon.GetGeometryN(0);
                Way way = CreateWay(tags, geometry, true);
                this.AddEntity(way);

                return way;
            }
            else
            {
                Relation relation = new Relation(IDGenerator.CrateId());
                relation.Geometry = polygon;
                relation.Tags = tags;
                relation.Tags.Add("isObject", true);
                for (int i = 0; i < polygon.NumGeometries; i++)
                {
                    IGeometry geometry = polygon.GetGeometryN(i);
                    Way way = CreateWay(new Dictionary<string, object>(), geometry, false);
                    Member member = new Member("Way", i == 0 ? "outer" : "innter");
                    member.RefEntity = way;
                    relation.Members.Add(member);
                    this.AddEntity(way);
                }
                this.AddEntity(relation);

                return relation;
            }

        }
        public Entity AddMPolygon(MultiPolygon polygon, Dictionary<string, object> tags)
        {
            Relation relation = new Relation(IDGenerator.CrateId());
            relation.Geometry = polygon;
            relation.Tags = tags;
            relation.Tags.Add("isObject", true);

            for (int j = 0; j < polygon.Count; j++)
            {
                Polygon polygonGeometry = polygon[j] as Polygon;
                for (int i = 0; i < polygonGeometry.NumGeometries; i++)
                {

                    IGeometry geometry = polygonGeometry.GetGeometryN(i);
                    Way way = CreateWay(new Dictionary<string, object>(), geometry, false);
                    Member member = new Member("Way", i == 0 ? "outer" : "innter");
                    member.RefEntity = way;
                    relation.Members.Add(member);
                    this.AddEntity(way);
                }
            }

            return relation;
        }
        private Way CreateWay(Dictionary<string, object> tags, IGeometry geometry, bool isObject)
        {
            Way way = new Way(IDGenerator.CrateId());
            way.Geometry = geometry as Geometry;
            way.Tags = tags;
            way.Tags.Add("area", true);
            way.Tags.Add("isObject", isObject);
            foreach (Coordinate coordinate in geometry.Coordinates)
            {
                Node node = CreateNode(way, coordinate);
                way.Nodes.Add(node);
                this.AddEntity(node);
            }

            return way;
        }

        private static Node CreateNode(Way way, Coordinate coordinate)
        {
            Node node = new Node(IDGenerator.CrateId(), coordinate.Y, coordinate.X);
            node.Geometry = new Point(coordinate);
            node.Tags.Add("isObject", false);
            node.Way = way;
            return node;
        }


        private void AddParentWay(long nodeId, long wayId)
        {
            List<long> wayIdList = null;
            if (ParentWays.ContainsKey(nodeId))
            {
                wayIdList = ParentWays[nodeId];
            }
            else
            {
                wayIdList = new List<long>();
                ParentWays.Add(nodeId, wayIdList);
            }
            wayIdList.Add(wayId);
        }

        private void AddParentRels(long id, long relId)
        {
            List<long> relIdList = null;
            if (ParentRels.ContainsKey(id))
            {
                relIdList = ParentRels[id];
            }
            else
            {
                relIdList = new List<long>();
                ParentRels.Add(id, relIdList);
            }
            relIdList.Add(relId);
        }
    }
}
