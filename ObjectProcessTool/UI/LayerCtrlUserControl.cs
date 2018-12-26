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
using ObjectProcessTool.Command;
using ObjectProcessTool.Util;
using SharpMap;
using ObjectProcessTool.MapControl;

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

            InitTree();
        }
        TreeNode rootLayerNode;
        TreeNode ShpLayerNode;
        TreeNode SObjectLayerNode;
        public void InitTree()
        {
            rootLayerNode = new TreeNode();
            rootLayerNode.Text = "图层";
            layer_treeView.Nodes.Add(rootLayerNode);

            ShpLayerNode = new TreeNode();
            ShpLayerNode.Text = "SHP图层";
            rootLayerNode.Nodes.Add(ShpLayerNode);


            SObjectLayerNode = new TreeNode();
            SObjectLayerNode.Text = "对象图层";

            rootLayerNode.Nodes.Add(SObjectLayerNode);


            layer_treeView.ExpandAll();
        }

        public void AddLayer(ILayer layer)
        {

            //checkedListBox1.Items.Add(new ListBoxItem(layer), true);

            TreeNode node = new TreeNode();
            node.Text = layer.LayerName;
            node.Tag = layer;
            node.Checked = true;
            if (layer is VectorLayer)
            {
                ShpLayerNode.Nodes.Add(node);
            }
            else if (layer is SObjectLayer)
            {
                SObjectLayerNode.Nodes.Add(node);
            }
        }

        public void RemoveLayer(ILayer layer)
        {

        }



        private void layer_treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // ListBoxItem listBoxItem = e.Node;// checkedListBox1.Items[e.Index] as ListBoxItem;

            LayerManager.Instance.SetLayerVisible(e.Node.Text, e.Node.Checked == true);

        }

        public ILayer GetSelectLayer()
        {


            if (layer_treeView.SelectedNode != null)
            {
                //ListBoxItem listBoxItem = checkedListBox1.Items[checkedListBox1.SelectedIndex] as ListBoxItem;

                return layer_treeView.SelectedNode.Tag as ILayer;
            }

            return null;
        }

        private void removeLayer_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (layer_treeView.SelectedNode != null && layer_treeView.SelectedNode.Tag != null)
            {
                // ListBoxItem listBoxItem = checkedListBox1.Items[checkedListBox1.SelectedIndex] as ListBoxItem;

                //checkedListBox1.Items.Remove(listBoxItem);
                LayerManager.Instance.RemoveLayer(layer_treeView.SelectedNode.Tag as ILayer);
                layer_treeView.SelectedNode.Remove();

            }
            else
            {
                MessageBox.Show("请选择移除图层");
            }
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


                ILayer layer = GetSelectLayer();
                if (layer is SObjectLayer)
                {
                    SObjectLayer sObjectLayer = layer as SObjectLayer;
                    List<string> vns = scope.GetVariableNames().ToList();
                    if (vns.Contains("convert"))
                    {
                        dynamic convertFunction = scope.GetVariable("convert");
                        foreach (SObject sObject in sObjectLayer.SObjects)
                        {
                            convertFunction(sObject);
                        }

                        MessageBox.Show("执行成功");
                    }
                    else if (vns.Contains("select"))
                    {
                       
                        Map map = GlobalContainer.GetInstance<Map>("Map");
                        ObjectMapBox mapBox = GlobalContainer.GetInstance<ObjectMapBox>("MapBox");
                        List<Entity> entities = new List<Entity>();

                        dynamic selectFunction = scope.GetVariable("select");
                        foreach (SObject sObject in sObjectLayer.SObjects)
                        {
                            if (selectFunction(sObject))
                            {
                                entities.AddRange(sObject.forms.Select(r => r.geom));
                            }
                        }

                        entities.ForEach(entity => map.Decorations.Add(entity));

                        mapBox.Invalidate();
                        // MessageBox.Show("执行成功");
                    }
                }


            }
            catch (Exception ee)
            {
                MessageBox.Show("脚本错误");
            }
        }

        private void converSObject_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShpToSObjectCommand shpToSObjectCommand = new ShpToSObjectCommand();

            shpToSObjectCommand.Execute(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "parent")
            {
                python_textBox.Text = @"def convert(sobject):
    sobject.parents[0].id=11920";
            }
        }


    }
}
