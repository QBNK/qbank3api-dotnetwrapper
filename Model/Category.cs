using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class Category
    {
        /// <summary>
        /// The ObjectType identifier Media belonging to this Category should have.
        /// </summary>
        public int MediaTypeId { get; set; }

        /// <summary>
        /// An optional description for the category
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The Objects name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether the object is deleted.
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// A systemName => value array of properties. This is only used when updating an object. See the "propertySets" parameter for complete properties when fetching an object.
        /// </summary>
        public List<string> Properties { get; set; }

        /// <summary>
        /// The identifier of the ObjectType describing the propertysets this object should use.
        /// </summary>
        public int TypeId { get; set; }
    }
}