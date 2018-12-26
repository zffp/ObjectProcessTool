using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Model
{
    public class DynamicPropertyDescriptor : PropertyDescriptor
    {
        public override Type ComponentType
        {
            get
            {
                return this.GetType();
            }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type PropertyType
        {
            get
            {
                return propertyType;
            }
        }
        private readonly Dictionary<string, object> businessObject;
        private readonly Type propertyType;

        public DynamicPropertyDescriptor(Dictionary<string, object> businessObject,
            string propertyName, Type propertyType, Attribute[] propertyAttributes)
            : base(propertyName, propertyAttributes)
        {
            this.businessObject = businessObject;
            this.propertyType = propertyType;
        }
        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override object GetValue(object component)
        {
            return businessObject[Name];
        }

        public override void ResetValue(object component)
        {

        }

        public override void SetValue(object component, object value)
        {
            businessObject[Name] = value;
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}
