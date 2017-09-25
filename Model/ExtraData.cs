using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class ExtraData
    {
        /// <summary>
        /// The ExtraData identifier.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Whether the object has been modified since constructed.
        /// </summary>
        public bool? Dirty { get; set; }

        /// <summary>
        /// Indicates if this ExtraData is deleted
        /// </summary>
        public bool? Deleted { get; set; }

        /// <summary>
        /// When the ExtraData was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The User Id that created the ExtraData
        /// </summary>
        public int? CreatedBy { get; set; }

        /// <summary>
        /// When the ExtraData was updated.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// User Id that updated the ExtraData
        /// </summary>
        public int? UpdatedBy { get; set; }

        /// <summary>
        /// The ExtraData key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The ExtraData Key Identifier
        /// </summary>
        public int? KeyId { get; set; }

        /// <summary>
        /// The value of the ExtraData
        /// </summary>
        public string Value { get; set; }
    }
}