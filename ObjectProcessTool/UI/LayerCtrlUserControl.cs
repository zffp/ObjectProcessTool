using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpMap.Layers;
using ObjectProcessTool.Layer;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using ObjectProcessTool.Model;

namespace ObjectProcessTool.UI
{
    public partial class LayerCtrlUserControl : UserControl
    {

        class ListBoxItem
        {
            public ILayer Layer { get; set; }
            public ListBoxItem(ILayer layer)
            {
                Layer = layer;
            }
            public override string ToString()
            {
                return Layer.LayerName;
            }
        }



        public LayerCtrlUserControl()
        {
            InitializeComponent();


        }


        public void AddLayer(ILayer layer)
        {

            checkedListBox1.Items.Add(new ListBoxItem(layer), true);
        }

        public void RemoveLayer(ILayer layer)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ListBoxItem listBoxItem = checkedListBox1.Items[e.Index] as ListBoxItem;

            LayerManager.Instance.SetLayerVisible(listBoxItem.Layer.LayerName, e.NewValue == CheckState.Checked);
        }

        public ILayer GetSelectLayer()
        {
            if (checkedListBox1.SelectedIndex >= 0)
            {
                ListBoxItem listBoxItem = checkedListBox1.Items[checkedListBox1.SelectedIndex] as ListBoxItem;

                return listBoxItem.Layer;
            }

            return null;
        }

        private void removeLayer_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex >= 0)
            {
                ListBoxItem listBoxItem = checkedListBox1.Items[checkedListBox1.SelectedIndex] as ListBoxItem;

                checkedListBox1.Items.Remove(listBoxItem);
                LayerManager.Instance.RemoveLayer(listBoxItem.Layer);
            }
            else
            {
                MessageBox.Show("请选择移除图层");
            }
        }

        private void setparent_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ILayer layer = GetSelectLayer();
            if (layer is SObjectLayer)
            {
                SObjectLayer sObjectLayer = layer as SObjectLayer;
                IDForm iDForm = new IDForm();
                if (iDForm.ShowDialog() == DialogResult.OK)
                {
                    long pid = iDForm.GetId();

                    sObjectLayer.SObjects.ForEach(r => r.parents[0].id = pid);
                }
            }

        }

        private void setsdomain_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void setotype_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 应用执行脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptEngine pyEngine = Python.CreateEngine();
                ScriptScope scope = pyEngine.CreateScope();
                pyEngine.Execute(python_textBox.Text, scope);

                dynamic convertFunction = scope.GetVariable("convert");
                ILayer layer = GetSelectLayer();
                if (layer is SObjectLayer)
                {
                    SObjectLayer sObjectLayer = layer as SObjectLayer;

                    foreach (SObject sObject in sObjectLayer.SObjects)
                    {
                        convertFunction(sObject);
                    }

                    MessageBox.Show("执行成功");
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("脚本错误");
            }
        }
    }
}
