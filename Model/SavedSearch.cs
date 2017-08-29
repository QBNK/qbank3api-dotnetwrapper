using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class SavedSearch : RestResponse
    {
        /// <summary>
        ///
        /// </summary>
        public string Search { get; set; }
    }
}