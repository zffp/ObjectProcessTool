using ObjectProcessTool.Layer;
using ObjectProcessTool.MapControl;
using ObjectProcessTool.UI;
using ObjectProcessTool.Util;
using SharpMap;
using SharpMap.Data.Providers;
using SharpMap.Layers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectProcessTool.Command
{
    class OpenShpFileCommand : ICommand
    {
        public string Name => "OpenShpFile";

        public void Execute(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "shpfile(*.shp)|*.shp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //string fileName = openFileDialog.FileName;
                foreach(string fname in openFileDialog.FileNames)
                {
                    OpenShp(fname, GlobalContainer.GetInstance<Map>("Map"));
                }
                
            }
        }
        private void OpenShp(string shpFileName, Map map)
        {
            var LayerName = Path.GetFileName(shpFileName);
            ShapeFile shapeFile = new ShapeFile(shpFileName);

            VectorLayer vectorLayer = new VectorLayer(LayerName);
            vectorLayer.DataSource = shapeFile;
            vectorLayer.Style.Line = new Pen(Color.FromArgb(205, 186, 93), 2f);
            vectorLayer.Style.Fill = new SolidBrush(Color.FromArgb(80, 0, 205, 56));

            LayerManager.Instance.AddLayer(vectorLayer);           
        }       
    }
}
