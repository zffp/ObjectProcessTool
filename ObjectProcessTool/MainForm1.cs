using GeoAPI.Geometries;
using ObjectProcessTool.Bil;
using ObjectProcessTool.Command;
using ObjectProcessTool.Layer;
using ObjectProcessTool.MapControl;
using ObjectProcessTool.Tool;
using ObjectProcessTool.UI;
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

namespace ObjectProcessTool
{
    public partial class MainForm1 : Form
    {
        public MainForm1()
        {
            InitializeComponent();

            GlobalContainer.Register("dockPanel", dockPanel1);

            InitUI();

            Init();
        }
        MapForm mapForm;

        private void InitUI()
        {
            mapForm = new MapForm();
            mapForm.Show(dockPanel1);


            LayerCtrlForm layerCtrlForm = new LayerCtrlForm();
            layerCtrlForm.Show(dockPanel1, DockState.DockLeft);


            StructureForm structureForm = new StructureForm();
            structureForm.Show(dockPanel1, DockState.DockRight);

           
           

            PropertyForm propertyForm = new PropertyForm();
            //propertyForm.AutoHidePortion = 250 / (double)this.dockPanel1.Width;
            propertyForm.Show(dockPanel1, DockState.DockRight);

           
        }
        private void Init()
        {

           

            CommandManager.Instance.RelationCommand(openshp_ToolStripMenuItem, new OpenShpFileCommand());
            CommandManager.Instance.RelationCommand(openshp_toolStripButton1, new OpenShpFileCommand());
            CommandManager.Instance.RelationCommand(delete_ToolStripMenuItem, new DeleteSobjectCommand());


            CommandManager.Instance.RelationCommand(wgs84To火星ToolStripMenuItem, new CoordtransformCommand("wgs84togcj02"));
            CommandManager.Instance.RelationCommand(火星ToWgs84ToolStripMenuItem, new CoordtransformCommand("gcj02towgs84"));


            //CommandManager.Instance.RelationCommand(shpToOSMToolStripMenuItem, new ShpToOsmCommand());
            CommandManager.Instance.RelationCommand(addattr_ToolStripMenuItem, new AddAttrCommand());
            CommandManager.Instance.RelationCommand(removeNode_ToolStripMenuItem, new RemoveRepeatNodeCommand());

            CommandManager.Instance.RelationCommand(savesobject_ToolStripMenuItem, new SaveSObjectCommand());
            CommandManager.Instance.RelationCommand(showtext_ToolStripMenuItem, new ShowHideSobjectTextCommand());



            ObjectMapBox objectMapBox1 = mapForm.GetMapBox();

            ToolManage.Instance.AddTool(new PanTool(objectMapBox1));
            ToolManage.Instance.AddTool(new QueryTool());
            ToolManage.Instance.AddTool(new MoveNodeTool());


            ToolManage.Instance.CurTool = "PanTool";


            objectMapBox1.MouseDown += ToolManage.Instance.MouseDown;
            objectMapBox1.MouseMove += ToolManage.Instance.MouseMove;
            objectMapBox1.MouseUp += ToolManage.Instance.MouseUp;
            objectMapBox1.MouseDoubleClick += ToolManage.Instance.MouseDoubleClick;




        }



        private void MainForm_Load(object sender, EventArgs e)
        {

        }



        private void exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pan_toolStripButton_Click(object sender, EventArgs e)
        {
            ToolManage.Instance.CurTool = "PanTool";
        }
        private void query_toolStripButton_Click(object sender, EventArgs e)
        {
            ToolManage.Instance.CurTool = "QueryTool";
        }
        private void movenode_toolStripButton_Click(object sender, EventArgs e)
        {
            ToolManage.Instance.CurTool = "MoveNode";
        }
        private void about_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void resetmap_toolStripButton_Click(object sender, EventArgs e)
        {
          
        }


    }
}
