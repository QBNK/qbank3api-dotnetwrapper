using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class User
    {
        /// <summary>
        /// The User identifier.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The full name of the User.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email-address of the User
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Optional last date this User can log in
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Optional first date this user can start logging in
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// First name of the User
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the User
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Username for the User
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Last login time of the User
        /// </summary>
        public DateTime LastLogin { get; set; }

        /// <summary>
        /// An array of Groups this User is a member of (Note: this will be left as null when listing Users.
        /// </summary>
        public List<Group> Groups { get; set; }

        /// <summary>
        /// Whether the User has been modified since constructed.
        /// </summary>
        public bool? Dirty { get; set; }

        /// <summary>
        /// Indicates if this User is deleted
        /// </summary>
        public bool? Deleted { get; set; }

        /// <summary>
        /// When the User was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The User Id that created the User
        /// </summary>
        public int? CreatedBy { get; set; }

        /// <summary>
        /// When the User was updated.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// User Id that updated the User
        /// </summary>
        public int? UpdatedBy { get; set; }

        /// <summary>
        /// An array of Functionalities connected to this User
        /// </summary>
        public List<Functionality> Functionalities { get; set; }

        /// <summary>
        /// An array of ExtraData connected to this User.
        /// </summary>
        public List<ExtraData> ExtraData { get; set; }

        /// <summary>
        /// Type of user
        /// </summary>
        public string UserType { get; set; }
    }
}