using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class MediaUsage : RestResponse
    {
        /// <summary>
        ///
        /// </summary>
        public int MediaId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string MediaUrl { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string PageUrl { get; set; }

        /// <summary>
        ///
        /// </summary>
        public List<string> Context { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Language { get; set; }
    }
}