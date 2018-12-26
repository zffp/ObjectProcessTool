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

        public void SetFeatureData(Entity featureModel)
        {
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
    }
}
