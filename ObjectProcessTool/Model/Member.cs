using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Model
{
    public class Member
    {
        public string Type { get; set; }
        public string Role { get; set; }
        public long RefId { get; set; }
        public Entity RefEntity { get; set; }

        public Member(string type, string role)
        {
            this.Type = type;
            this.Role = role;
        }

    }
}
