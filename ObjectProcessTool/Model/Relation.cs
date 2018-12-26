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
    }
}
