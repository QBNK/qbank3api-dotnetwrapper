using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class MimeType
    {
        /// <summary>
        /// The MimeType identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The MimeType string representation.
        /// </summary>
        public string Mimetype { get; set; }

        /// <summary>
        /// The MimeType human readable description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether the MimeType is usable in an ImageTemplate.
        /// </summary>
        public bool Imagetemplate { get; set; }

        /// <summary>
        /// Whether the MimeType is usable in a VideoTemplate.
        /// </summary>
        public bool Videotemplate { get; set; }

        /// <summary>
        /// The default file extension of the MimeType.
        /// </summary>
        public string Defaultextension { get; set; }

        /// <summary>
        /// The MimeType class. Eg. image, video, document.
        /// </summary>
        public string Classification { get; set; }
    }
}