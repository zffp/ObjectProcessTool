using Newtonsoft.Json;
using ObjectProcessTool.Layer;
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
    class SaveSObjectCommand : ICommand
    {
        public string Name => "SaveSObject";

        public void Execute(object sender, EventArgs e)
        {
            LayerCtrlUserControl layerCtrlUserControl = GlobalContainer.GetInstance<LayerCtrlUserControl>("LayerCtrlUserControl");

            ILayer layer = layerCtrlUserControl.GetSelectLayer();

            if (layer != null && layer is SObjectLayer)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "json(*.json)|*.json";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    SObjectLayer sObjectLayer = layer as SObjectLayer;

                    

                    string json = JsonConvert.SerializeObject(sObjectLayer.SObjects);


                    System.IO.File.WriteAllText(saveFileDialog.FileName, json);

                }
            }
            else
            {
                MessageBox.Show("请选择图层");
            }
        }
    }
}
