using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Model
{
    public class Member
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
        public long RefId { get; set; }

        [JsonProperty("refEntity")]
        public Entity RefEntity { get; set; }

        public Member(string type, string role)
        {
            this.Type = type;
            this.Role = role;
        }

    }
}
