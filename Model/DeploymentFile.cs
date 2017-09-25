using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class DeploymentFile
    {
        /// <summary>
        /// The identifier of the DeploymentSite this file is deployed to.
        /// </summary>
        public int? DeploymentSiteId { get; set; }

        /// <summary>
        /// The filename of the deployed file.
        /// </summary>
        public string RemoteFile { get; set; }

        /// <summary>
        /// The identifier of the Image template used.
        /// </summary>
        public int? ImageTemplateId { get; set; }

        /// <summary>
        /// The identifier of the Video template used.
        /// </summary>
        public int? VideoTemplateId { get; set; }

        /// <summary>
        /// The name of the template, if any.
        /// </summary>
        public string TemplateName { get; set; }

        /// <summary>
        /// The time of deployment for this file.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The original filename of the file when uploaded to QBank.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// The size of the file on disk
        /// </summary>
        public int? Filesize { get; set; }

        /// <summary>
        /// Metadata associated with the deployed media
        /// </summary>
        public object Metadata { get; set; }
    }
}