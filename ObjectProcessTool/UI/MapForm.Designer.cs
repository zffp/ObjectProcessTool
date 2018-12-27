namespace ObjectProcessTool.UI
{
    partial class MapForm
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
            this.objectMapBox1 = new ObjectProcessTool.MapControl.ObjectMapBox();
            this.SuspendLayout();
            // 
            // objectMapBox1
            // 
            this.objectMapBox1.ActiveTool = ObjectProcessTool.MapControl.ObjectMapBox.Tools.None;
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
            this.objectMapBox1.Size = new System.Drawing.Size(800, 450);
            this.objectMapBox1.TabIndex = 0;
            this.objectMapBox1.Text = "objectMapBox1";
            this.objectMapBox1.WheelZoomMagnitude = -2D;
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.CloseButton = false;
            this.Controls.Add(this.objectMapBox1);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Name = "MapForm";
            this.TabText = "对象地图";
            this.Text = "对象地图";
            this.Load += new System.EventHandler(this.MapForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MapControl.ObjectMapBox objectMapBox1;
    }
}