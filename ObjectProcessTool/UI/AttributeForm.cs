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
    public partial class AttributeForm : DockContent
    {
        public AttributeForm()
        {
            InitializeComponent();
        }

        public void SetData(DataTable dataTable)
        {
            dataGridView1.DataSource = dataTable;
        }
    }
}
