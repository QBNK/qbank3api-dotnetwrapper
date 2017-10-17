using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class MediaResponse : Media, IModelWithPropertySets
    {
        /// <summary>
        /// The Media identifier.
        /// </summary>
        public int? MediaId { get; set; }

        /// <summary>
        /// Indicates if this Media has a thumbnail, preview and/or if they have been changed. This is a bit field, with the following values currently in use; Has thumbnail = 0b00000001; Has preview = 0b00000010; Thumbnail changed = 0b00000100; Preview changed = 0b00001000;
        /// </summary>
        public int? ThumbPreviewStatus { get; set; }

        /// <summary>
        /// The Media's filename extension.
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// The MetaData extracted from the Media file.
        /// </summary>
        public List<MetaData> Metadata { get; set; }

        /// <summary>
        /// The Media MimeType.
        /// </summary>
        public MimeType Mimetype { get; set; }

        /// <summary>
        /// The Media size in bytes.
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// The Media status identifier.
        /// </summary>
        public int? StatusId { get; set; }

        /// <summary>
        /// When the Media was uploaded. A datetime string on the format ISO8601.
        /// </summary>
        public DateTime Uploaded { get; set; }

        /// <summary>
        /// The identifier of the User who uploaded the Media.
        /// </summary>
        public int? UploadedBy { get; set; }

        /// <summary>
        /// An array of deployed files
        /// </summary>
        public List<DeploymentFile> DeployedFiles { get; set; }

        /// <summary>
        /// Number of comments made on this media
        /// </summary>
        public int? CommentCount { get; set; }

        /// <summary>
        /// The rating for this media
        /// </summary>
        public int? Rating { get; set; }

        /// <summary>
        /// An array of Media
        /// </summary>
        public List<MediaResponse> ChildMedias { get; set; }

        /// <summary>
        /// The Category identifier of the Category the Media belongs to.
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// The Media's filename.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// The Media parent Media identifier. Only set when the Media is grouped.
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// The Media replacement Media identifier. Only set when the Media has been replaced, ie. versioning.
        /// </summary>
        public int? ReplacedBy { get; set; }

        /// <summary>
        /// The Objects name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether the object is deleted.
        /// </summary>
        public bool? Deleted { get; set; }

        /// <summary>
        /// A systemName => value array of properties. This is only used when updating an object. See the "propertySets" parameter for complete properties when fetching an object.
        /// </summary>
        public List<string> Properties { get; set; }

        /// <summary>
        /// The identifier of the ObjectType describing the propertysets this object should use.
        /// </summary>
        public int? TypeId { get; set; }

        /// <summary>
        /// The base Object identifier.
        /// </summary>
        public int? ObjectId { get; set; }

        /// <summary>
        /// When the Object was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The identifier of the User who created the Object.
        /// </summary>
        public int? CreatedBy { get; set; }

        /// <summary>
        /// When the Object was updated.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Which user that updated the Object.
        /// </summary>
        public int? UpdatedBy { get; set; }

        /// <summary>
        /// Whether the object has been modified since constructed.
        /// </summary>
        public bool? Dirty { get; set; }

        /// <summary>
        /// The objects PropertySets. This contains all properties with information and values. Use the "properties" parameter when setting properties.
        /// </summary>
        public List<PropertySet> PropertySets { get; set; }
    }
}