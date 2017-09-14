using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class PropertyRequest : PropertyCriteria
    {
        /// <summary>
        /// Whether this property should be included in the SearchResult.
        /// </summary>
        public bool Forfetching { get; set; }
    }
}