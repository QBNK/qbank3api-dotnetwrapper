using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class FilterItem : RestResponse
    {
        /// <summary>
        /// ID of the Filter (only applicable if Category or Folder FilterItem)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// An array of mediaIds that are tagged with this title
        /// </summary>
        public List<string> MediaIds { get; set; }

        /// <summary>
        ///
        /// </summary>
        public List<FilterItem> FilterItems { get; set; }
    }
}