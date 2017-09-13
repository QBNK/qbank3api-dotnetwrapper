using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBankApi.Model
{
    public interface IModelWithPropertySets
    {
        List<PropertySet> PropertySets { get; set; }
    }

    public static class ModelWithPropertySetsExtensions
    {
        public static PropertyResponse TryGetProperty(this IModelWithPropertySets model, string systemName)
        {
            foreach (var set in model.PropertySets)
            {
                foreach (var prop in set.Properties)
                {
                    if (prop.PropertyType.SystemName.Equals(systemName, StringComparison.OrdinalIgnoreCase))
                    {
                        return prop;
                    }
                }
            }

            return null;
        }


        public static PropertyResponse GetProperty(this IModelWithPropertySets model, string systemName)
        {
            var prop = TryGetProperty(model, systemName);

            if (prop == null)
            {
                throw new ArgumentException($"Property with systemName {systemName} was not found.");
            }
            else
            {
                return prop;
            }
        }
    }
}