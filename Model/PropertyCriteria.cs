using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class PropertyCriteria : RestResponse
    {
        /// <summary>
        /// The system name of the Property we filter on
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// The value we filter by
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Comparison operator for the criteria
        /// </summary>
        public string Operator { get; set; }
    }
}