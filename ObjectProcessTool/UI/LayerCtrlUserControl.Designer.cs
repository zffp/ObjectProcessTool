namespace ObjectProcessTool.UI
{
    partial class LayerCtrlUserControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.python_textBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeLayer_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.converSObject_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layer_treeView = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.python_textBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 322);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 415);
            this.panel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "otype",
            "parent",
            "sdomain"});
            this.comboBox1.Location = new System.Drawing.Point(8, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(268, 26);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "应用";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // python_textBox
            // 
            this.python_textBox.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.python_textBox.Location = new System.Drawing.Point(8, 46);
            this.python_textBox.Multiline = true;
            this.python_textBox.Name = "python_textBox";
            this.python_textBox.Size = new System.Drawing.Size(349, 366);
            this.python_textBox.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeLayer_ToolStripMenuItem,
            this.converSObject_ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 52);
            // 
            // removeLayer_ToolStripMenuItem
            // 
            this.removeLayer_ToolStripMenuItem.Name = "removeLayer_ToolStripMenuItem";
            this.removeLayer_ToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.removeLayer_ToolStripMenuItem.Text = "移除";
            this.removeLayer_ToolStripMenuItem.Click += new System.EventHandler(this.removeLayer_ToolStripMenuItem_Click);
            // 
            // converSObject_ToolStripMenuItem
            // 
            this.converSObject_ToolStripMenuItem.Name = "converSObject_ToolStripMenuItem";
            this.converSObject_ToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.converSObject_ToolStripMenuItem.Text = "转换SObject";
            this.converSObject_ToolStripMenuItem.Click += new System.EventHandler(this.converSObject_ToolStripMenuItem_Click);
            // 
            // layer_treeView
            // 
            this.layer_treeView.CheckBoxes = true;
            this.layer_treeView.ContextMenuStrip = this.contextMenuStrip1;
            this.layer_treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layer_treeView.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.layer_treeView.ItemHeight = 22;
            this.layer_treeView.Location = new System.Drawing.Point(0, 0);
            this.layer_treeView.Name = "layer_treeView";
            this.layer_treeView.Size = new System.Drawing.Size(365, 322);
            this.layer_treeView.TabIndex = 2;
            this.layer_treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.layer_treeView_AfterCheck);
            // 
            // LayerCtrlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layer_treeView);
            this.Controls.Add(this.panel1);
            this.Name = "LayerCtrlUserControl";
            this.Size = new System.Drawing.Size(365, 737);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeLayer_ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox python_textBox;
        private System.Windows.Forms.ToolStripMenuItem converSObject_ToolStripMenuItem;
        private System.Windows.Forms.TreeView layer_treeView;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
