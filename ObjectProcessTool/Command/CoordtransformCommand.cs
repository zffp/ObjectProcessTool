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
    class CoordtransformCommand : ICommand
    {
        public string Name => "Coordtransform";

        private string transformName;

        private Func<double, double, double[]> TransformFunction;
        public CoordtransformCommand(string transformName)
        {
            this.transformName = transformName;

            if (transformName == "wgs84togcj02")
            {
                TransformFunction = Coordtransform.wgs84togcj02;
            }
            else if (transformName == "gcj02towgs84")
            {
                TransformFunction = Coordtransform.gcj02towgs84;
            }
        }

        public void Execute(object sender, EventArgs e)
        {

            ILayer layer = LayerManager.Instance.GetSelectLayer();
            if (layer is SObjectLayer)
            {
                SObjectLayer osmLayer = layer as SObjectLayer;

                Graph graph = osmLayer.Graph;

                foreach (Node entity in graph.EntityMap.Values.Where(r => r is Node))
                {

                    double[] result = TransformFunction(entity.Lon, entity.Lat);

                    entity.Lon = result[0];
                    entity.Lat = result[1];
                }
                foreach (Entity entity in graph.EntityMap.Values)
                {
                    entity.CalculationEnvelope();
                }
                MessageBox.Show("转换完成");
            }
        }
    }
}
