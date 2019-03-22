using SharpMap;
using SharpMap.Rendering.Decoration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Model
{

    public class LineDecoration : IMapDecoration
    {
        public Point Pt1 { get; set; }
        public Point Pt2 { get; set; }

        static Pen pen = null;

        public void Render(Graphics g, Map map)
        {
            if (pen == null)
            {
                pen = new Pen(Color.Red, 3);
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.ArrowAnchor;

            }

            g.DrawLine(pen, Pt1, Pt2);

        }
    }
}
