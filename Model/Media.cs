using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class Media
    {
        /// <summary>
        /// The Category identifier of the Category the Media belongs to.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// The Media's filename.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// The Media parent Media identifier. Only set when the Media is grouped.
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// The Media replacement Media identifier. Only set when the Media has been replaced, ie. versioning.
        /// </summary>
        public int ReplacedBy { get; set; }

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