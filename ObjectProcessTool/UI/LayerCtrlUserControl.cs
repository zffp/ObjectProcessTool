﻿using System;
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
using ObjectProcessTool.Bil;
using SharpMap.Data;
using WeifenLuo.WinFormsUI.Docking;

namespace ObjectProcessTool.UI
{
    public partial class LayerCtrlUserControl : UserControl
    {
        public LayerCtrlUserControl()
        {
            InitializeComponent();

            InitTree();

            LoadScript();
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
            LayerManager.Instance.SetLayerVisible(e.Node.Text, e.Node.Checked == true);
        }

        public ILayer GetSelectLayer()
        {
            if (layer_treeView.SelectedNode != null)
            {
                return layer_treeView.SelectedNode.Tag as ILayer;
            }
            return null;
        }

        private void removeLayer_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (layer_treeView.SelectedNode != null && layer_treeView.SelectedNode.Tag != null)
            {
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
            string scriptContent = ScriptManager.Instance.ReadScript(comboBox1.Text);

            python_textBox.Text = scriptContent;
        }
        /// <summary>
        /// 载入脚本
        /// </summary>
        public void LoadScript()
        {
            comboBox1.Items.AddRange(ScriptManager.Instance.GetAllScript());
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

        private void showattr_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ILayer layer = GetSelectLayer();
            if (layer is VectorLayer)
            {


                VectorLayer vectorLayer = layer as VectorLayer;
                FeatureDataSet ds = new FeatureDataSet();
                vectorLayer.ExecuteIntersectionQuery(vectorLayer.Envelope, ds);

                if (ds.Tables.Count > 0)
                {
                    DockPanel dockPanel = GlobalContainer.GetInstance<DockPanel>("dockPanel");

                    AttributeForm attributeForm = new AttributeForm();
                    attributeForm.Text = layer.LayerName;
                    attributeForm.TabText = layer.LayerName;
                    attributeForm.SetData(ds.Tables[0]);

                    attributeForm.Show(dockPanel, DockState.Document);
                }

            }
        }
    }
}
