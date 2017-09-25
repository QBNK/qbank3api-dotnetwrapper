using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class Functionality
    {
        /// <summary>
        /// The Functionality identifier.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The name of the functionality (used programmatically)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of what this functionality means
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether the object has been modified since constructed.
        /// </summary>
        public bool? Dirty { get; set; }

        /// <summary>
        /// Indicates if this Functionality is deleted
        /// </summary>
        public bool? Deleted { get; set; }

        /// <summary>
        /// When the Functionality was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The User Id that created the Functionality
        /// </summary>
        public int? CreatedBy { get; set; }

        /// <summary>
        /// When the Functionality was updated.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// User Id that updated the Functionality
        /// </summary>
        public int? UpdatedBy { get; set; }

        /// <summary>
        /// A title that can be used to show the user
        /// </summary>
        public string Title { get; set; }
    }
}