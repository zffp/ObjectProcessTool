using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using ObjectProcessTool.Bil;
using ObjectProcessTool.Layer;
using ObjectProcessTool.Util;
using SharpMap;
using SharpMap.Layers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectProcessTool.UI
{
    public partial class ImportSetForm : Form
    {
        public ImportSetForm()
        {
            InitializeComponent();


            LoadScript();
        }

        /// <summary>
        /// 载入脚本
        /// </summary>
        public void LoadScript()
        {
            comboBox1.Items.AddRange(ScriptManager.Instance.GetAllScript());
        }

        public void SetImportLayerName(string name)
        {
            importlayer_textBox.Text = name;
        }
        private void ImportSetForm_Load(object sender, EventArgs e)
        {
            tag_comboBox.Items.AddRange(GetOsmLayerNameList().ToArray());
        }
        dynamic convertFunction = null;
        private void button2_Click(object sender, EventArgs e)
        {
            Tuple<string, dynamic> tuple= ScriptManager.Instance.GetScriptFunction(python_textBox.Text);


            if(tuple!=null&&tuple.Item1== "convert")
            {
                convertFunction = tuple.Item2;

                MessageBox.Show("验证成功");
            }
            else
            {
                MessageBox.Show("验证失败,只支持convert函数");
            }

           
        }
        /// <summary>
        /// 获取动态转换函数
        /// </summary>
        /// <returns></returns>
        public dynamic ConvertFunction()
        {
            return convertFunction;
        }
        /// <summary>
        /// 获取osm编辑图层
        /// </summary>
        /// <returns></returns>
        public SObjectLayer GetOsmLayer()
        {
            Map map = GlobalContainer.GetInstance<Map>("Map");
            string layerName = tag_comboBox.Text;
            if (!string.IsNullOrEmpty(layerName))
            {
                ILayer osmlayer = map.Layers.FirstOrDefault(layer => layer is SObjectLayer && layer.LayerName == layerName);

                if (osmlayer == null)
                {
                    //创建
                    osmlayer = new SObjectLayer(layerName);

                    LayerManager.Instance.AddLayer(osmlayer);
                }
                return osmlayer as SObjectLayer;
            }

            return null;
        }

        private List<string> GetOsmLayerNameList()
        {
            Map map = GlobalContainer.GetInstance<Map>("Map");
            return map.Layers.Where(layer => layer is SObjectLayer).Select(r => r.LayerName).ToList();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            ScriptManager.Instance.SaveScript(comboBox1.Text, python_textBox.Text);
            string text = comboBox1.Text;
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(ScriptManager.Instance.GetAllScript());
            comboBox1.Text = text;
            MessageBox.Show("保存成功！");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string scriptContent = ScriptManager.Instance.ReadScript(comboBox1.Text);

            python_textBox.Text = scriptContent;
        }
    }
}
