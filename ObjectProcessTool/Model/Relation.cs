using GeoAPI.Geometries;
using System;
using System.Collections.Generic;
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
