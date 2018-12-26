using GeoAPI.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectProcessTool.Tool
{
    abstract public class AbstractTool : ITool
    {
        abstract public string Name { get; }
        virtual public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }
        public List<ToolStripItem> ToolStripButtons { get; set; }

        virtual public void Active()
        {
            if (ToolStripButtons != null)
                ToolStripButtons.ForEach(r =>
                {
                    if (r is ToolStripMenuItem)
                    {
                        (r as ToolStripMenuItem).Checked = true;
                    }
                    else if (r is ToolStripButton)
                    {
                        (r as ToolStripButton).Checked = true;
                    }
                });
        }
        virtual public void UnActive()
        {
            if (ToolStripButtons != null)
                ToolStripButtons.ForEach(r =>
                {
                    if (r is ToolStripMenuItem)
                    {
                        (r as ToolStripMenuItem).Checked = false;
                    }
                    else if (r is ToolStripButton)
                    {
                        (r as ToolStripButton).Checked = false;
                    }
                });
        }
        virtual public void MouseDown(Coordinate worldPos, MouseEventArgs imagePos)
        {

        }
        virtual public void MouseMove(Coordinate worldPos, MouseEventArgs imagePos)
        {
        }
        virtual public void MouseUp(Coordinate worldPos, MouseEventArgs imagePos)
        {
        }
        virtual public void MouseDoubleClick(Coordinate worldPos, MouseEventArgs imagePos)
        {
        }
    }
}
