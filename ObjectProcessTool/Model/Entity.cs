using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using SharpMap;
using SharpMap.Data;
using SharpMap.Rendering.Decoration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Model
{
    public class Entity : ICustomTypeDescriptor, IMapDecoration
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        public short flag { get; set; }

        public string type { get; set; }

        [JsonIgnore]
        public SObject SObject { get; set; }

        [JsonIgnore]
        public Graph Graph { get; set; }

        [JsonProperty("tags")]
        public Dictionary<string, object> Tags { get; set; }

        [JsonIgnore]
        public Geometry Geometry { get; set; }

        [JsonIgnore]
        public bool IsObject
        {
            get
            {
                return Convert.ToBoolean(this.GetTagValue("isObject", false));
            }
        }

        public Entity(FeatureDataRow featureDataRow)
        {
            Tags = new Dictionary<string, object>();

            foreach (DataColumn dataColumn in featureDataRow.Table.Columns)
            {
                Tags.Add(dataColumn.ColumnName, featureDataRow[dataColumn.ColumnName]);
            }
            Geometry = featureDataRow.Geometry as Geometry;
        }

        public Entity(long id, string type)
        {
            this.Id = id;
            this.type = type;
            this.flag = 1;
            Tags = new Dictionary<string, object>();
            Tags.Add("Id", this.Id);
        }

        public virtual void RenderEntity(Graphics g, Map map)
        {

        }
        public virtual void Render(Graphics g, Map map)
        {

        }



        public object GetTagValue(string key, object defaultValue)
        {
            if (Tags.ContainsKey(key))
            {
                return Tags[key];
            }
            return defaultValue;
        }

        public int GetGeoType()
        {
            if (this is Node)
            {
                return 21;
            }
            else if (this is Way)
            {
                Way way = this as Way;
                bool isArea = Convert.ToBoolean(GetTagValue("area", false));
                if (isArea)
                {
                    return 23;
                }
                else
                {
                    return 21;
                }
            }
            return 0;
        }

        #region ICustomTypeDescriptor

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return TypeDescriptor.GetProperties(this, true);

        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var properties = Tags
                .Select(pair => new DynamicPropertyDescriptor(this.Tags,
                    pair.Key, pair.Value.GetType(), attributes)).ToList();


            return new PropertyDescriptorCollection(properties.ToArray());
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }



        #endregion

    }
}
