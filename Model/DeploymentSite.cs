using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class DeploymentSite
    {
        /// <summary>
        /// The human readable description of the DeploymentSite.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The Protocol used to deploy to the DeploymentSite.
        /// </summary>
        public Protocol Protocol { get; set; }

        /// <summary>
        /// A key-value object with the Protocol specific values.
        /// </summary>
        public object Definition { get; set; }

        /// <summary>
        /// The domain name of the server for the DeploymentSite.
        /// </summary>
        public string Viewserver { get; set; }

        /// <summary>
        /// The url path to were files are accessible for the DeploymentSite.
        /// </summary>
        public string Viewpath { get; set; }

        /// <summary>
        /// The pattern used for naming the files.
        /// </summary>
        public string Namingpattern { get; set; }

        /// <summary>
        /// Whether grouped Media should be deployed.
        /// </summary>
        public bool? Children { get; set; }

        /// <summary>
        /// The color associated with the DeploymentSite as a #-prepended hexadecimal string.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// The connected ImageTemplates.
        /// </summary>
        public List<ImageTemplate> Imagetemplates { get; set; }

        /// <summary>
        /// The connected VideoTemplates.
        /// </summary>
        public List<VideoTemplate> Videotemplates { get; set; }

        /// <summary>
        /// The connected Categories.
        /// </summary>
        public List<CategoryResponse> Categories { get; set; }

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
    }
}