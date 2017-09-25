using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class PropertySet
    {
        /// <summary>
        /// The PropertySet identifier
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The PropertySet name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// When the PropertySet was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The identifier of the User who created the PropertySet.
        /// </summary>
        public int? CreatedBy { get; set; }

        /// <summary>
        /// When the PropertySet was updated.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Which user who updated the PropertySet.
        /// </summary>
        public int? UpdatedBy { get; set; }

        /// <summary>
        /// Whether the PropertySet is deleted.
        /// </summary>
        public bool? Deleted { get; set; }

        /// <summary>
        /// Whether the PropertySet has been modified since constructed.
        /// </summary>
        public bool? Dirty { get; set; }

        /// <summary>
        /// Wheater the PropertySet is a system propertyset or not. (System propertysets are hidden from the enduser)
        /// </summary>
        public bool? System { get; set; }

        /// <summary>
        /// The Properties associated with the PropertySet.
        /// </summary>
        public List<PropertyResponse> Properties { get; set; }
    }
}