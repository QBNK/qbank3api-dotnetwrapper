using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class Property
    {
        /// <summary>
        /// The system name of the Property we filter on
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// The value we filter by
        /// </summary>
        public object Value { get; set; }
    }
}