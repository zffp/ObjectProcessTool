using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjectProcessTool.Model;
using NetTopologySuite.IO;

namespace ObjectProcessTool.UI
{
    public partial class PropertyUserControl : UserControl
    {
        public PropertyUserControl()
        {
            InitializeComponent();
        }

        WKTWriter wKTWriter = new WKTWriter();

        /// <summary>
        /// 初始化对象列表
        /// </summary>
        public void InitObjectList(Entity featureModel)
        {
            comboBox1.Items.Clear();
            if (featureModel != null)
            {
                if (featureModel.SObject == null)
                {
                    if (featureModel is Way)
                    {
                        //查找对应的relation
                        List<Entity> entities = featureModel.Graph.GetRelationByWid(featureModel.Id);
                        comboBox1.Items.AddRange(entities.ToArray());
                    }
                }
            }

        }
        public void SetFeatureData(Entity featureModel)
        {

            InitObjectList(featureModel);

            if (featureModel != null && featureModel.SObject != null)
            {
                this.propertyGrid1.SelectedObject = featureModel.SObject;
            }
            else
            {
                this.propertyGrid1.SelectedObject = featureModel;
            }



            if (featureModel != null && featureModel.Geometry != null)
            {
                this.textBox1.Text = wKTWriter.Write(featureModel.Geometry);
            }
            else
            {
                this.textBox1.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                this.SetFeatureData(comboBox1.SelectedItem as Entity);

            }

        }
    }
}
