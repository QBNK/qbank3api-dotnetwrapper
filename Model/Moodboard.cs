using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class Moodboard
    {
        /// <summary>
        /// The pincode used to access this Moodboard.
        /// </summary>
        public string PinCode { get; set; }

        /// <summary>
        /// The template used by the Moodboard.
        /// </summary>
        public int TemplateId { get; set; }

        /// <summary>
        /// The date and time this Moodboard expires.
        /// </summary>
        public DateTime ExpireDate { get; set; }

        /// <summary>
        /// A Key/Value Object containing specific template related settings.
        /// </summary>
        public object Definition { get; set; }

        /// <summary>
        /// Whether this moodboard should notify owner on visits and uploads
        /// </summary>
        public bool VisitNotification { get; set; }

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