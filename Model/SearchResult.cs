using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class SearchResult
    {
        /// <summary>
        /// Number of hits per page in the SearchResult
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Starting position of SearchResult
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// An array of Media matching the search
        /// </summary>
        public List<MediaResponse> Results { get; set; }

        /// <summary>
        /// Time spent searching
        /// </summary>
        public float TimeSearching { get; set; }

        /// <summary>
        /// Total number of hits
        /// </summary>
        public int? TotalHits { get; set; }
    }
}