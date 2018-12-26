namespace ObjectProcessTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openshp_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savesobject_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.转换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shpToSobjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addattr_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNode_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showtext_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.about_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.letf_panel = new System.Windows.Forms.Panel();
            this.layerCtrlUserControl1 = new ObjectProcessTool.UI.LayerCtrlUserControl();
            this.right_panel = new System.Windows.Forms.Panel();
            this.propertyUserControl1 = new ObjectProcessTool.UI.PropertyUserControl();
            this.main_panel = new System.Windows.Forms.Panel();
            this.objectMapBox1 = new ObjectProcessTool.MapControl.ObjectMapBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openshp_toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.resetmap_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pan_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.query_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.movenode_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.letf_panel.SuspendLayout();
            this.right_panel.SuspendLayout();
            this.main_panel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.转换ToolStripMenuItem,
            this.操作ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1229, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openshp_ToolStripMenuItem,
            this.savesobject_ToolStripMenuItem,
            this.exit_ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // openshp_ToolStripMenuItem
            // 
            this.openshp_ToolStripMenuItem.Name = "openshp_ToolStripMenuItem";
            this.openshp_ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.openshp_ToolStripMenuItem.Text = "打开SHP";
            // 
            // savesobject_ToolStripMenuItem
            // 
            this.savesobject_ToolStripMenuItem.Name = "savesobject_ToolStripMenuItem";
            this.savesobject_ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.savesobject_ToolStripMenuItem.Text = "保存对象";
            // 
            // exit_ToolStripMenuItem
            // 
            this.exit_ToolStripMenuItem.Name = "exit_ToolStripMenuItem";
            this.exit_ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.exit_ToolStripMenuItem.Text = "退出";
            this.exit_ToolStripMenuItem.Click += new System.EventHandler(this.exit_ToolStripMenuItem_Click);
            // 
            // 转换ToolStripMenuItem
            // 
            this.转换ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shpToSobjectToolStripMenuItem});
            this.转换ToolStripMenuItem.Name = "转换ToolStripMenuItem";
            this.转换ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.转换ToolStripMenuItem.Text = "转换";
            // 
            // shpToSobjectToolStripMenuItem
            // 
            this.shpToSobjectToolStripMenuItem.Name = "shpToSobjectToolStripMenuItem";
            this.shpToSobjectToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.shpToSobjectToolStripMenuItem.Text = "ShpToSobject";
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addattr_ToolStripMenuItem,
            this.removeNode_ToolStripMenuItem,
            this.showtext_ToolStripMenuItem});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.操作ToolStripMenuItem.Text = "操作";
            // 
            // addattr_ToolStripMenuItem
            // 
            this.addattr_ToolStripMenuItem.Name = "addattr_ToolStripMenuItem";
            this.addattr_ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.addattr_ToolStripMenuItem.Text = "添加属性";
            // 
            // removeNode_ToolStripMenuItem
            // 
            this.removeNode_ToolStripMenuItem.Name = "removeNode_ToolStripMenuItem";
            this.removeNode_ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.removeNode_ToolStripMenuItem.Text = "去除重复点";
            // 
            // showtext_ToolStripMenuItem
            // 
            this.showtext_ToolStripMenuItem.Name = "showtext_ToolStripMenuItem";
            this.showtext_ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.showtext_ToolStripMenuItem.Text = "显示隐藏注记";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about_ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // about_ToolStripMenuItem
            // 
            this.about_ToolStripMenuItem.Name = "about_ToolStripMenuItem";
            this.about_ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.about_ToolStripMenuItem.Text = "关于";
            this.about_ToolStripMenuItem.Click += new System.EventHandler(this.about_ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 790);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1229, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // letf_panel
            // 
            this.letf_panel.BackColor = System.Drawing.Color.White;
            this.letf_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.letf_panel.Controls.Add(this.layerCtrlUserControl1);
            this.letf_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.letf_panel.Location = new System.Drawing.Point(0, 55);
            this.letf_panel.Name = "letf_panel";
            this.letf_panel.Size = new System.Drawing.Size(379, 735);
            this.letf_panel.TabIndex = 2;
            // 
            // layerCtrlUserControl1
            // 
            this.layerCtrlUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layerCtrlUserControl1.Location = new System.Drawing.Point(0, 0);
            this.layerCtrlUserControl1.Name = "layerCtrlUserControl1";
            this.layerCtrlUserControl1.Size = new System.Drawing.Size(377, 733);
            this.layerCtrlUserControl1.TabIndex = 0;
            // 
            // right_panel
            // 
            this.right_panel.BackColor = System.Drawing.Color.White;
            this.right_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.right_panel.Controls.Add(this.propertyUserControl1);
            this.right_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.right_panel.Location = new System.Drawing.Point(849, 55);
            this.right_panel.Name = "right_panel";
            this.right_panel.Size = new System.Drawing.Size(380, 735);
            this.right_panel.TabIndex = 3;
            // 
            // propertyUserControl1
            // 
            this.propertyUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyUserControl1.Location = new System.Drawing.Point(0, 0);
            this.propertyUserControl1.Name = "propertyUserControl1";
            this.propertyUserControl1.Size = new System.Drawing.Size(378, 733);
            this.propertyUserControl1.TabIndex = 0;
            // 
            // main_panel
            // 
            this.main_panel.Controls.Add(this.objectMapBox1);
            this.main_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_panel.Location = new System.Drawing.Point(379, 55);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(470, 735);
            this.main_panel.TabIndex = 4;
            // 
            // objectMapBox1
            // 
            this.objectMapBox1.ActiveTool = ObjectProcessTool.MapControl.ObjectMapBox.Tools.None;
            this.objectMapBox1.BackColor = System.Drawing.Color.White;
            this.objectMapBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectMapBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectMapBox1.FineZoomFactor = 10D;
            this.objectMapBox1.Location = new System.Drawing.Point(0, 0);
            this.objectMapBox1.MapQueryMode = ObjectProcessTool.MapControl.ObjectMapBox.MapQueryType.LayerByIndex;
            this.objectMapBox1.Name = "objectMapBox1";
            this.objectMapBox1.QueryGrowFactor = 5F;
            this.objectMapBox1.QueryLayerIndex = 0;
            this.objectMapBox1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.objectMapBox1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.objectMapBox1.ShowProgressUpdate = false;
            this.objectMapBox1.Size = new System.Drawing.Size(470, 735);
            this.objectMapBox1.TabIndex = 0;
            this.objectMapBox1.Text = "objectMapBox1";
            this.objectMapBox1.WheelZoomMagnitude = -2D;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openshp_toolStripButton1,
            this.resetmap_toolStripButton,
            this.pan_toolStripButton,
            this.query_toolStripButton,
            this.movenode_toolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1229, 27);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openshp_toolStripButton1
            // 
            this.openshp_toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openshp_toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("openshp_toolStripButton1.Image")));
            this.openshp_toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openshp_toolStripButton1.Name = "openshp_toolStripButton1";
            this.openshp_toolStripButton1.Size = new System.Drawing.Size(73, 24);
            this.openshp_toolStripButton1.Text = "打开SHP";
            // 
            // resetmap_toolStripButton
            // 
            this.resetmap_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.resetmap_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("resetmap_toolStripButton.Image")));
            this.resetmap_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetmap_toolStripButton.Name = "resetmap_toolStripButton";
            this.resetmap_toolStripButton.Size = new System.Drawing.Size(43, 24);
            this.resetmap_toolStripButton.Text = "全图";
            this.resetmap_toolStripButton.Click += new System.EventHandler(this.resetmap_toolStripButton_Click);
            // 
            // pan_toolStripButton
            // 
            this.pan_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.pan_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pan_toolStripButton.Image")));
            this.pan_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pan_toolStripButton.Name = "pan_toolStripButton";
            this.pan_toolStripButton.Size = new System.Drawing.Size(43, 24);
            this.pan_toolStripButton.Text = "漫游";
            this.pan_toolStripButton.Click += new System.EventHandler(this.pan_toolStripButton_Click);
            // 
            // query_toolStripButton
            // 
            this.query_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.query_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("query_toolStripButton.Image")));
            this.query_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.query_toolStripButton.Name = "query_toolStripButton";
            this.query_toolStripButton.Size = new System.Drawing.Size(43, 24);
            this.query_toolStripButton.Text = "查询";
            this.query_toolStripButton.Click += new System.EventHandler(this.query_toolStripButton_Click);
            // 
            // movenode_toolStripButton
            // 
            this.movenode_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.movenode_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("movenode_toolStripButton.Image")));
            this.movenode_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.movenode_toolStripButton.Name = "movenode_toolStripButton";
            this.movenode_toolStripButton.Size = new System.Drawing.Size(73, 24);
            this.movenode_toolStripButton.Text = "移动节点";
            this.movenode_toolStripButton.Click += new System.EventHandler(this.movenode_toolStripButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 812);
            this.Controls.Add(this.main_panel);
            this.Controls.Add(this.right_panel);
            this.Controls.Add(this.letf_panel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "对象化数据处理工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.letf_panel.ResumeLayout(false);
            this.right_panel.ResumeLayout(false);
            this.main_panel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem exit_ToolStripMenuItem;
        private System.Windows.Forms.Panel letf_panel;
        private System.Windows.Forms.Panel right_panel;
        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem openshp_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savesobject_ToolStripMenuItem;
        private MapControl.ObjectMapBox objectMapBox1;
        private System.Windows.Forms.ToolStripButton pan_toolStripButton;
        private System.Windows.Forms.ToolStripMenuItem about_ToolStripMenuItem;
        private UI.LayerCtrlUserControl layerCtrlUserControl1;
        private System.Windows.Forms.ToolStripButton resetmap_toolStripButton;
        private System.Windows.Forms.ToolStripButton query_toolStripButton;
        private UI.PropertyUserControl propertyUserControl1;
        private System.Windows.Forms.ToolStripMenuItem 转换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addattr_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeNode_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shpToSobjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showtext_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton openshp_toolStripButton1;
        private System.Windows.Forms.ToolStripButton movenode_toolStripButton;
    }
}

