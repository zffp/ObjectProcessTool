namespace ObjectProcessTool
{
    partial class MainForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openshp_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savesobject_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.转换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delete_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addattr_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNode_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showtext_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wgs84To火星ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.火星ToWgs84ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.about_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openshp_toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.resetmap_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pan_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.query_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.movenode_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.menuStrip1.SuspendLayout();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(922, 25);
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
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // openshp_ToolStripMenuItem
            // 
            this.openshp_ToolStripMenuItem.Name = "openshp_ToolStripMenuItem";
            this.openshp_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openshp_ToolStripMenuItem.Text = "打开SHP";
            // 
            // savesobject_ToolStripMenuItem
            // 
            this.savesobject_ToolStripMenuItem.Name = "savesobject_ToolStripMenuItem";
            this.savesobject_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.savesobject_ToolStripMenuItem.Text = "保存对象";
            // 
            // exit_ToolStripMenuItem
            // 
            this.exit_ToolStripMenuItem.Name = "exit_ToolStripMenuItem";
            this.exit_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.exit_ToolStripMenuItem.Text = "退出";
            this.exit_ToolStripMenuItem.Click += new System.EventHandler(this.exit_ToolStripMenuItem_Click);
            // 
            // 转换ToolStripMenuItem
            // 
            this.转换ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delete_ToolStripMenuItem});
            this.转换ToolStripMenuItem.Name = "转换ToolStripMenuItem";
            this.转换ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.转换ToolStripMenuItem.Text = "编辑";
            // 
            // delete_ToolStripMenuItem
            // 
            this.delete_ToolStripMenuItem.Name = "delete_ToolStripMenuItem";
            this.delete_ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.delete_ToolStripMenuItem.Text = "删除";
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addattr_ToolStripMenuItem,
            this.removeNode_ToolStripMenuItem,
            this.showtext_ToolStripMenuItem,
            this.wgs84To火星ToolStripMenuItem,
            this.火星ToWgs84ToolStripMenuItem});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.操作ToolStripMenuItem.Text = "操作";
            // 
            // addattr_ToolStripMenuItem
            // 
            this.addattr_ToolStripMenuItem.Name = "addattr_ToolStripMenuItem";
            this.addattr_ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addattr_ToolStripMenuItem.Text = "添加属性";
            // 
            // removeNode_ToolStripMenuItem
            // 
            this.removeNode_ToolStripMenuItem.Name = "removeNode_ToolStripMenuItem";
            this.removeNode_ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.removeNode_ToolStripMenuItem.Text = "去除重复点";
            // 
            // showtext_ToolStripMenuItem
            // 
            this.showtext_ToolStripMenuItem.Name = "showtext_ToolStripMenuItem";
            this.showtext_ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.showtext_ToolStripMenuItem.Text = "显示隐藏注记";
            // 
            // wgs84To火星ToolStripMenuItem
            // 
            this.wgs84To火星ToolStripMenuItem.Name = "wgs84To火星ToolStripMenuItem";
            this.wgs84To火星ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.wgs84To火星ToolStripMenuItem.Text = "Wgs84To火星";
            // 
            // 火星ToWgs84ToolStripMenuItem
            // 
            this.火星ToWgs84ToolStripMenuItem.Name = "火星ToWgs84ToolStripMenuItem";
            this.火星ToWgs84ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.火星ToWgs84ToolStripMenuItem.Text = "火星ToWgs84";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about_ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // about_ToolStripMenuItem
            // 
            this.about_ToolStripMenuItem.Name = "about_ToolStripMenuItem";
            this.about_ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.about_ToolStripMenuItem.Text = "关于";
            this.about_ToolStripMenuItem.Click += new System.EventHandler(this.about_ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 628);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(922, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(922, 27);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openshp_toolStripButton1
            // 
            this.openshp_toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("openshp_toolStripButton1.Image")));
            this.openshp_toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openshp_toolStripButton1.Name = "openshp_toolStripButton1";
            this.openshp_toolStripButton1.Size = new System.Drawing.Size(79, 24);
            this.openshp_toolStripButton1.Text = "打开SHP";
            // 
            // resetmap_toolStripButton
            // 
            this.resetmap_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("resetmap_toolStripButton.Image")));
            this.resetmap_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetmap_toolStripButton.Name = "resetmap_toolStripButton";
            this.resetmap_toolStripButton.Size = new System.Drawing.Size(56, 24);
            this.resetmap_toolStripButton.Text = "全图";
            this.resetmap_toolStripButton.Click += new System.EventHandler(this.resetmap_toolStripButton_Click);
            // 
            // pan_toolStripButton
            // 
            this.pan_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pan_toolStripButton.Image")));
            this.pan_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pan_toolStripButton.Name = "pan_toolStripButton";
            this.pan_toolStripButton.Size = new System.Drawing.Size(56, 24);
            this.pan_toolStripButton.Text = "漫游";
            this.pan_toolStripButton.Click += new System.EventHandler(this.pan_toolStripButton_Click);
            // 
            // query_toolStripButton
            // 
            this.query_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.query_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("query_toolStripButton.Image")));
            this.query_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.query_toolStripButton.Name = "query_toolStripButton";
            this.query_toolStripButton.Size = new System.Drawing.Size(36, 24);
            this.query_toolStripButton.Text = "查询";
            this.query_toolStripButton.Click += new System.EventHandler(this.query_toolStripButton_Click);
            // 
            // movenode_toolStripButton
            // 
            this.movenode_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.movenode_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("movenode_toolStripButton.Image")));
            this.movenode_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.movenode_toolStripButton.Name = "movenode_toolStripButton";
            this.movenode_toolStripButton.Size = new System.Drawing.Size(60, 24);
            this.movenode_toolStripButton.Text = "移动节点";
            this.movenode_toolStripButton.Click += new System.EventHandler(this.movenode_toolStripButton_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockLeftPortion = 300D;
            this.dockPanel1.DockRightPortion = 300D;
            this.dockPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanel1.Location = new System.Drawing.Point(0, 52);
            this.dockPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(922, 576);
            this.dockPanel1.TabIndex = 6;
            // 
            // MainForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 650);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "对象化数据处理工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem openshp_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savesobject_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton pan_toolStripButton;
        private System.Windows.Forms.ToolStripMenuItem about_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton resetmap_toolStripButton;
        private System.Windows.Forms.ToolStripButton query_toolStripButton;
        private System.Windows.Forms.ToolStripMenuItem 转换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addattr_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeNode_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showtext_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton openshp_toolStripButton1;
        private System.Windows.Forms.ToolStripButton movenode_toolStripButton;
        private System.Windows.Forms.ToolStripMenuItem delete_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wgs84To火星ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 火星ToWgs84ToolStripMenuItem;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
    }
}

