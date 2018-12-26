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
    public partial class IDForm : Form
    {
        public IDForm()
        {
            InitializeComponent();
        }

        public long GetId()
        {
            try
            {
                return Convert.ToInt64(textBox1.Text);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
    }
}
