using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using ObjectProcessTool.Layer;
using ObjectProcessTool.Model;
using ObjectProcessTool.UI;
using ObjectProcessTool.Util;
using SharpMap.Data;
using SharpMap.Layers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectProcessTool.Command
{
    public class ShpToOsmCommand : ICommand
    {
        public string Name => "ShpToOsm";

        dynamic ConvertFunction;

        OsmLayer osmLayer;

        public void Execute(object sender, EventArgs e)
        {
            LayerCtrlUserControl layerCtrlUserControl = GlobalContainer.GetInstance<LayerCtrlUserControl>("LayerCtrlUserControl");



            ILayer layer = layerCtrlUserControl.GetSelectLayer();
            if (layer != null && layer is VectorLayer)
            {

                if (!ImportSetting())
                {
                    MessageBox.Show("设置导入图层");
                    return;
                }

                VectorLayer vectorLayer = layer as VectorLayer;
                FeatureDataSet ds = new FeatureDataSet();
                vectorLayer.ExecuteIntersectionQuery(vectorLayer.Envelope, ds);

                Graph graph = osmLayer.Graph;

                if (ds.Tables.Count > 0)
                {
                    foreach (FeatureDataRow dataRow in ds.Tables[0].Rows)
                    {
                        Dictionary<string, object> tags = new Dictionary<string, object>();
                        foreach (DataColumn dataColumn in dataRow.Table.Columns)
                        {
                            tags.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName]);
                        }
                        Entity entity = CreateEntity(graph, dataRow, tags);

                        ConvertFunction?.Invoke(entity);
                    }
                }
            }
            else
            {
                MessageBox.Show("没有选择转换图层");
            }
            
        }

        private Entity CreateEntity(Graph graph, FeatureDataRow dataRow, Dictionary<string, object> tags)
        {
            if (dataRow.Geometry is Point)
            {
                return graph.AddPoint(dataRow.Geometry as Point, tags);
            }
            else if (dataRow.Geometry is LineString)
            {
                return graph.AddLineString(dataRow.Geometry as LineString, tags);
            }
            else if (dataRow.Geometry is Polygon)
            {
                return graph.AddPolygon(dataRow.Geometry as Polygon, tags);
            }
            else if (dataRow.Geometry is MultiPolygon)
            {

            }

            return null;
        }

        private bool ImportSetting()
        {
            ImportSetForm importSetForm = new ImportSetForm();
            if (importSetForm.ShowDialog() == DialogResult.OK)
            {
                ConvertFunction = importSetForm.ConvertFunction();
               // osmLayer = importSetForm.GetOsmLayer();
                return osmLayer != null;
            }
            return false;
        }
    }
}
