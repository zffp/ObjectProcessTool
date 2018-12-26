using Newtonsoft.Json;
using ObjectProcessTool.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Model
{
    public class BaseId
    {
        public long id { get; set; }
        public override string ToString()
        {
            return id.ToString();
        }
    }

    public class BaseName : BaseId
    {
        public string name { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(name))
            {
                return id.ToString();
            }
            return name;
        }
    }
    public class Action : BaseId
    {
        public int operation { get; set; }
    }

    public class Trs : BaseName
    {

        public string content { get; set; }
    }


    public class BAttribute
    {
        public long fid { get; set; }
        public string name { get; set; }
        public string value { get; set; }

        public override string ToString()
        {
            return name;
        }
    }


    public class Form
    {
        public long id { get; set; }
        public long fid { get; set; }
        public long geomref { get; set; }
        public long geotype { get; set; }
        public long type { get; set; }
        public long minGrain { get; set; }
        public long maxGrain { get; set; }
        public string style { get; set; }

        public Entity geom { get; set; }
    }

    public class SObject
    {
        public long id { get; set; }
        public string name { get; set; }
        public List<Action> actions { get; set; }
        public long uuid { get; set; }
        public long from { get; set; }
        public List<BaseId> parents { get; set; }
        public Trs trs { get; set; }
        public Trs srs { get; set; }
        public string code { get; set; }
        public BaseName otype { get; set; }

        public List<BAttribute> attributes { get; set; }

        public string dataRef { get; set; }

        public List<Form> forms { get; set; }

        public long realTime { get; set; }
        public long sdomain { get; set; }

        public List<object> children { get; set; }

        [JsonIgnore]
        public SObjectLayer Layer { get; set; }

        public SObject()
        {
            attributes = new List<BAttribute>();
            forms = new List<Form>();
            actions = new List<Action>();
            parents = new List<BaseId>();
            children = new List<object>();
        }
    }
}

