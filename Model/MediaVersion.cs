using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class MediaVersion : RestResponse
    {
        /// <summary>
        /// The Media identifier.
        /// </summary>
        public int MediaId { get; set; }

        /// <summary>
        /// The Media filename
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// When the Media was uploaded. A datetime string on the format ISO8601.
        /// </summary>
        public DateTime Uploaded { get; set; }

        /// <summary>
        /// The Media replacement Media identifier. Only set when the Media has been replaced, ie. versioning.
        /// </summary>
        public int ReplacedBy { get; set; }

        /// <summary>
        /// An optional comment about the version.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// The User identifier of the user who created the new version.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The version number
        /// </summary>
        public int Version { get; set; }
    }
}