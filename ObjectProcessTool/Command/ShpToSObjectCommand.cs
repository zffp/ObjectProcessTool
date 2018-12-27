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
    class ShpToSObjectCommand : ICommand
    {
        public string Name => "ShpToSObject";

        public void Execute(object sender, EventArgs e)
        {
            LayerCtrlUserControl layerCtrlUserControl = GlobalContainer.GetInstance<LayerCtrlUserControl>("LayerCtrlUserControl");

            ILayer layer = layerCtrlUserControl.GetSelectLayer();
            if (layer != null && layer is VectorLayer)
            {
                if (!ImportSetting(layer))
                {
                    MessageBox.Show("设置导入图层");
                    return;
                }

                VectorLayer vectorLayer = layer as VectorLayer;
                FeatureDataSet ds = new FeatureDataSet();
                vectorLayer.ExecuteIntersectionQuery(vectorLayer.Envelope, ds);

                Graph graph = sObjectLayer.Graph;

                if (ds.Tables.Count > 0)
                {
                    foreach (FeatureDataRow dataRow in ds.Tables[0].Rows)
                    {
                        if (dataRow.Geometry == null)
                        {
                            continue;
                        }
                        Dictionary<string, object> tags = new Dictionary<string, object>();
                        foreach (DataColumn dataColumn in dataRow.Table.Columns)
                        {
                            tags.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName]);
                        }
                        Entity entity = CreateEntity(graph, dataRow, tags);

                        if (ConvertFunction != null)
                        {
                            ConvertFunction(entity);
                        }

                        entity.CalculationEnvelope();

                        SObject sObject = CreateSObject(entity);
                        sObjectLayer.SObjects.Add(sObject);

                        sObject.Layer = sObjectLayer;
                    }

                    sObjectLayer.RestEnvelope();
                    MessageBox.Show("转换成功!");
                }
            }
            else
            {
                MessageBox.Show("没有选择转换图层!");
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
                return graph.AddMPolygon(dataRow.Geometry as MultiPolygon, tags);
            }

            return null;
        }

        private SObject CreateSObject(Entity entity)
        {
            SObject sObject = new SObject();

            sObject.id = IDGenerator.CrateId();
            sObject.uuid = sObject.id;// IDGenerator.CrateId();

            sObject.name = Convert.ToString(entity.GetTagValue("name", ""));
            sObject.actions.Add(new Model.Action() { operation = 33 });

            long pid = Convert.ToInt64(Convert.ToString(entity.GetTagValue("parentid", 0)));
            sObject.parents.Add(new BaseId() { id = pid });

            sObject.trs = new Trs();
            sObject.srs = new Trs();


            string otypeName = Convert.ToString(entity.GetTagValue("otypename", ""));

            sObject.otype = new BaseName() { id = 0, name = otypeName };


            foreach (KeyValuePair<string, object> keyValue in entity.Tags)
            {
                if (keyValue.Key != "parentid" && keyValue.Key != "otypename" && keyValue.Key != "isObject")
                {
                    sObject.attributes.Add(new BAttribute() { fid = 0, name = keyValue.Key, value = Convert.ToString(keyValue.Value) });
                }
            }



            Model.Form form = new Model.Form();
            form.geom = entity;
            form.id = IDGenerator.CrateId();
            form.geomref = entity.Id;

            form.geotype = entity.GetGeoType();
            form.type = entity.GetGeoType();



            sObject.forms.Add(form);

            sObject.realTime = IDGenerator.GetTimeStamp();

            entity.SObject = sObject;

            return sObject;
        }

        dynamic ConvertFunction;

        SObjectLayer sObjectLayer;

        private bool ImportSetting(ILayer layer)
        {
            ImportSetForm importSetForm = new ImportSetForm();
            importSetForm.SetImportLayerName(layer.LayerName);
            if (importSetForm.ShowDialog() == DialogResult.OK)
            {
                ConvertFunction = importSetForm.ConvertFunction();
                sObjectLayer = importSetForm.GetOsmLayer();
                return sObjectLayer != null;
            }
            return false;
        }
    }
}
