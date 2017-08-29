using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class MetaData : RestResponse
    {
        /// <summary>
        /// The MetaData section name.
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// The MetaData data as a key-value object.
        /// </summary>
        public object Data { get; set; }
    }
}