using GeoAPI.Geometries;
using NetTopologySuite.Index.KdTree;
using NetTopologySuite.Index.Strtree;
using ObjectProcessTool.Layer;
using ObjectProcessTool.Model;
using ObjectProcessTool.UI;
using ObjectProcessTool.Util;
using SharpMap.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectProcessTool.Command
{
    /// <summary>
    /// 去除重复点
    /// </summary>
    class RemoveRepeatNodeCommand : ICommand
    {
        public string Name => "RemoveRepeatNode";



        double tolerance = 0.00000006;
        public void Execute(object sender, EventArgs e)
        {
            ILayer layer = LayerManager.Instance.GetSelectLayer();
            if (layer is SObjectLayer)
            {
                SObjectLayer osmLayer = layer as SObjectLayer;

                Graph graph = osmLayer.Graph;

                STRtree<Node> rtree = new STRtree<Node>();

                foreach (Node entity in osmLayer.Graph.EntityMap.Where(r => r.Value is Node).Select(r => r.Value))
                {
                    rtree.Insert(new Envelope(entity.Lon, entity.Lon, entity.Lat, entity.Lat), entity);
                }
                List<Entity> nodeList = osmLayer.Graph.EntityMap.Where(r => r.Value is Node && r.Value.IsObject).Select(r => r.Value).ToList();

                RemoveRepeatNode(graph, rtree, nodeList);

                nodeList = osmLayer.Graph.EntityMap.Where(r => r.Value is Node && !r.Value.IsObject).Select(r => r.Value).ToList();
                RemoveRepeatNode(graph, rtree, nodeList);

                List<Entity> entities = osmLayer.Graph.EntityMap.Where(r => r.Value is Way).Select(r => r.Value).ToList();

                foreach (Entity entity in entities)
                {
                    Way way = entity as Way;

                    List<Node> result = new List<Node>();
                    Node preNode = null;
                    foreach (Node node in way.Nodes)
                    {
                        if (preNode != null)
                        {
                            if (preNode.Id != node.Id)
                            {
                                result.Add(node);
                            }
                        }
                        else
                        {
                            result.Add(node);
                        }
                        preNode = node;
                    }

                    if (way.IsArea)
                    {
                        if (result[0].Id != result[result.Count - 1].Id)
                        {
                            result.Add(result[0]);
                        }
                    }

                    way.Nodes = result;
                }
                foreach (Entity entity in entities)
                {
                    Way way = entity as Way;
                    if (way.Nodes.Count <= 1)
                    {
                        //构不成线    //移除对象
                        osmLayer.SObjects.Remove(way.SObject);
                        graph.RemvoeEntity(way);                      
                    }
                }

                MessageBox.Show("完成：" + graph.EntityMap.Count);
            }
        }

        private void RemoveRepeatNode(Graph graph, STRtree<Node> rtree, List<Entity> nodeList)
        {
            HashSet<long> removeIdlist = new HashSet<long>();
            foreach (Node entity in nodeList)
            {
                if (removeIdlist.Contains(entity.Id))
                {
                    continue;
                }

                var envelope = new Envelope(entity.Lon - tolerance, entity.Lon + tolerance, entity.Lat - tolerance, entity.Lat + tolerance);
                IList<Node> nodes = rtree.Query(envelope);
                foreach (Node remNode in nodes)
                {
                    if (remNode != entity)
                    {
                        if (graph.ParentWays.ContainsKey(remNode.Id))
                        {
                            List<long> wayIds = graph.ParentWays[remNode.Id];

                            foreach (long wid in wayIds)
                            {
                                Way way = graph.EntityMap[wid] as Way;

                                int idx = way.Nodes.FindIndex(r => r.Id == remNode.Id);
                                way.Nodes.RemoveAt(idx);
                                way.Nodes.Insert(idx, entity);

                                graph.EntityMap.Remove(remNode.Id);
                                graph.ParentWays.Remove(remNode.Id);

                                removeIdlist.Add(remNode.Id);

                            }
                        }
                    }
                }
            }
        }
    }
}
