using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class PropertyResponse : RestResponse
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
        public string Value { get; set; }
    }
}