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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeLayer_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setparent_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setsdomain_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setrealTime_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setotype_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.python_textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.python_textBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 389);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 348);
            this.panel1.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(365, 389);
            this.checkedListBox1.TabIndex = 1;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeLayer_ToolStripMenuItem,
            this.setparent_ToolStripMenuItem,
            this.setsdomain_ToolStripMenuItem,
            this.setrealTime_ToolStripMenuItem,
            this.setotype_ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 124);
            // 
            // removeLayer_ToolStripMenuItem
            // 
            this.removeLayer_ToolStripMenuItem.Name = "removeLayer_ToolStripMenuItem";
            this.removeLayer_ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.removeLayer_ToolStripMenuItem.Text = "移除";
            this.removeLayer_ToolStripMenuItem.Click += new System.EventHandler(this.removeLayer_ToolStripMenuItem_Click);
            // 
            // setparent_ToolStripMenuItem
            // 
            this.setparent_ToolStripMenuItem.Name = "setparent_ToolStripMenuItem";
            this.setparent_ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.setparent_ToolStripMenuItem.Text = "设置父对象";
            this.setparent_ToolStripMenuItem.Click += new System.EventHandler(this.setparent_ToolStripMenuItem_Click);
            // 
            // setsdomain_ToolStripMenuItem
            // 
            this.setsdomain_ToolStripMenuItem.Name = "setsdomain_ToolStripMenuItem";
            this.setsdomain_ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.setsdomain_ToolStripMenuItem.Text = "设置时空域";
            this.setsdomain_ToolStripMenuItem.Click += new System.EventHandler(this.setsdomain_ToolStripMenuItem_Click);
            // 
            // setrealTime_ToolStripMenuItem
            // 
            this.setrealTime_ToolStripMenuItem.Name = "setrealTime_ToolStripMenuItem";
            this.setrealTime_ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.setrealTime_ToolStripMenuItem.Text = "设置RealTime";
            // 
            // setotype_ToolStripMenuItem
            // 
            this.setotype_ToolStripMenuItem.Name = "setotype_ToolStripMenuItem";
            this.setotype_ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.setotype_ToolStripMenuItem.Text = "设置OType";
            this.setotype_ToolStripMenuItem.Click += new System.EventHandler(this.setotype_ToolStripMenuItem_Click);
            // 
            // python_textBox
            // 
            this.python_textBox.Location = new System.Drawing.Point(8, 6);
            this.python_textBox.Multiline = true;
            this.python_textBox.Name = "python_textBox";
            this.python_textBox.Size = new System.Drawing.Size(349, 300);
            this.python_textBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "应用";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LayerCtrlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkedListBox1);
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
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeLayer_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setparent_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setsdomain_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setrealTime_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setotype_ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox python_textBox;
    }
}
