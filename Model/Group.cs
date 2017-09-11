using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class Group
    {
        /// <summary>
        /// The Group identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the Group
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of what this Group means
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether the object has been modified since constructed.
        /// </summary>
        public bool Dirty { get; set; }

        /// <summary>
        /// Indicates if this Group is deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// When the Group was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The User Id that created the Group
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// When the Group was updated.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// User Id that updated the Group
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// An array of Functionalities connected to this Group
        /// </summary>
        public List<Functionality> Functionalities { get; set; }

        /// <summary>
        /// An array of Roles connected to this Group
        /// </summary>
        public List<Role> Roles { get; set; }

        /// <summary>
        /// An array of ExtraData connected to this Group.
        /// </summary>
        public List<ExtraData> ExtraData { get; set; }
    }
}