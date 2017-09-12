using RestSharp;
using System.Collections.Generic;
using System;
using System.Linq;


namespace QBankApi.Model
{
    public class PropertyResponse
    {
        /// <summary>
        /// When the Property was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The identifier of the User who created the Property.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// When the Property was updated.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Which user who updated the Property.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Whether the Property is deleted.
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Whether the Property has been modified since constructed.
        /// </summary>
        public bool Dirty { get; set; }

        /// <summary>
        /// The PropertyType describing this Property.
        /// </summary>
        public PropertyType PropertyType { get; set; }

        /// <summary>
        /// The value of the Property.
        /// </summary>
        public object Value { get; set; }


        public T GetValue<T>()
        {
            if (Type.GetTypeCode(typeof(T)) == TypeCode.DateTime)
            {
                return (T) (object) Convert.ToDateTime(Value);
            }
			
	        if (Value is T)
		        return (T) Value;
	        else
		        return default(T);
        }

        public List<T> GetValueArray<T>()
        {
	        List<T> list = null;
            var array = Value as JsonArray;
	        if (array == null)
	        {
		        var typedValue = GetValue<T>();
				if (typedValue != null)
				list = new List<T>() { typedValue };
	        }
			else
            {
				list = new List<T>(from Dictionary<string, object> value in array where value["value"] is T select (T) value["value"]);
            }
            return list ?? new List<T>();
        }
    }
}