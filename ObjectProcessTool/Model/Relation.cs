using GeoAPI.Geometries;
using SharpMap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Model
{
    public class Relation : Entity
    {
        public List<Member> Members { get; set; }

        public Relation(long id) : base(id, "Relation")
        {
            Members = new List<Member>();
        }

        private static Brush outpolygonBrush = new SolidBrush(Color.FromArgb(100, 50, 205, 50));

        public override void RenderEntity(Graphics g, Map map)
        {
            var gp = new GraphicsPath(FillMode.Alternate);
            foreach (Member member in Members)
            {
                if (member.RefEntity is Way)
                {
                    Way way = member.RefEntity as Way;

                    Coordinate[] coordinates = way.Geometry.Coordinates;

                    gp.AddPolygon(GeoAPIEx.TransformToImage(coordinates, map));
                }
            }

            g.FillPath(outpolygonBrush, gp);


        }

        public override void CalculationEnvelope()
        {
            Envelope envelope = new Envelope();
            for (int i = 0; i < this.Members.Count; i++)
            {
                Member member = this.Members[i];
                if (member.RefEntity.Envelope == null)
                {
                    member.RefEntity.CalculationEnvelope();

                }
                if (i == 0)
                {
                    envelope = member.RefEntity.Envelope;
                }
                else
                {
                    envelope = envelope.ExpandedBy(member.RefEntity.Envelope);
                }
            }
            this.Envelope = envelope;
        }
    }
}
