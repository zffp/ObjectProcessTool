namespace ObjectProcessTool.UI
{
    partial class PropertyForm
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
            this.propertyUserControl1 = new ObjectProcessTool.UI.PropertyUserControl();
            this.SuspendLayout();
            // 
            // propertyUserControl1
            // 
            this.propertyUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyUserControl1.Location = new System.Drawing.Point(0, 0);
            this.propertyUserControl1.Name = "propertyUserControl1";
            this.propertyUserControl1.Size = new System.Drawing.Size(399, 795);
            this.propertyUserControl1.TabIndex = 0;
            // 
            // PropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 795);
            this.Controls.Add(this.propertyUserControl1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Name = "PropertyForm";
            this.TabText = "属性";
            this.Text = "属性";
            this.ResumeLayout(false);

        }

        #endregion

        private PropertyUserControl propertyUserControl1;
    }
}