using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class MoodboardResponse : Moodboard, IModelWithPropertySets
    {
        /// <summary>
        /// The Moodboard identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Enduser hash used to identify this moodboard.
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// The base Object identifier.
        /// </summary>
        public int ObjectId { get; set; }

        /// <summary>
        /// When the Object was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The identifier of the User who created the Object.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// When the Object was updated.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Which user that updated the Object.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Whether the object has been modified since constructed.
        /// </summary>
        public bool Dirty { get; set; }

        /// <summary>
        /// The objects PropertySets. This contains all properties with information and values. Use the "properties" parameter when setting properties.
        /// </summary>
        public List<PropertySet> PropertySets { get; set; }
    }
}