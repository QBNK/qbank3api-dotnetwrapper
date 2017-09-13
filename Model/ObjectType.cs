using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class ObjectType : IModelWithPropertySets
    {
        /// <summary>
        /// The name of the ObjectType
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A description of the ObjectType
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The type of Object Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The id of the ObjectType
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// When the ObjectType was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The identifier of the User who created the ObjectType.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// When the ObjectType was updated.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Which user that updated the ObjectType.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// The objects PropertySets. This contains all properties with information and values. Use the "properties" parameter when setting properties.
        /// </summary>
        public List<PropertySet> PropertySets { get; set; }

        /// <summary>
        /// Whether this ObjectType is deleted.
        /// </summary>
        public bool Deleted { get; set; }
    }
}