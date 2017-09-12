using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class FolderResponse : Folder, IModelWithPropertySets
	{
        /// <summary>
        /// The Folder identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Folder's children, ie. subfolders.
        /// </summary>
        public List<FolderResponse> SubFolders { get; set; }

        /// <summary>
        /// The saved search of the (filter-)folder.
        /// </summary>
        public SavedSearch SavedSearch { get; set; }

        /// <summary>
        /// The number of objects in this folder
        /// </summary>
        public int ObjectCount { get; set; }

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