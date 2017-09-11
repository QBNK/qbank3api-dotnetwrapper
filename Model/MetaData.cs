using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class MetaData
    {
        /// <summary>
        /// The MetaData section name.
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// The MetaData data as a key-value object.
        /// </summary>
        public Dictionary<string, string> Data { get; set; }
    }
}