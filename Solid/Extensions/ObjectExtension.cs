using Solid.Foundation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Extensions
{
    static class ObjectExtension
    {
        public static object GetPropValue(this object src, string propName, double value)
        {
            var propertyInfo = src.GetType().GetProperty(propName);
            propertyInfo.SetValue(src, Convert.ChangeType(value, propertyInfo.PropertyType), null);
            return src;
        }

    }
}
