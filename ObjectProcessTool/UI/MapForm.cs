using ObjectProcessTool.MapControl;
using ObjectProcessTool.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ObjectProcessTool.UI
{
    public partial class MapForm : DockContent
    {
        public MapForm()
        {
            InitializeComponent();

            //注册全局地图控件
            GlobalContainer.Register("MapBox", objectMapBox1);
            //注册全局地图
            GlobalContainer.Register("Map", objectMapBox1.Map);
        }

        private void MapForm_Load(object sender, EventArgs e)
        {

        }
        public ObjectMapBox GetMapBox()
        {
            return objectMapBox1;
        }
    }
}
