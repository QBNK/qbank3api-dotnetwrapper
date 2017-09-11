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
        public object Value { internal get; set; }


        public T getValue<T>()
        {
            if (Type.GetTypeCode(typeof(T)) == TypeCode.DateTime)
            {
                return (T) (object) Convert.ToDateTime(Value);
            }

            return (T) Value;
        }

        public List<T> getArrayProperty<T>()
        {
            var list = new List<T>();
            var array = Value as JsonArray;
            if (array != null)
            {
                list.AddRange(from Dictionary<string, object> value in array select (T) value["value"]);
            }
            return list;
        }
    }
}