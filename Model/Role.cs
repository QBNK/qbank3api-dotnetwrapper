using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class Role
    {
        /// <summary>
        /// The Role identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the Role
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of what this Role means
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether the object has been modified since constructed.
        /// </summary>
        public bool Dirty { get; set; }

        /// <summary>
        /// Indicates if this Role is deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// When the Role was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The User Id that created the Role
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// When the Role was updated.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// User Id that updated the Role
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// An array of Functionalities connected to this role
        /// </summary>
        public List<Functionality> Functionalities { get; set; }
    }
}