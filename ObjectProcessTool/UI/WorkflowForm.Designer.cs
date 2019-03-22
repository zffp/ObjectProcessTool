namespace ObjectProcessTool.UI
{
    partial class WorkflowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加处理节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加SHP文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectMapBox1 = new ObjectProcessTool.MapControl.ObjectMapBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.propertyGrid1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(595, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 678);
            this.panel1.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(363, 678);
            this.propertyGrid1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.objectMapBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(595, 678);
            this.panel2.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加SHP文件ToolStripMenuItem,
            this.添加处理节点ToolStripMenuItem,
            this.删除节点ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 76);
            // 
            // 添加处理节点ToolStripMenuItem
            // 
            this.添加处理节点ToolStripMenuItem.Name = "添加处理节点ToolStripMenuItem";
            this.添加处理节点ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.添加处理节点ToolStripMenuItem.Text = "添加处理节点";
            this.添加处理节点ToolStripMenuItem.Click += new System.EventHandler(this.添加处理节点ToolStripMenuItem_Click);
            // 
            // 删除节点ToolStripMenuItem
            // 
            this.删除节点ToolStripMenuItem.Name = "删除节点ToolStripMenuItem";
            this.删除节点ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.删除节点ToolStripMenuItem.Text = "删除节点";
            this.删除节点ToolStripMenuItem.Click += new System.EventHandler(this.删除节点ToolStripMenuItem_Click);
            // 
            // 添加SHP文件ToolStripMenuItem
            // 
            this.添加SHP文件ToolStripMenuItem.Name = "添加SHP文件ToolStripMenuItem";
            this.添加SHP文件ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.添加SHP文件ToolStripMenuItem.Text = "添加SHP文件";
            this.添加SHP文件ToolStripMenuItem.Click += new System.EventHandler(this.添加SHP文件ToolStripMenuItem_Click);
            // 
            // objectMapBox1
            // 
            this.objectMapBox1.ActiveTool = ObjectProcessTool.MapControl.ObjectMapBox.Tools.None;
            this.objectMapBox1.ContextMenuStrip = this.contextMenuStrip1;
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
            this.objectMapBox1.Size = new System.Drawing.Size(595, 678);
            this.objectMapBox1.TabIndex = 0;
            this.objectMapBox1.Text = "objectMapBox1";
            this.objectMapBox1.WheelZoomMagnitude = -2D;
            // 
            // WorkflowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 678);
            this.CloseButton = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Name = "WorkflowForm";
            this.TabText = "批处理";
            this.Text = "批处理";
            this.Load += new System.EventHandler(this.Workflow_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel2;
        private MapControl.ObjectMapBox objectMapBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加处理节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加SHP文件ToolStripMenuItem;
    }
}