namespace ObjectProcessTool.UI
{
    partial class ImportSetForm
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.python_textBox = new System.Windows.Forms.TextBox();
            this.tag_comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.importlayer_textBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.save_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(747, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "验证";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(828, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // python_textBox
            // 
            this.python_textBox.Location = new System.Drawing.Point(12, 86);
            this.python_textBox.Multiline = true;
            this.python_textBox.Name = "python_textBox";
            this.python_textBox.Size = new System.Drawing.Size(891, 385);
            this.python_textBox.TabIndex = 1;
            // 
            // tag_comboBox
            // 
            this.tag_comboBox.FormattingEnabled = true;
            this.tag_comboBox.Location = new System.Drawing.Point(468, 28);
            this.tag_comboBox.Name = "tag_comboBox";
            this.tag_comboBox.Size = new System.Drawing.Size(257, 23);
            this.tag_comboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(398, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "目标图层";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "转换脚本";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "导入图层";
            // 
            // importlayer_textBox
            // 
            this.importlayer_textBox.Enabled = false;
            this.importlayer_textBox.Location = new System.Drawing.Point(92, 25);
            this.importlayer_textBox.Name = "importlayer_textBox";
            this.importlayer_textBox.Size = new System.Drawing.Size(300, 25);
            this.importlayer_textBox.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(92, 54);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(300, 26);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(678, 54);
            this.save_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(63, 28);
            this.save_button.TabIndex = 6;
            this.save_button.Text = "保存";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // ImportSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 536);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.importlayer_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tag_comboBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.python_textBox);
            this.Controls.Add(this.button1);
            this.Name = "ImportSetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入设置";
            this.Load += new System.EventHandler(this.ImportSetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox python_textBox;
        private System.Windows.Forms.ComboBox tag_comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox importlayer_textBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button save_button;
    }
}