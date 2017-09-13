using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace QBankApi.Model
{
    public class Comment
    {
        /// <summary>
        /// Object that this comment is made on
        /// </summary>
        public int ObjectId { get; set; }

        /// <summary>
        /// The actual comment
        /// </summary>
        [JsonProperty("comment")]
        public string Message { get; set; }

        /// <summary>
        /// If a reply, indicates this comments parent
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// Set only if a anonymous user wrote this comment, see createdBy otherwise
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Set only if a anonymous user wrote this comment, see createdBy otherwise
        /// </summary>
        public string UserEmail { get; set; }
    }
}