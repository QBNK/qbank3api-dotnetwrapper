using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class DownloadItem
    {
        /// <summary>
        /// Media ID
        /// </summary>
        public int MediaId { get; set; }

        /// <summary>
        /// ImageTemplate ID
        /// </summary>
        public int ImageTemplateId { get; set; }

        /// <summary>
        /// ImageTemplate ID
        /// </summary>
        public int VideoTemplateId { get; set; }

        /// <summary>
        /// ImageTemplate ID
        /// </summary>
        public int DocumentTemplateId { get; set; }

        /// <summary>
        /// ImageTemplate ID
        /// </summary>
        public int AudioTemplateId { get; set; }
    }
}